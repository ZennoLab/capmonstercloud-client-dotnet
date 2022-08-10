using System;

namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// Base type for capmonster.cloud Client exceptions
    /// </summary>
    public class CapmonsterCloudClientException : ApplicationException
    {
        /// <summary>
        /// Creates new capmonster.cloud Client exception
        /// </summary>
        /// <param name="message">message</param>
        public CapmonsterCloudClientException(string message) : base(message)
        {
        }

        /// <summary>
        /// Creates new capmonster.cloud Client exception
        /// </summary>
        /// <param name="message">message</param>
        /// <param name="innerException">inner exception</param>
        public CapmonsterCloudClientException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
