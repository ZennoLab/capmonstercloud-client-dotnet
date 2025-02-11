using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Responses;

namespace Zennolab.CapMonsterCloud.Requests
{
    /// <summary>
    /// Base captcha recognition request
    /// </summary>
    public abstract class CaptchaRequestBaseWithProxy<TResponse> : CaptchaRequestBase<TResponse>, IProxyInfo where TResponse : CaptchaResponseBase
    {
        /// <inheritdoc/>
        [JsonIgnore]
        public ProxyContainer Proxy
        {
            get
            {
                if (!string.IsNullOrEmpty(ProxyAddress))
                    return new ProxyContainer(ProxyAddress, ProxyPort, ProxyType, ProxyLogin, ProxyPassword);

                return null;
            }
            set
            {
                if (value != null)
                {
                    ProxyAddress = value.ProxyAddress;
                    ProxyPort = value.ProxyPort;
                    ProxyType = value.ProxyType;
                    ProxyLogin = value.ProxyLogin;
                    ProxyPassword = value.ProxyPassword;
                }
            }
        }

        /// <inheritdoc/>
        [JsonProperty("proxyAddress")]
        internal string ProxyAddress { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyPort")]
        [Range(0, 65535)]
        protected internal int ProxyPort { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyType")]
        [JsonConverter(typeof(StringEnumConverter))]
        internal ProxyType ProxyType { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyLogin")]
        internal string ProxyLogin { get; set; }

        /// <inheritdoc/>
        [JsonProperty("proxyPassword")]
        internal string ProxyPassword { get; set; }
    }
}
