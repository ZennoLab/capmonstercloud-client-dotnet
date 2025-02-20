using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// ComplexImageTask recognition request for hcaptcha images
    /// </summary>
    public sealed class HCaptchaComplexImageTaskRequest : ComplexImageTaskRequestBase<DynamicComplexImageTaskResponse>
    {
        /// <summary>
        /// Metadata for recognition
        /// </summary>
        public sealed class HCaptchaMetadata
        {
            /// <summary>
            /// Task text(in english). Required.
            /// </summary>
            /// <example>
            /// Please click each image containing a mountain
            /// </example>
            [Required]
            [JsonProperty("Task")]
            public string Task { get; set; }
        }

        /// <inheritdoc/>
        public override string Class => "hcaptcha";

        /// <summary>
        /// Metadata for recognition
        /// </summary>
        [JsonProperty("metadata")]
        [Required]
        public HCaptchaMetadata Metadata { get; set; }

        /// <summary>
        /// Collection with image urls. Number of elements depends on type of captcha. Must be populated if <see cref="ExampleImagesBase64"/> not.
        /// </summary>
        [JsonProperty("exampleImageUrls")]
        public ICollection<string> ExampleImageUrls { get; set; }

        /// <summary>
        /// Collection with base64 encoded images. Number of elements depends on type of captcha. Must be populated if <see cref="ExampleImageUrls"/> not.
        /// </summary>
        [JsonProperty("exampleImagesBase64")]
        public ICollection<string> ExampleImagesBase64 { get; set; }
    }
}
