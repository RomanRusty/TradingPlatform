using Microsoft.AspNetCore.Mvc.Rendering;
using TradingPlatform.EntityContracts.Complaint;

namespace TradingPlatform.ClientService.Contracts.Complaints
{
    public class ComplaintEditViewModel
    {
        public ComplaintCreateDto ComplaintEdit { get; set; }
        public SelectList ComplaintTypes { get; set; }
    }
}
