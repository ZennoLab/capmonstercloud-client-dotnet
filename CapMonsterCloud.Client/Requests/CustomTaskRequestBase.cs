using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// CustomTask recognition request
    /// </summary>
    public abstract class CustomTaskRequestBase : CaptchaRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "CustomTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public sealed override string Type => TaskType;

        /// <summary>
        /// Class (subtype) of CustomTask
        /// </summary>
        [JsonProperty("class", Required = Required.Always)]
        public abstract string Class { get; }

        /// <summary>
        /// Address of the main page where the captcha is solved
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// The object that contains additional data about the captcha - captchaUrl: "captchaUrl": "..."
        /// You can take the link from the page with the captcha.
        /// Often it looks like https://geo.captcha-delivery.com/captcha/?initialCid=...
        /// </summary>
        [JsonProperty("metadata", Required = Required.Always)]
        public object Metadata { get; set; }

        /// <summary>
        /// Browser's User-Agent which is used in emulation.
        /// </summary>
        /// <remarks>
        /// Pass only the actual User-Agent from Windows OS.
        /// </remarks>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// For the specified domains the corresponding cookies will be returned in the response.
        /// </summary>
        [JsonProperty("domains")]
        public ICollection<string> Domains { get; set; }
    }
}
