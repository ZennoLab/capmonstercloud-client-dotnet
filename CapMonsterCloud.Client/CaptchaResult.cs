namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// General captcha recognition result
    /// </summary>
    /// <typeparam name="TSolution">Concrete captcha result type</typeparam>
    public class CaptchaResult<TSolution>
    {
        /// <summary>
        /// Error code
        /// </summary>
        public ErrorType? Error { get; internal set; }

        /// <summary>
        /// Task result. Different for each type of task.
        /// </summary>
        public TSolution Solution { get; internal set; }
    }
}
