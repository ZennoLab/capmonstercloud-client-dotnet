using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// HCaptcha recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zenno.link/doc-hcaptcha-en
    /// </example>
    public sealed class HCaptchaProxylessRequest : HCaptchaRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "HCaptchaTaskProxyless";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;
    }
}
