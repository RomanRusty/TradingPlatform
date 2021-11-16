using System;
using System.Collections.Generic;
using TradingPlatform.DatabaseService.Contracts.ApplicationUser;
using TradingPlatform.DatabaseService.Contracts.ProductOrder;
using TradingPlatform.DatabaseService.Domain.Entities;

namespace TradingPlatform.DatabaseService.Contracts.Order
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
