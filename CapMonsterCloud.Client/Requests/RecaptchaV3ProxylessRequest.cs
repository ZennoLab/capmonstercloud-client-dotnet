﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V3 recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zenno.link/doc-recaptcha3-en
    /// </example>
    public sealed class RecaptchaV3ProxylessRequest : CaptchaRequestBase<RecaptchaV3Response>
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "RecaptchaV3TaskProxyless";

        /// <inheritdoc/>
        [JsonProperty("type")]
        public override string Type => TaskType;

        /// <summary>
        /// Address of a webpage with Google ReCaptcha
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// Recaptcha website key.
        /// <![CDATA[
        /// <div class="g-recaptcha" data-sitekey="THAT_ONE"></div>
        /// ]]>
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Value from 0.1 to 0.9.
        /// </summary>
        [JsonProperty("minScore")]
        [Range(0.1, 0.9)]
        public double MinScore { get; set; }

        /// <summary>
        /// Widget action value.
        /// Website owner defines what user is doing on the page through this parameter.
        /// Default value: verify
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// grecaptcha.execute('site_key', {action:'login_test'})]]>
        /// </example>
        [JsonProperty("pageAction")]
        public string PageAction { get; set; } = "verify";

        /// <summary>
        /// Set true if the site only accepts a portion of the tokens from CapMonster Cloud.
        /// https://zenno.link/doc-token-accept-en
        /// </summary>
        [JsonProperty("nocache", NullValueHandling = NullValueHandling.Ignore)]
        public bool? NoCache { get; set; }

        internal override bool UseNoCache => this.NoCache ?? false;
    }
}
