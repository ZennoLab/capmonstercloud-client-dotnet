using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Runtime.InteropServices.ComTypes;
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
        /// Solve task
        /// </summary>
        /// <param name="task"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Captcha recognition result</returns>
        /// <exception cref="ValidationException">malformed task object</exception>
        /// <exception cref="HttpRequestException">exception on processing HTTP request to capmonster.cloud</exception>
        Task<CaptchaResult<TSolution>> SolveAsync<TSolution>(
            CaptchaRequestBase<TSolution> task,
            CancellationToken cancellationToken = default) where TSolution : CaptchaResponseBase;
    }
}
