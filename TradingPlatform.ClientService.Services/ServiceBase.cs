using System;
using System.Collections.Generic;
using System.Linq;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.HttpClients;

namespace TradingPlatform.ClientService.Services
{
    public abstract class ServiceBase
    {
        protected readonly IHttpClientManager _client;
        protected ServiceBase(IHttpClientManager client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }
    }
}