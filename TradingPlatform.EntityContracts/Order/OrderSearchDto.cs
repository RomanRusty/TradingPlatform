using System;
using TradingPlatform.EntityContracts.Enums;

namespace TradingPlatform.EntityContracts.Order
{
    public class OrderSearchDto
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
        public string CustumerId { get; set; }
        public string CustumerName { get; set; }
    }
}
