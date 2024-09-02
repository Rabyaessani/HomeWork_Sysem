using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System;
using CollegeChemistryLibrary.Interfaces;

namespace CollegeChemistryAPI.Controllers
{
    [Route("api/blogs")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly ILogger<BlogsController> _logger;
        private Interface_Blogs _college_blogs;

        public BlogsController(Interface_Blogs college_blogs ,ILogger<BlogsController> logger)
        {
            _logger = logger;
            _college_blogs = college_blogs;
        }

        [HttpGet("allblogs")]
        public ActionResult GetBlogs()
        {
            try
            {
               var result= _college_blogs.GetAllBlogs();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetBlogs Exception Error: " + xc);
            }
        }
    }
}
