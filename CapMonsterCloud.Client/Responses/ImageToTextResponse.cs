using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// ImageToText recognition response
    /// </summary>
    public class ImageToTextResponse : CaptchaResponseBase
    {
        /// <summary>
        /// Captcha answer
        /// </summary>
        [JsonProperty("text")]
        public string Value { get; set; }
    }
}
