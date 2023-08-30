using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using NUnit.Framework;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public class IntegrationTests
    {
        [Test]
        public async Task GetBalance_ShouldReturn()
        {
            var clientKey = Gen.RandomApiKey();
            var balance = Gen.RandomDecimal();

            var captchaResults = new List<(RequestType Type, string ExpectedRequest)>
            {
                (
                    Type: RequestType.GetBalance,
                    ExpectedRequest: JsonConvert.SerializeObject(new { clientKey = clientKey })
                ),
            };

            var actualResponses = new List<object>
            {
                new { balance = balance, errorId = 0, errorCode = (string)null! },
            };

            var sut = new Sut().CreateSut(clientKey);
            sut.SetupHttpServer(actualResponses);

            var actual = await sut.GetBalanceAsync();

            sut.GetActualRequests().Should().BeEquivalentTo(captchaResults);
            actual.Should().Be(balance);
        }

        [Test]
        public async Task RecaptchaV2Proxyless_ShouldSolve()
        {
            var clientKey = Gen.RandomApiKey();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.RecaptchaV2Proxyless.CreateTask();
            var expectedResult = ObjectGen.RecaptchaV2Proxyless.CreateSolution();

            var expectedRequests = new List<(RequestType Type, string ExpectedRequest)>
            {
                (
                    Type: RequestType.CreateTask,
                    ExpectedRequest: JsonConvert.SerializeObject(new
                        { clientKey = clientKey, task = captchaRequest, softId = 53 })
                ),
                (
                    Type: RequestType.GetTaskResult,
                    ExpectedRequest: JsonConvert.SerializeObject(new { clientKey = clientKey, taskId = taskId })
                ),
            };

            var captchaResults = new List<object>
            {
                new { taskId = taskId, errorId = 0, errorCode = (string)null! },
                new
                {
                    status = "ready",
                    solution = new
                    {
                        gRecaptchaResponse = expectedResult.Solution.Value
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut().CreateSut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task HCaptchaProxyless_ShouldSolve()
        {
            var clientKey = Gen.RandomApiKey();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.HCaptchaProxyless.CreateTask();
            var expectedResult = ObjectGen.HCaptchaProxyless.CreateSolution();

            var expectedRequests = new List<(RequestType Type, string ExpectedRequest)>
            {
                (
                    Type: RequestType.CreateTask,
                    ExpectedRequest: JsonConvert.SerializeObject(new
                        { clientKey = clientKey, task = captchaRequest, softId = 53 })
                ),
                (
                    Type: RequestType.GetTaskResult,
                    ExpectedRequest: JsonConvert.SerializeObject(new { clientKey = clientKey, taskId = taskId })
                ),
            };

            var captchaResults = new List<object>
            {
                new { taskId = taskId, errorId = 0, errorCode = (string)null! },
                new
                {
                    status = "ready",
                    solution = new
                    {
                        gRecaptchaResponse = expectedResult.Solution.Value, respKey = expectedResult.Solution.RespKey,
                        userAgent = expectedResult.Solution.UserAgent, cookies = captchaRequest.Cookies,
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut().CreateSut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
    }
}