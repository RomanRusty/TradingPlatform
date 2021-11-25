using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradingPlatform.EntityContracts.Enums;

namespace TradingPlatform.EntityContracts.Order
{
    public class OrderSearchDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
    }
}
