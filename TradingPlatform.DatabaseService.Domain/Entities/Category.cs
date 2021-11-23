using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.DatabaseService.Domain.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name { get; set; }
        [Required]
        [StringLength(3000, ErrorMessage = "Description must be less than 3000 symbols")]
        public string Description { get; set; }
        public virtual IEnumerable<Product> Products { get; set; }

        public Category(string name, string description)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description ?? throw new ArgumentNullException(nameof(description));
        }
        public Category()
        {

        }
    }
}
