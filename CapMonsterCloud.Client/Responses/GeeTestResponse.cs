using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// GeeTest recognition response
    /// </summary>
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    public class GeeTestResponse
    {
        /// <summary>
        /// </summary>
        /// <example>0f759dd1ea6c4wc76cedc2991039ca4f23</example>
        [JsonProperty("challenge")]
        public string Challenge { get; set; }

        /// <summary>
        /// </summary>
        /// <example>6275e26419211d1f526e674d97110e15</example>
        [JsonProperty("validate")]
        public string Validate { get; set; }

        /// <summary>
        /// </summary>
        /// <example>510cd9735583edcb158601067195a5eb|jordan</example>
        [JsonProperty("seccode")]
        public string SecCode { get; set; }
        
        /// <summary>
        /// </summary>
        /// <example>f5c2ad5a8a3cf37192d8b9c039950f79</example>
        [JsonProperty("captcha_id")]
        public string CaptchaId { get; set; }

        /// <summary>
        /// </summary>
        /// <example>bcb2c6ce2f8e4e9da74f2c1fa63bd713</example>
        [JsonProperty("lot_number")]
        public string LotNumber { get; set; }

        /// <summary>
        /// </summary>
        /// <example>edc7a17716535a5ae624ef4707cb6e7e478dc557608b068d202682c8297695cf</example>
        [JsonProperty("pass_token")]
        public string PassToken { get; set; }
        
        /// <summary>
        /// </summary>
        /// <example>1683794919</example>
        [JsonProperty("gen_time")]
        public string GenTime { get; set; }
        
        /// <summary>
        /// </summary>
        /// <example>XwmTZEJCJEnRIJBlvtEAZ662T...[cut]...SQ3fX-MyoYOVDMDXWSRQig56</example>
        [JsonProperty("captcha_output")]
        public string CaptchaOutput { get; set; }
    }
}
