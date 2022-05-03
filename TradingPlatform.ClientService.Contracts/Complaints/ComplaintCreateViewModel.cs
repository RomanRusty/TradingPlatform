using Microsoft.AspNetCore.Mvc.Rendering;
using TradingPlatform.EntityContracts.Complaint;

namespace TradingPlatform.ClientService.Contracts.Complaints
{
    public class ComplaintCreateViewModel
    {
        public ComplaintCreateDto ComplaintCreate { get; set; }
        public SelectList ComplaintTypes { get; set; }
    }
}
