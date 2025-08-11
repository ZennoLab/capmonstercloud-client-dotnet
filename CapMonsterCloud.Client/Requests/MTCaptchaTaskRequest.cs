using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// MTCaptcha recognition request.
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/mtcaptcha-task/
    /// </example>
    public sealed class MTCaptchaTaskRequest : CaptchaRequestBaseWithProxy<MTCaptchaTaskResponse>
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "MTCaptchaTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public sealed override string Type => TaskType;

        /// <summary>
        /// Address of a web page with MTCaptcha.
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// The MTCaptcha key (sk/sitekey).
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// true for invisible widget (has hidden confirmation field).
        /// </summary>
        [JsonProperty("isInvisible")]
        public bool Invisible { get; set; }

        /// <summary>
        /// Action value (passed as "act" and shown during token validation).
        /// Provide only if it differs from default "%24".
        /// </summary>
        [JsonProperty("pageAction")]
        public string PageAction { get; set; }

        /// <summary>
        /// Browser's User-Agent (actual Windows UA recommended).
        /// </summary>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
    }
}