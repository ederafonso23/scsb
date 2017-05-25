using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Areas.Administracao.Controllers
{
    public class FormsController : Controller
    {
        // GET: Forms
        public ActionResult Dropzone()
        {
            return View();
        }

        public ActionResult FormElements()
        {
            return View();
        }

        public ActionResult FormElements2()
        {
            return View();
        }

        public ActionResult FormWizard()
        {
            return View();
        }

        public ActionResult WYSIWYG()
        {
            return View();
        }
    }
}