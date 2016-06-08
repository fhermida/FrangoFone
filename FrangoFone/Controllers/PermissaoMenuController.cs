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
    public class PermissaoMenuController : Controller
    {
        private IPermissaoMenuRepository permissaoMenuRepository = new PermissaoMenuRepository();
        private IPermissaoRepository permissaoRepository = new PermissaoRepository();
        private IMenuRepository menuRepository = new MenuRepository();

        // GET: PermissaoMenu
        public ActionResult Index()
        {
            var permissaoMenuSet = permissaoMenuRepository.ObterTodos();
            return View(permissaoMenuSet.ToList());
        }

        // GET: PermissaoMenu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissaoMenuSet permissaoMenuSet = permissaoMenuRepository.ObterPorId(id.Value);
            if (permissaoMenuSet == null)
            {
                return HttpNotFound();
            }
            return View(permissaoMenuSet);
        }

        // GET: PermissaoMenu/Create
        public ActionResult Create()
        {
            ViewBag.Menu_Id = new SelectList(menuRepository.ObterTodos(), "Id", "nome");
            ViewBag.Permissao_Id = new SelectList(permissaoRepository.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: PermissaoMenu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Permissao_Id,Menu_Id")] PermissaoMenuSet permissaoMenuSet)
        {
            if (ModelState.IsValid)
            {
                permissaoMenuRepository.Inserir(permissaoMenuSet);
                return RedirectToAction("Index");
            }

            ViewBag.Menu_Id = new SelectList(menuRepository.ObterTodos(), "Id", "nome", permissaoMenuSet.Menu_Id);
            ViewBag.Permissao_Id = new SelectList(permissaoRepository.ObterTodos(), "Id", "Nome", permissaoMenuSet.Permissao_Id);
            return View(permissaoMenuSet);
        }

        // GET: PermissaoMenu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissaoMenuSet permissaoMenuSet = permissaoMenuRepository.ObterPorId(id.Value);
            if (permissaoMenuSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Menu_Id = new SelectList(menuRepository.ObterTodos(), "Id", "nome", permissaoMenuSet.Menu_Id);
            ViewBag.Permissao_Id = new SelectList(permissaoRepository.ObterTodos(), "Id", "Nome", permissaoMenuSet.Permissao_Id);
            return View(permissaoMenuSet);
        }

        // POST: PermissaoMenu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Permissao_Id,Menu_Id")] PermissaoMenuSet permissaoMenuSet)
        {
            if (ModelState.IsValid)
            {
                permissaoMenuRepository.Atualizar(permissaoMenuSet);
                return RedirectToAction("Index");
            }
            ViewBag.Menu_Id = new SelectList(menuRepository.ObterTodos(), "Id", "nome", permissaoMenuSet.Menu_Id);
            ViewBag.Permissao_Id = new SelectList(permissaoRepository.ObterTodos(), "Id", "Nome", permissaoMenuSet.Permissao_Id);
            return View(permissaoMenuSet);
        }

        // GET: PermissaoMenu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissaoMenuSet permissaoMenuSet = permissaoMenuRepository.ObterPorId(id.Value);
            if (permissaoMenuSet == null)
            {
                return HttpNotFound();
            }
            return View(permissaoMenuSet);
        }

        // POST: PermissaoMenu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PermissaoMenuSet permissaoMenuSet = permissaoMenuRepository.ObterPorId(id);
            permissaoMenuRepository.Apagar(permissaoMenuSet);
            return RedirectToAction("Index");
        }
    }
}
