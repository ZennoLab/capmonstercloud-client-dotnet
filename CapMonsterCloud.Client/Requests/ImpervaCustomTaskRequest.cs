namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Imperva CustomTask recognition request
    /// </summary>
    public class ImpervaCustomTaskRequest : CustomTaskRequestBase
    {        
        /// <inheritdoc/>
        public override string Class => "Imperva";

        /// <summary>
        ///
        /// These values will be set to Metadata property.
        ///
        /// - incapsulaScriptBase64: "incapsulaScriptBase64": "..."
        /// the base64-encoded content of the Incapsula JavaScript script. To obtain this value, you need to go to the script page.
        /// The script content loaded by this src must be encoded in base64 format. This will be the value for the parameter incapsulaScriptBase64.
        /// 
        /// - incapsulaSessionCookie: "incapsulaSessionCookie": "l/LsGnrvyB9lNhXI8borDKa2IGcAAAAAX0qAEHheCWuNDquzwb44cw="
        /// Your cookies from Incapsula. You can obtain them on the page using "document.cookie" or in the request header Set-Cookie: "incap_sess_*=..."
        /// 
        /// - reese84UrlEndpoint: "reese84UrlEndpoint": "Built-with-the-For-hopence-Hurleysurfecting-the-"
        /// The name of the endpoint where the reese84 fingerprint is sent can be found among the requests and ends with ?d=site.com
        /// 
        /// </summary>
        public ImpervaCustomTaskRequest(string incapsulaScriptBase64, string incapsulaSessionCookie, string reese84UrlEndpoint) => Metadata = new { incapsulaScriptBase64, incapsulaSessionCookie, reese84UrlEndpoint };
    }
}
