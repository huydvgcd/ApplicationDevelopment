using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ApplicationDevelopment.Models
{
    [Table("Store")]
    public class Store
    {
        [Key]
        [Required]
        [Display(Name = "Store ID")]
        public int StoreId { set; get; }

        [Display(Name = "UserID")]
        public int UserId { set; get; }

        [Display(Name = "Address")]
        public string Address { set; get; }

        //[Display(Name = "Slogan")]
        //public string Slogan { set; get; }
    }
}
