using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Capstone.Web.Models;


namespace Capstone.Web.DAL
{
    public interface IParkDAL
    {
        List<ParkModel> GetParks();
        ParkModel GetParks(string ParkCode);
    }
}