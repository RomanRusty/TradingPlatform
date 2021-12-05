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
        //private readonly Lazy<ICategoryHttpClient> _lazyCategoryHttpClient;
        //private readonly Lazy<IComplaintHttpClient> _lazyComplaintHttpClient;
        //private readonly Lazy<IOrderHttpClient> _lazyOrderHttpClient;
        //private readonly Lazy<IProductOrderHttpClient> _lazyProductOrderHttpClient;
        //private readonly Lazy<IProductHttpClient> _lazyProductHttpClient;
        public HttpClientManager(IOptions<AppConfiguration> config, HttpClient client,ILogger<CategoryHttpClient> categoryLogger,
            ILogger<ComplaintHttpClient> complaintLogger, ILogger<OrderHttpClient> orderLogger, ILogger<ProductOrderHttpClient> productOrderLogger,
            ILogger<ProductHttpClient> productLogger)
        {
            CategoryHttpClient = new CategoryHttpClient(config, client, categoryLogger);
            ComplaintHttpClient = new ComplaintHttpClient(config, client, complaintLogger);
            OrderHttpClient = new OrderHttpClient(config, client, orderLogger);
            ProductOrderHttpClient =  new ProductOrderHttpClient(config, client, productOrderLogger);
            ProductHttpClient =  new ProductHttpClient(config, client, productLogger);
        }
        public ICategoryHttpClient CategoryHttpClient { get; private set; } 
        public IComplaintHttpClient ComplaintHttpClient { get; private set; }
        public IOrderHttpClient OrderHttpClient { get; private set; }
        public IProductOrderHttpClient ProductOrderHttpClient { get; private set; }
        public IProductHttpClient ProductHttpClient { get; private set; }
    }
}
