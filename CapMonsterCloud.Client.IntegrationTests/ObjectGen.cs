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
                    Proxy = new ProxyContainer(Gen.RandomString(), proxyPort ?? Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
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
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
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
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
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
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
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
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
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
            
        public static class Turnstile
        {
            public static TurnstileRequest CreateTask()
            {
                return new TurnstileRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    CloudflareTaskType = Gen.RandomString(),
                    PageAction = Gen.RandomString(),
                    Data = Gen.RandomString(),
                    PageData = Gen.RandomString(),
                    HtmlPageBase64 = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
                    ApiJsUrl = Gen.RandomUri().ToString(),
                    NoCache = Gen.RandomBool(),
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
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


            public static RecognitionComplexImageTaskRequest CreateRecognitionComplexImageTask()
            {
                return new RecognitionComplexImageTaskRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    Metadata = new RecognitionComplexImageTaskRequest.RecognitionMetadata
                    {
                        Task = Gen.RandomString(),
                        TaskArgument = Gen.RandomString()
                    },
                    ImageUrls = Gen.ListOfValues(Gen.RandomUri().ToString),
                    ImagesBase64 = Gen.ListOfValues(Gen.RandomString),
                    UserAgent = Gen.UserAgent()
                };
            }

            public static CaptchaResult<GridComplexImageTaskResponse> CreateGridComplexImageTaskSolution()
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

            public static CaptchaResult<DynamicComplexImageTaskResponse> CreateDynamicComplexImageTaskSolutionWithGridAnswer()
            {
                return new CaptchaResult<DynamicComplexImageTaskResponse>
                {
                    Error = null,
                    Solution = new DynamicComplexImageTaskResponse
                    {
                        Answer = new RecognitionAnswer{ GridAnswer = Gen.ArrayOfValues(Gen.RandomBool) },
                        Metadata = new DynamicComplexImageTaskResponse.RecognitionMetadata { AnswerType = "Grid" }
                    }
                };
            }

            public static CaptchaResult<DynamicComplexImageTaskResponse> CreateDynamicComplexImageTaskSolutionWithNumericAnswer()
            {
                return new CaptchaResult<DynamicComplexImageTaskResponse>
                {
                    Error = null,
                    Solution = new DynamicComplexImageTaskResponse
                    {
                        Answer = new RecognitionAnswer { NumericAnswer = Gen.ArrayOfValues(Gen.RandomDecimal) },
                        Metadata = new DynamicComplexImageTaskResponse.RecognitionMetadata { AnswerType = "NumericArray" }
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
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
                };
            }

            public static CaptchaResult<CustomTaskResponse> CreateDataDomeSolution()
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

            public static TenDiCustomTaskRequest CreateTenDiTask()
            {
                return new TenDiCustomTaskRequest
                {
                    WebsiteKey = Gen.RandomGuid(),
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    UserAgent = Gen.UserAgent(),
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
                };
            }

            public static CaptchaResult<CustomTaskResponse> CreateTenDiSolution()
            {
                return new CaptchaResult<CustomTaskResponse>
                {
                    Error = null,
                    Solution = new CustomTaskResponse
                    {
                        Headers = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } },
                        Data = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } }
                    }
                };
            }

            public static BasiliskCustomTaskRequest CreateBasiliskTask()
            {
                return new BasiliskCustomTaskRequest
                {
                    WebsiteKey = Gen.RandomGuid(),
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    UserAgent = Gen.UserAgent(),
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
                };
            }

            public static CaptchaResult<CustomTaskResponse> CreateBasiliskSolution()
            {
                return new CaptchaResult<CustomTaskResponse>
                {
                    Error = null,
                    Solution = new CustomTaskResponse
                    {
                        Headers = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } },
                        Data = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } }
                    }
                };
            }

            public static ImpervaCustomTaskRequest CreateImpervaTask()
            {
                return new ImpervaCustomTaskRequest(Gen.RandomString(), Gen.RandomString(), Gen.RandomString())
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    UserAgent = Gen.UserAgent(),
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
                };
            }

            public static CaptchaResult<CustomTaskResponse> CreateImpervaSolution()
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
                                }
                            }
                        }
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
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
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

        public static class BinanceTask
        {
            public static BinanceTaskRequest CreateTask()
            {
                return new BinanceTaskRequest()
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    ValidateId = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
                    Proxy = new ProxyContainer(Gen.RandomString(), Gen.RandomInt(0, 65535), Gen.RandomEnum<ProxyType>(), Gen.RandomString(), Gen.RandomString())
                };
            }

            public static CaptchaResult<BinanceTaskResponse> CreateSolution()
            {
                return new CaptchaResult<BinanceTaskResponse>
                {
                    Error = null,
                    Solution = new BinanceTaskResponse
                    {
                        Value = Gen.RandomString(),
                        UserAgent = Gen.UserAgent(),
                        Cookies = new Dictionary<string, string> { { Gen.RandomString(), Gen.RandomString() } }
                    }
                };
            }
        }
    }
}