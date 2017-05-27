using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebAppLab2Turma20161.Models;

namespace Areas.Administracao.Controllers
{

    [Authorize(Roles = "Administrador")]
    public class CategoriaController : Controller
    {
        private ContextoEF db = new ContextoEF();

        public ActionResult ConsultarCategoria(int? pagina, string nomeCategoria = null)
        {
            int tamanhoPagina = 3;
            int numeroPagina = pagina ?? 1;
            var categoria = new Object();

            if (!String.IsNullOrEmpty(nomeCategoria))
            {
                categoria = db.Categorias
                    .Where(c => c.Descricao.ToUpper().Contains(nomeCategoria.ToUpper()))
                    .OrderBy(c => c.Descricao)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                categoria = db.Categorias.OrderBy(p => p.Descricao).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", categoria);
        }

        // GET: Categoria
        public ActionResult Index(string ordenacao, int? pagina)
        {

            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.DescricaoParam = String.IsNullOrEmpty(ordenacao) ? "Descricao_desc" : "";
            

            var categorias = from c in db.Categorias select c;


            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;


            switch (ordenacao)
            {
                case "Descricao_desc":
                    categorias = categorias.OrderByDescending(s => s.Descricao);
                    break;
                default:
                    categorias = categorias.OrderBy(s => s.Descricao);
                    break;
            }


            return View(categorias.ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoriaID,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Categorias.Add(categoria);
                db.SaveChanges();
                TempData["Mensagem"] = "Categoria cadastrada com sucesso!";
                return RedirectToAction("Index");
            }

            return View(categoria);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoriaID,Descricao")] Categoria categoria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(categoria).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Categoria atualizada com sucesso!";
                return RedirectToAction("Index");
            }
            return View(categoria);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Categoria categoria = db.Categorias.Find(id);
            if (categoria == null)
            {
                return HttpNotFound();
            }
            return View(categoria);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Categoria categoria = db.Categorias.Find(id);
            db.Categorias.Remove(categoria);
            db.SaveChanges();
            TempData["Mensagem"] = "Categoria excluída com sucesso!";
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
