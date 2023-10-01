
using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository) {
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index()
        {
            var category = _categoryRepository.GetAll().ToList();

            return View(category);
        }

        public IActionResult CreateCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Add(category);
                _categoryRepository.Save();
                TempData["success"] = "Category is created successfully";
                return RedirectToAction("Index");
            }
            return View();
           
        }

        public IActionResult EditCategory(int? id)
        {
            var category = _categoryRepository.Get(category => category.Id == id);

            return View(category);
        }

        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                _categoryRepository.Update(category);
                _categoryRepository.Save();
                TempData["success"] = "Category is updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult DeleteCategory(int? id)
        {
            var category = _categoryRepository.Get(category => category.Id == id);
            _categoryRepository.Remove(category);

            return View(category);
        }

        [HttpPost]
        public IActionResult DeleteCategory(Category category)
        {
            _categoryRepository.Remove(category);
            _categoryRepository.Save();
            TempData["success"] = "Category is deleted successfully";
            return RedirectToAction("Index");
        }


    }
}
