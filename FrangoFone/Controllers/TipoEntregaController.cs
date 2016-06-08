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
    public class TipoEntregaController : Controller
    {
        private ITipoEntregaRepository tipoEntregaRepository = new TipoEntregaRepository();

        // GET: TipoEntrega
        public ActionResult Index()
        {
            return View(tipoEntregaRepository.ObterTodos());
        }

        // GET: TipoEntrega/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntregaSet tipoEntregaSet = tipoEntregaRepository.ObterPorId(id.Value);
            if (tipoEntregaSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntregaSet);
        }

        // GET: TipoEntrega/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoEntrega/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Ativo")] TipoEntregaSet tipoEntregaSet)
        {
            if (ModelState.IsValid)
            {
                tipoEntregaRepository.Inserir(tipoEntregaSet);
                return RedirectToAction("Index");
            }

            return View(tipoEntregaSet);
        }

        // GET: TipoEntrega/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntregaSet tipoEntregaSet = tipoEntregaRepository.ObterPorId(id.Value);
            if (tipoEntregaSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntregaSet);
        }

        // POST: TipoEntrega/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Ativo")] TipoEntregaSet tipoEntregaSet)
        {
            if (ModelState.IsValid)
            {
                tipoEntregaRepository.Atualizar(tipoEntregaSet);
                return RedirectToAction("Index");
            }
            return View(tipoEntregaSet);
        }

        // GET: TipoEntrega/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoEntregaSet tipoEntregaSet = tipoEntregaRepository.ObterPorId(id.Value);
            if (tipoEntregaSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoEntregaSet);
        }

        // POST: TipoEntrega/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoEntregaSet tipoEntregaSet = tipoEntregaRepository.ObterPorId(id);
            tipoEntregaRepository.Apagar(tipoEntregaSet);
            return RedirectToAction("Index");
        }
        
    }
}
