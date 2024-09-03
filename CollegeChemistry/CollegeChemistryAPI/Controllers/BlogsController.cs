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
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ILogger<BlogsController> _logger;
        private Interface_Blogs _college_blogs;

        public BlogsController(Interface_Blogs college_blogs, ILogger<BlogsController> logger)
        {
            _logger = logger;
            _college_blogs = college_blogs;
        }

        [HttpGet("allblogs")]
        public ActionResult GetBlogs()
        {
            try
            {
                var result = _college_blogs.GetAllBlogs();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetBlogs Exception Error: " + xc);
            }
        }

        [HttpGet("{id}")]
        public ActionResult GetBlogsById(int id)
        {
            try
            {
                var result = _college_blogs.GetBlogById(id);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetBlogs by Id Exception Error: " + xc);
            }
        }

        [HttpPost]
        public ActionResult PostBlogs([FromBody] Blogs blog)
        {
            try
            {
                var result = _college_blogs.AddBlog(blog);
                if (result == 0)
                {
                    return StatusCode(500, "An error occurred while adding the blog.");
                }
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("AddBlogs  Exception Error: " + xc);
            }
        }

        [HttpDelete]
        public ActionResult DeleteBlog([FromBody] Blogs blog)
        {
            try
            {
                var result = _college_blogs.DeleteBlog(blog);
                if (result)
                {
                    return Ok(new { message = "Blog deleted successfully." });
                }
                else
                {
                    return NotFound(new { message = "Blog not found or could not be deleted." });
                }
            }
            catch (Exception xc)
            {
                return BadRequest("DeleteBlog Exception Error: " + xc);
            }
        }

        [HttpPatch]
        public ActionResult UpdateBlog([FromBody] Blogs blog)
        {
            try
            {
                bool result = _college_blogs.UpdateBlog(blog);
                if (result)
                {
                    return Ok(new { message = "Blog updated successfully." });
                }
                else
                {
                    return NotFound(new { message = "Blog not found or could not be updated." });
                }
            }
            catch (Exception xc)
            {
                return BadRequest("UpdateBlog  Exception Error: " + xc);
            }

        }
    }

}
