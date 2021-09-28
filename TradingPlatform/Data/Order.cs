using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.Data
{
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public virtual ApplicationUser Custumer { get; set; }
        public virtual IEnumerable<ProductOrder> ProductOrders { get; set; }
        public DateTime CreationDate { get; set; }
        [NotMapped]
        public int TotalPrice { get; set; }
        public Order(ApplicationUser custumer)
        {
            Custumer = custumer ?? throw new ArgumentNullException(nameof(custumer));
            CreationDate = DateTime.Now.Date;
        }
        public Order()
        {

        }

    }
}
