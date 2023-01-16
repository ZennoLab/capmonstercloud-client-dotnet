using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Interface for captcha recognition with proxy requests
    /// </summary>
    public interface IProxyInfo
    {
        /// <summary>
        /// Type of the proxy
        /// </summary>
        [JsonProperty("proxyType", Required = Required.Always)]
        [JsonConverter(typeof(StringEnumConverter))]
        ProxyType ProxyType { get; }

        /// <summary>
        /// Proxy IP address IPv4/IPv6. Not allowed to use:
        /// - host names instead of IPs
        /// - transparent proxies(where client IP is visible)
        /// - proxies from local networks(192.., 10.., 127...)
        /// </summary>
        [JsonProperty("proxyAddress", Required = Required.Always)]
        string ProxyAddress { get; }

        /// <summary>
        /// Proxy port
        /// </summary>
        [JsonProperty("proxyPort", Required = Required.Always)]
        [Range(0, 65535)]
        int ProxyPort { get; }

        /// <summary>
        /// Login for proxy which requires authorizaiton (basic)
        /// </summary>
        [JsonProperty("proxyLogin")]
        string ProxyLogin { get; }

        /// <summary>
        /// Proxy password
        /// </summary>
        [JsonProperty("proxyPassword")]
        string ProxyPassword { get; }
    }
}
