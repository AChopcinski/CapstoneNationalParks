using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class ParksController : Controller
    {
        private IParkDAL dal;

        public ParksController(IParkDAL dal)
        {
            this.dal = dal;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<ParksModel> list = dal.GetParks();
            return View("Index", list);
        }

        public ActionResult ParkDetail(string id)
        {
           ParksModel model = dal.GetPark(id);

            return View("ParkDetail", model);
        }

        //public ActionResult GetWeather(string id)
        //{
        //    WeatherForecastModel model = dal.GetWeather(id);

        //    return View("WeatherForecast", model);
        //}
    }
}