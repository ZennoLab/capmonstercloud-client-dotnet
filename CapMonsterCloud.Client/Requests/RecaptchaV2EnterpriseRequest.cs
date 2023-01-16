namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V2 Enterprise recognition request (with proxy).
    /// </summary>
    public sealed class RecaptchaV2EnterpriseRequest : RecaptchaV2EnterpriseRequestBase, IProxyInfo
    {
        /// <inheritdoc/>
        public override string Type => "RecaptchaV2EnterpriseTask";

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