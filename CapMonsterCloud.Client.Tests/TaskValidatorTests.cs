using FluentAssertions;
using NUnit.Framework;
using System;
using System.ComponentModel.DataAnnotations;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Validation;

#pragma warning disable IDE0058 // Expression value is never used

namespace Zennolab.CapMonsterCloud.Client.Tests
{
    public class TaskValidatorTests
    {
        [Test]
        public void FunCaptchaRequest_WithoutProxy__ShouldFailValidation()
        {
            // Arrange
            var target = new FunCaptchaRequest
            {
                WebsiteUrl = "https://example.com/",
                WebsiteKey = "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC"
            };

            // Act
            Action actual = () => TaskValidator.ValidateObjectIncludingInternals(target);

            // Assert
            actual.Should().Throw<AggregateException>()
                .WithInnerException<ValidationException>()
                .WithMessage("Proxy is required for FunCaptchaTask");
        }

        [Test]
        public void FunCaptchaRequest_WithProxyWithoutCredentials__ShouldPassValidation([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new FunCaptchaRequest
            {
                WebsiteUrl = "https://example.com/",
                WebsiteKey = "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, null, null)
            };

            // Act
            Action actual = () => TaskValidator.ValidateObjectIncludingInternals(target);

            // Assert
            actual.Should().NotThrow();
        }

        [Test]
        public void RequestWithOptionalProxy_WithoutProxy__ShouldPassValidation()
        {
            // Arrange
            var target = new RecaptchaV2Request
            {
                WebsiteUrl = "https://example.com/",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd"
            };

            // Act
            Action actual = () => TaskValidator.ValidateObjectIncludingInternals(target);

            // Assert
            actual.Should().NotThrow();
        }

        [Test]
        public void ProxyContainer_WithZeroPort__ShouldThrow()
        {
            // Act
            Action actual = () => new ProxyContainer("proxy.com", 0, ProxyType.Http, null, null);

            // Assert
            actual.Should().Throw<ArgumentException>()
                .WithMessage("Proxy port must be between 1 and 65535");
        }
    }
}

#pragma warning restore IDE0058 // Expression value is never used
