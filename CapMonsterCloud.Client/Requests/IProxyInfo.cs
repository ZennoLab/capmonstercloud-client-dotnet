namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Interface for captcha recognition with proxy
    /// </summary>
    public interface IProxyInfo
    {  
        /// <summary>
        /// Proxy settings
        /// </summary>
        ProxyContainer Proxy { get; }
    }
}
