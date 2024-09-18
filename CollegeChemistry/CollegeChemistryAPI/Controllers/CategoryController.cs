using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CollegeChemistryAPI.Controllers
{
    [Route("api/category")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private Interface_Category _college_category;

        public CategoryController(Interface_Category college_category, ILogger<CategoryController> logger)
        {
            _logger = logger;
            _college_category = college_category;
        }

        [HttpGet("allcategory")]
        public ActionResult GetCategory()
        {
            try
            {
                var result = _college_category.GetAllCategory();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetCategory Exception Error: " + xc);
            }
        }

        [HttpGet("getcategorybyid")]
        public ActionResult GetCategoryById(int id)
        {
            try
            {
                var result = _college_category.GetCategoryById(id);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetCategoryById by Id Exception Error: " + xc);
            }
        }

        [HttpGet("allPublishedCategory")]
        public ActionResult GetAllPublishCategory()
        {
            try
            {
                var result = _college_category.GetAllPublishCategory();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetPublishedCategory by  Exception Error: " + xc);
            }
        }

        [HttpPost("addcategory")]
        public ActionResult AddCategory([FromBody] Category category)
        {
            try
            {
                var result = _college_category.AddCategory(category);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("AddCategory  Exception Error: " + xc);
            }
        }

        [HttpPost("deletecategory")]
        public ActionResult DeleteCategory([FromBody] Category category)
        {
            try
            {
                var result = _college_category.DeleteCategory(category);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("DeleteCategory Exception Error: " + xc);
            }
        }

        [HttpPost("updatecategory")]
        public ActionResult UpdateCategory([FromBody] Category category)
        {
            try
            {
                bool result = _college_category.UpdateCategory(category);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("UpdateCategory  Exception Error: " + xc);
            }

        }

        [HttpPost("Publishcategory")]
        public ActionResult PublishCategory([FromBody] Category category)
        {
            int id = category.id;
            bool ispublish = category.ispublish;
            DateTime? published_at = category.published_at;

            if (ispublish == true)
            {
                published_at = DateTime.UtcNow;
            }

            try
            {
                var result = _college_category.PublishCategory(id, ispublish, published_at);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("PublishCategory  Exception Error: " + xc);
            }

        }
    }
}
