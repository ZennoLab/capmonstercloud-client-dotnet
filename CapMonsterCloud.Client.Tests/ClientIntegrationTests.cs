using FluentAssertions;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Zennolab.CapMonsterCloud.Requests;

namespace Zennolab.CapMonsterCloud.Client
{
    public class ClientIntegrationTests
    {
        private readonly static ClientOptions ClientOptions = new ClientOptions
        {
            ServiceUri = new Uri("https://api.capmonster.cloud"),
            ClientKey = Environment.GetEnvironmentVariable("CAPMONSTERCLOUD_CLIENTKEY")
        };

        [Test]
        public async Task GetBalance__ShouldReturn()
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var watch = new Stopwatch();
            watch.Start();

            // Act
            var actual = await target.GetBalanceAsync(default);

            // Assert
            watch.Stop();

            _ = actual.Should().BeGreaterOrEqualTo(0M);

            Console.WriteLine($"{watch.ElapsedMilliseconds}: current balance: {actual}");
        }

        [Test]
        public async Task SolveAsync_RecaptchaV2Proxyless_ShouldSolve()
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new RecaptchaV2ProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            var actual = await target.SolveAsync(request, default);

            // Assert
            watch.Stop();

            _ = actual.Error.Should().BeNull();
            _ = actual.Solution.Should().NotBeNull();

            Console.WriteLine($"{watch.ElapsedMilliseconds}: solve result: {actual.Solution.Value}");
        }

        [Test]
        public async Task SolveAsync_HCaptchaProxyless_ShouldSolve()
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new HCaptchaProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
                WebsiteKey = "472fc7af-86a4-4382-9a49-ca9090474471",
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            var actual = await target.SolveAsync(request, default);

            // Assert
            watch.Stop();

            _ = actual.Error.Should().BeNull();
            _ = actual.Solution.Should().NotBeNull();

            Console.WriteLine($"{watch.ElapsedMilliseconds}: solve result: {actual.Solution.Value}");
        }

        [Test]
        public async Task SolveAsync_IncorrectWebsiteUrl_ShouldThrowValidationException()
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new RecaptchaV2Request
            {
                WebsiteUrl = "incorrect url",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd"
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            Func<Task> act = () => target.SolveAsync(request, default);

            // Assert
            _ = await act.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The WebsiteUrl field is not a valid fully-qualified*URL*");
        }

        [Test]
        [TestCase(65535 + 1)]
        [TestCase(65535 + 2)]
        [TestCase(65535 + 100)]
        public async Task SolveAsync_IncorrectProxyPort_ShouldThrowValidationException(int port)
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new RecaptchaV2Request
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
                ProxyPort = port
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            Func<Task> act = () => target.SolveAsync(request, default);

            // Assert
            _ = await act.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field ProxyPort must be between 0 and 65535*");
        }

        [Test]
        [TestCase(0.09)]
        [TestCase(0.901)]
        [TestCase(1.1)]
        public async Task SolveAsync_IncorrectMinScore_ShouldThrowValidationException(double minScore)
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new RecaptchaV3ProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
                MinScore = minScore
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            Func<Task> act = () => target.SolveAsync(request, default);

            // Assert
            _ = await act.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field MinScore must be between 0.1 and 0.9*");
        }
        
        [Test]
        [TestCase(101)]
        [TestCase(102)]
        public async Task SolveAsync_IncorrectRecognizingThreshold_ShouldThrowValidationException(byte value)
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new ImageToTextRequest
            {
                RecognizingThreshold = value
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            Func<Task> act = () => target.SolveAsync(request, default);

            // Assert
            _ = await act.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field RecognizingThreshold must be between 0 and 100*");
        }

        [Test]
        public async Task SolveAsync_IncorrectWebsiteKey_ShouldThrowValidationException()
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new RecaptchaV2ProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                WebsiteKey = string.Empty
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            Func<Task> act = () => target.SolveAsync(request, default);

            // Assert
            _ = await act.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field WebsiteKey must be a string with a minimum length of 1*");
        }

        [Test]
        public async Task SolveAsync_IncorrectGt_ShouldThrowValidationException()
        {
            // Arrange
            var target = CapMonsterCloudClientFactory.Create(ClientOptions);

            var request = new GeeTestProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                Gt = string.Empty
            };

            var watch = new Stopwatch();
            watch.Start();

            // Act
            Func<Task> act = () => target.SolveAsync(request, default);

            // Assert
            _ = await act.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field Gt must be a string with a minimum length of 1*");
        }
    }
}
