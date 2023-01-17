using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Base Turnstile recognition request
    /// </summary>
    public abstract class TurnstileRequestBase : CaptchaRequestBase
    {
        /// <summary>
        /// Address of a webpage with Turnstile captcha
        /// </summary>
        /// <example>https://tsinvisble.zlsupport.com</example>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Turnstile website key.
        /// </summary>
        /// <example>0x4AAAAAAABUY0VLtOUMAHxE</example>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Set true if the site only accepts a portion of the tokens from CapMonster Cloud.
        /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1832714243/What+if+the+site+only+accepts+a+portion+of+the+tokens+from+CapMonster+Cloud
        /// </summary>
        [JsonProperty("nocache", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoCache { get; set; }

        internal override bool UseNoCache => this.NoCache ?? false;
    }
}
