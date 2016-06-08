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
    public class TipoContatoController : Controller
    {
        private ITipoContatoRepository tipoContatoRepository = new TipoContatoRepository();

        // GET: TipoContato
        public ActionResult Index()
        {
            return View(tipoContatoRepository.ObterTodos());
        }

        // GET: TipoContato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContatoSet tipoContatoSet = tipoContatoRepository.ObterPorId(id.Value);
            if (tipoContatoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoContatoSet);
        }

        // GET: TipoContato/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoContato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] TipoContatoSet tipoContatoSet)
        {
            if (ModelState.IsValid)
            {
                tipoContatoRepository.Inserir(tipoContatoSet);
                return RedirectToAction("Index");
            }

            return View(tipoContatoSet);
        }

        // GET: TipoContato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContatoSet tipoContatoSet = tipoContatoRepository.ObterPorId(id.Value);
            if (tipoContatoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoContatoSet);
        }

        // POST: TipoContato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] TipoContatoSet tipoContatoSet)
        {
            if (ModelState.IsValid)
            {
                tipoContatoRepository.Atualizar(tipoContatoSet);
                return RedirectToAction("Index");
            }
            return View(tipoContatoSet);
        }

        // GET: TipoContato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoContatoSet tipoContatoSet = tipoContatoRepository.ObterPorId(id.Value);
            if (tipoContatoSet == null)
            {
                return HttpNotFound();
            }
            return View(tipoContatoSet);
        }

        // POST: TipoContato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoContatoSet tipoContatoSet = tipoContatoRepository.ObterPorId(id);
            tipoContatoRepository.Apagar(tipoContatoSet);    
            return RedirectToAction("Index");
        }
    }
}
