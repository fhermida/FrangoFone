using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FrangoFone.Domain;
using FrangoFone.Repository.Interface;
using FrangoFone.Repository.Concrete;
using FrangoFone.Providers;

namespace FrangoFone.EntryPoint.Controllers
{

    [PermissionFilter(Roles = "Administrador,UsuarioEspecial")]
    public class TipoPagamentoController : Controller
    {
        private ITipoPagamentoRepository tipoPagamentoRepository = new TipoPagamentoRepository();

        // GET: TipoPagamento
        public ActionResult Index()
        {
            return View(tipoPagamentoRepository.ObterTodos());
        }

        // GET: TipoPagamento/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamentoSet tipoPagamentoSet = tipoPagamentoRepository.ObterPorId(id.Value);
            if (tipoPagamentoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamentoSet);
        }

        // GET: TipoPagamento/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoPagamento/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ativo")] TipoPagamentoSet tipoPagamentoSet)
        {
            if (ModelState.IsValid)
            {
                tipoPagamentoRepository.Inserir(tipoPagamentoSet);
                return RedirectToAction("Index");
            }

            return View(tipoPagamentoSet);
        }

        // GET: TipoPagamento/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamentoSet tipoPagamentoSet = tipoPagamentoRepository.ObterPorId(id.Value);
            if (tipoPagamentoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamentoSet);
        }

        // POST: TipoPagamento/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ativo")] TipoPagamentoSet tipoPagamentoSet)
        {
            if (ModelState.IsValid)
            {
                tipoPagamentoRepository.Atualizar(tipoPagamentoSet);
                return RedirectToAction("Index");
            }
            return View(tipoPagamentoSet);
        }

        // GET: TipoPagamento/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoPagamentoSet tipoPagamentoSet = tipoPagamentoRepository.ObterPorId(id.Value);
            if (tipoPagamentoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoPagamentoSet);
        }

        // POST: TipoPagamento/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoPagamentoSet tipoPagamentoSet = tipoPagamentoRepository.ObterPorId(id);
            tipoPagamentoRepository.Apagar(tipoPagamentoSet);
            return RedirectToAction("Index");
        }

    }
}
