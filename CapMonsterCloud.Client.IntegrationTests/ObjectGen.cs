using System.Linq;
using Zennolab.CapMonsterCloud;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public static class ObjectGen
    {
        public static class RecaptchaV2Proxyless
        {
            public static RecaptchaV2ProxylessRequest CreateTask()
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
        
        public static class HCaptchaProxyless
        {
            public static HCaptchaProxylessRequest CreateTask()
            {
                return new HCaptchaProxylessRequest
                {
                    WebsiteUrl = Gen.RandomUri().ToString(),
                    WebsiteKey = Gen.RandomGuid(),
                    Invisible = Gen.RandomBool(),
                    Data = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
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
    }
}