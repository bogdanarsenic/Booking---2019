using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyFirstMVCWebApp.Models;
using MyFirstMVCWebApp.ModelsDB;

namespace MyFirstMVCWebApp.Controllers
{
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        UserDB userDB = new UserDB();

       [Route("Register")]
       public string Register(User user)
        {
            if(userDB.GetOne(user.Username)!=null)
            {
                return "Username already exist!";
            }

            User temp = new User();

            temp.Id = Guid.NewGuid();
            temp.Name = user.Name;
            temp.Surname = user.Surname;
            temp.Username = user.Username;
            temp.Password = user.Password;
            temp.Gender = user.Gender;
            temp.Role = "Guest";
            userDB.Insert(temp);
            return "Success!";
        }
    }
}