using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using Zennolab.CapMonsterCloud.Requests;

namespace Zennolab.CapMonsterCloud.Client
{
    public class JsonConverterTests
    {
        [Test]
        public void NumericFlagConverter_ShouldDeserialize([Values] bool numeric)
        {
            // Arrange
            var request = new ImageToTextRequest
            {
                Body = "some base64 body",
                CapMonsterModule = CapMonsterModules.YandexWave,
                CaseSensitive = true,
                Numeric = numeric,
                RecognizingThreshold = 65,
                Math = false
            };

            var target = JsonConvert.SerializeObject(request);

            // Act
            var actual = JsonConvert.DeserializeObject<ImageToTextRequest>(target);

            // Assert
            _ = actual!.Numeric.Should().Be(request.Numeric);
        }

        [Test]
        public void DictionaryToSemicolonSplittedStringConverter_ShouldDeserialize()
        {
            // Arrange
            var request = new HCaptchaProxylessRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
                WebsiteKey = "472fc7af-86a4-4382-9a49-ca9090474471",
                Invisible = false,
                Data = "some data",
                Cookies = new Dictionary<string, string>
                {
                    { "cookieA", "value#A" },
                    { "cookieB", "value#B" }
                }
            };

            var target = JsonConvert.SerializeObject(request);

            // Act
            var actual = JsonConvert.DeserializeObject<HCaptchaProxylessRequest>(target);

            // Assert
            _ = actual!.Cookies.Should().ContainKeys(request.Cookies.Keys);
            _ = actual.Cookies.Should().ContainValues(request.Cookies.Values);
        }

        [Test]
        public void DictionaryToSemicolonSplittedStringConverter_ShouldThrowJsonReaderException()
        {
            // Arrange
            var target = JsonConvert.SerializeObject(
                new
                {
                    type = "HCaptchaTaskProxyless",
                    websiteURL = "https://lessons.zennolab.com/captchas/hcaptcha/?level=easy",
                    websiteKey = "472fc7af-86a4-4382-9a49-ca9090474471",
                    isInvisible = false,
                    data = "some data",
                    userAgent = "PostmanRuntime/7.29.0",
                    cookies = "some invalid cookie string"
                });

            // Act
            Func<HCaptchaProxylessRequest> act = () => JsonConvert.DeserializeObject<HCaptchaProxylessRequest>(target)!;

            // Assert
            _ = act.Should().Throw<JsonReaderException>();
        }
    }
}
