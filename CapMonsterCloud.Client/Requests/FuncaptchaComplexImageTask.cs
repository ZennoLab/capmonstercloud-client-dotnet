using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// ComplexImageTask recognition request for funcaptcha images
    /// </summary>
    public sealed class FunCaptchaComplexImageTaskRequest : ComplexImageTaskRequestBase<GridComplexImageTaskResponse>
    { 
        /// <summary>
        /// Metadata for recognition
        /// </summary>
        public sealed class FunCaptchaMetadata
        {
            /// <summary>
            /// Task text(in english). Required.
            /// </summary>
            /// <example>
            /// Pick the image that is the correct way up
            /// </example>
            [Required]
            [JsonProperty("Task")]
            public string Task { get; set; }
        }

        /// <inheritdoc/>
        public override string Class => "funcaptcha";

        /// <summary>
        /// Metadata for recognition
        /// </summary>
        [JsonProperty("metadata")]
        [Required]
        public FunCaptchaMetadata Metadata { get; set; }
    }
}
