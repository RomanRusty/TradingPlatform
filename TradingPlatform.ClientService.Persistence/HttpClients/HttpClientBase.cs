using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Persistence.Configurations;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public abstract class HttpClientBase
    {
        protected readonly HttpClient _client;
        public HttpClientBase(IOptions<AppConfiguration> config, HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri(config?.Value?.DatabaseApiUrl ?? throw new ArgumentNullException(nameof(config)));
        }
    }
}
