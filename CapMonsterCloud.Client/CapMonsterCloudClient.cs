using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;
using Zennolab.CapMonsterCloud.Validation;

namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// capmonster.cloud Client
    /// </summary>
    public partial class CapMonsterCloudClient : ICapMonsterCloudClient
    {
        private const string TaskReady = "ready";

        private readonly ClientOptions _options;

        /// <summary>
        /// Creates new capmonster.cloud Client
        /// </summary>
        /// <param name="options">client options</param>
        /// <param name="httpClient"></param>
        public CapMonsterCloudClient(ClientOptions options, HttpClient httpClient)
        {
            _options = options;

            HttpClient = httpClient;
        }

        internal HttpClient HttpClient { get; }

        /// <inheritdoc/>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public async Task<decimal> GetBalanceAsync(CancellationToken cancellationToken)
        {
            var response = await HttpClient.PostAsync(
                "getBalance",
                new StringContent(ToJson(
                    new { clientKey = _options.ClientKey })),
                cancellationToken);
            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Cannot get balance. Status code was {response.StatusCode}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var result = FromJson<GetBalanceResponse>(responseBody);
            if (result == null)
            {
                throw new HttpRequestException($"Cannot parse get balance response. Response was: {responseBody}");
            }

            if (result.errorId != 0)
            {
                throw new GetBalanceException(ToErrorType(result.errorCode));
            }

            return result.balance;
        }

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public async Task<CaptchaResult<TSolution>> SolveAsync<TSolution>(
            CaptchaRequestBase<TSolution> task,
            CancellationToken cancellationToken) where TSolution : CaptchaResponseBase
        {
            ValidateTask<CaptchaRequestBase<TSolution>, TSolution>(task);

            var createdTask = await CreateTask(task, cancellationToken);
            if (createdTask.errorId != 0)
            {
                return new CaptchaResult<TSolution> { Error = ToErrorType(createdTask.errorCode) };
            }

            var getResultTimeouts = GetTimeouts(task.GetType());

            using (var getResultTimeoutCts = new CancellationTokenSource(getResultTimeouts.Timeout))
            using (var linkedCts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, getResultTimeoutCts.Token))
            {
                TimeSpan firstRequestDelay = (task.UseNoCache ? getResultTimeouts.FirstRequestNoCacheDelay : null)
                    ?? getResultTimeouts.FirstRequestDelay;
                await Task.Delay(firstRequestDelay, linkedCts.Token);

                while (!linkedCts.IsCancellationRequested)
                {
                    try
                    {
                        var result = await GetTaskResult(createdTask.taskId, linkedCts.Token);
                        switch (result)
                        {
                            case TaskResult.TaskFailed failed:
                                return new CaptchaResult<TSolution> { Error = failed.Error };
                            case TaskResult.TaskCompleted completed:
                                return new CaptchaResult<TSolution> { Solution = CastSolution<TSolution>(completed.Solution) };
                            case TaskResult.TaskInProgress inProgress:
                            default:
                                break;
                        }
                    }
                    catch (OperationCanceledException)
                    {
                        if (getResultTimeoutCts.IsCancellationRequested)
                        {
                            break;
                        }

                        throw;
                    }

                    await Task.Delay(getResultTimeouts.RequestsInterval, linkedCts.Token);
                }
            }

            return new CaptchaResult<TSolution> { Error = ErrorType.Timeout };
        }

        private void ValidateTask<TTask, TSolution>(TTask task) where TTask : CaptchaRequestBase<TSolution> where TSolution : CaptchaResponseBase
            => TaskValidator.ValidateObjectIncludingInternals(task);

        private async Task<CreateTaskResponse> CreateTask<TSolution>(CaptchaRequestBase<TSolution> task, CancellationToken cancellationToken) where TSolution : CaptchaResponseBase
        {
            var body = ToJson(
                new CreateTaskRequest<TSolution>
                {
                    clientKey = _options.ClientKey,
                    task = task,
                    softId = _options.SoftId ?? ClientOptions.DefaultSoftId
                });

            var response = await HttpClient.PostAsync("createTask", new StringContent(body), cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Cannot create task. Status code was {response.StatusCode}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var result = FromJson<CreateTaskResponse>(responseBody);
            if (result == null)
            {
                throw new HttpRequestException($"Cannot parse create task response. Response was: {responseBody}");
            }

            return result;
        }

        private async Task<TaskResult> GetTaskResult(int taskId, CancellationToken cancellationToken)
        {
            var body = ToJson(
                new
                {
                    clientKey = _options.ClientKey,
                    taskId
                });

            var response = await HttpClient.PostAsync("getTaskResult", new StringContent(body), cancellationToken);

            if (response.StatusCode == System.Net.HttpStatusCode.ServiceUnavailable)
            {
                return TaskResult.InProgress;
            }

            if (!response.IsSuccessStatusCode)
            {
                throw new HttpRequestException($"Cannot get task result. Status code was {response.StatusCode}");
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var result = FromJson<GetTaskResultResponse>(responseBody);
            if (result == null)
            {
                throw new HttpRequestException($"Cannot parse get task result response. Response was: {responseBody}");
            }

            if (result.errorId != 0)
            {
                if ("CAPTCHA_NOT_READY".Equals(result.errorCode, StringComparison.OrdinalIgnoreCase))
                {
                    return TaskResult.InProgress;
                }
                else
                {
                    return TaskResult.Failed(ToErrorType(result.errorCode));
                }
            }

            if (TaskReady.Equals(result.status, StringComparison.OrdinalIgnoreCase))
            {
                return TaskResult.Completed(result.solution);
            }

            return TaskResult.InProgress;
        }

        private static TSolution CastSolution<TSolution>(object solution)
            => FromJson<TSolution>(solution.ToString());

        private static ErrorType ToErrorType(string errorCode)
            => ErrorCodeConverter.Convert(errorCode);

        private static string ToJson(object data)
            => JsonConvert.SerializeObject(data, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        private static TOut FromJson<TOut>(string json)
            => JsonConvert.DeserializeObject<TOut>(json);
    }
}
