using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CollegeChemistryAPI.Controllers
{
    [Route("api/mcqs")]
    [ApiController]
    public class MCQsController : ControllerBase
    {
        private readonly ILogger<MCQsController> _logger;
        private MCQs_Interface _college_Mcqs;

        public MCQsController(MCQs_Interface college_mcqs, ILogger<MCQsController> logger)
        {
            _logger = logger;
            _college_Mcqs = college_mcqs;
        }

        [HttpGet("allmcqs")]
        public ActionResult GetMCQs()
        {
            try
            {
                var result = _college_Mcqs.GetAllMCQs();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetMCQs Exception Error: " + xc);
            }
        }

        [HttpGet("getmcqbyid")]
        public ActionResult GetMCQsById(int id)
        {
            try
            {
                var result = _college_Mcqs.GetMCQsById(id);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetMcqs by Id Exception Error: " + xc);
            }
        }

        [HttpGet("allPublishedMCQs")]
        public ActionResult GetAllPublishMCQs()
        {
            try
            {
                var result = _college_Mcqs.GetAllPublishMCQs();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("Get Published MCQS by  Exception Error: " + xc);
            }
        }

        [HttpPost("addMcq")]
        public ActionResult AddMCQ([FromBody] MCQs mcq)
        {
            try
            {
                var result = _college_Mcqs.AddMCQ(mcq);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("AddMCQ Exception Error: " + xc);
            }
        }

        [HttpPost("deleteMCQ")]
        public ActionResult DeleteMCQ([FromBody] MCQs mcq)
        {
            try
            {
                var result = _college_Mcqs.DeleteMCQ(mcq);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("DeleteMCQ Exception Error: " + xc);
            }
        }

        [HttpPost("updateMCQ")]
        public ActionResult UpdateMCQ([FromBody] MCQs mcq)
        {
            try
            {
                bool result = _college_Mcqs.UpdateMCQ(mcq);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("UpdateMCQ  Exception Error: " + xc);
            }

        }

        [HttpPost("PublishMCQ")]
        public ActionResult PublishMCQ([FromBody] MCQs mcq)
        {
            int id = mcq.id;
            bool ispublish = mcq.ispublish;
            DateTime? published_at = mcq.published_at;

            if (ispublish == true)
            {
                published_at = DateTime.UtcNow;
            }

            try
            {
                var result = _college_Mcqs.PublishMCQ(id, ispublish, published_at);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("PublishMCQ  Exception Error: " + xc);
            }

        }

    }
}
