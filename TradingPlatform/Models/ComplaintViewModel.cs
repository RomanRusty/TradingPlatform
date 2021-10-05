using TradingPlatform.DataAccess;

namespace TradingPlatform.Models
{
    public class ComplaintViewModel
    {
        public string Title { get; set; }
        public ComplaintType Type { get; set; }
        public string Description { get; set; }
    }
}
