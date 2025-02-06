using FluentAssertions;
using NUnit.Framework;
using Zennolab.CapMonsterCloud.Validation;

namespace Zennolab.CapMonsterCloud.Client.Tests
{
    public class ProxyValidatorTests
    {
        [Test]
        [TestCase("8.8.8.8", true)]
        [TestCase("192.168.1.1", false)]
        [TestCase("10.0.0.1", false)]
        [TestCase("example.com", true)]
        [TestCase("localhost", false)]
        [TestCase("256.256.256.256", false)]
        [TestCase("google.com", true)]
        public void ProxyValidation__GetValidationResult(string address, bool isValid)
        {
            // Act
            var actual = ProxyValidator.IsValidProxy(address);

            // Assert
            actual.Should().Be(isValid);
        }
    }
}
