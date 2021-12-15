using System;
using System.ComponentModel.DataAnnotations;
using TradingPlatform.EntityContracts.ApplicationUser;
using TradingPlatform.EntityContracts.Enums;

namespace TradingPlatform.EntityContracts.Order
{
    public class OrderCreateDto
    {
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public string Name { get; set; }
        public string CustumerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreationDate { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
    }
}
