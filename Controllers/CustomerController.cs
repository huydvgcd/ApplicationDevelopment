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
        public ApplicationDbContext _context;
        public UserManager<ApplicationUser> _userManager;

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

        [HttpGet]
        public IActionResult AddItemToCart(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            List<Book> listBook = _context.Books.Include(b => b.Category).ToList();

            Book bookToBuy = _context.Books.FirstOrDefault(b => b.Id == id);

            Cart itemExitInCart = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == id);

            // Trường này được sử dụng để add item vào giỏ hàng - khi cặp PK giống nhau thì nó chính là 1 PK cho cả table - từ table này ta tham chiếu tới table khác - tăng quantity lên 


            if (itemExitInCart == null)
            {
                var item = new Cart
                {
                    UserId = userId,
                    BookId = id,
                    Quantity = 1,
                    Total = bookToBuy.Price
                };
                _context.Carts.Add(item);
                _context.SaveChanges();
            }

            if (itemExitInCart != null)
            {
                itemExitInCart.Quantity += 1;
                itemExitInCart.Total += bookToBuy.Price;
                _context.Carts.Update(itemExitInCart);
                _context.SaveChanges();
            } 
            return View(nameof(Index), listBook);
        }

        public IActionResult Cart()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            // List<Cart> listItemInCart = _context.Carts.Include(c => c.UserId == userId).ToList();

            var listItemInCart = (from item in _context.Carts where item.UserId == userId select item).Include(b => b.Book).ToList(); 
            
            return View(listItemInCart); 
        }

        [HttpGet]
        public IActionResult MinusItem(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            

            Cart itemToMinus = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == id);
            Book bookToMinus = _context.Books.FirstOrDefault(b => b.Id == id);

            itemToMinus.Quantity -= 1;
            itemToMinus.Total -= bookToMinus.Price;

            _context.Update(itemToMinus);
            _context.SaveChanges(); 
            
            var listItemInCart = (from item in _context.Carts where item.UserId == userId select item).Include(b => b.Book).ToList(); 
            return View(nameof(Cart), listItemInCart);
        }
        
      

        public IActionResult IncreaseItem(int id)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            

            Cart itemToIncrease = _context.Carts.FirstOrDefault(c => c.UserId == userId && c.BookId == id);
            Book bookToMinus = _context.Books.FirstOrDefault(b => b.Id == id);

            itemToIncrease.Quantity += 1;
            itemToIncrease.Total += bookToMinus.Price;

            _context.Update(itemToIncrease);
            _context.SaveChanges(); 
            
            var listItemInCart = (from item in _context.Carts where item.UserId == userId select item).Include(b => b.Book).ToList();
            return View(nameof(Cart), listItemInCart); 
        }

        public IActionResult CreateOrder()
        {
            return View(nameof(Cart)); 
        }
    }
    
    
}