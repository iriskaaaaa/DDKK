using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AgileEnglish.Controllers
{
  
    public class TestGameController : Controller
    {
        // GET: TestGame
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}