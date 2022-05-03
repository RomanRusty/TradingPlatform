namespace TradingPlatform.EntityExceptions.Product
{
    public class ProductNotFoundException : NotFoundException
    {
        public ProductNotFoundException(string message) : base(message)
        {
        }
    }
}
