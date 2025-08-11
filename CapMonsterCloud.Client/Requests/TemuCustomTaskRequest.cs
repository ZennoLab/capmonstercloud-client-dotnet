using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Temu CustomTask recognition request.
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/temu-task
    /// </example>
    public sealed class TemuCustomTaskRequest : CustomTaskRequestBase
    {
        /// <inheritdoc/>
        public override string Class => "Temu";

        /// <summary>
        /// Initializes Temu task with required metadata.
        /// </summary>
        /// <param name="cookie">
        /// Cookies string from the page with captcha (document.cookie).
        /// </param>
        public TemuCustomTaskRequest(string cookie)
        {
            Metadata = new { cookie };
        }

        /// <summary>
        /// The full URL of the page where the CAPTCHA is loaded.
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public new string WebsiteUrl
        {
            get => base.WebsiteUrl;
            set => base.WebsiteUrl = value;
        }

        // userAgent, Proxy, Domains — уже есть в базе (CustomTaskRequestBase)
    }
}