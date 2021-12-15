using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.ClientService.Services.Abstractions
{
    public interface IServiceManager
    {
        IHomeService HomeService { get; }
        IProductService ProductService { get; }
        ICategoryService CategoryService { get; }
        IOrderService OrderService { get; }
        ICartService CartService { get; }
    }
}
