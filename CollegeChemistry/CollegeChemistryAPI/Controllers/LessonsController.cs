using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using CollegeChemistryLibrary.Interfaces;
using CollegeChemistryLibrary.Entities;
using System.Reflection.Metadata;

namespace CollegeChemistryAPI.Controllers
{
    [Route("api/lessons")]
    [ApiController]
    public class LessonsController : ControllerBase
    {
        private readonly ILogger<LessonsController> _logger;
        private Interface_Lessons _college_Lessons;

        public LessonsController(Interface_Lessons college_Lessons, ILogger<LessonsController> logger)
        {
            _logger = logger;
            _college_Lessons = college_Lessons;
        }

        [HttpGet("allLessons")]
        public ActionResult GetLessons()
        {
            try
            {
                var result = _college_Lessons.GetAllLessons();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetLessons Exception Error: " + xc);
            }
        }

        [HttpGet("allPublishedLessons")]
        public ActionResult GetPublishLessons(bool ispublish)
        {
            try
            {
                var result = _college_Lessons.GetAllPublishLessons(ispublish);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("Get Published lessons by  Exception Error: " + xc);
            }
        }

        [HttpGet("getlessonbyid")]
        public ActionResult GetLessonsById(int id)
        {
            try
            {
                var result = _college_Lessons.GetLessonById(id);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("Getlesson by Id Exception Error: " + xc);
            }
        }

        [HttpPost("Publishlesson")]
        public ActionResult PublishLesson([FromBody] Lessons lesson)
        {
            int id = lesson.id;
            bool ispublish = lesson.ispublish;
            DateTime? published_at=lesson.published_at;

            if (ispublish == true)
            {
                published_at = DateTime.UtcNow;
            }
            
            try
            {
                var result = _college_Lessons.PublishLesson(id,ispublish,published_at);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("PublishLessons  Exception Error: " + xc);
            }

        }

        [HttpPost("addlesson")]
        public ActionResult AddLesson([FromBody] Lessons lesson)
        {
            try
            {
                var result = _college_Lessons.AddLesson(lesson);
                if (result == 0)
                {
                    return StatusCode(500, "An error occurred while adding the lesson.");
                }
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("AddLessons  Exception Error: " + xc);
            }
        }

        [HttpPost("deletelessons")]
        public ActionResult DeleteBlog([FromBody] Lessons lesson)
        {
            try
            {
                var result = _college_Lessons.DeleteLesson(lesson);
                if (result)
                {
                    return Ok(new { message = "lesson deleted successfully." });
                }
                else
                {
                    return NotFound(new { message = "lesson not found or could not be deleted." });
                }
            }
            catch (Exception xc)
            {
                return BadRequest("Deletelesson Exception Error: " + xc);
            }
        }

        [HttpPost("updatelessons")]
        public ActionResult UpdateLessons([FromBody] Lessons lessons)
        {
            try
            {
                bool result = _college_Lessons.UpdateLesson(lessons);
                if (result)
                {
                    return Ok(new { message = "Lesson updated successfully." });
                }
                else
                {
                    return NotFound(new { message = "lesson not found or could not be updated." });
                }
            }
            catch (Exception xc)
            {
                return BadRequest("Updatelesson  Exception Error: " + xc);
            }

        }

    }
}
