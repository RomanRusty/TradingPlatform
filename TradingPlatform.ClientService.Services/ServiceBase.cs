using AutoMapper;
using Microsoft.AspNetCore.Http;
using TradingPlatform.ClientService.Domain.HttpInterfaces;

namespace TradingPlatform.ClientService.Services
{
    public abstract class ServiceBase
    {
        protected readonly IHttpClientManager _client;
        protected readonly IHttpContextAccessor _contextAccessor;
        protected readonly IMapper _mapper;

        protected ServiceBase(IHttpClientManager client, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _client = client;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
    }
}