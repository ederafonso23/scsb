using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Areas.Administracao.Controllers
{
    public class BaseController : Controller
    {
        #region Variables


        protected string ControllerName
        {
            get
            {
                return (string)RouteData.Values["controller"];
            }
        }

        #endregion


        // GET: Base
        public ActionResult NavigatorBar()
        {
            return PartialView("NavigatorBarContainer");
        }

        public ActionResult NavigatorBarList()
        {
            return PartialView("NavigatorBarList");
        }

        public ActionResult Breadcrumbs()
        {
            return PartialView("BreadcrumbsPartial");
        }

        public ActionResult Footer()
        {
            return PartialView("FooterPartial");
        }
    }
}