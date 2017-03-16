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
        private IParkDAL parkDal;

        public SurveyController(ISurveyDAL surveyDal, IParkDAL parkDal)
        {
            this.surveyDal = surveyDal;
            this.parkDal = parkDal;
        }
        // GET: Survey
        public ActionResult SurveyInput()
        {
            SurveyModel survey = new SurveyModel();
            List<ParksModel> parks = parkDal.GetParks();
            foreach (ParksModel park in parks)
            {
                survey.Parks.Add(new SelectListItem() { Text = park.ParkName, Value = park.ParkCode });
            }
            return View("SurveyInput", survey);
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