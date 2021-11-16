using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.DatabaseService.Contracts.Category;
using TradingPlatform.DatabaseService.Contracts.ProductImage;
using TradingPlatform.DatabaseService.Contracts.ProductImageThumbnail;

namespace TradingPlatform.DatabaseService.Contracts.Product
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
        [RegularExpression(@"/^\d+$/", ErrorMessage = "Quantity must be higher than 0")]
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        //[Required]
        public virtual ProductImageThumbnailReadDto ImageThumbnail { get; set; }

        [Required]
        public virtual CategoryReadDto Category { get; set; }
        public virtual IEnumerable<ProductImageReadDto> Images { get; set; }
    }
}
