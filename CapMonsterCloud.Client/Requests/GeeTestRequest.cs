namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// GeeTest recognition request (with proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1940357159/GeeTestTask+GeeTest+captcha+recognition
    /// </example>
    public sealed class GeeTestRequest : GeeTestRequestBase, IProxyInfo
    {
        /// <inheritdoc/>
        public override string Type => "GeeTestTask";

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