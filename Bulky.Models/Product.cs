using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Bulky.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string ISBN { get; set; }
        [Required]
        public string Author { get; set; }

        [Range(1, 1000)]
        [Display(Name = "List Price")]
        [Required]
        public double ListPrice { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Price for 1-50")]
        [Required]
        public double Price { get; set; }

        [Range(1, 1000)]
        [Display(Name = "Price for 50+")]
        [Required]
        public double Price50 { get; set; }

        [Range(1,1000)]
        [Display(Name = "Price for 100+")]
        [Required]
        public double Price100 { get; set; }

        public int CategoryId { get; set; }

        [ValidateNever]
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }

        [ValidateNever]
        public string ImageUrl { get; set; }
    }
}
