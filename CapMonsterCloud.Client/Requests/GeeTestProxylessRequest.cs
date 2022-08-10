using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// GeeTest recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/1940291626/GeeTestTaskProxyless+GeeTest+captcha+recognition+without+proxy
    /// </example>
    public sealed class GeeTestProxylessRequest : GeeTestRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "GeeTestTaskProxyless";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;
    }
}
