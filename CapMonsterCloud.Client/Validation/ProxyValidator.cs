using System;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace Zennolab.CapMonsterCloud.Validation
{
    internal class ProxyValidator
    {
        private static readonly Regex HostnameRegex = new Regex(@"^(?!\d+(\.\d+){3}$)([a-zA-Z0-9.-]+)$", RegexOptions.Compiled, TimeSpan.FromSeconds(1));

        internal static bool IsValidProxy(string proxy)
        {
            if (string.IsNullOrWhiteSpace(proxy))
                return false;

            if (IPAddress.TryParse(proxy, out IPAddress ipAddress))
            {
                return IsPublicIPAddress(ipAddress);
            }

            return IsValidHostname(proxy);
        }

        private static bool IsValidHostname(string hostname)
        {
            if (hostname.Equals("localhost", StringComparison.OrdinalIgnoreCase))
                return false;

            // Ensure it follows domain name rules
            return hostname.Length <= 253 && HostnameRegex.IsMatch(hostname);
        }

        private static bool IsPublicIPAddress(IPAddress ip)
        {
            if (ip.AddressFamily == AddressFamily.InterNetwork || ip.AddressFamily == AddressFamily.InterNetworkV6)
            {
                byte[] bytes = ip.GetAddressBytes();

                // Private IPv4 ranges
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    if (bytes[0] == 10 ||
                        (bytes[0] == 172 && bytes[1] >= 16 && bytes[1] <= 31) ||
                        (bytes[0] == 192 && bytes[1] == 168))
                    {
                        return false;
                    }
                }

                // IPv6 private/local addresses
                if (ip.IsIPv6LinkLocal || ip.IsIPv6SiteLocal)
                {
                    return false;
                }

                // Loopback and unspecified addresses
                if (IPAddress.IsLoopback(ip) || ip.Equals(IPAddress.Any) || ip.Equals(IPAddress.IPv6Any))
                {
                    return false;
                }

                return true;
            }

            return false;
        }
    }
}
