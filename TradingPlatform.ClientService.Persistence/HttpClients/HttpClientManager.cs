using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Domain.Tokens;
using TradingPlatform.ClientService.Persistence.Configurations;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class HttpClientManager: IHttpClientManager
    {
        public HttpClientManager(IOptions<AppConfiguration> config, HttpClient client,ILoggerFactory loggerFactory, ITokenManager tokenManager, IHttpContextAccessor contextAccessor)
        {
            CategoryHttpClient = new CategoryHttpClient(config, client, loggerFactory, tokenManager, contextAccessor);
            ComplaintHttpClient = new ComplaintHttpClient(config, client, loggerFactory, tokenManager, contextAccessor);
            OrderHttpClient = new OrderHttpClient(config, client, loggerFactory, tokenManager, contextAccessor);
            ProductOrderHttpClient =  new ProductOrderHttpClient(config, client, loggerFactory, tokenManager, contextAccessor);
            ProductHttpClient =  new ProductHttpClient(config, client, loggerFactory, tokenManager, contextAccessor);
        }
        public ICategoryHttpClient CategoryHttpClient { get; init; } 
        public IComplaintHttpClient ComplaintHttpClient { get; init; }
        public IOrderHttpClient OrderHttpClient { get; init ; }
        public IProductOrderHttpClient ProductOrderHttpClient { get; init; }
        public IProductHttpClient ProductHttpClient { get; init; }
    }
}
