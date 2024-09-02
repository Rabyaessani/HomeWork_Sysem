using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeChemistryAdmin.Controllers
{
    public class BlogsController : Controller
    {
        private readonly Interface_Blogs _college_chem_interface_blogs;
        private readonly ILogger<BlogsController> _logger;
        public BlogsController(Interface_Blogs college_chem_interface_blogs, ILogger<BlogsController> logger)
        {
            _college_chem_interface_blogs = college_chem_interface_blogs;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
              var result=_college_chem_interface_blogs.GetAllBlogs().ToList();
              return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }
    }
}
