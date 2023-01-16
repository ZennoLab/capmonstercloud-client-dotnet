namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V2 recognition request (with proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/373161985/NoCaptchaTaskProxyless+solving+Google+recaptcha
    /// </example>
    public sealed class RecaptchaV2Request : RecaptchaV2RequestBase, IProxyInfo
    {
        /// <inheritdoc />
        public override string Type => "NoCaptchaTask";

        /// <inheritdoc/>
        public ProxyType ProxyType { get; set; }

        /// <inheritdoc/>
        public string ProxyAddress { get; set; }

        /// <inheritdoc/>
        public int ProxyPort { get; set; }

        /// <inheritdoc/>
        public string ProxyLogin { get; set; }

        /// <inheritdoc/>
        public string ProxyPassword { get; set; }
    }
}