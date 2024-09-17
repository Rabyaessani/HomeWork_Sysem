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

        [HttpGet("getblogbyid")]
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

        [HttpGet("allPublishedBlogs")]
        public ActionResult GetAllPublishBlogs()
        {
            try
            {
                var result = _college_blogs.GetAllPublishBlogs();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("Get Published Blogs by  Exception Error: " + xc);
            }
        }

        [HttpPost("addblog")]
        public ActionResult AddBlogs([FromBody] Blogs blog)
        {
            try
            {
                var result = _college_blogs.AddBlog(blog);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("AddBlogs  Exception Error: " + xc);
            }
        }

        [HttpPost("deleteblog")]
        public ActionResult DeleteBlog([FromBody] Blogs blog)
        {
            try
            {
                var result = _college_blogs.DeleteBlog(blog);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("DeleteBlog Exception Error: " + xc);
            }
        }

        [HttpPost("updateblog")]
        public ActionResult UpdateBlog([FromBody] Blogs blog)
        {
            try
            {
                bool result = _college_blogs.UpdateBlog(blog);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("UpdateBlog  Exception Error: " + xc);
            }

        }

        [HttpPost("Publishblog")]
        public ActionResult PublishBlog([FromBody] Blogs blog)
        {
            int id = blog.id;
            bool ispublish = blog.ispublish;
            DateTime? published_at = blog.published_at;

            if (ispublish == true)
            {
                published_at = DateTime.UtcNow;
            }

            try
            {
                var result = _college_blogs.PublishBlog(id, ispublish, published_at);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("PublishBlog  Exception Error: " + xc);
            }

        }

    }

}
