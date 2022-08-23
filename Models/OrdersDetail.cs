using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ApplicationDevelopment.Models
{
    [Table("Orders Detail")]
    public class OrdersDetail
    {

        [Display(Name = "Order Id")]
        public int? OrderId { set; get; }

        [ForeignKey("OrderId")]
        public Orders Orders { set; get; }

        [Display(Name = "Book Id")]
        public string? BookId { set; get; }

        [ForeignKey("BookId")]
        public Book Book { set; get; }

        [Display(Name = "Quantity")]
        public int Quantity { set; get; }
    }
}
