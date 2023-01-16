using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Turnstile recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/2256764929/TurnstileTaskProxyless+Turnstile
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
