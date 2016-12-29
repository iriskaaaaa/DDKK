using AgileEnglish.Models.DataProvider;
using AgileEnglish.Models.Entities;
using AgileEnglish.Models.Helpers;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AgileEnglish.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ViewResult Index()
        {
            return View();
        }

        #region Modal controllers
        [HttpPost]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = user.Password.HashToSHA256();
                MongoDbProvider.Get.UsersRepository.InsertOneAsync(user);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult LogIn(User user)
        {
            User userEntity = null;
            if (ModelState.IsValid)
            {
                var usersRepository = MongoDbProvider.Get.UsersRepository;
                //var filter = Builders<BsonDocument>.Filter.Eq("Name", user.Name) & Builders<BsonDocument>.Filter.Eq("Password", user.Password.HashToSHA256());
                
             
                var result = usersRepository.FindAsync(x => x.Name == user.Name && x.Password == user.Password.HashToSHA256()).Result.SingleOrDefault();

                if (result != null)
                {
                    userEntity = result;//BsonSerializer.Deserialize<User>(result);

                    //if (dbUser != null)
                    //{
                    
                    FormsAuthentication.SetAuthCookie(user.Name, false);
                    TempData["user"] = userEntity;
                    return RedirectToAction("Index", "UserPage");
                    //}
                }
              
            }
            return RedirectToAction("Index", userEntity);
        }
        #endregion

        //public ActionResult RedirectToUserPage(User user)
        //{
        //    return View("/UserPage/Index", user);
        //}


        public ViewResult LogOut()
        {
            FormsAuthentication.SignOut();
            return View("Index");
        }

        public ViewResult UserPage()
        {
            //Implement this in another controller. Create UserController.
            return View();
        }
    }
}