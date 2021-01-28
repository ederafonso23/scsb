using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using WebAppLab2Turma20161.Models;
using WebAppLab2Turma20161.ViewModels;

namespace WebAppLab2Turma20161.Controllers
{
    public class ShoppingCartController : Controller
    {
        private ContextoEF db = new ContextoEF();

        public ActionResult Index()
        {
            var cart = CarrinhoCompras.ObterCarrinhoAtual(this.HttpContext);

            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.ObterItensCarrinho(),
                CartTotal = cart.ObterTotal()
            };

            return View(viewModel);
        }

        public ActionResult AddToCart(int id)
        {
            var addedProduct = db.Produtos.Single(product => product.ProdutoId == id);

            var cart = CarrinhoCompras.ObterCarrinhoAtual(this.HttpContext);

            cart.AdicionarNoCarrinho(addedProduct);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            var cart = CarrinhoCompras.ObterCarrinhoAtual(this.HttpContext);

            string productName = db.Carrinhos.FirstOrDefault(item => item.ProdutoId == id).Produto.Nome;

            int itemCount = cart.RemoverItemDoCarrinho(id);

            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(productName) + " foi removido do seu carrinho de compras",
                CartTotal = cart.ObterTotal(),
                CartCount = cart.ObterTotalItens(),
                ItemCount = itemCount,
                DeleteId = id
            };

            return Json(results);
        }

        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = CarrinhoCompras.ObterCarrinhoAtual(this.HttpContext);

            ViewData["CartCount"] = cart.ObterTotalItens();
            return PartialView("CartSummary");
        }

    }
}