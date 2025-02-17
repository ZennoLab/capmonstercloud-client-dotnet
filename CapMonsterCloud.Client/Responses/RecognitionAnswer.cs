namespace Zennolab.CapMonsterCloud.Responses
{
    public class RecognitionAnswer
    {
        public decimal[] DecimalValues { get; set; }

        public bool[] BoolValues { get; set; }

        public bool IsDecimal => DecimalValues != null;

        public bool IsBool => BoolValues != null;

        public override string ToString()
        {
            return IsDecimal ? string.Join(", ", DecimalValues) : string.Join(", ", BoolValues);
        }
    }
}
