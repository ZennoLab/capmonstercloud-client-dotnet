using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// GeeTest recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://zenno.link/doc-geetest-en
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
