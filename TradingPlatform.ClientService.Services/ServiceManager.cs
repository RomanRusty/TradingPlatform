using Microsoft.Extensions.Options;
using System;
using System.Net.Http;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.ClientService.Persistence.HttpClients;
using TradingPlatform.ClientService.Services.Abstractions;

namespace TradingPlatform.ClientService.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IHomeService> _lazyHomeService;
        public ServiceManager(IHttpClientManager httpClientManager)
        {
            _lazyHomeService = new Lazy<IHomeService>(() => new HomeService(httpClientManager));
        }
        public IHomeService HomeService => _lazyHomeService.Value;
    }
}