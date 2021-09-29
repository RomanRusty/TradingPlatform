using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.DataAccess
{
    
    [Table("ProductOrders")]
    public class ProductOrder
    {
       [Key]
        public int Id {  get; set; }
        [Required]
        [RegularExpression(@"/^\d+$/", ErrorMessage = "Quantity must be higher than 0")]
        public int Quantity { get; set; }

        [Required]
        public virtual ApplicationUser Custumer { get; set; }
        [Required]
        public virtual Product Product { get; set; }
        public ProductOrder(int quantity, ApplicationUser custumer, Product product)
        {
            Quantity = quantity;
            Custumer = custumer ?? throw new ArgumentNullException(nameof(custumer));
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }
        public ProductOrder()
        {

        }
    }
}
