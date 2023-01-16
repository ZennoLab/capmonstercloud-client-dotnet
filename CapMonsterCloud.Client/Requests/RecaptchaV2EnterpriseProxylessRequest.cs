namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V2 Enterprise recognition request (without proxy).
    /// </summary>
    public sealed class RecaptchaV2EnterpriseProxylessRequest : RecaptchaV2EnterpriseRequestBase
    {
        /// <inheritdoc />
        public override string Type => "RecaptchaV2EnterpriseTaskProxyless";
    }
}
