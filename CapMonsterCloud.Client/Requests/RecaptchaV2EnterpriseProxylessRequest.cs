using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V2 Enterprise recognition request (without proxy).
    /// </summary>
    public sealed class RecaptchaV2EnterpriseProxylessRequest : RecaptchaV2EnterpriseRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "RecaptchaV2EnterpriseTaskProxyless";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;
    }
}
