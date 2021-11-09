using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.Contracts.Category;
using TradingPlatform.Contracts.Complaint;
using TradingPlatform.Contracts.ProductImage;
using TradingPlatform.Contracts.ProductOrder;

namespace TradingPlatform.Contracts.Product
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
        public virtual ProductImageReadDto ImageThumbnail { get; set; }
        public virtual CategoryReadDto Category { get; set; }
        public virtual IEnumerable<ProductOrderReadDto> ProductOrders { get; set; }
        public virtual IEnumerable<ComplaintReadDto> Complaints { get; set; }
        public virtual IEnumerable<ProductImageReadDto> Images { get; set; }
    }
}
