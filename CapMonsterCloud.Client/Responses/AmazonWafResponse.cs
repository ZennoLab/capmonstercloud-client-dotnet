using Newtonsoft.Json;
using System.Collections.Generic;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// AmazonWaf recognition response
    /// </summary>
    public sealed class AmazonWafResponse
    {
        /// <inheritdoc/>
        [JsonProperty("captcha_voucher")]
        public string CaptchaVoucher { get; set; }

        /// <inheritdoc/>
        [JsonProperty("existing_token")]
        public string ExistingToken { get; set; }

        /// <inheritdoc/>
        [JsonProperty("cookies", NullValueHandling = NullValueHandling.Ignore)]
        public Dictionary<string, string> Cookies { get; set; }

        /// <inheritdoc/>
        [JsonProperty("userAgent", NullValueHandling = NullValueHandling.Ignore)]
        public string UserAgent { get; set; }
    }
}
