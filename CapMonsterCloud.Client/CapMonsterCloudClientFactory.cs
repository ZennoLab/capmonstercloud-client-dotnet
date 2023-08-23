using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Net.Http;
using System.Reflection;

namespace Zennolab.CapMonsterCloud
{
    /// <summary>
    /// Factory for <see cref="CapMonsterCloudClient"/>
    /// </summary>
    public class CapMonsterCloudClientFactory : ICapMonsterCloudClientFactory, IDisposable
    {
        private static readonly TimeSpan HttpTimeout = TimeSpan.FromSeconds(21);

        private static readonly ConcurrentDictionary<Uri, HttpClient> HttpClients = new ConcurrentDictionary<Uri, HttpClient>();

        private readonly ClientOptions _options;
        private readonly Func<HttpMessageHandler> _httpMessageHandlerFactory;
        private readonly Action<HttpClient> _configureClient;

        /// <summary>
        /// Creates new instance of factory
        /// </summary>
        /// <param name="options">client options</param>
        /// <param name="httpMessageHandlerFactory">optional HTTP message handler factory</param>
        /// <param name="configureClient">optional <see cref="HttpClient"/> configurator</param>
        public CapMonsterCloudClientFactory(
            ClientOptions options,
            Func<HttpMessageHandler> httpMessageHandlerFactory = null,
            Action<HttpClient> configureClient = null)
        {
            _options = options;
            _httpMessageHandlerFactory = httpMessageHandlerFactory;
            _configureClient = configureClient;
        }

        /// <inheritdoc/>
        public ICapMonsterCloudClient Create()
            => Create(_options, _httpMessageHandlerFactory, _configureClient);

        /// <summary>
        /// Creates instance of <see cref="CapMonsterCloudClient"/>
        /// </summary>
        /// <param name="options">client options</param>
        /// <returns>Instance of <see cref="CapMonsterCloudClient"/></returns>
        public static ICapMonsterCloudClient Create(ClientOptions options)
            => Create(options, httpMessageHandlerFactory: null, configureClient: null);

        private static ICapMonsterCloudClient Create(
            ClientOptions options,
            Func<HttpMessageHandler> httpMessageHandlerFactory,
            Action<HttpClient> configureClient)
            => new CapMonsterCloudClient(
                options,
                HttpClients.GetOrAdd(
                    options.ServiceUri,
                    uri => CreateHttpClient(uri, httpMessageHandlerFactory, configureClient)));

        private static HttpClient CreateHttpClient(
            Uri uri,
            Func<HttpMessageHandler> httpMessageHandlerFactory,
            Action<HttpClient> configureClient)
        {
            var handler = httpMessageHandlerFactory?.Invoke();

            var httpClient = handler != null
                ? new HttpClient(handler, true)
                : new HttpClient();

            httpClient.BaseAddress = uri;
            httpClient.Timeout = HttpTimeout;

            configureClient?.Invoke(httpClient);

            httpClient.DefaultRequestHeaders.UserAgent.TryParseAdd(CreateUserAgentString());

            return httpClient;
        }

        private static string CreateUserAgentString()
        {
            var fileVersionInfo = Assembly.GetExecutingAssembly().GetName();
            
            return $"{fileVersionInfo.Name}/{fileVersionInfo.Version}";
        }

        /// <inheritdoc/>
        public void Dispose()
        {
            var clients = HttpClients.Values.ToList();

            HttpClients.Clear();

            clients.ForEach(c => c.Dispose());
        }
    }
}
