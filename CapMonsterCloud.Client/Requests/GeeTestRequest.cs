﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// GeeTest recognition request.
    /// </summary>
    /// <example>
    /// https://zenno.link/doc-geetest-proxy-en
    /// </example>
    public sealed class GeeTestRequest : CaptchaRequestBaseWithProxy
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "GeeTestTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;

        /// <summary>
        /// Address of the page on which the captcha is recognized
        /// </summary>
        /// <example>https://example.com/geetest.php</example>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// The GeeTest identifier key for the domain.
        /// Static value, rarely updated.
        /// </summary>
        /// <example>81dc9bdb52d04dc20036dbd8313ed055</example>
        [JsonProperty("gt", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Gt { get; set; }

        /// <summary>
        /// Version number. The default value is 3. Versions 4 is supported.
        /// </summary>
        /// <example>4</example>
        [JsonProperty("version")]
        public int? Version { get; set; }

        /// <summary>
        /// Additional initialization parameters for version 4.
        /// </summary>
        /// <example>{ "riskType": "slide" }</example>
        [JsonProperty("initParameters")]
        public object InitParameters { get; set; }

        /// <summary>
        /// A dynamic key.
        /// Each time our API is called, we need to get a new key value.
        /// If the captcha is loaded on the page, then the challenge value is no longer valid and you will get <see cref="ErrorType.TOKEN_EXPIRED"/> error.
        /// IMPORTANT. You will be charged for tasks with <see cref="ErrorType.TOKEN_EXPIRED"/> error!
        /// </summary>
        /// <example>d93591bdf7860e1e4ee2fca799911215</example>
        /// <remarks>
        /// It is necessary to examine the requests and find the one in which this value is returned and,
        /// before each creation of the recognition task, execute this request and parse the <![CDATA[challenge]]> from it.
        /// </remarks>
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        /// <summary>
        /// May be required for some sites.
        /// </summary>
        [JsonProperty("geetestApiServerSubdomain")]
        public string Subdomain { get; set; }

        /// <summary>
        /// May be required for some sites.
        /// Send JSON as a string.
        /// </summary>
        [JsonProperty("geetestGetLib")]
        public string GetLib { get; set; }

        /// <summary>
        /// Browser's User-Agent which is used in emulation.
        /// </summary>
        /// <remarks>
        /// It is required that you use a signature of a modern browser,
        /// otherwise Google will ask you to "update your browser".
        /// </remarks>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
    }
}