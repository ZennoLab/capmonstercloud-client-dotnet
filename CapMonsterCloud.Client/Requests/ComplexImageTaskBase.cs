using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// ComplexImageTask recognition request
    /// </summary>
    public abstract class ComplexImageTaskRequestBase : CaptchaRequestBase<GridComplexImageTaskResponse>
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "ComplexImageTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public sealed override string Type => TaskType;

        /// <summary>
        /// Class(subtype) of ComplexImageTask
        /// </summary>
        [JsonProperty("class", Required = Required.Always)]
        public abstract string Class { get; }

        /// <summary>
        /// Collection with image urls. Must be populated if <see cref="ImagesBase64"/> not.
        /// </summary>
        [JsonProperty("imageUrls")]
        public ICollection<string> ImageUrls { get; set; }

        /// <summary>
        /// Collection with base64 encoded images. Must be populated if <see cref="ImageUrls"/> not.
        /// </summary>
        [JsonProperty("imagesBase64")]
        public ICollection<string> ImagesBase64 { get; set; }

        /// <summary>
        /// Browser's User-Agent which is used in emulation.
        /// </summary>
        /// <remarks>
        /// It is required that you use a signature of a modern browser
        /// </remarks>
        [JsonProperty("userAgent")]
        public string UserAgent { get; set; }
        
        /// <summary>
        /// Address of a webpage with captcha
        /// </summary>
        [JsonProperty("websiteURL", Required = Required.Always)]
        [Url]
        public string WebsiteUrl { get; set; }
    }
}
