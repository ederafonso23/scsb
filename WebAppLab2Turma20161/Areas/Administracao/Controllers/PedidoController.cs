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

namespace Areas.Administracao.Controllers
{
    //[Authorize(Roles = "Administrador")]
    //public class PedidoController : Controller
    //{
    //    private ContextoEF db = new ContextoEF();


    //    public ActionResult GerarPDF(int id)
    //    {
    //        var modelo = db.Pedidos.Find(id);

    //        var pdf = new ViewAsPdf
    //        {
    //            ViewName = "DetailsParaImpressao",
    //            Model = modelo
    //        };

    //        return pdf;
    //    }

    //    public ActionResult ConsultarCliente(int? pagina, string nomeCliente = null)
    //    {
    //        int tamanhoPagina = 3;
    //        int numeroPagina = pagina ?? 1;
    //        var cliente = new Object();

    //        if (!String.IsNullOrEmpty(nomeCliente))
    //        {
    //            cliente = db.Pedidos
    //                .Where(c => c.Cliente.Nome.ToUpper().Contains(nomeCliente.ToUpper()))
    //                .OrderBy(c => c.Cliente.Nome)
    //                .ToPagedList(numeroPagina, tamanhoPagina);
    //        }
    //        else
    //        {
    //            cliente = db.Pedidos.OrderBy(p => p.Cliente.Nome).ToPagedList(numeroPagina, tamanhoPagina);
    //        }
    //        return View("Index", cliente);
    //    }
    //    //TODO: criar as seguintes actions methods: PedidosPorCodigoDoCliente, PrimeiroPedidoRealizado,
    //    //TodosPedidosDeClientes, TodosPedidosClientesEnviadoNaoEntregue,
    //    //DetalhesDoPedidoComFiltro
    //    //Utilize as consultas produzidas no LinqPad

    //    // GET: Pedido
    //    public ActionResult Index(string ordenacao, int? pagina)
    //    {
    //        ViewBag.OrdenacaoAtual = ordenacao;
    //        ViewBag.NomeParam = String.IsNullOrEmpty(ordenacao) ? "Nome_desc" : "";
    //        ViewBag.DataPedidoParam = ordenacao == "DataPedido" ? "DataPedido_desc" : "DataPedido";
    //        ViewBag.DataEnvioParam = ordenacao == "DataEnvio" ? "DataEnvio_desc" : "DataEnvio";
    //        ViewBag.DataEntregaParam = ordenacao == "DataEntrega" ? "DataEntrega_desc" : "DataEntrega";

    //        var pedidos = from c in db.Pedidos select c;
        
    //        int tamanhoPagina = 5;
    //        int numeroPagina = pagina ?? 1;

    //        switch (ordenacao)
    //        {
    //            case "Nome_desc":
    //                pedidos = pedidos.OrderByDescending(s => s.Cliente.Nome);
    //                break;
    //            case "DataPedido":
    //                pedidos = pedidos.OrderBy(s => s.DataPedido);
    //                break;
    //            case "DataPedido_desc":
    //                pedidos = pedidos.OrderByDescending(s => s.DataPedido);
    //                break;
    //            case "DataEenvio":
    //                pedidos = pedidos.OrderBy(s => s.DataEnvio);
    //                break;
    //            case "DataEnvio_desc":
    //                pedidos = pedidos.OrderByDescending(s => s.DataEnvio);
    //                break;
    //            case "DataEntrega":
    //                pedidos = pedidos.OrderBy(s => s.DataEntrega);
    //                break;
    //            case "DataEntrega_desc":
    //                pedidos = pedidos.OrderByDescending(s => s.DataEntrega);
    //                break;
    //            default:
    //                pedidos = pedidos.OrderBy(s => s.Cliente.Nome);
    //                break;
    //        }



    //        return View(pedidos.ToPagedList(numeroPagina, tamanhoPagina));
    //    }

    //    // GET: Pedido/Details/5
    //    public ActionResult Details(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Pedido pedido = db.Pedidos.Find(id);
    //        if (pedido == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(pedido);
    //    }

    //    // GET: Pedido/Create
    //    public ActionResult Create()
    //    {
    //        ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome");
    //        return View();
    //    }

    //    // POST: Pedido/Create
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Create([Bind(Include = "PedidoID,ClienteID,DataPedido,DataEnvio,DataEntrega")] Pedido pedido)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Pedidos.Add(pedido);
    //            db.SaveChanges();
    //            TempData["Mensagem"] = "Pedido cadastrado com sucesso!";
    //            return RedirectToAction("Index");
    //        }

    //        ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", pedido.ClienteID);
    //        return View(pedido);
    //    }

    //    // GET: Pedido/Edit/5
    //    public ActionResult Edit(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Pedido pedido = db.Pedidos.Find(id);
    //        if (pedido == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", pedido.ClienteID);
    //        return View(pedido);
    //    }

    //    // POST: Pedido/Edit/5
    //    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    //    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult Edit([Bind(Include = "PedidoID,ClienteID,DataPedido,DataEnvio,DataEntrega")] Pedido pedido)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            db.Entry(pedido).State = EntityState.Modified;
    //            db.SaveChanges();
    //            TempData["Mensagem"] = "Pedido atualizado com sucesso!";
    //            return RedirectToAction("Index");
    //        }
    //        ViewBag.ClienteID = new SelectList(db.Clientes, "ClienteID", "Nome", pedido.ClienteID);
    //        return View(pedido);
    //    }

    //    // GET: Pedido/Delete/5
    //    public ActionResult Delete(int? id)
    //    {
    //        if (id == null)
    //        {
    //            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    //        }
    //        Pedido pedido = db.Pedidos.Find(id);
    //        if (pedido == null)
    //        {
    //            return HttpNotFound();
    //        }
    //        return View(pedido);
    //    }

    //    // POST: Pedido/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public ActionResult DeleteConfirmed(int id)
    //    {
    //        Pedido pedido = db.Pedidos.Find(id);
    //        db.Pedidos.Remove(pedido);
    //        db.SaveChanges();
    //        TempData["Mensagem"] = "Pedido excluído com sucesso!";
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
