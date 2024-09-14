using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeChemistryAdmin.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly Interface_Questions _college_chem_interface_questions;
        private readonly ILogger<QuestionsController> _logger;
        public QuestionsController(Interface_Questions college_chem_interface_questions, ILogger<QuestionsController> logger)
        {
            _college_chem_interface_questions = college_chem_interface_questions;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var result = _college_chem_interface_questions.GetAllQuestions().ToList();
                return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }
        public IActionResult AddUpdateQuestion(int id)
        {
            try
            {
                ViewBag.Questionid = id;
                var result = _college_chem_interface_questions.GetQuestionById(id);
                return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }

        }

        [HttpPost]
        public IActionResult InsertQuestion(Questions questions)
        {
            try
            {
                questions.created_at = DateTime.UtcNow;
                var result = _college_chem_interface_questions.AddQuestion(questions);
                return RedirectToAction("Index", "Questions");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult UpdateQuestions(Questions questions)
        {
            try
            {
                questions.updated_at = DateTime.UtcNow;
                var result = _college_chem_interface_questions.UpdateQuestion(questions);
                if (result)
                {
                    // Redirect to the Index page if successful
                    return RedirectToAction("Index", "Questions");
                }
                else
                {
                    _logger.LogWarning("UpdateQuestion failed.");
                    return RedirectToAction("AddUpdateQuestion", "Questions");
                }
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult DeleteQuestion(Questions questions)
        {
            try
            {
                var result = _college_chem_interface_questions.DeleteQuestion(questions);
                return RedirectToAction("Index", "Questions");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult Publish_Unpublish_Questions(Questions questions)
        {
            try
            {

                var result = _college_chem_interface_questions.PublishQuestions(questions.id, questions.ispublish, questions.published_at);
                return RedirectToAction("Index", "Questions");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }


    }
}
