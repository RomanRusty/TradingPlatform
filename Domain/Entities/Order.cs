using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.Domain.Entities
{
    public enum OrderStatus
    {
        Selecting,
        Conirmed,
        Paid,
        Sent,
        Delivered,
        Closed,
        Сomplained
    }
    [Table("Orders")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name {  get; set; }
        public virtual ApplicationUser Custumer { get; set; }
        public virtual IEnumerable<ProductOrder> ProductOrders { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
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
