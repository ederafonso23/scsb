using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Areas.Administracao.Controllers
{
    public class HomeController : Controller
    {
        // GET: Administracao/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}