using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// TenDi CustomTask recognition request base
    /// </summary>
    public abstract class TenDiCustomTaskRequestBase : CustomTaskRequestBase
    { 
        /// <inheritdoc/>
        public override string Class => "TenDI";

        /// <summary>
        /// captchaAppId. For example "websiteKey": "189123456" - is a unique parameter for your site. You can take it from an html page with a captcha or from traffic (see description below).
        /// </summary>
        /// <example>189123456</example>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }
    }
}
