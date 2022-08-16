using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Collections.Generic;
using Zennolab.CapMonsterCloud.Requests;

#pragma warning disable IDE0058 // Expression value is never used

namespace Zennolab.CapMonsterCloud.Client
{
    public class RequestsSerializationTests
    {
        [Test]
        public void RecaptchaV2ProxylessRequest__ShouldSerialize()
        {
            // Arrange
            var target = new RecaptchaV2ProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
                DataSValue = "some data-s value",
                UserAgent = "PostmanRuntime/7.29.0",
                Cookies = new Dictionary<string, string>
                {
                    { "cookieA", "value#A" },
                    { "cookieB", "value#B" }
                }
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "NoCaptchaTaskProxyless",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    recaptchaDataSValue = target.DataSValue,
                    userAgent = target.UserAgent,
                    cookies = "cookieA=value#A;cookieB=value#B"
                }));
        }

        [Test]
        public void RecaptchaV2Request__ShouldSerialize([Values]ProxyType proxyType)
        {
            // Arrange
            var target = new RecaptchaV2Request
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
                DataSValue = "some data-s value",
                UserAgent = "PostmanRuntime/7.29.0",
                Cookies = new Dictionary<string, string>
                {
                    { "cookieA", "value#A" },
                    { "cookieB", "value#B" }
                },
                ProxyType = proxyType,
                ProxyAddress = "https://proxy.com",
                ProxyPort = 6045,
                ProxyLogin = "login",
                ProxyPassword = "p@ssword"
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "NoCaptchaTask",
                    proxyType = proxyType.ToString().ToLower(),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword,
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    recaptchaDataSValue = target.DataSValue,
                    userAgent = target.UserAgent,
                    cookies = "cookieA=value#A;cookieB=value#B"
                }));
        }

        [Test]
        [TestCase(true, 1)]
        [TestCase(false, 0)]
        public void ImageToTextRequest__ShouldSerialize(bool numeric, byte numericJson)
        {
            // Arrange
            var target = new ImageToTextRequest
            {
                Body = "some base64 body",
                CapMonsterModule = CapMonsterModules.YandexWave,
                CaseSensitive = true,
                Numeric = numeric,
                RecognizingThreshold = 65,
                Math = false
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "ImageToTextTask",
                    body = target.Body,
                    CapMonsterModule = target.CapMonsterModule,
                    recognizingThreshold = target.RecognizingThreshold,
                    Case = target.CaseSensitive,
                    numeric = numericJson,
                    math = target.Math
                }));
        }

        [Test]
        public void RecaptchaV3ProxylessRequest__ShouldSerialize()
        {
            // Arrange
            var target = new RecaptchaV3ProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_simple.php?level=high",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
                MinScore = 0.6,
                PageAction = "some-action"
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "RecaptchaV3TaskProxyless",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    minScore = target.MinScore,
                    pageAction = target.PageAction
                }));
        }

        [Test]
        public void FunCaptchaProxylessRequest__ShouldSerialize()
        {
            // Arrange
            var target = new FunCaptchaProxylessRequest
            {
                WebsiteUrl = "https://funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
                WebsiteKey = "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
                Data = "{\"blob\":\"dyXvXANMbHj1iDyz.Qj97JtSqR2n%2BuoY1V%2FbdgbrG7p%2FmKiqdU9AwJ6MifEt0np4vfYn6TTJDJEfZDlcz9Q1XMn9przeOV%2FCr2%2FIpi%2FC1s%3D\"}",
                Subdomain = "mywebsite-api.funcaptcha.com"
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "FunCaptchaTaskProxyless",
                    websiteURL = target.WebsiteUrl,
                    websitePublicKey = target.WebsiteKey,
                    funcaptchaApiJSSubdomain = target.Subdomain,
                    data = target.Data,
                }));
        }

        [Test]
        public void FunCaptchaRequest__ShouldSerialize([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new FunCaptchaRequest
            {
                WebsiteUrl = "https://funcaptcha.com/fc/api/nojs/?pkey=69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
                WebsiteKey = "69A21A01-CC7B-B9C6-0F9A-E7FA06677FFC",
                Data = "{\"blob\":\"dyXvXANMbHj1iDyz.Qj97JtSqR2n%2BuoY1V%2FbdgbrG7p%2FmKiqdU9AwJ6MifEt0np4vfYn6TTJDJEfZDlcz9Q1XMn9przeOV%2FCr2%2FIpi%2FC1s%3D\"}",
                Subdomain = "mywebsite-api.funcaptcha.com",
                ProxyType = proxyType,
                ProxyAddress = "https://proxy.com",
                ProxyPort = 6045,
                ProxyLogin = "login",
                ProxyPassword = "p@ssword"
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "FunCaptchaTask",
                    proxyType = proxyType.ToString().ToLower(),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword,
                    websiteURL = target.WebsiteUrl,
                    websitePublicKey = target.WebsiteKey,
                    funcaptchaApiJSSubdomain = target.Subdomain,
                    data = target.Data,
                }));
        }

        [Test]
        public void HCaptchaProxylessRequest__ShouldSerialize([Values]bool invisible)
        {
            // Arrange
            var target = new HCaptchaProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
                WebsiteKey = "472fc7af-86a4-4382-9a49-ca9090474471",
                Invisible = invisible,
                Data = "some data",
                UserAgent = "PostmanRuntime/7.29.0",
                Cookies = new Dictionary<string, string>
                {
                    { "cookieA", "value#A" },
                    { "cookieB", "value#B" }
                },
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "HCaptchaTaskProxyless",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    isInvisible = invisible,
                    data = target.Data,
                    userAgent = target.UserAgent,
                    cookies = "cookieA=value#A;cookieB=value#B"
                }));
        }

        [Test]
        public void HCaptchaRequest__ShouldSerialize([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new HCaptchaRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
                WebsiteKey = "472fc7af-86a4-4382-9a49-ca9090474471",
                Data = "some data",
                UserAgent = "PostmanRuntime/7.29.0",
                Cookies = new Dictionary<string, string>
                {
                    { "cookieA", "value#A" },
                    { "cookieB", "value#B" }
                },
                ProxyType = proxyType,
                ProxyAddress = "https://proxy.com",
                ProxyPort = 6045,
                ProxyLogin = "login",
                ProxyPassword = "p@ssword"
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "HCaptchaTask",
                    proxyType = proxyType.ToString().ToLower(),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword,
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    isInvisible = target.Invisible,
                    data = target.Data,
                    userAgent = target.UserAgent,
                    cookies = "cookieA=value#A;cookieB=value#B"
                }));
        }
    }
}

#pragma warning restore IDE0058 // Expression value is never used