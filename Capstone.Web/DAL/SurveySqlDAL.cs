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
        private const string SQL_InsertPost = "INSERT INTO survey_result VALUES (@parkCode, @emailAddress, @state, @activityLevel);";
        //private const string SQL_SurveyResult = "SELECT "

        public SurveySqlDAL(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool SaveNewSurvey(SurveyModel newEntry)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(SQL_InsertPost, conn);
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

        //public List<SurveyModel> GetSurveyResults()
        //{

        //}
    }
}
