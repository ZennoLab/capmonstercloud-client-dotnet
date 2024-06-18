using System.Collections.Generic;
using System.Linq;
using Zennolab.CapMonsterCloud;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public static class ObjectGen
    {
        public static class ImageToText
        {
            public static ImageToTextRequest CreateTask(
                byte? recognizingThreshold = null)
            {
                return new ImageToTextRequest
                {
                    Body = Gen.RandomString(),
                    CapMonsterModule = Gen.RandomString(),
                    RecognizingThreshold = recognizingThreshold ?? (byte)Gen.RandomInt(0,100),
                    CaseSensitive = Gen.RandomBool(),
                    Numeric = Gen.RandomBool(),
                    Math = Gen.RandomBool()
                };
            }

            public static CaptchaResult<ImageToTextResponse> CreateSolution()
            {
                return new CaptchaResult<ImageToTextResponse>
                {
                    Error = null,
                    Solution = new ImageToTextResponse
                    {
                        Value = Gen.RandomString(),
                    }
                };
            }
        }
        
        public static class RecaptchaV2
        {
            public static RecaptchaV2Request CreateTask(
                string? websiteUrl = null,
                string? websiteKey = null,
                int? proxyPort = null)
            {
                return new RecaptchaV2Request
                {
                    WebsiteUrl = websiteUrl ?? Gen.RandomUri().ToString(),
                    WebsiteKey = websiteKey ?? Gen.RandomGuid(),
                    DataSValue = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
                    Cookies = Gen.ListOfValues(Gen.RandomString).ToDictionary(_ => Gen.RandomString(), value => value),
                    NoCache = Gen.RandomBool(),
                    ProxyType = Gen.RandomEnum<ProxyType>(),
                    ProxyAddress = Gen.RandomString(),
                    ProxyPort = proxyPort ?? Gen.RandomInt(0, 65535),
                    ProxyLogin = Gen.RandomString(),
                    ProxyPassword = Gen.RandomString()
                };
            }
            
            public static RecaptchaV2ProxylessRequest CreateProxylessTask()
            {
                return new RecaptchaV2ProxylessRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    DataSValue = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
                    Cookies = Gen.ListOfValues(Gen.RandomString).ToDictionary(_ => Gen.RandomString(), value => value),
                    NoCache = Gen.RandomBool()
                };
            }

            public static CaptchaResult<RecaptchaV2Response> CreateSolution()
            {
                return new CaptchaResult<RecaptchaV2Response>
                {
                    Error = null,
                    Solution = new RecaptchaV2Response
                    {
                        Value = Gen.RandomString(),
                    }
                };
            }
        }
        
        public static class RecaptchaV3Proxyless
        {
            public static RecaptchaV3ProxylessRequest CreateTask(
                double? minScore = null)
            {
                return new RecaptchaV3ProxylessRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    MinScore = minScore ?? Gen.RandomDouble(0.1, 0.9),
                    PageAction = Gen.RandomString(),
                    NoCache = Gen.RandomBool()
                };
            }

            public static CaptchaResult<RecaptchaV3Response> CreateSolution()
            {
                return new CaptchaResult<RecaptchaV3Response>
                {
                    Error = null,
                    Solution = new RecaptchaV3Response
                    {
                        Value = Gen.RandomString(),
                    }
                };
            }
        }
        
        public static class FunCaptcha
        {
            public static FunCaptchaRequest CreateTask()
            {
                return new FunCaptchaRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    Subdomain = Gen.RandomString(),
                    Data = Gen.RandomString(),
                    NoCache = Gen.RandomBool(),
                    ProxyType = Gen.RandomEnum<ProxyType>(),
                    ProxyAddress = Gen.RandomString(),
                    ProxyPort = Gen.RandomInt(0, 65535),
                    ProxyLogin = Gen.RandomString(),
                    ProxyPassword = Gen.RandomString()
                };
            }
            
            public static FunCaptchaProxylessRequest CreateProxylessTask()
            {
                return new FunCaptchaProxylessRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    Subdomain = Gen.RandomString(),
                    Data = Gen.RandomString(),
                    NoCache = Gen.RandomBool()
                };
            }

            public static CaptchaResult<FunCaptchaResponse> CreateSolution()
            {
                return new CaptchaResult<FunCaptchaResponse>
                {
                    Error = null,
                    Solution = new FunCaptchaResponse
                    {
                        Value = Gen.RandomString(),
                    }
                };
            }
        }
        
        public static class HCaptcha
        {
            public static HCaptchaRequest CreateHCaptchaTask()
            {
                return new HCaptchaRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    Invisible = Gen.RandomBool(),
                    Data = Gen.RandomString(),
#pragma warning disable CS0618
                    UserAgent = Gen.UserAgent(),
#pragma warning restore CS0618
                    FallbackToActualUA = Gen.RandomBool(),
                    Cookies = Gen.ListOfValues(Gen.RandomString).ToDictionary(_ => Gen.RandomString(), value => value),
                    NoCache = Gen.RandomBool(),
                    ProxyType = Gen.RandomEnum<ProxyType>(),
                    ProxyAddress = Gen.RandomString(),
                    ProxyPort = Gen.RandomInt(0, 65535),
                    ProxyLogin = Gen.RandomString(),
                    ProxyPassword = Gen.RandomString()
                };
            }

            public static HCaptchaProxylessRequest CreateHCaptchaProxylessTask()
            {
                return new HCaptchaProxylessRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    Invisible = Gen.RandomBool(),
                    Data = Gen.RandomString(),
#pragma warning disable CS0618
                    UserAgent = Gen.UserAgent(),
#pragma warning restore CS0618
                    FallbackToActualUA = Gen.RandomBool(),
                    Cookies = Gen.ListOfValues(Gen.RandomString).ToDictionary(_ => Gen.RandomString(), value => value),
                    NoCache = Gen.RandomBool()
                };
            }

            public static CaptchaResult<HCaptchaResponse> CreateSolution()
            {
                return new CaptchaResult<HCaptchaResponse>
                {
                    Error = null,
                    Solution = new HCaptchaResponse
                    {
                        RespKey = Gen.RandomString(),
                        UserAgent = Gen.UserAgent(),
                        Value = Gen.RandomString(),
                    }
                };
            }
        }
        
        public static class GeeTest
        {
            public static GeeTestRequest CreateTask(
                string? gt = null)
            {
                return new GeeTestRequest()
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    Gt = gt ?? Gen.RandomString(),
                    Version = Gen.RandomInt(3, 4),
                    InitParameters = new { riskType = "slide" },
                    Challenge = Gen.RandomString(),
                    Subdomain = Gen.RandomString(),
                    GetLib = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
                    ProxyType = Gen.RandomEnum<ProxyType>(),
                    ProxyAddress = Gen.RandomString(),
                    ProxyPort = Gen.RandomInt(0, 65535),
                    ProxyLogin = Gen.RandomString(),
                    ProxyPassword = Gen.RandomString()
                };
            }
            
            public static GeeTestProxylessRequest CreateProxylessTask()
            {
                return new GeeTestProxylessRequest()
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    Gt = Gen.RandomString(),
                    Version = Gen.RandomInt(3, 4),
                    InitParameters = new { riskType = "slide" },
                    Challenge = Gen.RandomString(),
                    Subdomain = Gen.RandomString(),
                    GetLib = Gen.RandomString(),
                    UserAgent = Gen.UserAgent()
                };
            }

            public static CaptchaResult<GeeTestResponse> CreateSolution()
            {
                return new CaptchaResult<GeeTestResponse>
                {
                    Error = null,
                    Solution = new GeeTestResponse
                    {
                        Challenge = Gen.RandomString(),
                        Validate = Gen.RandomString(),
                        SecCode = Gen.RandomString(),
                        CaptchaId = Gen.RandomString(),
                        LotNumber = Gen.RandomString(),
                        PassToken = Gen.RandomString(),
                        GenTime = Gen.RandomString(),
                        CaptchaOutput = Gen.RandomString()
                    }
                };
            }
        }
        
        public static class RecaptchaV2Enterprise
        {
            public static RecaptchaV2EnterpriseRequest CreateTask()
            {
                return new RecaptchaV2EnterpriseRequest()
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomString(),
                    EnterprisePayload = Gen.RandomString(),
                    DataSValue = Gen.RandomString(),
                    ProxyType = Gen.RandomEnum<ProxyType>(),
                    ProxyAddress = Gen.RandomString(),
                    ProxyPort = Gen.RandomInt(0, 65535),
                    ProxyLogin = Gen.RandomString(),
                    ProxyPassword = Gen.RandomString()
                };
            }
            
            public static RecaptchaV2EnterpriseProxylessRequest CreateProxylessTask()
            {
                return new RecaptchaV2EnterpriseProxylessRequest()
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomString(),
                    EnterprisePayload = Gen.RandomString(),
                    DataSValue = Gen.RandomString()
                };
            }

            public static CaptchaResult<RecaptchaV2EnterpriseResponse> CreateSolution()
            {
                return new CaptchaResult<RecaptchaV2EnterpriseResponse>
                {
                    Error = null,
                    Solution = new RecaptchaV2EnterpriseResponse
                    {
                        Value = Gen.RandomString()
                    }
                };
            }
        }
            
        public static class TurnstileProxyless
        {
            public static TurnstileProxylessRequest CreateTask()
            {
                return new TurnstileProxylessRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    CloudflareTaskType = Gen.RandomString(),
                    PageAction = Gen.RandomString(),
                    Data = Gen.RandomString(),
                    PageData = Gen.RandomString(),
                    HtmlPageBase64 = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
                    NoCache = Gen.RandomBool()
                };
            }

            public static CaptchaResult<TurnstileResponse> CreateSolution()
            {
                return new CaptchaResult<TurnstileResponse>
                {
                    Error = null,
                    Solution = new TurnstileResponse
                    {
                        Value = Gen.RandomString(),
                        Clearance = Gen.RandomString()
                    }
                };
            }
        }
        
        public static class ComplexImageTask
        {
            public static RecaptchaComplexImageTaskRequest CreateRecaptchaComplexImageTask()
            {
                return new RecaptchaComplexImageTaskRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    Metadata = new RecaptchaComplexImageTaskRequest.RecaptchaMetadata()
                    {
                        Grid = Gen.RandomEnum<RecaptchaComplexImageTaskRequest.RecaptchaMetadata.GridSize>(),
                        Task = Gen.RandomString(),
                        TaskDefinition = Gen.RandomString()
                    },
                    ImageUrls = Gen.ListOfValues(Gen.RandomUri().ToString),
                    ImagesBase64 = Gen.ListOfValues(Gen.RandomString),
                    UserAgent = Gen.UserAgent()
                };
            }
            
            public static HCaptchaComplexImageTaskRequest CreateHCaptchaComplexImageTask()
            {
                return new HCaptchaComplexImageTaskRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    Metadata = new HCaptchaComplexImageTaskRequest.HCaptchaMetadata()
                    {
                        Task = Gen.RandomString(),
                    },
                    ImageUrls = Gen.ListOfValues(Gen.RandomUri().ToString),
                    ImagesBase64 = Gen.ListOfValues(Gen.RandomString),
                    ExampleImageUrls = Gen.ListOfValues(Gen.RandomUri().ToString),
                    ExampleImagesBase64 = Gen.ListOfValues(Gen.RandomString),
                    UserAgent = Gen.UserAgent()
                };
            }
            
            public static FunCaptchaComplexImageTaskRequest CreateFunCaptchaComplexImageTask()
            {
                return new FunCaptchaComplexImageTaskRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    Metadata = new FunCaptchaComplexImageTaskRequest.FunCaptchaMetadata()
                    {
                        Task = Gen.RandomString(),
                    },
                    ImageUrls = Gen.ListOfValues(Gen.RandomUri().ToString),
                    ImagesBase64 = Gen.ListOfValues(Gen.RandomString),
                    UserAgent = Gen.UserAgent()
                };
            }

            public static CaptchaResult<GridComplexImageTaskResponse> CreateSolution()
            {
                return new CaptchaResult<GridComplexImageTaskResponse>
                {
                    Error = null,
                    Solution = new GridComplexImageTaskResponse
                    {
                        Answer = Gen.ListOfValues(Gen.RandomBool),
                    }
                };
            }
        }

        public static class CustomTask
        {
            public static DataDomeCustomTaskRequest CreateDataDomeTask()
            {
                return new DataDomeCustomTaskRequest(Gen.RandomString(), Gen.RandomUri().ToString(), Gen.RandomString())
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    UserAgent = Gen.UserAgent(),
                    Domains = Gen.ListOfValues(Gen.RandomString),
                    ProxyType = Gen.RandomEnum<ProxyType>(),
                    ProxyAddress = Gen.RandomString(),
                    ProxyPort = Gen.RandomInt(0, 65535),
                    ProxyLogin = Gen.RandomString(),
                    ProxyPassword = Gen.RandomString()
                };
            }

            public static DataDomeCustomTaskProxylessRequest CreateDataDomeProxylessTask()
            {
                return new DataDomeCustomTaskProxylessRequest(Gen.RandomString(), Gen.RandomUri().ToString(), Gen.RandomString())
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    UserAgent = Gen.UserAgent(),
                    Domains = Gen.ListOfValues(Gen.RandomString)
                };
            }

            public static CaptchaResult<CustomTaskResponse> CreateSolution()
            {
                return new CaptchaResult<CustomTaskResponse>
                {
                    Error = null,
                    Solution = new CustomTaskResponse
                    {
                        Domains = new Dictionary<string, CustomTaskResponse.DomainInfo>
                        {
                            {
                                Gen.RandomString(),
                                new CustomTaskResponse.DomainInfo()
                                {
                                    Cookies = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } },
                                    LocalStorage = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } }
                                }
                            },
                        },
                        Url = Gen.RandomUri().ToString(),
                        Fingerprint = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } },
                        Headers = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } }
                    }
                };
            }
        }

        public static class AmazonWaf
        {
            public static AmazonWafRequest CreateTask()
            {
                return new AmazonWafRequest()
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    CaptchaScript = Gen.RandomString(),
                    ChallengeScript = Gen.RandomString(),
                    Context = Gen.RandomString(),
                    Iv = Gen.RandomString(),
                    CookieSolution = Gen.RandomBool(),
                    ProxyType = Gen.RandomEnum<ProxyType>(),
                    ProxyAddress = Gen.RandomString(),
                    ProxyPort = Gen.RandomInt(0, 65535),
                    ProxyLogin = Gen.RandomString(),
                    ProxyPassword = Gen.RandomString()
                };
            }

            public static CaptchaResult<AmazonWafResponse> CreateSolution()
            {
                return new CaptchaResult<AmazonWafResponse>
                {
                    Error = null,
                    Solution = new AmazonWafResponse
                    {
                        CaptchaVoucher = Gen.RandomString(),
                        ExistingToken = Gen.RandomString(),
                        UserAgent = Gen.UserAgent(),
                        Cookies = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } }
                    }
                };
            }
        }

        public static class AmazonWafProxyless
        {
            public static AmazonWafProxylessRequest CreateTask()
            {
                return new AmazonWafProxylessRequest()
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    CaptchaScript = Gen.RandomString(),
                    ChallengeScript = Gen.RandomString(),
                    Context = Gen.RandomString(),
                    Iv = Gen.RandomString(),
                    CookieSolution = Gen.RandomBool()
                };
            }

            public static CaptchaResult<AmazonWafResponse> CreateSolution()
            {
                return new CaptchaResult<AmazonWafResponse>
                {
                    Error = null,
                    Solution = new AmazonWafResponse
                    {
                        CaptchaVoucher = Gen.RandomString(),
                        ExistingToken = Gen.RandomString(),
                        UserAgent = Gen.UserAgent(),
                        Cookies = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } }
                    }
                };
            }
        }
    }
}