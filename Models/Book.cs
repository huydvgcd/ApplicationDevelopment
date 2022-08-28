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
        [Display(Name = "Key Book")]
        public int Id { set; get; }

        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        
        [Display(Name = "Book title")]
        [Required(ErrorMessage = "Name Book can not be null")]
        public string Title { set; get; }
        
        [Display(Name = "Book price")]
        [Required(ErrorMessage = "Price Book can not be null")]
        public int Price { set; get; }

        
        [Display(Name = "Book Author")]
        [Required(ErrorMessage = "Book Author can not be null")]
        public string Author { set; get; }

        [Display(Name = "Book Description")]
        [Required(ErrorMessage = " Book Description can not be null")]
        public string Description { set; get; }

        [Display(Name = "Book Quantity")]
        [Range(1, 100)]
        [Required(ErrorMessage = " Book quantity can not be null")]
        public int Quantity { set; get; }
        
        [Display(Name = "Profile Picture")]
        public string ProfilePicture { get; set; }

    }
}
