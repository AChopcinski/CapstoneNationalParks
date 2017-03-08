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
        public ActionResult GetWeather()
        {
             WeatherForecastModel model = dal.GetWeather();

            return View("WeatherForecast", model);
        }
    }
}