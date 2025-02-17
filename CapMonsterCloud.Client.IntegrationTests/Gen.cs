using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public static class Gen
    {
        private static readonly Random Rnd = new();

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

        public static T RandomElement<T>(this IEnumerable<T> elements) =>
            elements.OrderBy(x => RandomString()).First();

        public static T RandomEnum<T>()
        {
            var enumValues = Enum.GetValues(typeof(T)).Cast<T>();
            return enumValues.RandomElement();
        }

        public static List<T> ListOfValues<T>(Func<T> createFunc) =>
            ListOfValues(createFunc, 5);

        public static List<T> ListOfValues<T>(Func<T> createFunc, int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            return Enumerable.Repeat(0, count).Select(x => createFunc()).ToList();
        }

        public static T[] ArrayOfValues<T>(Func<T> createFunc) =>
            ArrayOfValues(createFunc, 5);

        public static T[] ArrayOfValues<T>(Func<T> createFunc, int count)
        {
            if (count <= 0) throw new ArgumentOutOfRangeException(nameof(count));
            return Enumerable.Repeat(0, count).Select(x => createFunc()).ToArray();
        }

        public static bool RandomBool() => Rnd.NextDouble() >= 0.5;
        
        public static string RandomGuid()
        {
            return Guid.NewGuid().ToString();
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
