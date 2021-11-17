using ExampleWebApplication.Configurations;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TradingPlatform.ClientService.Services
{
    public abstract class ServiceBase
    {
        protected readonly HttpClient _client;
        public ServiceBase(IOptions<AppConfiguration> config, HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _client.BaseAddress = new Uri(config?.Value?.DatabaseApiUrl ?? throw new ArgumentNullException(nameof(config)));
        }
    }
}
