using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDevelopment.Data;
using ApplicationDevelopment.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.Controllers
{
    public class CustomerController : Controller
    {
        public readonly ApplicationDbContext _context;
        public readonly UserManager<ApplicationUser> _userManager;

        public CustomerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            List<Book> listBook = _context.Books.Include(b => b.Category).ToList();

            return View(listBook);
        }

        // [HttpGet]
        // public IActionResult AddItemToCart(int id)
        // {
        //     var userId = _userManager.GetUserId(HttpContext.User);
        //     List<Book> listBook = _context.Books.Include(b => b.Category).ToList();
        //
        //     Book bookToBuy = _context.Books.FirstOrDefault(b => b.Id == id);
        //
        //     Cart itemExitInCart = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == id);
        //
        //     // Trường này được sử dụng để add item vào giỏ hàng - khi cặp PK giống nhau thì nó chính là 1 PK cho cả table - từ table này ta tham chiếu tới table khác - tăng quantity lên 
        //
        //
        //     if (itemExitInCart == null)
        //     {
        //         var item = new Cart
        //         {
        //             UserId = userId,
        //             BookId = id,
        //             Quantity = 1,
        //             Total = bookToBuy.Price
        //         };
        //         _context.Carts.Add(item);
        //         _context.SaveChanges();
        //     }
        //
        //     if (itemExitInCart != null)
        //     {
        //         itemExitInCart.Quantity += 1;
        //         itemExitInCart.Total += bookToBuy.Price;
        //         _context.Carts.Update(itemExitInCart);
        //         _context.SaveChanges();
        //     } 
        //     return View(nameof(Index), listBook);
        // }

        public IActionResult Cart()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            var listItemInCart = (from item in _context.Carts where item.UserId == userId select item).Include(b => b.Book).ToList(); 
            
            return View(listItemInCart); 
        }

        // [HttpGet]
        // public IActionResult MinusItem(int id)
        // {
        //     var userId = _userManager.GetUserId(HttpContext.User);
        //     
        //
        //     Cart itemToMinus = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == id);
        //     var bookPrice = _context.Books.FirstOrDefault(b => b.Id == id)!.Price;
        //
        //     if (itemToMinus != null && itemToMinus.Quantity > 0)
        //     {
        //         itemToMinus.Quantity -= 1;
        //         itemToMinus.Total -= bookPrice;
        //         _context.Update(itemToMinus);
        //         
        //     }
        //
        //     if (itemToMinus != null && itemToMinus.Quantity <= 0)
        //     {
        //         _context.Carts.Remove(itemToMinus);
        //     }
        //     
        //     _context.SaveChanges(); 
        //     
        //
        //     var listItemInCart = (from item in _context.Carts where item.UserId == userId select item).Include(b => b.Book).ToList(); 
        //     return View(nameof(Cart), listItemInCart);
        // }
        //
        //
        //
        // public IActionResult IncreaseItem(int id)
        // {
        //     var userId = _userManager.GetUserId(HttpContext.User);
        //     
        //
        //     Cart itemToIncrease = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == id);
        //     Book bookToMinus = _context.Books.FirstOrDefault(b => b.Id == id);
        //     
        //     itemToIncrease.Quantity += 1;
        //     itemToIncrease.Total += bookToMinus.Price;
        //
        //     _context.Update(itemToIncrease);
        //     _context.SaveChanges(); 
        //     
        //     var listItemInCart = (from item in _context.Carts where item.UserId == userId select item).Include(b => b.Book).ToList();
        //     return View(nameof(Cart), listItemInCart); 
        // }

        // public IActionResult CreateOrder()
        // {
        //     var userId = _userManager.GetUserId(HttpContext.User);
        //     List<OrdersDetail> listOrdersDetails = new List<OrdersDetail>();
        //
        //     Orders newOrder = new Orders
        //     {   
        //         UserId = userId, 
        //         OrderTime = DateTime.Now
        //     };
        //     _context.Orders.Add(newOrder); 
        //     _context.SaveChanges();
        //     
        //     var orderInDb = _context.Orders.OrderByDescending(t => t.Id).First();
        //     var bookInCart = (from item in _context.Carts where item.UserId == userId select item).Include(b => b.Book).ToList();
        //
        //     foreach (var item in bookInCart)
        //     {
        //         var orderDetail = new OrdersDetail
        //         {
        //             OrderId = orderInDb.Id, 
        //             BookId = item.BookId,
        //             Quantity = item.Quantity, 
        //             Total = item.Total
        //         };
        //
        //         listOrdersDetails.Add(orderDetail);
        //         
        //         _context.OrdersDetails.Add(orderDetail); 
        //         
        //     }
        //     
        //     _context.OrdersDetails.AddRange(listOrdersDetails);
        //     _context.RemoveRange(bookInCart);
        //     _context.SaveChanges();
        //
        //     List<Book> listBook = _context.Books.Include(b => b.Category).ToList();
        //
        //     return View(nameof(Index), listBook); 
        // }

        [HttpPost]
        public IActionResult SearchItem(string searchString)
        {
            var book = _context.Books.Include(c => c.Category)
                .Where(s => s.Title.Contains(searchString) || s.Category.CategoryName.Contains(searchString))
                .ToList();
    
            return View(nameof(Index), book);
        }
        
      
        public IActionResult SearchItem()
        {
            return View(nameof(Index));
        }

    }
    
}