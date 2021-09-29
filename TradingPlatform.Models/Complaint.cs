using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TradingPlatform.DataAccess
{
    public enum ComplaintType
    {
        UnpropriateContent,
        OffensiveContent,
    }
    [Table("Complaints")]
    public class Complaint
    {
        [Key]
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
        [Required]
        public virtual Product Product { get; set; }

        public Complaint(string title, ComplaintType type, string description, Product product)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Type = type;
            Description = description;
            CreationDate = DateTime.Now.Date;
            Product = product ?? throw new ArgumentNullException(nameof(product));
        }
        public Complaint()
        {

        }

    }
}
