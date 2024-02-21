using System.Collections.Generic;
using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// Response for custom tasks
    /// </summary>
    public class CustomTaskResponse
    {
        public sealed class DomainInfo
        {
            [JsonProperty("cookies")]
            public Dictionary<string, string> Cookies { get; set; }

            [JsonProperty("localStorage")]
            public Dictionary<string, string> LocalStorage { get; set; }
        }

        [JsonProperty("domains")]
        public Dictionary<string, DomainInfo> Domains { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("fingerprint")]
        public Dictionary<string, string> Fingerprint { get; set; }

        [JsonProperty("headers")]
        public Dictionary<string, string> Headers { get; set; }
    }
}
