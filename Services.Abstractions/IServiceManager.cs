using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradingPlatform.DatabaseService.Services.Abstractions
{
    public interface IServiceManager
    {
        ICategoryService CategoryService { get; }
        IComplaintService ComplaintService { get; }
        IOrderService OrderService { get; }
        IProductOrderService ProductOrderService { get; }
        IProductService ProductService { get; }
    }
}
