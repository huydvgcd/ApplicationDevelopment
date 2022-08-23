using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ApplicationDevelopment.Models
{
    public class Cart
    {
        public string UserId { set; get; }
        public ApplicationUser AppUser { set; get; }


        [Display(Name = "BOOKID")]
        public string? BookId { set; get; }


        [ForeignKey("BookId")]
        public Book Book { set; get; }
    }
}
