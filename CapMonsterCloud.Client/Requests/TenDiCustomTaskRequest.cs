using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// TenDi CustomTask recognition request
    /// </summary>
    public sealed class TenDiCustomTaskRequest : CustomTaskRequestBase
    {        
        /// <inheritdoc/>
        public override string Class => "TenDI";

        /// <summary>
        /// captchaAppId. For example "websiteKey": "189123456" - is a unique parameter for your site. You can take it from an html page with a captcha or from traffic.
        /// </summary>
        /// <example>189123456</example>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Initializes TenDI task with required metadata.
        /// </summary>
        /// 
        /// <param name="captchaUrl">
        /// Link to the captcha script. It usually ends with TCaptcha.js or TCaptcha-global.js. You can find it in the list of requests
        /// </param>
        /// <param name="aidEncrypted">
        /// Aid value obtained from the target website. It is single-use: request a new one for each task.
        /// Do not pass it if the website does not return Aid.
        /// </param>
        public TenDiCustomTaskRequest(string captchaUrl = null, string aidEncrypted = null) => Metadata = new { captchaUrl, aidEncrypted };
    }
}
