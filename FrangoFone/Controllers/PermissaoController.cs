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
    [PermissionFilter(Roles = "Administrador")]
    public class PermissaoController : Controller
    {
        private IPermissaoRepository permissaoRepository = new PermissaoRepository();

        // GET: Permissao
        public ActionResult Index()
        {
            return View(permissaoRepository.ObterTodos());
        }

        // GET: Permissao/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissaoSet permissaoSet = permissaoRepository.ObterPorId(id.Value);
            if (permissaoSet == null)
            {
                return HttpNotFound();
            }
            return View(permissaoSet);
        }

        // GET: Permissao/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Permissao/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] PermissaoSet permissaoSet)
        {
            if (ModelState.IsValid)
            {
                permissaoRepository.Inserir(permissaoSet);
                return RedirectToAction("Index");
            }

            return View(permissaoSet);
        }

        // GET: Permissao/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissaoSet permissaoSet = permissaoRepository.ObterPorId(id.Value);
            if (permissaoSet == null)
            {
                return HttpNotFound();
            }
            return View(permissaoSet);
        }

        // POST: Permissao/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] PermissaoSet permissaoSet)
        {
            if (ModelState.IsValid)
            {
                permissaoRepository.Atualizar(permissaoSet);
                return RedirectToAction("Index");
            }
            return View(permissaoSet);
        }

        // GET: Permissao/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissaoSet permissaoSet = permissaoRepository.ObterPorId(id.Value);
            if (permissaoSet == null)
            {
                return HttpNotFound();
            }
            return View(permissaoSet);
        }

        // POST: Permissao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PermissaoSet permissaoSet = permissaoRepository.ObterPorId(id);
            permissaoRepository.Apagar(permissaoSet);
            return RedirectToAction("Index");
        }
         
    }
}
