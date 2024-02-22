using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Turnstile recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zenno.link/doc-turnstile-en
    /// </example>
    public sealed class TurnstileProxylessRequest : TurnstileRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "TurnstileTaskProxyless";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override string Type => TaskType;
    }
}
