using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// HCaptcha recognition request (with proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1203240988/HCaptchaTask+hCaptcha+puzzle+solving
    /// </example>
    public sealed class HCaptchaRequest : HCaptchaRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "HCaptchaTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;

        /// <inheritdoc/>
        [JsonProperty("proxyType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyType ProxyType { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyAddress", Required = Required.Always)]
        public string ProxyAddress { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyPort", Required = Required.Always)]
        public int ProxyPort { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyLogin")]
        public string ProxyLogin { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyPassword")]
        public string ProxyPassword { get; set; }
    }
}
