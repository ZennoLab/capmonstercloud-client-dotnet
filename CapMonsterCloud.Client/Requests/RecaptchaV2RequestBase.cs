using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Base Recaptcha V2 recognition request
    /// </summary>
    public abstract class RecaptchaV2RequestBase : CaptchaRequestBase
    {
        /// <summary>
        /// Address of a webpage with Google ReCaptcha
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Recaptcha website key.
        /// <![CDATA[<div class="g-recaptcha" data-sitekey="THAT_ONE"></div>]]>
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Some custom implementations may contain additional "data-s" parameter in ReCaptcha2 div, which is in fact a one-time token and must be grabbed every time you want to solve a ReCaptcha2.
        /// <![CDATA[<div class="g-recaptcha" data-sitekey="some sitekey" data-s="THIS_ONE"></div>]]>
        /// </summary>
        [JsonProperty("recaptchaDataSValue")]
        public string DataSValue { get; set; }

        /// <summary>
        /// Browser's User-Agent which is used in emulation.
        /// </summary>
        /// <remarks>
        /// It is required that you use a signature of a modern browser,
        /// otherwise Google will ask you to "update your browser".
        /// </remarks>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// Additional cookies which we must use during interaction with target page or Google.
        /// </summary>
        [JsonProperty("cookies")]
        [JsonConverter(typeof(Json.DictionaryToSemicolonSplittedStringConverter))]
        public IDictionary<string, string> Cookies { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Set true if the site only accepts a portion of the tokens from CapMonster Cloud.
        /// https://zenno.link/doc-token-accept-en
        /// </summary>
        [JsonProperty("nocache", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoCache { get; set; }

        internal override bool UseNoCache => this.NoCache ?? false;
    }
}
