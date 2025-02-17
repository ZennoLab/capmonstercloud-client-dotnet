using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// ComplexImageTask recognition request for Recognition images
    /// </summary>
    public sealed class RecognitionComplexImageTaskRequest : ComplexImageTaskRequestBase<DynamicGridComplexImageTaskResponse>
    {
        /// <inheritdoc/>
        public override string Class => "recognition";

        /// <summary>
        /// Metadata for recognition
        /// </summary>
        public sealed class RecognitionMetadata
        {
            /// <summary>
            /// Task definition. Required.
            /// </summary>
            /// <example>
            /// oocl_rotate_new
            /// </example>
            [Required]
            [JsonProperty("Task")]
            public string Task { get; set; }

            /// <summary>
            /// Additional task argument definition. Optional.
            /// </summary>
            /// <example>
            /// 546
            /// </example>
            [JsonProperty("TaskArgument")]
            public string TaskArgument { get; set; }
        }

        /// <summary>
        /// Metadata for recognition
        /// </summary>
        [JsonProperty("metadata")]
        [Required]
        public RecognitionMetadata Metadata { get; set; }
    }
}
