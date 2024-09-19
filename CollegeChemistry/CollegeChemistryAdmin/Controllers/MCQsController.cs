using CollegeChemistryLibrary.Entities;
using CollegeChemistryLibrary.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CollegeChemistryAdmin.Controllers
{
    public class MCQsController : Controller
    {
        private readonly Interface_MCQs _college_chem_interface_mcqs;
        private readonly ILogger<MCQsController> _logger;
        public MCQsController(Interface_MCQs college_chem_interface_mcqs, ILogger<MCQsController> logger)
        {
            _college_chem_interface_mcqs = college_chem_interface_mcqs;
            _logger = logger;
        }
        public IActionResult Index()
        {
            try
            {
                var result = _college_chem_interface_mcqs.GetAllMCQs().ToList();
                return View(result);
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        [HttpPost]
        public IActionResult InsertMCQ(MCQs mcq)
        {
            try
            {

                mcq.created_at = DateTime.UtcNow;
                var result = _college_chem_interface_mcqs.AddMCQ(mcq);
                return RedirectToAction("Index", "MCQs");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }


        [HttpPost]
        public IActionResult UpdateMCQ(MCQs mcq)
        {
            try
            {
                
                mcq.updated_at = DateTime.UtcNow;
                var result = _college_chem_interface_mcqs.UpdateMCQ(mcq);
                if (result)
                {
                    // Redirect to the Index page if successful
                    return RedirectToAction("Index", "MCQs");
                }
                else
                {
                    _logger.LogWarning("UpdateMCQ failed.");
                    return RedirectToAction("Index", "MCQs");
                }
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult DeleteMCQ(MCQs mcq)
        {
            try
            {
                var result = _college_chem_interface_mcqs.DeleteMCQ(mcq);
                return RedirectToAction("Index", "MCQs");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }

        public IActionResult Publish_Unpublish_MCQs(MCQs mcq)
        {
            try
            {

                var result = _college_chem_interface_mcqs.PublishMCQ(mcq.id, mcq.ispublish, mcq.published_at);
                return RedirectToAction("Index", "MCQs");
            }
            catch (Exception xc)
            {
                _logger.LogError(xc.ToString());
                return View("Error");
            }
        }
    }
}
