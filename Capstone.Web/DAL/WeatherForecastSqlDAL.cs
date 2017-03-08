using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class WeatherForecastSqlDAL : IWeatherForecastDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["npgeek"].ConnectionString;

        private const string SQL_GetWeather = "SELECT * FROM weather WHERE parkCode = (@parkCode);";

        public WeatherForecastSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }


        public WeatherForecastModel GetWeather()
        {
            WeatherForecastModel w = new WeatherForecastModel();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetWeather, conn);
                    
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        w.ParkCode = Convert.ToString(reader["parkCode"]);
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return w;
        }

    }
}