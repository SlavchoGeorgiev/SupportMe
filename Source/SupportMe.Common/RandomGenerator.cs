namespace SupportMe.Common
{
    using System;
    using System.Text;

    public static class RandomGenerator
    {
        private static string alphabet = " _abcdefghijklmnopqrstuvqxyzABCDEFGHIJKLMNOPQRSTUVQXYZ0123456789";

        private static readonly Random randomGenerator = new Random(DateTime.Now.Millisecond);

        public static bool GetBool()
        {
            int randomNumber = randomGenerator.Next(1, 11);

            if (randomNumber <= 5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int GetInt(int minIncludedValue, int maxIncludedValue)
        {
            return randomGenerator.Next(minIncludedValue, maxIncludedValue + 1);
        }

        public static char GetChar()
        {
            return alphabet[GetInt(0, alphabet.Length - 1)];
        }

        public static string GetString(int minLength, int maxLength)
        {
            var stringLength = GetInt(minLength, maxLength);

            var sb = new StringBuilder();

            for (int i = 0; i < stringLength; i++)
            {
                sb.Append(GetChar());
            }

            return sb.ToString();
        }

        public static DateTime GetDate(DateTime fromDate, DateTime toDate)
        {
            TimeSpan timeSpan = toDate - fromDate;
            TimeSpan newSpan = new TimeSpan(0, GetInt(0, (int)timeSpan.TotalMinutes), 0);
            DateTime randomDate = fromDate + newSpan;

            return randomDate;
        }
    }
}
