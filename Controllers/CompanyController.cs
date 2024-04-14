using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using TobaccoWebShop.Data;
using TobaccoWebShop.Models;

namespace TobaccoWebShop.Controllers
{
    public class CompanyController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Company> companies = _context.Companies.ToList();
            return View(companies);
        }

        public IActionResult Upsert(int? companyId)
        {
            if (companyId == null || companyId == 0)
            {
                //Create
                Company companyCreate = new Company();
                return View(companyCreate);
            }
            else
            {
                //Update
                Company companyCreate = _context.Companies.Where(x => x.Id == companyId).FirstOrDefault();
                return View(companyCreate);
            }
        }


        [HttpPost]
        public IActionResult Upsert(Company company)
        {
            if (ModelState.IsValid)
            {            
                if (company.Id == 0)
                {                
                    _context.Companies.Add(company);
                    TempData["success"] = "Company created successfully";
                }
                else
                {
                    _context.Companies.Update(company);
                    TempData["success"] = "Company updated successfully";
                }

                _context.SaveChanges();
                return RedirectToAction("Companies", "Admin");
            }
            else
            {
                return View(company);
            }
        }


        #region API Calls
        [HttpGet]
        public IActionResult GetAll()
        {
            List<Company> companies = _context.Companies.ToList();

            return Json(new { data = companies });
        }

        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var company = _context.Companies.Where(x => x.Id == id).FirstOrDefault();

            if (company == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _context.Companies.Remove(company);
            _context.SaveChanges();

            return Json(new { success = true, message = "Delete successful" });
        }

        #endregion

    }
}
