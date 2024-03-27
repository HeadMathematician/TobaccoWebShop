using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using TobaccoWebShop.Data;
using TobaccoWebShop.Models;
using TobaccoWebShop.Enums;

namespace TobaccoWebShop.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Delete(int productId)
        {
            if(productId == 0)
            {
                return NotFound();
            }

            Product product = _context.Products.FirstOrDefault(x => x.Id == productId);
            if(product != null)
            {
                return View(product);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Delete(Product product)
        {
            var toDelete = _context.Products.Where(x => x.Id == product.Id).FirstOrDefault();
            _context.Products.Remove(toDelete);
            _context.SaveChanges();
            return RedirectToAction("Products", "Admin");
        }

        public IActionResult Upsert(int? productId)
        {
            if(productId == null || productId == 0)
            {
                //Create
                Product productCreate = new Product();
                return View(productCreate);
            }
            else
            {
                //Update
                Product productUpdate = _context.Products.Where(x => x.Id == productId).FirstOrDefault();
                return View(productUpdate);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Product product, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                byte[] imageBytes = null;

                if (file != null)
                {
                    using (var stream = file.OpenReadStream())
                    using (var memoryStream = new MemoryStream())
                    {
                        stream.CopyTo(memoryStream);
                        imageBytes = memoryStream.ToArray();
                    }
                }

                if (product.Id == 0)
                {
                    if (!imageBytes.IsNullOrEmpty())
                    {
                        product.Image = Convert.ToBase64String(imageBytes);
                    }
                    _context.Products.Add(product);
                    TempData["success"] = "Product created successfully";
                }
                else
                {
                    if (!imageBytes.IsNullOrEmpty())
                    {
                        product.Image = Convert.ToBase64String(imageBytes);
                    }

                    _context.Products.Update(product);
                    TempData["success"] = "Product updated successfully";
                }

                _context.SaveChanges();
                return RedirectToAction("Products", "Admin");

            }
            else
            {
                return View(product);
            }
        }

    }
}
