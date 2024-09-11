using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace CollegeChemistryAPI.Controllers
{
    [Route("api/questions")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly ILogger<QuestionsController> _logger;
        private Interface_Questions _college_Questions;

        public QuestionsController(Interface_Questions college_Questions, ILogger<QuestionsController> logger)
        {
            _logger = logger;
            _college_Questions = college_Questions;
        }

        [HttpGet("allQuestions")]
        public ActionResult GetQuestions()
        {
            try
            {
                var result = _college_Questions.GetAllQuestions();
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetQuestions Exception Error: " + xc);
            }
        }

        [HttpGet("getQuestionbyid")]
        public ActionResult GetQuestionsById(int id)
        {
            try
            {
                var result = _college_Questions.GetQuestionById(id);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("GetQuestions by Id Exception Error: " + xc);
            }
        }

        [HttpPost("addquestions")]
        public ActionResult AddQuestions([FromBody] Questions questions)
        {
            try
            {
                var result = _college_Questions.AddQuestion(questions);
                return Ok(result);

            }
            catch (Exception xc)
            {
                return BadRequest("AddQuestions  Exception Error: " + xc);
            }
        }

        [HttpPost("deletequestion")]
        public ActionResult DeleteQuestion([FromBody] Questions questions)
        {
            try
            {
                var result = _college_Questions.DeleteQuestion(questions);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("DeleteQuestion Exception Error: " + xc);
            }
        }

        [HttpPost("updatequestion")]
        public ActionResult UpdateQuestion([FromBody] Questions questions)
        {
            try
            {
                bool result = _college_Questions.UpdateQuestion(questions);
                return Ok(result);
            }
            catch (Exception xc)
            {
                return BadRequest("UpdateQuestions  Exception Error: " + xc);
            }

        }


    }
}
