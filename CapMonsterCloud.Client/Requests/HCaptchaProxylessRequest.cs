namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// HCaptcha recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1203240977/HCaptchaTaskProxyless+hCaptcha+puzzle+solving
    /// </example>
    public sealed class HCaptchaProxylessRequest : HCaptchaRequestBase
    {
        /// <inheritdoc/>
        public override string Type => "HCaptchaTaskProxyless";
    }
}
