namespace Zennolab.CapMonsterCloud.Responses
{
    /// <summary>
    /// Recognition captcha answer
    /// </summary>
    public class RecognitionAnswer
    {
        /// <summary>
        /// Decimal answer
        /// </summary>
        public decimal[] NumericAnswer { get; set; }

        /// <summary>
        /// Bool answer
        /// </summary>
        public bool[] GridAnswer { get; set; }

        /// <inheritdoc/>
        public bool IsNumeric => NumericAnswer != null;

        /// <inheritdoc/>
        public bool IsGrid => NumericAnswer != null;
    }
}
