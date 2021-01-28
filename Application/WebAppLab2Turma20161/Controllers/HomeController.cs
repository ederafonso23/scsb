using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppLab2Turma20161.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult JQuery()
        {
            return View();
        }

       
        public ActionResult Index()
        {
            //DiagramaDeClasse.DiagramaDeClasse.GerarDiagrama();
            return View();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

       
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}