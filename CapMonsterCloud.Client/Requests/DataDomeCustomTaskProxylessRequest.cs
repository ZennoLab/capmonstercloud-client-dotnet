namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// DataDome CustomTask recognition request without proxy
    /// </summary>
    public sealed class DataDomeCustomTaskProxylessRequest : DataDomeCustomTaskRequestBase
    { 
        /// <summary>
        /// captchaUrl - the value will be set to Metadata property
        /// </summary>
        /// <param name="captchaUrl"></param>
        public DataDomeCustomTaskProxylessRequest(string captchaUrl) : base(captchaUrl) { }
    }
}
