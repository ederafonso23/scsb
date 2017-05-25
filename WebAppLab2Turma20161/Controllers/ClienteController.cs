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

namespace WebAppLab2Turma20161.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ClienteController : Controller
    {
        private ContextoEF db = new ContextoEF();

     /*   public ActionResult UltimoClienteCadastrado()
        {
          var ultimoClienteCadastrado = db.Clientes.ToList().LastOrDefault();
            return View(ultimoClienteCadastrado);
        }

        public ActionResult MediaIdadeCliente()
        {
            var mediaIdadeCliente = db.Clientes.Average(c => c.Idade);
            ViewBag.MediaIdadeCliente = mediaIdadeCliente;
            return View();
        }

        public ActionResult ClienteMaisVelho()
        {
            var clienteMaiorIdade = db.Clientes.Max(c => c.Idade);
            ViewBag.Idade = clienteMaiorIdade;
            return View();
        }

        public ActionResult ClientesMaioresDeIdade()
        {

            var clientesMaioresIdade = db.Clientes.Where(c => c.Idade > 18).ToList();
            return View(clientesMaioresIdade);
        } */

        public ActionResult ConsultarCliente(int? pagina, string nomeCliente = null)
        {
            int tamanhoPagina = 3;
            int numeroPagina = pagina ?? 1;
            var cliente = new Object();

            if (!String.IsNullOrEmpty(nomeCliente))
            {
                cliente = db.Clientes
                    .Where(c => c.Nome.ToUpper().Contains(nomeCliente.ToUpper()))
                    .OrderBy(c => c.Nome)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else 
            {
                cliente = db.Clientes.OrderBy(p => p.Nome).ToPagedList(numeroPagina, tamanhoPagina);      
            }
            return View("Index", cliente);
        }

        // GET: Cliente
        public ActionResult Index(string ordenacao, int? pagina)
        {
            ViewBag.OrdenacaoAtual = ordenacao;
            ViewBag.NomeParam = String.IsNullOrEmpty(ordenacao) ? "Nome_desc" : "";
            ViewBag.DataNascimentoParam = ordenacao == "DataNascimento" ? "DataNascimento_desc" : "DataNascimento";
            ViewBag.CPFParam = ordenacao == "CPF" ? "CPF_desc" : "CPF";
            ViewBag.EnderecoParam = ordenacao == "Endereco" ? "Endereco_desc" : "Endereco";
            ViewBag.CEPParam = ordenacao == "CEP" ? "CEP_desc" : "CEP";

            var clientes = from c in db.Clientes select c;


            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;

            switch (ordenacao)
            {
                case "Nome_desc":
                    clientes = clientes.OrderByDescending(s => s.Nome);
                    break;
                case "DataNascimento":
                    clientes = clientes.OrderBy(s => s.DataNascimento);
                        break;
                case "DataNascimento_desc":
                    clientes = clientes.OrderByDescending(s => s.DataNascimento);
                    break;
                case "CPF":
                    clientes = clientes.OrderBy(s => s.CPF);
                    break;
                case "CPF_desc":
                    clientes = clientes.OrderByDescending(s => s.CPF);
                    break;
                case "Endereco":
                    clientes = clientes.OrderBy(s => s.Endereco);
                    break;
                case "Endereco_desc":
                    clientes = clientes.OrderByDescending(s => s.Endereco);
                    break;
                case "CEP":
                    clientes = clientes.OrderBy(s => s.CEP);
                    break;
                case "CEP_desc":
                    clientes = clientes.OrderByDescending(s => s.CEP);
                    break;
                default:
                    clientes = clientes.OrderBy(s => s.Nome);
                    break;
            }



            return View(clientes.ToPagedList(numeroPagina, tamanhoPagina));
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,Nome,DataNascimento,CPF,Endereco,CEP")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                TempData["Mensagem"] = "Cliente Cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,Nome,DataNascimento,CPF,Endereco,CEP")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Cliente atualizado com sucesso!";
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
            db.SaveChanges();
            TempData["Mensagem"] = "Cliente excluído com sucesso!";
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
