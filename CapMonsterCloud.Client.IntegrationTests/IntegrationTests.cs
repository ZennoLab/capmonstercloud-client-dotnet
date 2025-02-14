using System;
using System.Collections.Generic;
using System.Linq;
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
            var clientKey = Gen.RandomString();
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

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(actualResponses);

            var actual = await sut.GetBalanceAsync();

            sut.GetActualRequests().Should().BeEquivalentTo(captchaResults);
            actual.Should().Be(balance);
        }
        
        [Test]
        public async Task ImageToText_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.ImageToText.CreateTask();
            var expectedResult = ObjectGen.ImageToText.CreateSolution();

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
                        text = expectedResult.Solution.Value
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        public async Task RecaptchaV2_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.RecaptchaV2.CreateTask();
            var expectedResult = ObjectGen.RecaptchaV2.CreateSolution();

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

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        public async Task RecaptchaV2Enterprise_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.RecaptchaV2Enterprise.CreateTask();
            var expectedResult = ObjectGen.RecaptchaV2Enterprise.CreateSolution();

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

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        public async Task RecaptchaV3Proxyless_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.RecaptchaV3Proxyless.CreateTask();
            var expectedResult = ObjectGen.RecaptchaV3Proxyless.CreateSolution();

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

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        public async Task FunCaptcha_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.FunCaptcha.CreateTask();
            var expectedResult = ObjectGen.FunCaptcha.CreateSolution();

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
                        token = expectedResult.Solution.Value
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        public async Task HCaptcha_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.HCaptcha.CreateHCaptchaTask();
            var expectedResult = ObjectGen.HCaptcha.CreateSolution();

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
                        respKey = expectedResult.Solution.RespKey,
                        userAgent = expectedResult.Solution.UserAgent,
                        gRecaptchaResponse = expectedResult.Solution.Value
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        public async Task GeeTest_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.GeeTest.CreateTask();
            var expectedResult = ObjectGen.GeeTest.CreateSolution();

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
                        challenge = expectedResult.Solution.Challenge,
                        validate = expectedResult.Solution.Validate,
                        seccode = expectedResult.Solution.SecCode,
                        captcha_id = expectedResult.Solution.CaptchaId,
                        lot_number = expectedResult.Solution.LotNumber,
                        pass_token = expectedResult.Solution.PassToken,
                        gen_time = expectedResult.Solution.GenTime,
                        captcha_output = expectedResult.Solution.CaptchaOutput
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task Turnstile_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.Turnstile.CreateTask();
            var expectedResult = ObjectGen.Turnstile.CreateSolution();

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
                        token = expectedResult.Solution.Value,
                        cf_clearance = expectedResult.Solution.Clearance
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task DataDome_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.CustomTask.CreateDataDomeTask();
            var expectedResult = ObjectGen.CustomTask.CreateDataDomeSolution();

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
                        domains = expectedResult.Solution.Domains,
                        url = expectedResult.Solution.Url,
                        fingerprint = expectedResult.Solution.Fingerprint,
                        headers = expectedResult.Solution.Headers
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task Imperva_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.CustomTask.CreateImpervaTask();
            var expectedResult = ObjectGen.CustomTask.CreateImpervaSolution();

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
                        domains = expectedResult.Solution.Domains
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task RecaptchaComplexImageTask_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.ComplexImageTask.CreateRecaptchaComplexImageTask();
            var expectedResult = ObjectGen.ComplexImageTask.CreateSolution();

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
                        answer = expectedResult.Solution.Answer
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }      
        
        [Test]
        public async Task HCaptchaComplexImageTask_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.ComplexImageTask.CreateHCaptchaComplexImageTask();
            var expectedResult = ObjectGen.ComplexImageTask.CreateSolution();

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
                        answer = expectedResult.Solution.Answer
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }   
        
        [Test]
        public async Task FunCaptchaComplexImageTask_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.ComplexImageTask.CreateFunCaptchaComplexImageTask();
            var expectedResult = ObjectGen.ComplexImageTask.CreateSolution();

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
                        answer = expectedResult.Solution.Answer
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
        
        [Test]
        public async Task RecaptchaV2_IncorrectWebsiteUrl_ShouldThrowValidationException()
        {
            var clientKey = Gen.RandomString();
            var captchaRequest = ObjectGen.RecaptchaV2.CreateTask(
                websiteUrl: "incorrect url");

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(new List<object>());

            Func<Task> actual = () => sut.SolveAsync(captchaRequest);
            
            await actual.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The WebsiteUrl field is not a valid fully-qualified*URL*");
        }
        
        [Test]
        public async Task RecaptchaV2_IncorrectWebsiteKey_ShouldThrowValidationException()
        {
            var clientKey = Gen.RandomString();
            var captchaRequest = ObjectGen.RecaptchaV2.CreateTask(
                websiteKey: string.Empty);
            
            var sut = new Sut(clientKey);
            sut.SetupHttpServer(new List<object>());

            Func<Task> actual = () => sut.SolveAsync(captchaRequest);
            
            _ = await actual.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field WebsiteKey must be a string with a minimum length of 1*");
        }
        
        [Test]
        public async Task RecaptchaV2_IncorrectProxyPort_ShouldThrowArgumentException()
        {
            Action actual = () => ObjectGen.RecaptchaV2.CreateTask(
                proxyPort: Gen.RandomInt(65535));

            _ = actual.Should().Throw<ArgumentException>()
                .WithMessage("*Proxy port must be between 0 and 65535*");
        }
        
        [Test]
        public async Task RecaptchaV3Proxyless_IncorrectMinScore_ShouldThrowValidationException()
        {
            var clientKey = Gen.RandomString();
            var captchaRequest = ObjectGen.RecaptchaV3Proxyless.CreateTask(
                minScore: Gen.RandomBool() ? Gen.RandomDouble(0, 0.09) : Gen.RandomDouble(0.91, 1.5));
            
            var sut = new Sut(clientKey);
            sut.SetupHttpServer(new List<object>());

            Func<Task> actual = () => sut.SolveAsync(captchaRequest);
            
            _ = await actual.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field MinScore must be between 0?1 and 0?9*");
        }
        
        [Test]
        public async Task ImageToTextRequest_IncorrectRecognizingThreshold_ShouldThrowValidationException()
        {
            var clientKey = Gen.RandomString();
            var captchaRequest = ObjectGen.ImageToText.CreateTask(
                recognizingThreshold: Convert.ToByte(Gen.RandomInt(101, 150)));

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(new List<object>());

            Func<Task> actual = () => sut.SolveAsync(captchaRequest);
            
            _ = await actual.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field RecognizingThreshold must be between 0 and 100*");
        }
        
        [Test]
        public async Task GeeTest_IncorrectGt_ShouldThrowValidationException()
        {
            var clientKey = Gen.RandomString();
            var captchaRequest = ObjectGen.GeeTest.CreateTask(
                gt: string.Empty);
            
            var sut = new Sut(clientKey);
            sut.SetupHttpServer(new List<object>());

            Func<Task> actual = () => sut.SolveAsync(captchaRequest);
            
            _ = await actual.Should().ThrowAsync<System.ComponentModel.DataAnnotations.ValidationException>()
                .WithMessage("*The field Gt must be a string with a minimum length of 1*");
        }

        [Test]
        public async Task AmazonWaf_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.AmazonWaf.CreateTask();
            var expectedResult = ObjectGen.AmazonWaf.CreateSolution();

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
                        existing_token = expectedResult.Solution.ExistingToken,
                        captcha_voucher = expectedResult.Solution.CaptchaVoucher,
                        userAgent = expectedResult.Solution.UserAgent,
                        cookies = expectedResult.Solution.Cookies
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task TenDi_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.CustomTask.CreateTenDiTask();
            var expectedResult = ObjectGen.CustomTask.CreateTenDiSolution();

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
                        data = expectedResult.Solution.Data,
                        headers = expectedResult.Solution.Headers
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task Basilisk_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.CustomTask.CreateBasiliskTask();
            var expectedResult = ObjectGen.CustomTask.CreateBasiliskSolution();

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
                        data = expectedResult.Solution.Data,
                        headers = expectedResult.Solution.Headers
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }

        [Test]
        public async Task Binance_ShouldSolve()
        {
            var clientKey = Gen.RandomString();
            var taskId = Gen.RandomInt();

            var captchaRequest = ObjectGen.BinanceTask.CreateTask();
            var expectedResult = ObjectGen.BinanceTask.CreateSolution();

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
                        token = expectedResult.Solution.Value,
                        userAgent = expectedResult.Solution.UserAgent,
                        cookies = expectedResult.Solution.Cookies
                    },
                    errorId = 0,
                    errorCode = (string)null!
                }
            };

            var sut = new Sut(clientKey);
            sut.SetupHttpServer(captchaResults);

            var actual = await sut.SolveAsync(captchaRequest);

            sut.GetActualRequests().Should().BeEquivalentTo(expectedRequests);
            actual.Should().BeEquivalentTo(expectedResult);
        }
    }
}