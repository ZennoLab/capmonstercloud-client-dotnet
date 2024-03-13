namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// DataDome CustomTask recognition request base
    /// </summary>
    public abstract class DataDomeCustomTaskRequestBase : CustomTaskRequestBase
    {        
        /// <inheritdoc/>
        public override string Class => "DataDome";

        /// <summary>
        ///
        /// These values will be set to Metadata property.
        ///
        /// - captchaUrl: "captchaUrl": "..."
        /// Is required if metadata.htmlPageBase64 is not filled.
        /// You can take the link from the page with the captcha.
        /// Often it looks like https://geo.captcha-delivery.com/captcha/?initialCid=...
        /// 
        /// - htmlPageBase64: "htmlPageBase64": "PGh0bWw+PGhlYWQ+PHRpdGxlPmJs...N0E5QTA1"
        /// Is required if 'captchaUrl' is not filled.
        /// A base64 encoded html page that comes with a 403 code and a Set-Cookie: datadome="..." header in response to a get request to the target site.
        /// 
        /// - datadomeCookie: "datadomeCookie": "datadome=6BvxqELMoorFNoo7GT1...JyfP_mhz"
        /// Is required. Your cookies from datadome. You can get it on the page using "document.cookie" or in the Set-Cookie request header: "datadome=..."
        /// 
        /// </summary>
        protected DataDomeCustomTaskRequestBase(string datadomeCookie, string captchaUrl, string htmlPageBase64) => Metadata = new { datadomeCookie, captchaUrl, htmlPageBase64 };
    }
}
