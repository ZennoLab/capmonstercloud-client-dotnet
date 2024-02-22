using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V2 recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zenno.link/doc-recaptcha2-en
    /// </example>
    public sealed class RecaptchaV2ProxylessRequest : RecaptchaV2RequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "NoCaptchaTaskProxyless";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;
    }
}
