using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// Recaptcha recognition response base
    /// </summary>
    public abstract class RecaptchaResponseBase
    {
        /// <summary>
        /// Hash which should be inserted into Recaptcha2 submit form in
        /// <![CDATA[
        /// <textarea id="g-recaptcha-response" ..></textarea>
        /// ]]>
        /// It has a length of 500 to 2190 bytes.
        /// </summary>
        /// <example>
        /// <![CDATA[3AHJ_VuvYIBNBW5yyv0zRYJ75VkOKvhKj9_xGBJKnQimF72rfoq3Iy-DyGHMwLAo6a3]]>
        /// </example>
        [JsonProperty("gRecaptchaResponse")]
        public string Value { get; set; }
    }
}
