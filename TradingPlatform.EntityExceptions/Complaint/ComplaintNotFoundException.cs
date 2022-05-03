namespace TradingPlatform.EntityExceptions.Complaint
{
    public class ComplaintNotFoundException : NotFoundException
    {
        public ComplaintNotFoundException(string message) : base(message)
        {
        }
    }
}
