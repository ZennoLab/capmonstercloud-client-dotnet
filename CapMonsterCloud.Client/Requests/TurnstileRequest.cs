using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Turnstile recognition request (with proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/2256797706/TurnstileTask+Turnstile
    /// </example>
    public sealed class TurnstileRequest : TurnstileRequestBase, IProxyInfo
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "TurnstileTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override string Type => TaskType;

        /// <inheritdoc/>
        [JsonProperty("proxyType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyType ProxyType { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyAddress", Required = Required.Always)]
        public string ProxyAddress { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyPort", Required = Required.Always)]
        [Range(0, 65535)]
        public int ProxyPort { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyLogin")]
        public string ProxyLogin { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyPassword")]
        public string ProxyPassword { get; set; }
    }
}