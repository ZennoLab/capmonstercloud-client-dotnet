﻿using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// ImageToText recognition request
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/655469/ImageToTextTask+solve+image+captcha
    /// </example>
    public sealed class ImageToTextRequest : CaptchaRequestBase
    {
        /// <inheritdoc />
        public override string Type => "ImageToTextTask";

        /// <summary>
        /// File body encoded in base64. Make sure to send it without line breaks.
        /// </summary>
        [JsonProperty("body", Required = Required.Always)]
        public string Body { get; set; }

        /// <summary>
        /// Name of recognizing module. Supported module names are <seealso cref="CapMonsterModules"/>
        /// </summary>
        [JsonProperty("CapMonsterModule")]
        public string CapMonsterModule { get; set; }

        /// <summary>
        /// Captcha recognition threshold with a possible value from 0 to 100.
        /// </summary>
        /// <example>
        /// If <see cref="RecognizingThreshold"/> was set to 90 and the task was solved with a confidence of 80, you won't be charged.
        /// In this case the user will get a response <see cref="ErrorType.CAPTCHA_UNSOLVABLE"/>.
        /// </example>
        [JsonProperty("recognizingThreshold")]
        [Range(0, 100)]
        public byte RecognizingThreshold { get; set; }

        /// <summary>
        /// Set true if captcha is case sensitive.
        /// </summary>
        [JsonProperty("Case")]
        public bool CaseSensitive { get; set; }

        /// <summary>
        /// Set true if captcha contains numbers only
        /// </summary>
        [JsonProperty("numeric")]
        [JsonConverter(typeof(Json.NumericFlagConverter))]
        public bool Numeric { get; set; }

        /// <summary>
        /// Set true if captcha requires a mathematical operation.
        /// </summary>
        /// <example>
        /// Captcha 2 + 6 = will return a value of 8
        /// </example>
        [JsonProperty("math")]
        public bool Math { get; set; }
    }
}
