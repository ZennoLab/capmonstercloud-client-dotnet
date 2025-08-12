using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Yidun (NECaptcha) recognition request.
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/yidun-task
    /// </example>
    public sealed class YidunTaskRequest : CaptchaRequestBaseWithProxy<YidunTaskResponse>
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "YidunTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;

        /// <summary>
        /// Full URL of the page with the captcha.
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// The siteKey value found on the page.
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Browser User-Agent (actual Windows UA recommended).
        /// </summary>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// Full URL of JS loader (Enterprise cases).
        /// </summary>
        [JsonProperty("yidunGetLib")]
        public string YidunGetLib { get; set; }

        /// <summary>
        /// Custom API server subdomain (Enterprise cases).
        /// </summary>
        [JsonProperty("yidunApiServerSubdomain")]
        public string YidunApiServerSubdomain { get; set; }

        /// <summary>
        /// Enterprise: current captcha challenge id.
        /// </summary>
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        /// <summary>
        /// Enterprise: captcha hash.
        /// </summary>
        [JsonProperty("hcg")]
        public string Hcg { get; set; }

        /// <summary>
        /// Enterprise: numeric timestamp.
        /// </summary>
        [JsonProperty("hct")]
        public long? Hct { get; set; }
    }
}
