namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// FunCaptcha recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/643629079/FunCaptchaTaskProxyless+solving+FunCaptcha
    /// </example>
    public sealed class FunCaptchaProxylessRequest : FunCaptchaRequestBase
    {

        /// <inheritdoc/>
        public override string Type => "FunCaptchaTaskProxyless";
    }
}
