namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// HCaptcha recognition request (with proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1203240988/HCaptchaTask+hCaptcha+puzzle+solving
    /// </example>
    public sealed class HCaptchaRequest : HCaptchaRequestBase, IProxyInfo
    {
        /// <inheritdoc/>
        public override string Type => "HCaptchaTask";

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
