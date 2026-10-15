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
        public void RecaptchaV2Request__ShouldSerialize([Values] ProxyType proxyType)
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
                IsInvisible = true,
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "NoCaptchaTask",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    recaptchaDataSValue = target.DataSValue,
                    userAgent = target.UserAgent,
                    cookies = "cookieA=value#A;cookieB=value#B",
                    isInvisible = target.IsInvisible,
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
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
                PageAction = "some-action",
                IsEnterprise = true
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
                    pageAction = target.PageAction,
                    isEnterprise = target.IsEnterprise
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
                UserAgent = "PostmanRuntime/7.29.0",
                Cookies = "cookieA=value#A;cookieB=value#B",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "FunCaptchaTask",
                    websiteURL = target.WebsiteUrl,
                    websitePublicKey = target.WebsiteKey,
                    funcaptchaApiJSSubdomain = target.Subdomain,
                    data = target.Data,
                    userAgent = target.UserAgent,
                    cookies = target.Cookies,
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
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
                Cookies = new Dictionary<string, string>
                {
                    { "cookieA", "value#A" },
                    { "cookieB", "value#B" }
                },
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "HCaptchaTask",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    isInvisible = target.Invisible,
                    data = target.Data,
                    userAgent = default(string),
                    cookies = "cookieA=value#A;cookieB=value#B",
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void RecaptchaV3EnterpriseRequest__ShouldSerialize()
        {
            // Arrange
            var target = new RecaptchaV3EnterpriseRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v3.php?level=beta",
                WebsiteKey = "6Le0xVgUAAAAAIt20XEB4rVhYOODgTl00d8juDob",
                MinScore = 0.6,
                PageAction = "some-action",
                NoCache = true
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "RecaptchaV3EnterpriseTask",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    minScore = target.MinScore,
                    pageAction = target.PageAction,
                    nocache = target.NoCache
                }));
        }

        [Test]
        public void RecaptchaV2EnterpriseRequest__ShouldSerialize([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new RecaptchaV2EnterpriseRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/recaptcha/v2_enterprise.php",
                WebsiteKey = "6Lcg7CMUAAAAANphynKgn9YAgA4tQ2KI_iqRyTwd",
                EnterprisePayload = "{\"s\":\"some-s-value\"}",
                DataSValue = "some data-s value",
                ApiDomain = "www.recaptcha.net",
                PageAction = "login",
                Cookies = new Dictionary<string, string>
                {
                    { "cookieA", "value#A" },
                    { "cookieB", "value#B" }
                },
                UserAgent = "PostmanRuntime/7.29.0",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "RecaptchaV2EnterpriseTask",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    enterprisePayload = target.EnterprisePayload,
                    recaptchaDataSValue = target.DataSValue,
                    apiDomain = target.ApiDomain,
                    pageAction = target.PageAction,
                    cookies = "cookieA=value#A;cookieB=value#B",
                    userAgent = target.UserAgent,
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void AmazonWafRequest__ShouldSerialize_ChallengeOnly([Values] ProxyType proxyType)
        {
            // Arrange: only the challenge variant, websiteKey/captchaScript/context/iv are optional in the API
            var target = new AmazonWafRequest
            {
                WebsiteUrl = "https://example.com/",
                ChallengeScript = "https://example.com/challenge.js",
                CookieSolution = true,
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "AmazonTask",
                    websiteURL = target.WebsiteUrl,
                    challengeScript = target.ChallengeScript,
                    cookieSolution = target.CookieSolution,
                    userAgent = default(string),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void TurnstileRequest__ShouldSerialize([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new TurnstileRequest
            {
                WebsiteUrl = "https://lessons.zennolab.com/captchas/turnstile",
                WebsiteKey = "0x4AAAAAAADnPIDROrmt1Wwj",
                CloudflareTaskType = "token",
                PageAction = "managed",
                Data = "some cData",
                PageData = "some chlPageData",
                HtmlPageBase64 = "aHRtbA==",
                UserAgent = "PostmanRuntime/7.29.0",
                ApiJsUrl = "https://challenges.cloudflare.com/turnstile/v0/api.js",
                Action = "managed",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "TurnstileTask",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    cloudflareTaskType = target.CloudflareTaskType,
                    pageAction = target.PageAction,
                    data = target.Data,
                    pageData = target.PageData,
                    htmlPageBase64 = target.HtmlPageBase64,
                    userAgent = target.UserAgent,
                    apiJsUrl = target.ApiJsUrl,
                    action = target.Action,
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void ProsopoTaskRequest__ShouldSerialize([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new ProsopoTaskRequest
            {
                WebsiteUrl = "https://example.com/",
                WebsiteKey = "5EZq7z1nBnKDpeNPz3sedVMqAXWMwc8FbSGhq7yLDYEr4W6H",
                UserAgent = "PostmanRuntime/7.29.0",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    type = "ProsopoTask",
                    websiteURL = target.WebsiteUrl,
                    websiteKey = target.WebsiteKey,
                    userAgent = target.UserAgent,
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void RecognitionComplexImageTaskRequest__ShouldSerialize_WithoutWebsiteUrl()
        {
            // Arrange: bills_audio needs PayloadType and does not need websiteURL
            var target = new RecognitionComplexImageTaskRequest
            {
                Metadata = new RecognitionComplexImageTaskRequest.RecognitionMetadata
                {
                    Task = "bills_audio",
                    PayloadType = "Audio"
                },
                ImagesBase64 = new List<string> { "UklGRnjuAwBXQVZFZm10" }
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    @class = "recognition",
                    metadata = new
                    {
                        Task = target.Metadata.Task,
                        TaskArgument = default(string),
                        PayloadType = target.Metadata.PayloadType
                    },
                    type = "ComplexImageTask",
                    imageUrls = default(List<string>),
                    imagesBase64 = target.ImagesBase64,
                    userAgent = default(string)
                }));
        }

        [Test]
        public void HuntCustomTaskRequest__ShouldSerialize_WidgetUrl([Values] ProxyType proxyType)
        {
            // Arrange: widgetUrl mode, data must not be sent
            var target = new HuntCustomTaskRequest(
                "https://example.com/hd-api/external/apps/a2157wab1045d68672a63557e0n2a77edbfd15ea/api.js",
                null,
                "https://captcha.example.com/widget?hash=1234")
            {
                WebsiteUrl = "https://example.com/login",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    @class = "Hunt",
                    type = "CustomTask",
                    websiteURL = target.WebsiteUrl,
                    metadata = new
                    {
                        apiGetLib = "https://example.com/hd-api/external/apps/a2157wab1045d68672a63557e0n2a77edbfd15ea/api.js",
                        data = default(string),
                        widgetUrl = "https://captcha.example.com/widget?hash=1234"
                    },
                    userAgent = default(string),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void AlibabaCustomTaskRequest__ShouldSerialize([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new AlibabaCustomTaskRequest(
                "1ww7426c4",
                "dlw3kug",
                userId: "user-id",
                userUserId: "user-user-id",
                verifyType: "verify-type",
                region: "cn",
                UserCertifyId: "certify-id",
                apiGetLib: "https://example.com/captcha.js",
                punishUrl: "https://example.com/_____tmd_____/punish?x5secdata=abc&x5step=2",
                cookieRequired: true)
            {
                WebsiteUrl = "https://example.com/",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    @class = "alibaba",
                    type = "CustomTask",
                    websiteURL = target.WebsiteUrl,
                    metadata = new
                    {
                        sceneId = "1ww7426c4",
                        prefix = "dlw3kug",
                        userId = "user-id",
                        userUserId = "user-user-id",
                        verifyType = "verify-type",
                        region = "cn",
                        UserCertifyId = "certify-id",
                        apiGetLib = "https://example.com/captcha.js",
                        punishUrl = "https://example.com/_____tmd_____/punish?x5secdata=abc&x5step=2",
                        cookieRequired = true
                    },
                    userAgent = default(string),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void ImpervaCustomTaskRequest__ShouldSerialize_WithoutReese84UrlEndpoint([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new ImpervaCustomTaskRequest("_Incapsula_Resource?SWJIYLWA=abc", "visid_incap_123=xyz; incap_ses_456=uvw")
            {
                WebsiteUrl = "https://example.com/",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    @class = "Imperva",
                    type = "CustomTask",
                    websiteURL = target.WebsiteUrl,
                    metadata = new
                    {
                        incapsulaScriptUrl = "_Incapsula_Resource?SWJIYLWA=abc",
                        incapsulaCookies = "visid_incap_123=xyz; incap_ses_456=uvw",
                        reese84UrlEndpoint = default(string)
                    },
                    userAgent = default(string),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void TenDiCustomTaskRequest__ShouldSerialize_WithoutCaptchaUrl([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new TenDiCustomTaskRequest
            {
                WebsiteKey = "189123456",
                WebsiteUrl = "https://example.com/",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    @class = "TenDI",
                    websiteKey = target.WebsiteKey,
                    type = "CustomTask",
                    websiteURL = target.WebsiteUrl,
                    metadata = new
                    {
                        captchaUrl = default(string),
                        aidEncrypted = default(string)
                    },
                    userAgent = default(string),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }

        [Test]
        public void TenDiCustomTaskRequest__ShouldSerialize_WithAidEncrypted([Values] ProxyType proxyType)
        {
            // Arrange
            var target = new TenDiCustomTaskRequest(
                captchaUrl: "https://global.captcha.example.com/TCaptcha-global.js",
                aidEncrypted: "YOUR_AID_ENCRYPTED")
            {
                WebsiteKey = "189123456",
                WebsiteUrl = "https://example.com/",
                Proxy = new ProxyContainer("proxy.com", 6045, proxyType, "login", "p@ssword")
            };

            // Act
            var actual = JsonConvert.SerializeObject(target);

            // Assert
            actual.Should().Be(JsonConvert.SerializeObject(
                new
                {
                    @class = "TenDI",
                    websiteKey = target.WebsiteKey,
                    type = "CustomTask",
                    websiteURL = target.WebsiteUrl,
                    metadata = new
                    {
                        captchaUrl = "https://global.captcha.example.com/TCaptcha-global.js",
                        aidEncrypted = "YOUR_AID_ENCRYPTED"
                    },
                    userAgent = default(string),
                    proxyAddress = target.ProxyAddress,
                    proxyPort = target.ProxyPort,
                    proxyType = proxyType.ToString().ToLower(),
                    proxyLogin = target.ProxyLogin,
                    proxyPassword = target.ProxyPassword
                }));
        }
    }
}

#pragma warning restore IDE0058 // Expression value is never used