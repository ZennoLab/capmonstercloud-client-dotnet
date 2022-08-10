using System.Runtime.Serialization;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Proxy types
    /// </summary>
    public enum ProxyType
    {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
        [EnumMember(Value = "http")]
        Http,
        [EnumMember(Value = "https")]
        Https,
        [EnumMember(Value = "socks4")]
        Socks4,
        [EnumMember(Value = "socks5")]
        Socks5
#pragma warning restore CS1591 // Missing XML comment for publicly visible type or member
    }
}
