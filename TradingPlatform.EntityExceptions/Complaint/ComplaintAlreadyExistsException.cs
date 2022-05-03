namespace TradingPlatform.EntityExceptions.Complaint
{
    public class ComplaintAlreadyExistsException : BadRequestException
    {
        public ComplaintAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
