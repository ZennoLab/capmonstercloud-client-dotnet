using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

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
        public Task<CaptchaResult<ImageToTextResponse>> SolveAsync(
            ImageToTextRequest task,
            CancellationToken cancellationToken = default)
            => Solve<ImageToTextResponse>(task, ImageToTextTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<RecaptchaV2Response>> SolveAsync(
            RecaptchaV2Request task,
            CancellationToken cancellationToken = default)
            => Solve<RecaptchaV2Response>(task, RecaptchaV2Timeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<RecaptchaV2Response>> SolveAsync(
            RecaptchaV2ProxylessRequest task,
            CancellationToken cancellationToken = default)
            => Solve<RecaptchaV2Response>(task, RecaptchaV2Timeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<RecaptchaV3Response>> SolveAsync(
            RecaptchaV3ProxylessRequest task,
            CancellationToken cancellationToken = default)
            => Solve<RecaptchaV3Response>(task, RecaptchaV3Timeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<FunCaptchaResponse>> SolveAsync(
            FunCaptchaRequest task,
            CancellationToken cancellationToken = default)
            => Solve<FunCaptchaResponse>(task, FunCaptchaTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<FunCaptchaResponse>> SolveAsync(
            FunCaptchaProxylessRequest task,
            CancellationToken cancellationToken = default)
            => Solve<FunCaptchaResponse>(task, FunCaptchaTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<HCaptchaResponse>> SolveAsync(
            HCaptchaRequest task,
            CancellationToken cancellationToken = default)
            => Solve<HCaptchaResponse>(task, HCaptchaTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<HCaptchaResponse>> SolveAsync(
            HCaptchaProxylessRequest task,
            CancellationToken cancellationToken = default)
            => Solve<HCaptchaResponse>(task, HCaptchaTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<GeeTestResponse>> SolveAsync(
            GeeTestRequest task,
            CancellationToken cancellationToken = default)
            => Solve<GeeTestResponse>(task, GeeTestTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<GeeTestResponse>> SolveAsync(
            GeeTestProxylessRequest task,
            CancellationToken cancellationToken = default)
            => Solve<GeeTestResponse>(task, GeeTestTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<RecaptchaV2EnterpriseResponse>> SolveAsync(
            RecaptchaV2EnterpriseRequest task,
            CancellationToken cancellationToken)
            => Solve<RecaptchaV2EnterpriseResponse>(task, RecaptchaV2EnterpriseTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<RecaptchaV2EnterpriseResponse>> SolveAsync(
            RecaptchaV2EnterpriseProxylessRequest task,
            CancellationToken cancellationToken)
            => Solve<RecaptchaV2EnterpriseResponse>(task, RecaptchaV2EnterpriseTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<TurnstileResponse>> SolveAsync(
            TurnstileRequest task,
            CancellationToken cancellationToken)
            => Solve<TurnstileResponse>(task, TurnstileTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<TurnstileResponse>> SolveAsync(
            TurnstileProxylessRequest task,
            CancellationToken cancellationToken)
            => Solve<TurnstileResponse>(task, TurnstileTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync(
            RecaptchaComplexImageTaskRequest taskRequest,
            CancellationToken cancellationToken)
            => Solve<GridComplexImageTaskResponse>(taskRequest, ImageToTextTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync(
            HCaptchaComplexImageTaskRequest taskRequest,
            CancellationToken cancellationToken)
            => Solve<GridComplexImageTaskResponse>(taskRequest, ImageToTextTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync(
            FunCaptchaComplexImageTaskRequest taskRequest,
            CancellationToken cancellationToken)
            => Solve<GridComplexImageTaskResponse>(taskRequest, ImageToTextTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<CustomTaskResponse>> SolveAsync(
            DataDomeCustomTaskRequest task,
            CancellationToken cancellationToken)
            => Solve<CustomTaskResponse>(task, DataDomeTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<CustomTaskResponse>> SolveAsync(
            DataDomeCustomTaskProxylessRequest task,
            CancellationToken cancellationToken)
            => Solve<CustomTaskResponse>(task, DataDomeTimeouts, cancellationToken);

        /// <inheritdoc/>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        public Task<CaptchaResult<AmazonWafResponse>> SolveAsync(
            AmazonWafProxylessRequest task,
            CancellationToken cancellationToken)
            => Solve<AmazonWafResponse>(task, AmazonWafTimeouts, cancellationToken);

        private async Task<CaptchaResult<TSolution>> Solve<TSolution>(
            CaptchaRequestBase task,
            GetResultTimeouts getResultTimeouts,
            CancellationToken cancellationToken)
        {
            ValidateTask(task);

            var createdTask = await CreateTask(task, cancellationToken);
            if (createdTask.errorId != 0)
            {
                return new CaptchaResult<TSolution> { Error = ToErrorType(createdTask.errorCode) };
            }

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

        private void ValidateTask<TTask>(TTask task) where TTask : CaptchaRequestBase
            => Validator.ValidateObject(task, new ValidationContext(task), validateAllProperties: true);

        private async Task<CreateTaskResponse> CreateTask(CaptchaRequestBase task, CancellationToken cancellationToken)
        {
            var body = ToJson(
                new CreateTaskRequest
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
