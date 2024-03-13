namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// DataDome CustomTask recognition request without proxy
    /// </summary>
    public sealed class DataDomeCustomTaskProxylessRequest : DataDomeCustomTaskRequestBase
    {
        /// <inheritdoc/>
        public DataDomeCustomTaskProxylessRequest(string datadomeCookie, string captchaUrl = null, string htmlPageBase64 = null) : base(datadomeCookie, captchaUrl, htmlPageBase64) { }
    }
}
