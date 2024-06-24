using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// AmazonWaf recognition request (with proxy).
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/amazon-task
    /// </example>
    public class AmazonWafRequest : AmazonWafRequestBase, IProxyInfo
    { 
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "AmazonTask";

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
