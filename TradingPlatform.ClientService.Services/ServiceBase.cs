using Microsoft.AspNetCore.Http;
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
        protected readonly IHttpContextAccessor _contextAccessor;
        protected ServiceBase(IHttpClientManager client, IHttpContextAccessor contextAccessor)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _contextAccessor= contextAccessor ?? throw new ArgumentNullException(nameof(_contextAccessor));
        }
    }
}