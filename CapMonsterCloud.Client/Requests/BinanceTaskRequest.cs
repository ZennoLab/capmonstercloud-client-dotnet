using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// BinanceTask recognition request.
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/binance
    /// </example>
    public sealed class BinanceTaskRequest : CaptchaRequestBaseWithProxy
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "BinanceTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;

        /// <summary>
        /// The address of the main page where the captcha is solved.
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// A unique parameter for your website's section. The value of the parameter bizId, bizType, or bizCode. It can be taken from the traffic
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// A dynamic key. The value of the parameter validateId, securityId, or securityCheckResponseValidateId. It can be taken from the traffic.
        /// </summary>
        [JsonProperty("validateId", Required = Required.Always)]
        public string ValidateId { get; set; }

        /// <summary>
        /// Browser's User-Agent which is used in emulation.
        /// </summary>
        /// <remarks>
        /// It is required that you use a signature of a modern browser,
        /// otherwise Google will ask you to "update your browser".
        /// </remarks>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
    }
}
