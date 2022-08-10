using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// FunCaptcha recognition response
    /// </summary>
    public class FunCaptchaResponse
    {
        /// <summary>
        /// FunCaptcha token that needs to be substituted into the form.
        /// </summary>
        /// <example>
        /// <![CDATA[
        /// 36859d1086acb06e7.08293101|r=ap-southeast-1|metabgclr=%23ffffff|guitextcolor=%23555555|metaiconclr=%23cccccc|meta=3|pk=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC|injs=https://funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC|rid=11|cdn_url=https://cdn.funcaptcha.com/fc|surl=https://funcaptcha.com
        /// ]]>
        /// </example>
        [JsonProperty("token")]
        public string Value { get; set; }
    }
}
