using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL surveyDal;

        public SurveyController(ISurveyDAL surveyDal)
        {
            this.surveyDal = surveyDal;
        }
        // GET: Survey
        public ActionResult SurveyInput()
        {
            return View("SurveyInput");
        }

        [HttpPost]
        public ActionResult GetSurvey(SurveyModel newEntry)
        {
            surveyDal.SaveSurvey(newEntry);
            return RedirectToAction("SubmitSurvey", "Survey");
        }

        [HttpGet]
        public ActionResult SubmitSurvey()
        {
            return View ("SurveyResults", surveyDal.GetSurveyResults());
        }
        
    }
}