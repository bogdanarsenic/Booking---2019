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
    [RoutePrefix("api/Comment")]
    public class CommentController : ApiController
    {
        UserDB userDB = new UserDB();
        ApartmentDB apartmentDB = new ApartmentDB();
        ApartmentItemDB apartmentItemDB = new ApartmentItemDB();
        CommentDB commentDB = new CommentDB();
        LocationDB locationDB = new LocationDB();
        ReservationDB reservationDB = new ReservationDB();

        [Route("GetAllByApartmentId")]
        public List<Komentari> GetAllByApartmentId(string Id)
        {
            List<Komentari> ret = null;
            ret = commentDB.GetAllByApartmentId(Id);
            return ret;
        }

        [Route("GetAllByApartmentIdGuest")]
        public List<Komentari> GetAllByApartmentIdGuest(string Id)
        {
            List<Komentari> ret = null;
            ret = commentDB.GetAllByApartmentIdGuest(Id);
            return ret;
        }


        [Route("RegisterComment")]
        public string RegisterComment(Komentari com)
        {
            com.Id = Guid.NewGuid();
            commentDB.Insert(com);
            return "Success";
        }



        [Route("GetOneCommentApproved")]
        public string GetOneCommentApproved(Guid IdA)
        {
            try
            {
                string IdTemp = IdA.ToString();
                commentDB.Approve(IdTemp);
            }
            catch
            {
                return "Error!";
            }

            return "Success!";
        }


    }
}
