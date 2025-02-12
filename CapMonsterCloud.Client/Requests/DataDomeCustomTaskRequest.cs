namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// DataDome CustomTask recognition request
    /// </summary>
    public sealed class DataDomeCustomTaskRequest : DataDomeCustomTaskRequestBase
    {
        /// <inheritdoc/>
        public DataDomeCustomTaskRequest(string datadomeCookie, string captchaUrl = null, string htmlPageBase64 = null) : base(datadomeCookie, captchaUrl, htmlPageBase64) { }
    }
}
