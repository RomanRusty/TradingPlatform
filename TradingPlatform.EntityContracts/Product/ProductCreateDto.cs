using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.EntityContracts.Category;
using TradingPlatform.EntityContracts.ProductImage;

namespace TradingPlatform.EntityContracts.Product
{
    public class ProductCreateDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name { get; set; }
        [Required]
        [StringLength(3000, ErrorMessage = "Description must be less than 3000 symbols")]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,4})?$", ErrorMessage = "Wrong price type")]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        //[Required]
        public ProductImageCreateDto ImageThumbnail { get; set; }
        public IEnumerable<ProductImageCreateDto> Images { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
