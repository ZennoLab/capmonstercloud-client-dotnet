using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;
using Zennolab.CapMonsterCloud;
using Zennolab.CapMonsterCloud.Responses;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public class HCaptchaProxylessTests
    {
        [Test]
        public async Task HCaptchaProxyless_ShouldSolve()
        {
            var clientKey = Gen.RandomApiKey();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.HCaptchaProxyless.CreateRequest();
            var captchaSolution = ObjectGen.HCaptchaProxyless.CreateResponse();

            var testData = new List<HttpRequestSettings>
            {
                new(
                    Type: RequestType.CreateTask,
                    ExpectedRequest: JsonConvert.SerializeObject(new
                    {
                        clientKey = clientKey,
                        task = captchaRequest,
                        softId = 53
                    }),
                    ActualResponse: new
                    {
                        taskId = taskId,
                        errorId = 0,
                        errorCode = (string)null!,
                    }),
                new(
                    Type: RequestType.GetTaskResult,
                    ExpectedRequest: JsonConvert.SerializeObject(new
                    {
                        clientKey = clientKey,
                        taskId = taskId
                    }),
                    ActualResponse: new
                    {
                        status = "ready",
                        solution = new
                        {
                            gRecaptchaResponse = captchaSolution.Value,
                            respKey = captchaSolution.RespKey,
                            userAgent = captchaSolution.UserAgent,
                            coockies = captchaRequest.Cookies,
                        },
                        errorId = 0,
                        errorCode = (string)null!,
                    })
            };

            var expectedRequests = testData.Select(r => (r.Type, r.ExpectedRequest)).ToList();
            var actualResponses = testData.Select(r => r.ActualResponse).ToList();

            var expectedResult = new CaptchaResult<HCaptchaResponse>
            {
                Error = null,
                Solution = captchaSolution
            };

            var sut = new Sut().CreatedSut(clientKey);
            sut.SetupHttpServer(actualResponses);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.actualRequests.Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
    }
}