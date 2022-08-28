using ApplicationDevelopment.Data;
using ApplicationDevelopment.Models;
using ApplicationDevelopment.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApplicationDevelopment.Enums;

namespace ApplicationDevelopment.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _context;
        public IFormFile ProfileImage { get; set; }
        private readonly IWebHostEnvironment webHostEnvironment;

        public BookController(ApplicationDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        private string UploadedFile(BookViewModel model)
        {
            string uniqueFileName = null;
            if (model.ProfileImage != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.ProfileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Book> listBook = _context.Books.Include(b => b.Category).ToList();
            return View(listBook);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var getCategoryInDb = (from category in _context.Categories
                where category.Status == CategoryStatus.Accepted
                select category).ToList();
            var model = new BookViewModel
            {
                listCategory = getCategoryInDb
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Create(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var getCategoryInDb = (from category in _context.Categories
                    where category.Status == CategoryStatus.Accepted
                    select category).ToList();
                model.listCategory = getCategoryInDb; 
                 
                return View(model);
            }
            string uniqueFileName = UploadedFile(model);
            Book newBook = new Book 
            {
                Author = model.book.Author,
                Price = model.book.Price,
                Title = model.book.Title,
                Description = model.book.Description,
                Quantity = model.book.Quantity,
                CategoryId = model.book.CategoryId,
                ProfilePicture = uniqueFileName
            };

            _context.Books.Add(newBook);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            Book bookToDelete = _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
            if (bookToDelete == null)
            {
                return BadRequest();
            }

            _context.Remove(bookToDelete);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Detail(int id)
        {
            Book book = _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
            return View(book);
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var getCategoryInDb = (from category in _context.Categories
                where category.Status == CategoryStatus.Accepted
                select category).ToList();
            var model = new BookViewModel
            {
                listCategory = getCategoryInDb
            };

            Book bookToUpdate = _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);

            model.book = bookToUpdate;
            return View(model);
        }

        [HttpPost]
        public IActionResult Update(BookViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var getCategoryInDb = (from category in _context.Categories
                    where category.Status == CategoryStatus.Accepted
                    select category).ToList();
                model.listCategory = getCategoryInDb; 
                 
                return View(model);
            }
            string uniqueFileName = UploadedFile(model);
            var bookUpdate = _context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == model.book.Id);
            
            bookUpdate.Author = model.book.Author;
            bookUpdate.Price = model.book.Price;    
            bookUpdate.Title = model.book.Title;
            bookUpdate.Description = model.book.Description;
            bookUpdate.Quantity = model.book.Quantity;
            bookUpdate.CategoryId = model.book.CategoryId;
            bookUpdate.ProfilePicture = uniqueFileName;    



            _context.Books.Update(bookUpdate);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
