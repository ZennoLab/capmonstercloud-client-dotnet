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
        ProxyType ProxyType { get; }

        /// <summary>
        /// Proxy IP address IPv4/IPv6. Not allowed to use:
        /// - host names instead of IPs
        /// - transparent proxies(where client IP is visible)
        /// - proxies from local networks(192.., 10.., 127...)
        /// </summary>
        string ProxyAddress { get; }

        /// <summary>
        /// Proxy port
        /// </summary>
        int ProxyPort { get; }

        /// <summary>
        /// Login for proxy which requires authorizaiton (basic)
        /// </summary>
        string ProxyLogin { get; }

        /// <summary>
        /// Proxy password
        /// </summary>
        string ProxyPassword { get; }
    }
}
