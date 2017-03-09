using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.Web.Models
{
    public class WeatherForecastModel
    {
        public string ParkCode { get; set; }
        public int FiveDayForecastValue { get; set; }
        public int Low { get; set; }
        public int High { get; set; }
        public string Forecast { get; set; }
        public string ParkName { get; set; }
        public string WeatherStatement { get; set; }
        public bool IsFarenheit { get; set; }

        public string GetWeatherStatement(string Forecast, int Low, int High)
        {
            string output = " ";

            if (Forecast == "snow")
            {
                output += "Pack snow shoes. ";
            }
            if (Forecast == "rain")
            {
                output += "Pack raingear and wear water-proof shoes. ";
            }
            if (Forecast == "thunderstorms")
            {
                output += "Seek shelter and avoid hiking on exposed ridges. ";
            }
            if (Forecast == "sunny")
            {
                output += "Pack sunblock. ";
            }
            if (Math.Abs(High - Low) > 20)
            {
                output += "Wear breathable layers. ";
            }
            if (Low < 20)
            {
                output += "You might be exposed to frigid temperatures.  Plan accordingly. ";
            }
            if (High > 75)
            {
                output += "Bring an extra gallon of water! ";
            }
            if (output == " ")
            {
                output += "What a wonderful day to enjoy nature! ";
            }

            return output;
        }
        public double CelsiusCalculation(int temperature)
        {
            //method for calculation
           double temp;
            temp = Math.Round((temperature - 32) * (.56), 0);
            return temp;
        }


    }



    //if isfarenthit is true print it this way, if not print it that way
}