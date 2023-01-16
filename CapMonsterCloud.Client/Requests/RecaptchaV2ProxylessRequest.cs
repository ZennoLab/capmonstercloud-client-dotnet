namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V2 recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/680689685/NoCaptchaTask+solving+Google+recaptcha
    /// </example>
    public sealed class RecaptchaV2ProxylessRequest : RecaptchaV2RequestBase
    {
        /// <inheritdoc />
        public override string Type => "NoCaptchaTaskProxyless";
    }
}
