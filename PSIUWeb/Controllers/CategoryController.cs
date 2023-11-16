using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PSIUWeb.Data;
using PSIUWeb.Data.Interface;
using PSIUWeb.Models;

namespace PSIUWeb.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryRepository categoryRepository;
        private readonly AppDbContext _context;

        public CategoryController(
            ICategoryRepository repo
            , AppDbContext context            
        )
        { 
            categoryRepository = repo;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(
                categoryRepository.GetCategories()
            );
        }

        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id <= 0 || id == null)
                return NotFound();

            Category? c =
                categoryRepository.GetCategoryById(id.Value);

            if (c == null)
                return NotFound();

            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    categoryRepository.Update(category);
                    return View("Index", categoryRepository.GetCategories());
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == null)
                return NotFound();

            Category? c = categoryRepository.GetCategoryById(id.Value);

            if (c == null)
                return NotFound();

            return View(c);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (id == null || id == 0)
                return NotFound();

            categoryRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Insert()
        {
            ViewData["CategoryID"] = new SelectList(_context.Categories, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Insert(Category c)
        {
            //if (ModelState.IsValid)
            //{
                try
                {
                    categoryRepository.Create(c);
                    return View("Index", categoryRepository.GetCategories());
                }
                catch (Exception)
                {
                    throw;
                }
            //}
            return View();
        }
    }
}
