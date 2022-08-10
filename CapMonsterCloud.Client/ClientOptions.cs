using System;

namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// Client options
    /// </summary>
    public class ClientOptions
    {
        internal const int DefaultSoftId = 53;
        /// <summary>
        /// capmonster.cloud API URI.
        /// By default https://api.capmonster.cloud
        /// </summary>
        public Uri ServiceUri { get; set; } = new Uri("https://api.capmonster.cloud");

        /// <summary>
        /// capmonster.cloud API key
        /// </summary>
        public string ClientKey { get; set; }

        /// <summary>
        /// SoftId
        /// </summary>
        public int? SoftId { get; set; }
    }
}
