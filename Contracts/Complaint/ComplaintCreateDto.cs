using System;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.Contracts.Product;
using TradingPlatform.Domain.Entities;

namespace TradingPlatform.Contracts.Complaint
{
    public class ComplaintCreateDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Title must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Title must be less than 255 symbols.")]
        public string Title { get; set; }
        [Required]
        public ComplaintType Type { get; set; }
        [StringLength(3000, ErrorMessage = "Description must be less than 3000 symbols")]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        //[Required]
        //public virtual ProductReadDto Product { get; set; }
    }
}
