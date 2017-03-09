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

        private const string SQL_GetWeather = "SELECT * FROM weather WHERE parkCode = @parkCode;";
        private const string SQL_GetParkName = "SELECT parkName from park WHERE parkCode = @parkCode;";

        public WeatherForecastSqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<WeatherForecastModel> GetWeatherF(string id)
        {
            //WeatherForecastModel w = new WeatherForecastModel();
            List<WeatherForecastModel> weathers = new List<WeatherForecastModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetWeather, conn);
                    cmd.Parameters.AddWithValue("@parkCode", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        WeatherForecastModel w = new WeatherForecastModel();
                        w.ParkCode = Convert.ToString(reader["parkCode"]);
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);
                        weathers.Add(w);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return weathers;
        }
        public List<WeatherForecastModel> GetWeatherC(string id)
        {
            //WeatherForecastModel w = new WeatherForecastModel();
            List<WeatherForecastModel> weathers = new List<WeatherForecastModel>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetWeather, conn);
                    cmd.Parameters.AddWithValue("@parkCode", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        WeatherForecastModel w = new WeatherForecastModel();
                        w.ParkCode = Convert.ToString(reader["parkCode"]);
                        w.FiveDayForecastValue = Convert.ToInt32(reader["fiveDayForecastValue"]);
                        w.Low = Convert.ToInt32(reader["low"]);
                        w.High = Convert.ToInt32(reader["high"]);
                        w.Forecast = Convert.ToString(reader["forecast"]);
                        weathers.Add(w);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return weathers;
        }

        public ParksModel GetParkName(string id)
        {
            ParksModel p = new ParksModel();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_GetParkName, conn);
                    cmd.Parameters.AddWithValue("@parkCode", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        p.ParkName = Convert.ToString(reader["parkName"]);
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return p;
        }

        //    ublic string WeatherDetail()
        //    {
        //      ;
        //    }
        //}p

    }
}
