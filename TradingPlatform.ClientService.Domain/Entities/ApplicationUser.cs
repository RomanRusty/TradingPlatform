
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.ClientService.Domain.Entities
{
    [Table("ApplicationUsers")]
    public class ApplicationUser:IdentityUser
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 symbols.")]
        [MaxLength(255, ErrorMessage = "Name must be less than 255 symbols.")]
        public override string UserName {  get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public override string Email {  get; set; } 
    }
}