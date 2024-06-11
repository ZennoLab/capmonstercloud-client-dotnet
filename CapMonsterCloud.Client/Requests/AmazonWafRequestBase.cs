using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    public abstract class AmazonWafRequestBase : CaptchaRequestBase
    {
        /// <summary>
        /// The address of the main page where captcha is solved.
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// A string that can be retrieved from an html page with a captcha or with javascript by executing the window.gokuProps.key
        /// </summary>
        [JsonProperty("websiteKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// Link to challenge.js (see description below the table)
        /// </summary>
        [JsonProperty("challengeScript", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string ChallengeScript { get; set; }

        /// <summary>
        /// Link to captcha.js (see description below the table)
        /// </summary>
        [JsonProperty("captchaScript", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string CaptchaScript { get; set; }

        /// <summary>
        /// A string that can be retrieved from an html page with a captcha or with javascript by executing the window.gokuProps.context
        /// </summary>
        [JsonProperty("context", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Context { get; set; }

        /// <summary>
        /// A string that can be retrieved from an html page with a captcha or with javascript by executing the window.gokuProps.iv
        /// </summary>
        [JsonProperty("iv", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string Iv { get; set; }

        /// <summary>
        /// By default false. If you need to use cookies "aws-waf-token", specify the value true. Otherwise, what you will get in return is "captcha_voucher" and "existing_token".
        /// </summary>
        [JsonProperty("cookieSolution")]
        public bool CookieSolution { get; set; }
    }
}
