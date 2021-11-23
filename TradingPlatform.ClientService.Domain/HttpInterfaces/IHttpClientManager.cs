namespace TradingPlatform.ClientService.Domain.HttpInterfaces
{
    public interface IHttpClientManager
    {
        ICategoryHttpClient CategoryHttpClient { get; }
        IComplaintHttpClient ComplaintHttpClient { get; }
        IOrderHttpClient OrderHttpClient { get; }
        IProductOrderHttpClient ProductOrderHttpClient { get; }
        IProductHttpClient ProductHttpClient { get; }
    }
}