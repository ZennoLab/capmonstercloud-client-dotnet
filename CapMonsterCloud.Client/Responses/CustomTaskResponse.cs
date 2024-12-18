using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// Response for custom tasks
    /// </summary>
    public class CustomTaskResponse
    {
        /// <inheritdoc/>
        public sealed class DomainInfo
        {
            /// <inheritdoc/>
            [JsonProperty("cookies")]
            public Dictionary<string, string> Cookies { get; set; }

            /// <inheritdoc/>
            [JsonProperty("localStorage")]
            public Dictionary<string, string> LocalStorage { get; set; }
        }

        /// <inheritdoc/>
        [JsonProperty("domains")]
        public Dictionary<string, DomainInfo> Domains { get; set; }

        /// <inheritdoc/>
        [JsonProperty("url")]
        public string Url { get; set; }

        /// <inheritdoc/>
        [JsonProperty("fingerprint")]
        public Dictionary<string, string> Fingerprint { get; set; }

        /// <inheritdoc/>
        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }

        /// <inheritdoc/>
        [JsonProperty("data")]
        public Dictionary<string, string> Data;
    }
}
