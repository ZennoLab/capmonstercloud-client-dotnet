using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Base FunCaptcha recognition request
    /// </summary>
    public abstract class FunCaptchaRequestBase : CaptchaRequestBase
    {
        /// <summary>
        /// Address of a webpage with FunCaptcha
        /// </summary>
        /// <example>https://funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC</example>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }

        /// <summary>
        /// FunCaptcha website key.
        /// <![CDATA[<div id="funcaptcha" data-pkey="THAT_ONE"></div>]]>
        /// </summary>
        /// <example>69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC</example>
        [JsonProperty("websitePublicKey", Required = Required.Always)]
        [StringLength(int.MaxValue, MinimumLength = 1)]
        public string WebsiteKey { get; set; }

        /// <summary>
        /// A special subdomain of funcaptcha.com, from which the JS captcha widget should be loaded.
        /// Most FunCaptcha installations work from shared domains, so this option is only needed in certain rare cases.
        /// </summary>
        /// <example>mywebsite-api.funcaptcha.com</example>
        [JsonProperty("funcaptchaApiJSSubdomain")]
        public string Subdomain { get; set; }

        /// <summary>
        /// Additional parameter that may be required by FunCaptcha implementation.
        /// Use this property to send "blob" value as a stringified array. See example how it may look like.
        /// <![CDATA[{"\blob\":\"HERE_COMES_THE_blob_VALUE\"}]]>
        /// </summary>
        /// <example>"{\"blob\":\"dyXvXANMbHj1iDyz.Qj97JtSqR2n%2BuoY1V%2FbdgbrG7p%2FmKiqdU9AwJ6MifEt0np4vfYn6TTJDJEfZDlcz9Q1XMn9przeOV%2FCr2%2FIpi%2FC1s%3D\"}"</example>
        [JsonProperty("data")]
        // UNDONE: вроде как не используется, может тогда и не добавлять в request?
        public string Data { get; set; }

        /// <summary>
        /// Set true if the site only accepts a portion of the tokens from CapMonster Cloud.
        /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1832714243/What+if+the+site+only+accepts+a+portion+of+the+tokens+from+CapMonster+Cloud
        /// </summary>
        [JsonProperty("nocache")]
        public bool NoCache { get; set; }

        internal override bool UseNoCache => this.NoCache;
    }
}
