using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Name must have minimum length of 3")]
        [MaxLength(15, ErrorMessage = "Name must have maximum length of 15")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Display Order")]
        [Range(1, 500, ErrorMessage = "Display Order must be between 1-500")]
        public int DisplayOrder { get; set; }
    }
}
