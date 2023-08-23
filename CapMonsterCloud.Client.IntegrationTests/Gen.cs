using System.Security.Cryptography;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public static class Gen
    {
        private static readonly Random Rnd = new Random();

        public static int RandomInt()
        {
            return RandomInt(
                minValue: int.MinValue,
                maxValue: int.MaxValue);
        }

        public static int RandomInt(
            int minValue,
            int maxValue = int.MaxValue)
        {
            return Rnd.Next(
                minValue: minValue,
                maxValue: maxValue);
        }

        public static long RandomLong()
        {
            return RandomLong(
                minValue: long.MinValue,
                maxValue: long.MaxValue);
        }

        public static long RandomLong(
            long minValue,
            long maxValue)
        {
            if (maxValue <= minValue)
            {
                throw new ArgumentOutOfRangeException(nameof(maxValue), "max must be > min!");
            }

            ulong uRange = (ulong)(maxValue - minValue);

            ulong ulongRand;
            do
            {
                byte[] buf = new byte[8];
                Rnd.NextBytes(buf);
                ulongRand = (ulong)BitConverter.ToInt64(buf, 0);
            }
            while (ulongRand > ulong.MaxValue - (((ulong.MaxValue % uRange) + 1) % uRange));

            return (long)(ulongRand % uRange) + minValue;
        }

        public static decimal RandomDecimal()
        {
            return RandomDecimal(
                minValue: decimal.MinValue,
                maxValue: decimal.MaxValue);
        }

        public static decimal RandomDecimal(
            decimal minValue,
            decimal maxValue)
        {
            return Convert.ToDecimal(RandomDouble((double)minValue, (double)maxValue));
        }

        public static double RandomDouble()
        {
            return RandomDouble(
                minValue: double.MinValue / 2,
                maxValue: double.MaxValue / 2);
        }

        public static double RandomDouble(
            double minValue,
            double maxValue) =>
            minValue + (Rnd.NextDouble() * (maxValue - minValue));

        public static string RandomString()
        {
            return RandomString(36);
        }
        
       public static string RandomString(int length)
        {
            var values = Enumerable.Repeat(0, (length / 36) + 1).Select(x => Guid.NewGuid().ToString());
            return string.Join(string.Empty, values).Substring(0, length);
        }

        public static List<string> RandomStrings(int count) =>
            Enumerable.Repeat(0, count).Select(x => RandomString()).ToList();

        public static T RandomElement<T>(this IEnumerable<T> elements) =>
            elements.OrderBy(x => RandomString()).First();

        public static T RandomEnum<T>()
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();
            return enumValues.RandomElement();
        }

        public static string RandomEmail() =>
            Guid.NewGuid().ToString("N") + "@zennolab.com";

        public static List<T> ListOfValues<T>(Func<T> createFunc) =>
            ListOfValues(createFunc, 5);

        public static List<T> ListOfValues<T>(Func<T> createFunc, int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            return Enumerable.Repeat(0, count).Select(x => createFunc()).ToList();
        }

        public static bool RandomBool() => Rnd.NextDouble() >= 0.5;

        public static DateTime RandomDate(int samplingTicks = 10_000_000)
        {
            var randomTicks = RandomLong(
                minValue: 0,
                maxValue: 3155378975999999999);

            return new DateTime(ticks: randomTicks / samplingTicks * samplingTicks);
        }

        public static DateTime RandomDateBetween(
            DateTime firstDate,
            DateTime secondDate)
        {
            var ticksBetween = Math.Abs((firstDate - secondDate).Ticks);
            var minTicks = Math.Min(firstDate.Ticks, secondDate.Ticks);
            return new DateTime(ticks: minTicks + RandomLong(0, ticksBetween));
        }
        
        public static string RandomGuid()
        {
            return Guid.NewGuid().ToString();
        }
        
        public static string RandomApiKey()
        {
            return RandomApiKey(Guid.NewGuid());
        }
        
        public static string RandomApiKey(Guid guid)
        {
            var key = guid.ToByteArray();
            using var hmac = new MD5CryptoServiceProvider();
            var h = hmac.ComputeHash(key);
            return BitConverter.ToString(h).Replace("-", string.Empty).ToLower();
        }
        
        public static string UserAgent()
        {
            return "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/115.0.0.0 Safari/537.36";
        }
        
        public static Uri RandomUri()
        {
            return new Uri($"https://{RandomString()}.zennolab.com");
        }
    }
}
