using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.DataAccess
{
    [Table("Products")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name { get; set; }
        [Required]
        [StringLength(3000,ErrorMessage = "Description must be less than 3000 symbols")]
        public string Description { get; set; }
        [Required]
        [RegularExpression(@"^\d{0,8}(\.\d{1,4})?$",ErrorMessage ="Wrong price type")]
        public double Price { get; set; }
        [Required]
        [RegularExpression(@"/^\d+$/", ErrorMessage = "Quantity must be higher than 0")]
        public int Quantity { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        //[Required]
        public virtual ProductImageThumbnail ImageThumbnail { get; set; }

        [Required]
        public virtual Category Category { get; set; }
        public virtual IEnumerable<ProductOrder> ProductOrders { get; set; }
        public virtual IEnumerable<Complaint> Complaints { get; set; }
        public virtual IEnumerable<ProductImage> Images { get; set; }

        public Product(string name, string description, double price, int quantity, Category category)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Description = description;
            Price = price;
            Quantity = quantity;
            CreationDate = DateTime.Now.Date;
            Category = category ?? throw new ArgumentNullException(nameof(category));
        }
        public Product()
        {

        }
    }
}
