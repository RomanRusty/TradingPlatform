namespace TradingPlatform.EntityExceptions.ProductOrder
{
    public class ProductOrderNotFoundException : NotFoundException
    {
        public ProductOrderNotFoundException(string message) : base(message)
        {
        }
    }
}
