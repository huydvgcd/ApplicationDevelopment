using System.Collections.Generic;
using ApplicationDevelopment.Models;

namespace ApplicationDevelopment.ViewModels
{
    public class OrderOrderDetailViewModel
    {
        public List<Orders> Orders { set; get; } = new List<Orders>();
        public List<OrdersDetail> OrdersDetails { set; get; } = new List<OrdersDetail>(); 
        
    }
}