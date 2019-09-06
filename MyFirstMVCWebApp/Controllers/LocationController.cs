using MyFirstMVCWebApp.Models;
using MyFirstMVCWebApp.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyFirstMVCWebApp.Controllers
{
    [RoutePrefix("api/Location")]
    public class LocationController : ApiController
    {
        LocationDB locationDB = new LocationDB();
        [Route("GetAllLocations")]
        public List<Lokacija> GetAllLocations()
        {
            List<Lokacija> ret = null;
            ret = locationDB.GetAll();
            return ret;
        }


    }
}
