namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// Exception on getting balance
    /// </summary>
    public class GetBalanceException : CapmonsterCloudClientException
    {
        /// <summary>
        /// Creates new exception on getting balance
        /// </summary>
        /// <param name="error">error</param>
        public GetBalanceException(ErrorType error)
            : base($"Cannot get balance. Error was {error}")
        {
            Error = error;
        }

        /// <summary>
        /// Gets occured error
        /// </summary>
        public ErrorType Error { get; }
    }
}
