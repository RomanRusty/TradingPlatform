using System;
using System.Collections.Generic;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Enums;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.EntityContracts.Order
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
        //public virtual ApplicationUserReadDto Custumer { get; set; }
        //public virtual IEnumerable<ProductOrderReadDto> ProductOrders { get; set; }

    }
}
