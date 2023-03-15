using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// ComplexImageTask recognition request for hcaptcha images
    /// </summary>
    public sealed class HCaptchaComplexImageTaskRequest : ComplexImageTaskRequestBase
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
    }
}
