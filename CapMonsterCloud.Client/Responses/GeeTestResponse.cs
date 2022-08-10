using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// GeeTest recognition response
    /// </summary>
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
    }
}
