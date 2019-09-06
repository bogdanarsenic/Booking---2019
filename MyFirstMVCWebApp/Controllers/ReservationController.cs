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
    [RoutePrefix("api/Reservation")]
    public class ReservationController : ApiController
    {
        UserDB userDB = new UserDB();
        ApartmentDB apartmentDB = new ApartmentDB();
        ApartmentItemDB apartmentItemDB = new ApartmentItemDB();
        CommentDB commentDB = new CommentDB();
        LocationDB locationDB = new LocationDB();
        ReservationDB reservationDB = new ReservationDB();

        [Route("GetAllReservations")]
        public List<Rezervacija> GetAllReservations()
        {
            List<Rezervacija> ret = null;
            ret = reservationDB.GetAll();
            return ret;
        }

        [Route("GetAllReservationsApartment")]
        public List<Rezervacija> GetAllReservationsApartment(string IdAp)
        {
            List<Rezervacija> ret = null;
            ret = reservationDB.GetAllByApId(IdAp);
            return ret;
        }

        [Route("RegisterReservation")]
        public string RegisterReservation(Rezervacija res)
        {
            res.Id = Guid.NewGuid();
            res.StartingDate = Convert.ToDateTime(res.DaniRezervacije);
            reservationDB.Insert(res);
            return "Success";
        }

        [Route("GetAllReservationsHost")]
        public List<Rezervacija> GetAllReservationsHost(string IdHost)
        {
            List<Rezervacija> ret1 = null;
            List<Rezervacija> ret2 = new List<Rezervacija>();
            User U = userDB.GetOneByID(new Guid(IdHost));
            ret1 = reservationDB.GetAll();
            foreach (Rezervacija r in ret1)
            {
                r.Apartman = apartmentDB.GetOneById(r.ApartmanId);

                if (r.Apartman.Host == U.Name + " " + U.Surname)
                {
                    ret2.Add(r);
                }
            }
            return ret2;
        }


        [Route("GetAllReservationsGuest")]
        public List<Rezervacija> GetAllReservationsGuest(string IdGuest)
        {
            List<Rezervacija> ret1 = null;
            List<Rezervacija> ret2 = new List<Rezervacija>();
            User U = userDB.GetOneByID(new Guid(IdGuest));
            ret1 = reservationDB.GetAll();
            foreach (Rezervacija r in ret1)
            {
                if (r.UserId == IdGuest)
                {
                    ret2.Add(r);
                }
            }
            return ret2;
        }
    }
}