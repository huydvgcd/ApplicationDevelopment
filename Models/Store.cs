using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ApplicationDevelopment.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        [Required]
        [Display(Name = "Category ID")]
        public int Id { set; get; }

        [Display(Name = "Name")]
        public int CategoryName { set; get; }

        [Display(Name = "Address")]
        public DateTime CreateAt { set; get; }

        [Display(Name = "Status")]
        public string Status { set; get; }
    }
}
