using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeChemistryAdmin.Controllers
{
    public class CategoryController : Controller
    {
        private readonly Interface_Category _college_chem_interface_category;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(Interface_Category college_chem_interface_category, ILogger<CategoryController> logger)
        {
            _college_chem_interface_category = college_chem_interface_category;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var result = _college_chem_interface_category.GetAllCategory().ToList();
                return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }
        [HttpPost]
        public IActionResult InsertCategory(Category category)
        {
            try
            {

                category.created_at = DateTime.UtcNow;
                var result = _college_chem_interface_category.AddCategory(category);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult UpdateCategory(Category category)
        {
            try
            {

                category.updated_at = DateTime.UtcNow;
                var result = _college_chem_interface_category.UpdateCategory(category);
                if (result)
                {
                    // Redirect to the Index page if successful
                    return RedirectToAction("Index", "Category");
                }
                else
                {
                    _logger.LogWarning("UpdateCategory failed.");
                    return RedirectToAction("Index", "Category");
                }
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult DeleteCategory(Category category)
        {
            try
            {
                var result = _college_chem_interface_category.DeleteCategory(category);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult Publish_Unpublish_Category(Category category)
        {
            try
            {

                var result = _college_chem_interface_category.PublishCategory(category.id, category.ispublish, category.published_at);
                return RedirectToAction("Index", "Category");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }
    }
}
