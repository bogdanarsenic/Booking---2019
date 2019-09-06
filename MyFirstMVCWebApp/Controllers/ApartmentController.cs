using MyFirstMVCWebApp.Models;
using MyFirstMVCWebApp.ModelsDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace MyFirstMVCWebApp.Controllers
{
    [RoutePrefix("api/Apartment")]
    public class ApartmentController : ApiController
    {

            UserDB userDB = new UserDB();
            ApartmentDB apartmentDB = new ApartmentDB();
            ApartmentItemDB apartmentItemDB = new ApartmentItemDB();
            CommentDB commentDB = new CommentDB();
            LocationDB locationDB = new LocationDB();
            ReservationDB reservationDB = new ReservationDB();

            [Route("GetAllApartments")]
            public List<Apartman> GetAllApartments()
            {
                List<Apartman> ret = null;
                ret = apartmentDB.GetAll();
                return ret;

            }

            [Route("GetAllApartmentsGuest")]
            public List<Apartman> GetAllApartmentsGuest()
            {
                List<Apartman> ret = null;
                ret = apartmentDB.GetAllGuest();
                return ret;

            }


            [Route("GetOneApartmentAddedImage")]
            public string GetOneApartmentAddedImage(string IdAp, string ImgName)
            {
                Apartman temp = apartmentDB.GetOneById(IdAp);
                if (temp.Pictures == "")
                {
                    temp.Pictures = ImgName;
                }
                else
                {
                    temp.Pictures = temp.Pictures + ";" + ImgName;
                }

                apartmentDB.Update(temp);
                return "Success";

            }




            [Route("RegisterApartment")]
            public string RegisterApartment(Apartman register)
            {
                string[] temp = register.Amenities.Split(';');
                temp[0] = temp[0].Substring(9);
                register.Amenities = "";
                foreach (string a in temp)
                {
                    register.Amenities += a + ';';
                }
                register.Amenities = register.Amenities.Remove(register.Amenities.Length - 1);
                register.Address = GetAddress(register.Latitude.ToString(), register.Longitude.ToString());
                register.Id = Guid.NewGuid();
                register.RentedDates = "";
                register.Pictures = "";
                register.IsDeleted = false;
                register.IsActive = false;
                apartmentDB.Insert(register);

                return register.Id.ToString();
            }

            [Route("UpdateFreeDates")]
            public string UpdateFreeDates(Apartman apartment)
            {
                apartmentDB.UpdateFreeDates(apartment);
                return "Success";

            }


            [Route("GetAllApartmentsByUserId")]
            public List<Apartman> GetAllApartmentsByUserId(string IdAp)
            {
                List<Apartman> ret = null;
                ret = apartmentDB.GetAllByUserId(IdAp);
                return ret;

            }

            [Route("GetOneApartment")]
            public Apartman GetOneApartment(Guid Id)
            {
                string idTemp = Id.ToString();
                Apartman ret = null;
                ret = apartmentDB.GetOneById(idTemp);
                return ret;

            }

            [Route("GetOneApartmentUpdate")]
            public string GetOneApartmentUpdate(Guid IdA)
            {
                try
                {
                    string IdTemp = IdA.ToString();
                    apartmentDB.Delete(IdTemp);
                }
                catch
                {
                    return "Error!";
                }

                return "Success!";
            }


            private string GetAddress(string latitude, string longitude)
            {
                string apiKey = "AIzaSyDSTqAtW8AcMgmi5v9AgrdL-12ovbTMHSc";
                string locationName = "";
                string url = string.Format("https://maps.googleapis.com/maps/api/geocode/xml?key={0}&latlng={1},{2}&sensor=false", apiKey, latitude, longitude);
                XElement xml = XElement.Load(url);
                if (xml.Element("status").Value == "OK")
                {
                    locationName = string.Format("{0}",
                        xml.Element("result").Element("formatted_address").Value);

                }
                return locationName;

            }
            
        }
    }

