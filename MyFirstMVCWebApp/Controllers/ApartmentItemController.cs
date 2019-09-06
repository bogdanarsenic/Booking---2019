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
    [RoutePrefix("api/ApartmentItem")]
    public class ApartmentItemController : ApiController
    {
        ApartmentItemDB apartmentItemDB = new ApartmentItemDB();

        [Route("GetAllApartmentItems")]
        public List<SadrzajApartman> GetAllApartmentItems()
        {
            List<SadrzajApartman> ret = null;
            ret = apartmentItemDB.GetAll();
            return ret;

        }
    }
}
