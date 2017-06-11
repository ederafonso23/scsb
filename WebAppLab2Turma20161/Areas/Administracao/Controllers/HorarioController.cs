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
    //[Authorize(Roles = "Administrador")]
    //public class HorarioController : Controller
    //{
    //    private ContextoEF db = new ContextoEF();

    //    public ActionResult ConsultarCliente(int? pagina, string nomeCliente = null)
    //    {
    //        int tamanhoPagina = 3;
    //        int numeroPagina = pagina ?? 1;
    //        var cliente = new Object();

    //        if (!String.IsNullOrEmpty(nomeCliente))
    //        {
    //            cliente = db.Horarios
    //                .Where(c => c.Cliente.Nome.ToUpper().Contains(nomeCliente.ToUpper()))
    //                .OrderBy(c => c.Cliente.Nome)
    //                .ToPagedList(numeroPagina, tamanhoPagina);
    //        }
    //        else
    //        {
    //            cliente = db.Horarios.OrderBy(p => p.Cliente.Nome).ToPagedList(numeroPagina, tamanhoPagina);
    //        }
    //        return View("Index", cliente);
    //    }

    //    // GET: Horario
    //    public ActionResult Index(string ordenacao, int? pagina)
    //    {

    //        ViewBag.OrdenacaoAtual = ordenacao;
    //        ViewBag.NomeParam = String.IsNullOrEmpty(ordenacao) ? "Nome_desc" : "";
    //        ViewBag.DescricaoParam = ordenacao == "Descricao" ? "Descricao_desc" : "Descricao";
    //        ViewBag.DataParam = ordenacao == "Data" ? "Data_desc" : "Data";
    //        ViewBag.HorarioParam = ordenacao == "Horario" ? "Horario_desc" : "Horario";
          

    //        var horarios = from c in db.Horarios select c;

    //        int tamanhoPagina = 5;
    //        int numeroPagina = pagina ?? 1;

    //        switch (ordenacao)
    //        {
    //            case "Nome_desc":
    //                horarios = horarios.OrderByDescending(s => s.Cliente.Nome);
    //                break;
    //            case "Descricao":
    //                horarios = horarios.OrderBy(s => s.Descricao);
    //                break;
    //            case "Descricao_desc":
    //                horarios = horarios.OrderByDescending(s => s.Descricao);
    //                break;
    //            case "Data":
    //                horarios = horarios.OrderBy(s => s.DataAtendimento);
    //                break;
    //            case "Data_desc":
    //                horarios = horarios.OrderByDescending(s => s.DataAtendimento);
    //                break;
    //            case "Horario":
    //                horarios = horarios.OrderBy(s => s.HorarioAtendimento);
    //                break;
    //            case "Horario_desc":
    //                horarios = horarios.OrderByDescending(s => s.HorarioAtendimento);
    //                break;
             
    //            default:
    //                horarios = horarios.OrderBy(s => s.Cliente.Nome);
    //                break;
    //        }



    //        return View(horarios.ToPagedList(numeroPagina, tamanhoPagina));



    //        return View(db.Horarios.OrderBy(p => p.Cliente.Nome).ToPagedList(numeroPagina, tamanhoPagina));
    //    }

    //    // GET: Horario/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Horario horario = db.Horarios.Find(id);
    //        if (horario == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(horario);
    //    }

    //    // GET: Horario/Create
    //    public ActionResult Create()
    //    {
    //        ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
    //        return View();
    //    }

    //    // POST: Horario/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create(Horario horario)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Horarios.Add(horario);
    //            db.SaveChanges();
    //            TempData["Mensagem"] = "Horário cadastrado com sucesso!";
    //            return RedirectToAction("Index");
    //        }

    //        return View(horario);
    //    }

    //    // GET: Horario/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Horario horario = db.Horarios.Find(id);
    //        if (horario == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(horario);
    //    }

    //    // POST: Horario/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "HorarioID,Descricao,DataAtendimento,HorarioAtendimento")] Horario horario)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(horario).State = EntityState.Modified;
    //            db.SaveChanges();
    //            TempData["Mensagem"] = "Horário atualizado com sucesso!";
    //            return RedirectToAction("Index");
    //        }
    //        return View(horario);
    //    }

    //    // GET: Horario/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Horario horario = db.Horarios.Find(id);
    //        if (horario == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(horario);
    //    }

    //    // POST: Horario/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Horario horario = db.Horarios.Find(id);
    //        db.Horarios.Remove(horario);
    //        db.SaveChanges();
    //        TempData["Mensagem"] = "Horário excluído com sucesso!";
    //        return RedirectToAction("Index");
    //    }

    //    protected override void Dispose(bool disposing)
    //    {
    //        if (disposing)
    //        {
    //            db.Dispose();
    //        }
    //        base.Dispose(disposing);
    //    }
    //}
}
