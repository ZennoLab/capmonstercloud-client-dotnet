using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Moq;
using Moq.Contrib.HttpClient;
using Moq.Protected;
using Newtonsoft.Json;
using Zennolab.CapMonsterCloud;
using Zennolab.CapMonsterCloud.Requests;
using Zennolab.CapMonsterCloud.Responses;

namespace CapMonsterCloud.Client.IntegrationTests
{
    public class Sut
    {
        private Mock<HttpMessageHandler> httpMessageHandler;
        private ICapMonsterCloudClient _cloudClient;
        private List<(RequestType, string)> _actualRequests = new();

        public Sut CreateSut(string clientKey)
        {
            var clientOptions = new ClientOptions
            {
                ServiceUri = Gen.RandomUri(),
                ClientKey = clientKey
            };

            httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var httpClient = httpMessageHandler.CreateClient();

            var cloudClientFactory = new CapMonsterCloudClientFactory(
                clientOptions,
                () => httpMessageHandler.Object,
                (_) =>
                {
                    httpMessageHandler.CreateClient();
                    httpClient.BaseAddress = clientOptions.ServiceUri;
                });

            _cloudClient = cloudClientFactory.Create();
                
            return this;
        }

        public async Task<CaptchaResult<RecaptchaV2Response>> SolveAsync (
            RecaptchaV2ProxylessRequest request) => await _cloudClient.SolveAsync(request);
        
        public async Task<CaptchaResult<HCaptchaResponse>> SolveAsync (
            HCaptchaProxylessRequest request) => await _cloudClient.SolveAsync(request);

        public async Task<decimal> GetBalanceAsync()
        {
            return await _cloudClient.GetBalanceAsync();
        }

        public List<(RequestType, string)> GetActualRequests()
        {
            return _actualRequests;
        }

        public void SetupHttpServer(
            List<object> expectedResponses)
        {
            var part = httpMessageHandler
                .Protected()
                .SetupSequence<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(request => SaveRequest(request)),
                    ItExpr.IsAny<CancellationToken>()
                );

            foreach (var item in expectedResponses)
            {
                part.ReturnsResponse(HttpStatusCode.OK, new StringContent(JsonConvert.SerializeObject(item)));
            }
        }

        private bool SaveRequest(HttpRequestMessage request)
        {
            var path = request.RequestUri.GetComponents(UriComponents.Path, UriFormat.Unescaped);
            var type = (RequestType)Enum.Parse(typeof(RequestType), path, true);

            var requestStringContent = request.Content.ReadAsStringAsync().Result;

            _actualRequests.Add(new(type, requestStringContent));

            return true;
        }
    }
}