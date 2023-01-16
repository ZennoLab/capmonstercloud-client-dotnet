namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// GeeTest recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1940291626/GeeTestTaskProxyless+GeeTest+captcha+recognition+without+proxy
    /// </example>
    public sealed class GeeTestProxylessRequest : GeeTestRequestBase
    {
        /// <inheritdoc/>
        public override string Type => "GeeTestTaskProxyless";
    }
}
