using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public interface IWeatherForecastDAL
    {
        List<WeatherForecastModel> GetWeatherF(string id);
        ParksModel GetParkName(string id);
        List<WeatherForecastModel> GetWeatherC(string id);
    }
}