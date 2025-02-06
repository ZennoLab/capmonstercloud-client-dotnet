using System;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Validation;

namespace Zennolab.CapMonsterCloud
{
    public class ProxyContainer
    {
        public ProxyContainer(
            string address,
            int port,
            ProxyType type,
            string login,
            string password)
        {
            if (port < 0 || port > 65535)
                throw new ArgumentException("Proxy port can not be less than 0 or more than 65535");

            if (!ProxyValidator.IsValidProxy(address))
                throw new ArgumentNullException("Proxy address is not valid");

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
        /// Login for proxy which requires authorizaiton (basic)
        /// </summary>
        public string ProxyLogin { get; private set; }

        /// <summary>
        /// Proxy password
        /// </summary>
        public string ProxyPassword { get; private set; }
    }
}
