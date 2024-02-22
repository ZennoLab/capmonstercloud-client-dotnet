using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// DataDome CustomTask recognition request with proxy
    /// </summary>
    public sealed class DataDomeCustomTaskRequest : DataDomeCustomTaskRequestBase
    {
        /// <summary>
        /// captchaUrl - the value will be set to Metadata property
        /// </summary>
        /// <param name="captchaUrl"></param>
        public DataDomeCustomTaskRequest(string captchaUrl) : base(captchaUrl) { }

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
