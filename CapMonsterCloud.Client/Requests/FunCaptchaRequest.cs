using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// FunCaptcha recognition request (with proxy).
    /// </summary>
    /// <example>
    /// https://zennolab.atlassian.net/wiki/spaces/APIS/pages/735805497/FunCaptchaTask+solving+FunCaptcha
    /// </example>
    public sealed class FunCaptchaRequest : FunCaptchaRequestBase, IProxyInfo
    {
        /// <inheritdoc />
        public override string Type => "FunCaptchaTask";

        /// <inheritdoc/>
        [JsonConverter(typeof(StringEnumConverter))]
        public ProxyType ProxyType { get; set; }

        /// <inheritdoc/>
        public string ProxyAddress { get; set; }

        /// <inheritdoc/>
        [Range(0, 65535)]
        public int ProxyPort { get; set; }

        /// <inheritdoc/>
        public string ProxyLogin { get; set; }

        /// <inheritdoc/>
        public string ProxyPassword { get; set; }
    }
}
