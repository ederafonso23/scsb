using PagedList;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppLab2Turma20161.Models;
using WebAppLab2Turma20161.Models.ViewModels;


namespace WebAppLab2Turma20161.Controllers
{

    [Authorize(Roles = "Administrador")]
    public class ProdutoController : Controller
    {
        private ContextoEF db = new ContextoEF();

        [AllowAnonymous]
        public ActionResult ConsultarProduto(int? pagina, string nomeProduto = null)
        {
            int tamanhoPagina = 3;
            int numeroPagina = pagina ?? 1;
            var produto = new Object();

            if (!String.IsNullOrEmpty(nomeProduto))
            {
                produto = db.Produtos
                    .Where(c => c.Descricao.ToUpper().Contains(nomeProduto.ToUpper()))
                    .OrderBy(c => c.Descricao)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                produto = db.Produtos.OrderBy(p => p.Descricao).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", produto);
        }

       
        public ActionResult FiltroPorIntervaloValor()
        {
            var filtroProdutoPorIntervadoValor = db.Produtos
                    .Where(p => p.Valor >= 100 && p.Valor <= 1800)
                    .Select(
                         p => new ProdutoPorIntervaloValorViewModel {
                             CodigoProduto = p.ProdutoID
                            ,ValorProduto = p.Valor
                            ,NomeProduto = p.Descricao
                         }
                            ).ToList();

            return View(filtroProdutoPorIntervadoValor);
        }

     
        public ActionResult ProdutosCategorias()
        {

            var ProdutosCategorias = (from p in db.Produtos
                                      join c in db.Categorias
                                      on p.CategoriaID equals c.CategoriaID
                                      orderby p.Descricao
                                      select new ProdutoCategoriaViewModel
                                      {
                                          CodigoProduto = p.ProdutoID
                                         ,DescricaoProduto = p.Descricao
                                         ,CodigoCategoria = c.CategoriaID
                                         ,DescricaoCategoria = c.Descricao

                                      }).ToList();

            return View(ProdutosCategorias);
        }

        // GET: Produto
        [AllowAnonymous]
        public ActionResult Index(string ordenacao, int? pagina)
        {

            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.NomeCatParam = String.IsNullOrEmpty(ordenacao) ? "NomeCat_desc" : "";
            ViewBag.ProdutoParam = ordenacao == "Produto" ? "Produto_desc" : "Produto";
            ViewBag.ValorParam = ordenacao == "Valor" ? "Valor_desc" : "Valor";

            var produtos = from c in db.Produtos select c;

            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;


            switch (ordenacao)
            {
                case "NomeCat_desc":
                    produtos = produtos.OrderByDescending(s => s.Categoria.Descricao);
                    break;
                case "Produto":
                    produtos = produtos.OrderBy(s => s.Descricao);
                    break;
                case "Produto_desc":
                    produtos = produtos.OrderByDescending(s => s.Descricao);
                    break;
                case "Valor":
                    produtos = produtos.OrderBy(s => s.Valor);
                    break;
                case "Valor_desc":
                    produtos = produtos.OrderByDescending(s => s.Valor);
                    break;
                default:
                    produtos = produtos.OrderBy(s => s.Categoria.Descricao);
                    break;
            }



            return View(produtos.ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Produto/Details/5
     
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produto/Create
     
        public ActionResult Create()
        {
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProdutoID,CategoriaID,Descricao,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Produtos.Add(produto);
                db.SaveChanges();
                TempData["Mensagem"] = "Produto cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProdutoID,CategoriaID,Descricao,Valor")] Produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Produto atualizado com sucesso!";
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaID = new SelectList(db.Categorias, "CategoriaID", "Descricao", produto.CategoriaID);
            return View(produto);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = db.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Produto produto = db.Produtos.Find(id);
            db.Produtos.Remove(produto);
            db.SaveChanges();
            TempData["Mensagem"] = "Produto excluído com sucesso!";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
