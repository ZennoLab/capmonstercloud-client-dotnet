using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Prosopo Procaptcha recognition request.
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/prosopo-task
    /// </example>
    public sealed class ProsopoTaskRequest : CaptchaRequestBaseWithProxy<ProsopoTaskResponse>
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "ProsopoTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public sealed override string Type => TaskType;

        /// <summary>
        /// The full URL of the CAPTCHA page.
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// The value of the "siteKey" parameter found on the page.
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }
    }
}