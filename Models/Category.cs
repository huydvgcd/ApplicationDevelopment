using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ApplicationDevelopment.Models
{
    [Table("Category")]
    public class Category
    {
        [Key]
        public int Id { set; get; }

     
        public string CategoryName { set; get; } 
        public DateTime CreateAt { set; get; }
        public string Status { set; get; }

        public List<Book> Books { get; set; }
    }
}
