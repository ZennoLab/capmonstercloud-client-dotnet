using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zennolab.CapMonsterCloud.Responses
{    
    /// <summary>
    /// BinanceTask recognition response
    /// </summary>
    public sealed class BinanceTaskResponse : CaptchaResponseBase
    {
        /// <summary>
        /// BinanceTask token
        /// </summary>
        /// <example>
        /// captcha#09ba4905a79f44f2a99e44f234439644-ioVA7neog7eRHCDAsC0MixpZvt5kc99maS943qIsquNP9D77
        /// </example>
        [JsonProperty("token")]
        public string Value { get; set; }

        /// <inheritdoc/>
        [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }

        /// <inheritdoc/>
        [JsonProperty("cookies", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Cookies { get; set; }
    }
}
