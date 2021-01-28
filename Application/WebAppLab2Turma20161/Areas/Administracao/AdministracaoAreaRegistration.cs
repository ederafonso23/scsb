using System.Web.Mvc;

namespace WebAppEvento.Areas.Administracao
{
    public class AdministracaoAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administracao";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administracao_default",
                "Administracao/{controller}/{action}/{id}",
                 new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Areas.Administracao.Controllers" }

            );
        }
    }
}