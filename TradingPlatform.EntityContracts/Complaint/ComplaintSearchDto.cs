using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Enums;

namespace TradingPlatform.EntityContracts.Complaint
{
    public class ComplaintSearchDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public ComplaintType Type { get; set; }
    }
}
