namespace TradingPlatform.EntityExceptions.Category
{
    public class CategoryAlreadyExistsException:BadRequestException
    {
        public CategoryAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
