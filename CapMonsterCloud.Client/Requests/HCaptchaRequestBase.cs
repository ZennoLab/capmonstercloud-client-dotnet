using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Base HCaptcha recognition request
    /// </summary>
    public abstract class HCaptchaRequestBase : CaptchaRequestBase
    {
        /// <summary>
        /// Address of a webpage with hCaptcha.
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// hCaptcha website key.
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Set true for invisible version of hCaptcha
        /// </summary>
        [JsonProperty("isInvisible")]
        public bool Invisible { get; set; }

        /// <summary>
        /// Custom data that is used in some implementations of hCaptcha, mostly with <see cref="Invisible"/>=true.
        /// In most cases you see it as <![CDATA[rqdata]]> inside network requests.
        /// IMPORTANT: you MUST provide <see cref="UserAgent"/> if you submit captcha with data parameter.
        /// The value should match the User-Agent you use when interacting with the target website.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// Obsolete, use <see cref="HCaptchaResponse.UserAgent"/> instead. Browser's User-Agent which is used in emulation.
        /// </summary>
        /// <remarks>
        /// It is required that you use a signature of a modern browser.
        /// </remarks>
        [Obsolete("UserAgent is deprecated, please use UserAgent from HCaptchaResponse instead.")]
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// true - when specifying this parameter, we ignore the irrelevant User Agent
        /// that users send in the request, and return our own (relevant) one with
        /// getTaskResult. This will improve the acceptance of tokens.
        ///
        /// false - we insert the User Agent that is specified in the request. If the User
        /// Agent is invalid, you will receive an error ERROR_WRONG_USERAGENT
        /// (USERAGENT IS EXPIRED in the log).
        ///
        /// null - we insert the User Agent that is specified in the request,
        /// but we don’t validate it
        /// </summary>
        [JsonProperty("fallbackToActualUA", NullValueHandling = NullValueHandling.Ignore)]
        public bool? FallbackToActualUA { get; set; }

        /// <summary>
        /// Additional cookies which we must use during interaction with target page.
        /// </summary>
        [JsonProperty("cookies")]
        [JsonConverter(typeof(Json.DictionaryToSemicolonSplittedStringConverter))]
        public IDictionary<string, string> Cookies { get; set; } = new Dictionary<string, string>();

        /// <summary>
        /// Set true if the site only accepts a portion of the tokens from CapMonster Cloud.
        /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1832714243/What+if+the+site+only+accepts+a+portion+of+the+tokens+from+CapMonster+Cloud
        /// </summary>
        [JsonProperty("nocache", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoCache { get; set; }

        internal override bool UseNoCache => this.NoCache ?? false;
    }
}
