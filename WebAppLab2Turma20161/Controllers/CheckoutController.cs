using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebAppLab2Turma20161.Models;

namespace WebAppLab2Turma20161.Controllers
{

    [Authorize]
    public class CheckoutController : Controller
    {

        private ContextoEF db = new ContextoEF();
        const String PromoCode = "FREE";
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Pedido();

            TryUpdateModel(order);

            try
            {
                if (string.Equals(values["PromoCode"], PromoCode, StringComparison.OrdinalIgnoreCase) == false)
                {
                    return View(order);
                }
                else
                {
                    order.NomeUsuarioCliente = User.Identity.Name;
                    order.DataRegistro = DateTime.Now;

                    db.Pedidos.Add(order);
                    db.SaveChanges();

                    var cart = CarrinhoCompras.ObterCarrinhoAtual(this.HttpContext);
                    cart.CriarPedido(order);

                    db.SaveChanges();//we have received the total amount lets update it
                    ViewBag.TotalPedido = order.Total;
                    return RedirectToAction("Complete", new {id = order.PedidoId});
                }
            }
            catch(Exception ex)
            {
                ex.InnerException.ToString();
                return View(order);
            }
        }

        public ActionResult Complete(int id)
        {
            bool isValid = db.Pedidos.Any(
                o => o.PedidoId == id &&
                     o.NomeUsuarioCliente == User.Identity.Name
                );

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}