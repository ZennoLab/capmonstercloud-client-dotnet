﻿using System.ComponentModel.DataAnnotations;
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
        /// https://zenno.link/doc-token-accept-en
        /// </summary>
        [JsonProperty("nocache", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoCache { get; set; }

        internal override bool UseNoCache => this.NoCache ?? false;
        
        /// <summary>
        /// cf_clearance - if cookies are needed
        /// token - if token is needed
        /// </summary>
        /// <example>token</example>
        [JsonProperty("cloudflareTaskType")]
        public string CloudflareTaskType { get; set; }
        
        /// <summary>
        /// Action field, which can be found in the callback function for loading captcha
        /// Usually "managed" or "non-interactive"
        /// </summary>
        /// <example>managed</example>
        [JsonProperty("pageAction")]
        public string PageAction{ get; set; }

        /// <summary>
        /// cData
        /// </summary>
        /// <example>7ea32c865ef0b936</example>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// chlPageData
        /// </summary>
        /// <example>3gAFo2l2MbhCQ3F...Ua3pPVFkzTnk0Mk1ERT0=</example>
        [JsonProperty("pageData")]
        public string PageData { get; set; }

        /// <summary>
        /// A base64 encoded html page with a captcha.
        /// </summary>
        /// <example>PCFET0NUWVBFIGh0...vYm9keT48L2h0bWw+</example>
        [JsonProperty("htmlPageBase64")]
        public string HtmlPageBase64 { get; set; }

        /// <summary>
        /// Browser's User-Agent which is used in emulation.
        /// </summary>
        /// <remarks>
        /// It is required that you use a signature of a modern browser
        /// </remarks>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }

        /// <inheritdoc/>
        [JsonProperty("apiJsUrl")]
        public string ApiJsUrl { get; set; }
    }
}
