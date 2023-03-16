using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// ComplexImageTask recognition request for recaptcha images
    /// </summary>
    public sealed class RecaptchaComplexImageTaskRequest : ComplexImageTaskRequestBase
    {
        /// <summary>
        /// Metadata for recognition
        /// </summary>
        public sealed class RecaptchaMetadata
        {
            private const string EnumPrefix = "Grid";

            /// <summary>
            /// Image grid.
            /// </summary>
            public enum GridSize
            {
#pragma warning disable CS1591
                Grid3x3,
                Grid4x4,
                Grid1x1
#pragma warning restore CS1591
            }

            /// <inheritdoc cref="GridSize"/>
            [JsonIgnore]
            public GridSize Grid
            {
                get => (GridSize)Enum.Parse(typeof(GridSize), EnumPrefix + GridString);
                set => GridString = value.ToString().Replace(EnumPrefix, string.Empty);
            }

            [JsonProperty("Grid")]
            internal string GridString { get; set; }


            /// <summary>
            /// Preferred way to identify what should we looking for on image.
            /// Task text(in english). Required if <see cref="TaskDefinition"/> is empty.
            /// </summary>
            /// <example>
            /// Click on traffic lights
            /// </example>
            [Required]
            [JsonProperty("Task")]
            public string Task { get; set; }

            /// <summary>
            /// Secondary way to identify what should we looking for on image.
            /// Required if <see cref="Task"/> is empty.
            /// Useful if you can sniff traffic between page and recaptcha backend.
            /// The data can be found in responses to "/recaptcha/{recaptchaApi}/reload" or "/recaptcha/{recaptchaApi}/userverify" requests,
            /// where recaptchaApi is "enterprise" or "api2" depending on the Recaptcha type.
            /// The response contains json,
            /// in which one can take a list of TaskDefinitions for loaded captchas.
            /// </summary>
            /// <example>
            /// /m/015qff
            /// </example>
            [Required]
            [JsonProperty("TaskDefinition")]
            public string TaskDefinition { get; set; }
        }

        /// <inheritdoc/>
        public override string Class => "recaptcha";

        /// <summary>
        /// Metadata for recognition
        /// </summary>
        [JsonProperty("metadata")]
        [Required]
        public RecaptchaMetadata Metadata { get; set; }
    }
}
