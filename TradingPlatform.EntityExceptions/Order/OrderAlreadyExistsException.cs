namespace TradingPlatform.EntityExceptions.Order
{
    public class OrderAlreadyExistsException : BadRequestException
    {
        public OrderAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
