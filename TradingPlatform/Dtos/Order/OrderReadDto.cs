using System;
using System.Collections.Generic;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Dtos
{
    public class OrderReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public OrderStatus Status { get; set; }
        public virtual ApplicationUserReadDto Custumer { get; set; }
        public virtual IEnumerable<ProductOrderReadDto> ProductOrders { get; set; }

    }
}
