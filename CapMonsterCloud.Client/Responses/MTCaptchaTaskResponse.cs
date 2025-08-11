using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// MTCaptcha recognition response
    /// </summary>
    public sealed class MTCaptchaTaskResponse : CaptchaResponseBase
    {
        /// <summary>
        /// MTCaptcha token to submit to the target site.
        /// </summary>
        [JsonProperty("token")]
        public string Value { get; set; }
    }
}