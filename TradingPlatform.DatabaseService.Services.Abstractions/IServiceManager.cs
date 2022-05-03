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
