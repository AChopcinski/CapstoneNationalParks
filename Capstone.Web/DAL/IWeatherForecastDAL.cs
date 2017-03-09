﻿using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public interface IWeatherForecastDAL
    {
        List<WeatherForecastModel> GetWeather(string id);
        ParksModel GetParkName(string id);
       
    }
}