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
        public ActionResult GetWeatherF(string id)
        {
             List<WeatherForecastModel> model = dal.GetWeatherF(id);

            return View("WeatherF", model);
        }

        public ActionResult GetWeatherC(string id)
        {
            List<WeatherForecastModel> model = dal.GetWeatherC(id);

            return View("WeatherC", model);
        }

        //public ActionResult GetParkName(string id)
        //{
        //   ParksModel p = dal.GetParkName(id);

        //    return View("Weather", p);
        //}

        public ActionResult WeatherDetailF()
        {
            return View("WeatherF");
        }

        public ActionResult WeatherDetailC()
        {
            return View("WeatherC");
        }


        public ActionResult TemperatureType()
        {
            Session["isFarenheit"] = true;

            return View("Weather");
        }

        public ActionResult SwitchToCelsius()
        {
            Session["isFarenheit"] = false;

            return View("Weather");
        }
    }
}