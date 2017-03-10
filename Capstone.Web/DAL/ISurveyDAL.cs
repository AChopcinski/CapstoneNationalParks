using Capstone.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace Capstone.Web.DAL
{
    public interface ISurveyDAL
    {
       bool SaveSurvey(SurveyModel newEntry);

       Dictionary<string, int> GetSurveyResults();
       
    }
}
