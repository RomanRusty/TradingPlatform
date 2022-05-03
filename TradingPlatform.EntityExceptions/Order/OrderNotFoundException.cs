namespace TradingPlatform.EntityExceptions.Order
{
    public class OrderNotFoundException : NotFoundException
    {
        public OrderNotFoundException(string message) : base(message)
        {
        }
    }
}
