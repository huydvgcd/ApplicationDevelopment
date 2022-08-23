using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System;

namespace ApplicationDevelopment.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        [Required]
        [Display(Name = "Key Book")]
        public string Id { set; get; }

       
        [ForeignKey("CategoryId")]
        public Category Category{ set; get; }


        [Display(Name = "Book title")]
        public string Title { set; get; }


        [Display(Name = "Book price")]
        public Decimal Price { set; get; }


        [Display(Name = "Book image")]
        public string ImgUrl { set; get; }

        [Display(Name = "Book Author")]
        public string Author { set; get; }
    }
}
