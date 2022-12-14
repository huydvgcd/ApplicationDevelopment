using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationDevelopment.Data;
using ApplicationDevelopment.Models;
using ApplicationDevelopment.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApplicationDevelopment.Controllers
{
    public class StoreOwnerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public StoreOwnerController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        
        
        [HttpGet]
        public async Task<IActionResult> IndexAsync(List<ApplicationUser> listCustomer)
        {
            if (listCustomer.Count != 0)
            {
                return View(listCustomer);
            }
            var usersInRole = await _userManager.GetUsersInRoleAsync(Role.CUSTOMER);
            return View(usersInRole);
        }

        [HttpPost]
        public async Task<IActionResult> IndexAsync(string searchString)
        {

            if (searchString == null)
            {
                return NotFound();
            }
            return await SearchCustomerAsync(searchString);


        }

        [NonAction]
        public async Task<IActionResult> SearchCustomerAsync(string searchString)
        {
            var customer = await _userManager.GetUsersInRoleAsync(Role.CUSTOMER);

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                var result = customer.Where(t => t.Email.Contains(searchString)).ToList();

                return  View(nameof(Index), result); 
            }

            return View("Index");
        }


        [HttpGet]
        public IActionResult SendCategoryRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendCategoryRequest(Category category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            Category newCategory = new Category();

            newCategory.CategoryName = category.CategoryName;
            newCategory.Status = Enums.CategoryStatus.InProgess;

            _context.Add(newCategory);
            _context.SaveChanges();
            TempData["Message"] = "Send Category Successfully";

            return View(newCategory);
        }
        
        

        [HttpGet]
        public IActionResult ListCustomerOrder() 
        {
            
            // var listOrder = _context.OrdersDetails.Include(b => b.Orders).ThenInclude(u => u.AppUser).ToList();

            var order = _context.Orders.Include(u => u.AppUser).Include(b => b.OrdersDetails).ToList(); 
            return View(order);
        }
        public IActionResult OrderCustomerDetail(int orderId)
        {
            var orderDetail = (from o in _context.OrdersDetails where o.OrderId == orderId select o)
                .Include(b => b.Book).ThenInclude(c => c.Category).ToList();
            
            return View(orderDetail);
        }
    }
}
