using System.Net;
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
        private ICapMonsterCloudClient cloudClient;

        public List<(RequestType, string)> actualRequests = new();

        public Sut CreatedSut(string clientKey)
        {
            var clientOptions = new ClientOptions
            {
                ServiceUri = Gen.RandomUri(),
                ClientKey = clientKey
            };

            httpMessageHandler = new Mock<HttpMessageHandler>(MockBehavior.Strict);
            var httpClient = httpMessageHandler.CreateClient();

            cloudClient = CapMonsterCloudClientFactory.Create(
                clientOptions,
                () => httpMessageHandler.Object,
                (_) =>
                {
                    httpMessageHandler.CreateClient();
                    httpClient.BaseAddress = clientOptions.ServiceUri;
                });

            return this;
        }

        public async Task<CaptchaResult<HCaptchaResponse>> SolveAsync(
            HCaptchaProxylessRequest request)
        {
            return await cloudClient.SolveAsync(request, default);
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

            actualRequests.Add(new(type, requestStringContent));

            return true;
        }
    }
}