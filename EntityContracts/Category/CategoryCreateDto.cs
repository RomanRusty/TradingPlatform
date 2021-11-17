using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TradingPlatform.EntityContracts.Category
{
    public class CategoryCreateDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name { get; set; }
        [Required]
        [StringLength(3000, ErrorMessage = "Description must be less than 3000 symbols")]
        public string Description { get; set; }
    }
}
