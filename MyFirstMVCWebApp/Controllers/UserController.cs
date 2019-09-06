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
       
        public int Proba()
        {
                int brojac = 0;
                User admin = new User();
                string[] lines = System.IO.File.ReadAllLines(@"C:\Users\Bogdan\Desktop\MyFirstMVCWebApp\Admin.txt");

                foreach (string line in lines)
                {

                    string[] nesto = line.Split(',');

                    admin.Id = Guid.NewGuid();
                    admin.Username = nesto[0];
                    admin.Password = nesto[1];
                    admin.Name = nesto[2];
                    admin.Surname = nesto[3];
                    admin.Gender = nesto[4];
                    admin.Role = "Admin";
                    brojac++;
                    userDB.Insert(admin);
                }

                return brojac;
        
          }
       


        [Route("Register")]
        public string Register(User register)
        {           
            if(this.Proba()==0)
            {
                Proba();
            }

            if(userDB.GetOne(register.Username)!=null)
            {
                return "Username already exist!";
            }

            User temp = new User();

            temp.Id = Guid.NewGuid();
            temp.Name = register.Name;
            temp.Surname = register.Surname;
            temp.Username = register.Username;
            temp.Password = register.Password;
            temp.Gender = register.Gender;
            temp.Role = "Guest";
            userDB.Insert(temp);

            return "Success";
        }

        [Route("GetCurrent")]
        public User GetCurrent(string Username,string Password)
        {
            User user = null;

            user = userDB.GetOne(Username);

            if(user==null)
            {
                return null;
            }
            
            if(user.Password==Password)
            {
                return user;
            }
            return null;
        }

        [Route("GetAllUsers")]
        public List<User>GetAllUsers()
        {

            List<User> users = null;
            users=userDB.GetAll();
            return users;
        }

        [Route("Update")]
        public string Update(User register)
        {

            User temp = new User();
            temp.Id = register.Id;
            temp.Name = register.Name;
            temp.Surname = register.Surname;
            temp.Username = register.Username;
            temp.Password = register.Password;
            temp.Gender = register.Gender;
            temp.Role = register.Role;
            userDB.Update(temp);
            return "Success!";
        }

        [Route("RegisterHost")]
        public string RegisterHost(User register)
        {
            if (userDB.GetOne(register.Username) != null)
            {
                return "Username already exists!";
            }

            User temp = new User();
            temp.Id = Guid.NewGuid();
            temp.Name = register.Name;
            temp.Surname = register.Surname;
            temp.Username = register.Username;
            temp.Password = register.Password;
            temp.Gender = register.Gender;
            temp.Role = "Host";
            userDB.Insert(temp);
            return "Success!";
        }

        [Route("GetCurrentByUsername")]
        public User GetCurrentByUsername(string Username)
        {
            User u = null;
            u = userDB.GetOne(Username);
            if (u == null)
            {
                return null;
            }
            return u;
        }



    }
}