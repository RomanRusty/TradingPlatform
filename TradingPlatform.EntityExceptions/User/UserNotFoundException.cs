namespace TradingPlatform.EntityExceptions.User
{
    public class UserNotFoundException : NotFoundException
    {
        public UserNotFoundException(string message) : base(message)
        {
        }
    }
}
