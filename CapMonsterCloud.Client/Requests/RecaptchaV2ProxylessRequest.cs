using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Recaptcha V2 recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/680689685/NoCaptchaTask+solving+Google+recaptcha
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
