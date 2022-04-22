using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
