using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public static class ObjectGen
    {
        public static class HCaptchaProxyless
        {
            public static HCaptchaProxylessRequest CreateRequest()
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

            public static HCaptchaResponse CreateResponse()
            {
                return new HCaptchaResponse
                {
                    RespKey = Gen.RandomString(),
                    UserAgent = Gen.UserAgent(),
                    Value = Gen.RandomString(),
                };
            }
        }
    }
}