using AgileEnglish.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileEnglish.Controllers
{
    public class UserPageController : Controller
    {
        private User currentUser;

        public ActionResult UserPage()
        {
            User user = (User)TempData["user"];
            if (currentUser == null)
            {
                currentUser = user;
            }

            return View("UserPage", currentUser);
        }
    }
}