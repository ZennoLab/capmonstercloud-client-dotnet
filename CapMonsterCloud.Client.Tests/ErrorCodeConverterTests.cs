using FluentAssertions;
using NUnit.Framework;

namespace Zennolab.CapMonsterCloud.Client.Tests
{
    public class ErrorCodeConverterTests
    {
        [TestCase("ERROR_KEY_DOES_NOT_EXIST", ErrorType.KEY_DOES_NOT_EXIST)]
        [TestCase("ERROR_ZERO_CAPTCHA_FILESIZE", ErrorType.ZERO_CAPTCHA_FILESIZE)]
        [TestCase("ERROR_TOO_BIG_CAPTCHA_FILESIZE", ErrorType.TOO_BIG_CAPTCHA_FILESIZE)]
        [TestCase("ERROR_ZERO_BALANCE", ErrorType.ZERO_BALANCE)]
        [TestCase("ERROR_IP_NOT_ALLOWED", ErrorType.IP_NOT_ALLOWED)]
        [TestCase("ERROR_CAPTCHA_UNSOLVABLE", ErrorType.CAPTCHA_UNSOLVABLE)]
        [TestCase("ERROR_NO_SUCH_CAPCHA_ID", ErrorType.NO_SUCH_CAPCHA_ID)]
        [TestCase("WRONG_CAPTCHA_ID", ErrorType.NO_SUCH_CAPCHA_ID)]
        [TestCase("CAPTCHA_NOT_READY", ErrorType.Unknown)]
        [TestCase("ERROR_IP_BANNED", ErrorType.IP_BANNED)]
        [TestCase("ERROR_NO_SUCH_METHOD", ErrorType.NO_SUCH_METHOD)]
        [TestCase("ERROR_TOO_MUCH_REQUESTS", ErrorType.TOO_MUCH_REQUESTS)]
        [TestCase("ERROR_DOMAIN_NOT_ALLOWED", ErrorType.DOMAIN_NOT_ALLOWED)]
        [TestCase("ERROR_TOKEN_EXPIRED", ErrorType.TOKEN_EXPIRED)]
        [TestCase("ERROR_NO_SLOT_AVAILABLE", ErrorType.NO_SLOT_AVAILABLE)]
        public void Convert__ShouldConvert(string errorCode, ErrorType expected)
        {
            // Arrange

            // Act
            var actual = ErrorCodeConverter.Convert(errorCode);

            // Assert
            actual.Should().Be(expected);
        }
    }
}
