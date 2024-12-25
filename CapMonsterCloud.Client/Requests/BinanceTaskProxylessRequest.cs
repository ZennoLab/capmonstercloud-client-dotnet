using Newtonsoft.Json;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// BinanceTask recognition request (without proxy).
    /// </summary>
    /// <example>
    /// https://docs.capmonster.cloud/docs/captchas/binance
    /// </example>
    public sealed class BinanceTaskProxylessRequest : BinanceTaskRequestBase
    {
        /// <summary>
        /// Recognition task type
        /// </summary>
        public const string TaskType = "BinanceTaskProxyless";

        /// <inheritdoc/>
        [JsonProperty("type", Required = Required.Always)]
        public override sealed string Type => TaskType;
    }
}
