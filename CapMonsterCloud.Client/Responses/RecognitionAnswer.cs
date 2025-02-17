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
        public decimal[] DecimalValues { get; set; }

        /// <summary>
        /// Bool answer
        /// </summary>
        public bool[] BoolValues { get; set; }

        /// <inheritdoc/>
        public bool IsDecimal => DecimalValues != null;

        /// <inheritdoc/>
        public bool IsBool => BoolValues != null;
    }
}
