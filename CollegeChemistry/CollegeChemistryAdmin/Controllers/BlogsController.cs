using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

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

        public IActionResult AddUpdateBlog(int id)
        {
            try
            {
                ViewBag.Blogid = id;
                var result = _college_chem_interface_blogs.GetBlogById(id);
                return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
           
        }

        [HttpPost]
        public IActionResult InsertBlog(Blogs blog, IFormFile coverPicture)
        {
            try
            {
                if (coverPicture != null && coverPicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        coverPicture.CopyToAsync(memoryStream);
                        blog.cover_picture = memoryStream.ToArray();
                    }
                }

                blog.created_at = DateTime.UtcNow;
                var result = _college_chem_interface_blogs.AddBlog(blog);
                return RedirectToAction("Index", "Blogs");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult UpdateBlog(Blogs blog, IFormFile coverPicture)
        {
            try
            {
                if (coverPicture != null && coverPicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        coverPicture.CopyToAsync(memoryStream);
                        blog.cover_picture = memoryStream.ToArray();
                    }
                }

                blog.updated_at = DateTime.UtcNow;
                var result = _college_chem_interface_blogs.UpdateBlog(blog);
                if (result)
                {
                    // Redirect to the Index page if successful
                    return RedirectToAction("Index", "Blogs");
                }
                else
                {
                    _logger.LogWarning("UpdateBlog failed.");
                    return RedirectToAction("AddBlog", "Blogs");
                }
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult DeleteBlog(Blogs blog)
        {
            try
            {
                var result = _college_chem_interface_blogs.DeleteBlog(blog);
                return RedirectToAction("Index", "Blogs");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        }
}
