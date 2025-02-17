using Newtonsoft.Json;
using Zennolab.CapMonsterCloud.Json;

namespace Zennolab.CapMonsterCloud.Responses
{    
    /// <summary>
    /// Response for Recognition grid-like tasks
    /// </summary>
    public class DynamicGridComplexImageTaskResponse : CaptchaResponseBase
    {
        /// <summary>
        /// Bool or decimal collection with answers
        /// </summary>
        /// <example>
        /// [false,true,false,true,false,false,true,false,false]
        /// [4,4,4,4,4,3,1,2,2]
        /// [130.90909]
        /// </example>
        [JsonProperty("answer")]
        [JsonConverter(typeof(RecognitionAnswerJsonConverter))]
        public RecognitionAnswer Answer { get; set; }
    }
}
