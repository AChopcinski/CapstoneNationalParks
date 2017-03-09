using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class SurveyController : Controller
    {
        private ISurveyDAL dal;
        // GET: Survey
        public ActionResult SurveyInput()
        {
            return View("SurveyInput");
        }

    //    [HttpPost]
    //    public ActionResult Index(SurveyModel newEntry)
    //    {
    //         dal.SaveNewSurvey(newEntry);
    //        return RedirectToAction("SubmitSurvey", "Survey");
    //    }
   
    //[HttpGet]
    //public ActionResult SubmitSurvey()
    //{
    //    List<ForumPost> model = forumPostDal.GetAllPosts();
    //    return View("AllPosts", model);
    //}
}
}