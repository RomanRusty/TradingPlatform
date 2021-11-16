using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.DatabaseService.Contracts.Category;
using TradingPlatform.DatabaseService.Contracts.Complaint;
using TradingPlatform.DatabaseService.Contracts.ProductImage;
using TradingPlatform.DatabaseService.Contracts.ProductOrder;

namespace TradingPlatform.DatabaseService.Contracts.Product
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public DateTime CreationDate { get; set; }
        //public virtual CategoryReadDto Category { get; set; }
        //public virtual ProductImageReadDto ImageThumbnail { get; set; }
        //public virtual IEnumerable<ProductOrderReadDto> ProductOrders { get; set; }
        //public virtual IEnumerable<ComplaintReadDto> Complaints { get; set; }
        //public virtual IEnumerable<ProductImageReadDto> Images { get; set; }
    }
}
