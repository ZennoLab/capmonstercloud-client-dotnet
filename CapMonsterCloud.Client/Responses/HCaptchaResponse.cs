using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// HCaptcha recognition response
    /// </summary>
    public sealed class HCaptchaResponse : RecaptchaResponseBase
    {
        /// <summary>
        /// The result of the "window.hcaptcha.getRespKey()" function when available. Some sites use this value for additional verification.
        /// </summary>
        /// <example>
        /// E0_eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJkYXRhIjoidjQ3RjlqZGFYTllFQXlZZFYyRTlaWlBVQUdLaFpPakpRNjBXRTljVW40VnY3NnhuN2V3R0wwVWd1MW1Wai90WEdoYmt5a2NqVGlGdWpsSlpmVjczaTZOTTFrN0ErWnNueGNDd1BLc1lUVTBsSUw2N0k4ZVRFTXN4Z01acnU2S3hYTXdOVlBjMlNNQ2xjZUZiKytQTVRhbUlHWTUrZ2xqRTRpTkgzYUFGbE5VcVZGanhEWWNya0Mvb1Y3ZGZteEJXbmlrVGpJSVBrMTh1dmpPRnRTVHB5SFY0Y3RDTnE2T1RlL2s0bE1xZ245dFcvUjYxK1A1NE12bHk4SzAxcmFXZHpaSUZmRTNtOCtReFUvQmxDQT09UGxYaHN4aTRqMkF6ZHJNZyJ9.lPi7EmuKyKoAErvt7MqqO0Zf9XmFJBswYvQCSpUxRp8
        /// </example>
        [JsonProperty("respKey")]
        public string RespKey { get; set; }

        /// <summary>
        /// During submitting, you should use the same User Agent with which hCaptcha was solved.
        /// </summary>
        /// <example>
        /// Mozilla/5.0 (Windows NT 6.3; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/109.0.0.0 Safari/537.36
        /// </example>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
    }
}
