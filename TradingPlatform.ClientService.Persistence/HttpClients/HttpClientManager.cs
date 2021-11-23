using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.ClientService.Domain.HttpInterfaces;
using TradingPlatform.ClientService.Persistence.Configurations;
using TradingPlatform.ClientService.Persistence.HttpClients;

namespace TradingPlatform.ClientService.Persistence.HttpClients
{
    public class HttpClientManager: IHttpClientManager
    {
        private readonly Lazy<ICategoryHttpClient> _lazyCategoryHttpClient;
        private readonly Lazy<IComplaintHttpClient> _lazyComplaintHttpClient;
        private readonly Lazy<IOrderHttpClient> _lazyOrderHttpClient;
        private readonly Lazy<IProductOrderHttpClient> _lazyProductOrderHttpClient;
        private readonly Lazy<IProductHttpClient> _lazyProductHttpClient;
        public HttpClientManager(IOptions<AppConfiguration> config, HttpClient client,ILogger<CategoryHttpClient> categoryLogger,
            ILogger<ComplaintHttpClient> complaintLogger, ILogger<OrderHttpClient> orderLogger, ILogger<ProductOrderHttpClient> productOrderLogger,
            ILogger<ProductHttpClient> productLogger)
        {
            _lazyCategoryHttpClient = new Lazy<ICategoryHttpClient>(() => new CategoryHttpClient(config, client, categoryLogger));
            _lazyComplaintHttpClient = new Lazy<IComplaintHttpClient>(() => new ComplaintHttpClient(config, client, complaintLogger));
            _lazyOrderHttpClient = new Lazy<IOrderHttpClient>(() => new OrderHttpClient(config, client, orderLogger));
            _lazyProductOrderHttpClient = new Lazy<IProductOrderHttpClient>(() => new ProductOrderHttpClient(config, client, productOrderLogger));
            _lazyProductHttpClient = new Lazy<IProductHttpClient>(() => new ProductHttpClient(config, client, productLogger));
        }
        public ICategoryHttpClient CategoryHttpClient => _lazyCategoryHttpClient.Value;
        public IComplaintHttpClient ComplaintHttpClient => _lazyComplaintHttpClient.Value;
        public IOrderHttpClient OrderHttpClient => _lazyOrderHttpClient.Value;
        public IProductOrderHttpClient ProductOrderHttpClient => _lazyProductOrderHttpClient.Value;
        public IProductHttpClient ProductHttpClient => _lazyProductHttpClient.Value;
    }
}
