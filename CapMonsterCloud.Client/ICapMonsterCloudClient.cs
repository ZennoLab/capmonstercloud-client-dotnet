using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// CapMonsterCloud client
    /// </summary>
    public interface ICapMonsterCloudClient
    {
        /// <summary>
        /// Gets current amount of money on balance
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>Current amount of money</returns>
        /// <exception cref="GetBalanceException"></exception>
        Task<decimal> GetBalanceAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="ImageToTextRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 300ms to 6s period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<ImageToTextResponse>> SolveAsync(ImageToTextRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="RecaptchaV2Request.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<RecaptchaV2Response>> SolveAsync(RecaptchaV2Request task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="RecaptchaV2ProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<RecaptchaV2Response>> SolveAsync(RecaptchaV2ProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="RecaptchaV3ProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<RecaptchaV3Response>> SolveAsync(RecaptchaV3ProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="FunCaptchaRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 80 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<FunCaptchaResponse>> SolveAsync(FunCaptchaRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="FunCaptchaProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 80 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<FunCaptchaResponse>> SolveAsync(FunCaptchaProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="HCaptchaRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<HCaptchaResponse>> SolveAsync(HCaptchaRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="HCaptchaProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<HCaptchaResponse>> SolveAsync(HCaptchaProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="GeeTestRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 80 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<GeeTestResponse>> SolveAsync(GeeTestRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="GeeTestProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 80 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<GeeTestResponse>> SolveAsync(GeeTestProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="RecaptchaV2EnterpriseRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<RecaptchaV2EnterpriseResponse>> SolveAsync(RecaptchaV2EnterpriseRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="RecaptchaV2EnterpriseProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<RecaptchaV2EnterpriseResponse>> SolveAsync(RecaptchaV2EnterpriseProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="TurnstileRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 80 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<TurnstileResponse>> SolveAsync(TurnstileRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="TurnstileProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 80 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<TurnstileResponse>> SolveAsync(TurnstileProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="ComplexImageTaskRequestBase.TaskType"/> task with 'recaptcha' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync(RecaptchaComplexImageTaskRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="ComplexImageTaskRequestBase.TaskType"/> task with 'hcaptcha' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync(HCaptchaComplexImageTaskRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="ComplexImageTaskRequestBase.TaskType"/> task with 'funcaptcha' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<GridComplexImageTaskResponse>> SolveAsync(FunCaptchaComplexImageTaskRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="CustomTaskRequestBase.TaskType"/> task with 'DataDome' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<CustomTaskResponse>> SolveAsync(DataDomeCustomTaskRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="CustomTaskRequestBase.TaskType"/> task with 'DataDome' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<CustomTaskResponse>> SolveAsync(DataDomeCustomTaskProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="AmazonWafProxylessRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<AmazonWafResponse>> SolveAsync(AmazonWafProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="AmazonWafRequest.TaskType"/> task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<AmazonWafResponse>> SolveAsync(AmazonWafRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="CustomTaskRequestBase.TaskType"/> task with 'TenDi' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<CustomTaskResponse>> SolveAsync(TenDiCustomTaskRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="CustomTaskRequestBase.TaskType"/> task with 'TenDi' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 180 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<CustomTaskResponse>> SolveAsync(TenDiCustomTaskProxylessRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="CustomTaskRequestBase.TaskType"/> task with 'Basilisk' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 100 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<CustomTaskResponse>> SolveAsync(BasiliskCustomTaskRequest task, CancellationToken cancellationToken = default);

        /// <summary>
        /// Solve <see cref="CustomTaskRequestBase.TaskType"/> task with 'Basilisk' class
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <remarks>
        /// You will get response within 10 - 100 secs period depending on service workload.
        /// </remarks>
        /// <returns>Captcha recognition result</returns>
        Task<CaptchaResult<CustomTaskResponse>> SolveAsync(BasiliskCustomTaskProxylessRequest task, CancellationToken cancellationToken = default);
    }
}
