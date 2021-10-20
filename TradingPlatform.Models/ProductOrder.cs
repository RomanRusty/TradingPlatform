using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    
    [Table("ProductOrders")]
    public class ProductOrder
    {
       [Key]
        public int Id {  get; set; }
        [Required]
        //[RegularExpression(@"/^\d+$/", ErrorMessage = "Quantity must be higher than 0")]
        public int Quantity { get; set; }
        public virtual Order Order { get; set; }
        public virtual Product Product { get; set; }
     
        public ProductOrder(int quantity, Order order, Product product)
        {
            Quantity = quantity;
            Order = order ?? throw new ArgumentNullException(nameof(order));
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }
        public ProductOrder()
        {

        }
    }
}
