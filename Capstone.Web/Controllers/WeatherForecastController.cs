using Capstone.Web.DAL;
using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Controllers
{
    public class WeatherForecastController : Controller
    {
        private IWeatherForecastDAL dal;

        public WeatherForecastController(IWeatherForecastDAL dal)
        {
            this.dal = dal;
        }

        // GET: WeatherForecast
        public ActionResult GetWeather(string id)
        {
             List<WeatherForecastModel> model = dal.GetWeather(id);

            return View("Weather", model);
        }

        //public ActionResult GetParkName(string id)
        //{
        //   ParksModel p = dal.GetParkName(id);

        //    return View("Weather", p);
        //}

        public ActionResult WeatherDetail()
        {
            return View("Weather");
        }
    }
}