using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// Prosopo Procaptcha recognition response
    /// </summary>
    public sealed class ProsopoTaskResponse : CaptchaResponseBase
    {
        /// <summary>
        /// Prosopo token
        /// </summary>
        /// <example>
        /// 0x00016c68747470733a2f2f70726f6e6f6465332e70726f736f706f2e696f...
        /// </example>
        [JsonProperty("token")]
        public string Value { get; set; }
    }
}