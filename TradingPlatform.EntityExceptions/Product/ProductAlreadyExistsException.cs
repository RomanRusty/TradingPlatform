namespace TradingPlatform.EntityExceptions.Product
{
    public class ProductAlreadyExistsException:BadRequestException
    {
        public ProductAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
