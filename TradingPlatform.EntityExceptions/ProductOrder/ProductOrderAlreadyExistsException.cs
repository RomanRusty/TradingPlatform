namespace TradingPlatform.EntityExceptions.ProductOrder
{
    public class ProductOrderAlreadyExistsException : BadRequestException
    {
        public ProductOrderAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
