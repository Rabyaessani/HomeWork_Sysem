using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeChemistryAdmin.Controllers
{
    public class LessonsController : Controller
    {
        private readonly Interface_Lessons _college_chem_interface_lessons;
        private readonly ILogger<LessonsController> _logger;
        public LessonsController(Interface_Lessons college_chem_interface_lessons, ILogger<LessonsController> logger)
        {
            _college_chem_interface_lessons = college_chem_interface_lessons;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var result = _college_chem_interface_lessons.GetAllLessons().ToList();
                return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }
        public IActionResult AddUpdateLesson(int id)
        {
            try
            {
                ViewBag.LessonId = id;
                var result = _college_chem_interface_lessons.GetLessonById(id);
                return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }

        }

        [HttpPost]
        public IActionResult InsertLesson(Lessons lessons, IFormFile coverPicture)
        {
            try
            {
                if (coverPicture != null && coverPicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        coverPicture.CopyToAsync(memoryStream);
                        lessons.cover_picture = memoryStream.ToArray();
                    }
                }

                lessons.created_at = DateTime.UtcNow;
                var result = _college_chem_interface_lessons.AddLesson(lessons);
                return RedirectToAction("Index", "Lessons");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult UpdateLesson(Lessons lesson, IFormFile coverPicture)
        {
            try
            {
                if (coverPicture != null && coverPicture.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        coverPicture.CopyToAsync(memoryStream);
                        lesson.cover_picture = memoryStream.ToArray();
                    }
                }

                else
                {
                    // Fetch the existing blog data to retain the current cover picture
                    var existingBlog = _college_chem_interface_lessons.GetLessonById(lesson.id);
                    if (existingBlog != null)
                    {
                        lesson.cover_picture = existingBlog.cover_picture;
                    }
                }

                lesson.updated_at = DateTime.UtcNow;
                var result = _college_chem_interface_lessons.UpdateLesson(lesson);
                if (result)
                {
                    // Redirect to the Index page if successful
                    return RedirectToAction("Index", "Lessons");
                }
                else
                {
                    _logger.LogWarning("UpdateBlog failed.");
                    return RedirectToAction("AddUpdateLesson", "Lessons");
                }
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult DeleteLesson(Lessons lesson)
        {
            try
            {
                var result = _college_chem_interface_lessons.DeleteLesson(lesson);
                return RedirectToAction("Index", "Lessons");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

    }
}
