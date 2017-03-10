using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Capstone.Web.DAL
{
    public class SurveySqlDAL : ISurveyDAL
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["npgeek"].ConnectionString;
        private const string SQL_InsertSurvey = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        private const string SQL_SurveyResults = "SELECT park.parkName, count(survey_result.parkCode) AS occurrences FROM survey_result INNER JOIN park on park.parkCode = survey_result.parkCode GROUP BY park.parkName ORDER BY occurrences DESC;";
        private object newEntry;

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SaveSurvey(SurveyModel newEntry)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_InsertSurvey, conn);
                    cmd.Parameters.AddWithValue("@parkCode", newEntry.ParkCode);
                    cmd.Parameters.AddWithValue("@emailAddress", newEntry.EmailAddress);
                    cmd.Parameters.AddWithValue("@state", newEntry.State);
                    cmd.Parameters.AddWithValue("@activityLevel", newEntry.ActivityLevel);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        return true;
                    }
                }
            }
            catch (SqlException e)
            {
                throw;
            }
            return false;
        }

        public Dictionary<string, int> GetSurveyResults()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_SurveyResults, conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        result.Add(Convert.ToString(reader["parkName"]), Convert.ToInt32(reader["occurrences"]));
                    }
                }
            }
            catch (SqlException e)
            {
              throw;
            }

            return result;

        }
    }
}
