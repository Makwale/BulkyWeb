using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository, IWebHostEnvironment webHostEnvironment)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var productList = _productRepository.GetAll().ToList();
            return View(productList);
        }

        public IActionResult CreateProduct()
        {
            var categoryList = _categoryRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            var productVM = new ProductVM
            {
                CategoryList = categoryList,
                Product = new Product()
            };
            return View(productVM);
        }

        [HttpPost]
        public IActionResult CreateProduct(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if(file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\products");

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                        productVM.Product.ImageUrl = @"\images\products\" + fileName;
                    }
                }
                _productRepository.Add(productVM.Product);
                _productRepository.Save();
                TempData["success"] = "Product is created successfully";
                return RedirectToAction("Index");
            }
            else
            {
                var categoryList = _categoryRepository.GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

                productVM.CategoryList = categoryList;
                return View(productVM);
            }


        }

        public IActionResult UpdateProduct(int id, IFormFile? file)
        {
            var categoryList = _categoryRepository.GetAll().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });

            var productVM = new ProductVM
            {
                CategoryList = categoryList,
                Product = _productRepository.Get(product => product.Id == id)
            };
        

            return View(productVM);
        }

        [HttpPost]
        public IActionResult UpdateProduct(ProductVM productVM, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                _productRepository.Update(productVM.Product);
                _productRepository.Save();
                TempData["success"] = "Product is updated successfully";
                return RedirectToAction("Index");
            }
            
            return View();
        }
    }
}
