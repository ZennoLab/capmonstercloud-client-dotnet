using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// HCaptcha recognition response
    /// </summary>
    public sealed class HCaptchaResponse : RecaptchaResponseBase
    {
        [JsonProperty("respKey")]
        public string RespKey { get; set; }

        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
    }
}
