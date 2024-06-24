using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// AmazonTask recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/amazon-task
    /// </example>
    public class AmazonWafProxylessRequest : AmazonWafRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "AmazonTask";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;
    }
}
