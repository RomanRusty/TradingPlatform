using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityContracts.Complaint;
using TradingPlatform.EntityContracts.ProductImage;
using TradingPlatform.EntityContracts.ProductOrder;

namespace TradingPlatform.EntityContracts.Product
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
        public virtual IEnumerable<ProductImageReadDto> Images { get; set; }
        public int CategoryId { get; set; }
    }
}
