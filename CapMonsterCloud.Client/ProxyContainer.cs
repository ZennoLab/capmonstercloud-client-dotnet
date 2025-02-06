using System;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Validation;

namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// Represents a proxy configuration container with validation.
    /// </summary>
    public class ProxyContainer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ProxyContainer"/> class.
        /// </summary>
        /// <param name="address">The proxy IP address (IPv4/IPv6). Must not be a transparent proxy, or from a local network.</param>
        /// <param name="port">The proxy port number (0-65535).</param>
        /// <param name="type">The type of the proxy.</param>
        /// <param name="login">The login credential for proxies requiring authentication.</param>
        /// <param name="password">The password credential for proxies requiring authentication.</param>
        /// <exception cref="ArgumentException">Thrown when the port is out of range or the address is invalid.</exception>
        public ProxyContainer(
            string address,
            int port,
            ProxyType type,
            string login,
            string password)
        {
            if (port < 0 || port > 65535)
                throw new ArgumentException("Proxy port must be between 0 and 65535");

            if (!ProxyValidator.IsValidProxy(address))
                throw new ArgumentException("Proxy address is not valid");

            ProxyAddress = address;
            ProxyPort = port;

            ProxyType = type;
            ProxyLogin = login;
            ProxyPassword = password;
        }

        /// <summary>
        /// Proxy IP address IPv4/IPv6. Not allowed to use:
        /// - host names instead of IPs
        /// - transparent proxies(where client IP is visible)
        /// - proxies from local networks(192.., 10.., 127...)
        /// </summary>
        public string ProxyAddress { get; private set; }

        /// <summary>
        /// Proxy port
        /// </summary>
        [Range(0, 65535)]
        public int ProxyPort { get; private set; }

        /// <summary>
        /// Type of the proxy
        /// </summary>
        public ProxyType ProxyType { get; private set; }

        /// <summary>
        /// Login for proxy which requires authorization (basic)
        /// </summary>
        public string ProxyLogin { get; private set; }

        /// <summary>
        /// Proxy password
        /// </summary>
        public string ProxyPassword { get; private set; }
    }
}
