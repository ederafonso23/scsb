using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppLab2Turma20161.Models
{
    public partial class CarrinhoCompras
    {
        ContextoEF db = new ContextoEF();

        public string CarrinhoCompraId { get; set; }

        public const string CarrinhoSessionKey = "CarrinhoId";

        public static CarrinhoCompras ObterCarrinhoAtual(HttpContextBase context)
        {
            var carrinho = new CarrinhoCompras();

            carrinho.CarrinhoCompraId = carrinho.ObterCarrinhoCompraId(context);

            return carrinho;
        }

        public static CarrinhoCompras ObterCarrinhoAtual(Controller controller)
        {
            return ObterCarrinhoAtual(controller.HttpContext);
        }

        public void AdicionarNoCarrinho(Produto produto)
        {
            var itemCarrinho = db.Carrinhos
                .SingleOrDefault(c=>
                        c.CarrinhoId == CarrinhoCompraId && 
                        c.ProdutoId == produto.ProdutoId);

            if (itemCarrinho == null)
            {
                itemCarrinho = new Carrinho
                {
                    ProdutoId = produto.ProdutoId,
                    CarrinhoId = CarrinhoCompraId,
                    TotalItens = 1,
                    DataRegistro = DateTime.Now
                };
                db.Carrinhos.Add(itemCarrinho);
            }
            else
            {
                itemCarrinho.TotalItens++;
            }

            db.SaveChanges();
        }

        public int RemoverItemDoCarrinho(int id)
        {
            var itemCarrinho = db.Carrinhos
                .SingleOrDefault(c => 
                    c.CarrinhoId == CarrinhoCompraId && 
                    c.ProdutoId == id);

            int totalItens = 0;

            if (itemCarrinho != null)
            {
                if (itemCarrinho.TotalItens > 1)
                {
                    itemCarrinho.TotalItens--;
                    totalItens = itemCarrinho.TotalItens;
                }
                else
                {
                    db.Carrinhos.Remove(itemCarrinho);
                }

                db.SaveChanges();
            }
            return totalItens;
        }

        public void CarrinhoVazio()
        {
            var itensCarrinho = db.Carrinhos
                .Where(c => c.CarrinhoId == CarrinhoCompraId);

            foreach (var itemCarrinho in itensCarrinho)
            {
                db.Carrinhos.Remove(itemCarrinho);
            }
            db.SaveChanges();
        }

        public List<Carrinho> ObterItensCarrinho()
        {
            return db.Carrinhos
                .Where(c => 
                c.CarrinhoId == CarrinhoCompraId).ToList();
        }

        public int ObterTotalItens()
        {
            int? soma =
                (from itensCarrinho in db.Carrinhos
                 where itensCarrinho.CarrinhoId == 
                 CarrinhoCompraId
                 select (int?)itensCarrinho.TotalItens)
                 .Sum();

            return soma ?? 0;
        }

        public decimal ObterTotal()
        {
            decimal? total = (
                from itensCarrinho in db.Carrinhos
                where 
                    itensCarrinho.CarrinhoId == 
                    CarrinhoCompraId
                select 
                    (int?)itensCarrinho.TotalItens * 
                    itensCarrinho.Produto.Preco
                ).Sum();

            return total ?? decimal.Zero;
        }

        public int CriarPedido(Pedido clientePedido)
        {
            decimal totalPedido = 0;

            var itensCarrinho = ObterItensCarrinho();

            foreach (var item in itensCarrinho)
            {
                var produtoEncomendado = new ItensDoPedido
                {
                    ProdutoId = item.ProdutoId,
                    PedidoId = clientePedido.PedidoId,
                    Quantidade = item.TotalItens
                };

                totalPedido += (item.TotalItens * item.Produto.Preco);

                db.ProdutosEncomendados.Add(produtoEncomendado);
            }

            clientePedido.Total = totalPedido;

            db.SaveChanges();

            CarrinhoVazio();

            return clientePedido.PedidoId;
        }

        public string ObterCarrinhoCompraId(HttpContextBase context)
        {
            if (context.Session[CarrinhoSessionKey] == null)
            {
                if (!string.IsNullOrWhiteSpace(context.User.Identity.Name))
                {
                    context.Session[CarrinhoSessionKey] = context.User.Identity.Name;
                }

                else
                {
                    Guid tempCarrinhoCompraId = Guid.NewGuid();
                    context.Session[CarrinhoSessionKey] = tempCarrinhoCompraId.ToString();
                }
            }

            return context.Session[CarrinhoSessionKey].ToString();
        }

        public void MigrarCarrinhoCompra(string userName)
        {
            var carrinhoCompra = db.Carrinhos
                .Where(c => c.CarrinhoId == CarrinhoCompraId);
            foreach (Carrinho item in carrinhoCompra)
            {
                item.CarrinhoId = userName;
            }

            db.SaveChanges();
        }

    }
}