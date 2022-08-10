using System;

namespace Zennolab.CapMonsterCloud
{
    internal static class ErrorCodeConverter
    {
        public static ErrorType Convert(string errorCode)
        {
            const string Prefix = "ERROR_";
            const int PrefixLen = 6;

            if (errorCode.StartsWith(Prefix))
            {
                errorCode = errorCode.Substring(PrefixLen, errorCode.Length - PrefixLen);
            }

            return Enum.TryParse<ErrorType>(errorCode, ignoreCase: true, out var result)
                ? result
                : errorCode.Equals("WRONG_CAPTCHA_ID", StringComparison.OrdinalIgnoreCase)
                    ? ErrorType.NO_SUCH_CAPCHA_ID
                    : ErrorType.Unknown;
        }
    }
}
