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
    public class MenuController : Controller
    {
        private IMenuRepository menuRepository = new MenuRepository();

        // GET: Menu
        public ActionResult Index()
        {
            return View(menuRepository.ObterTodos());
        }

        // GET: Menu/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuSet menuSet = menuRepository.ObterPorId(id.Value);
            if (menuSet == null)
            {
                return HttpNotFound();
            }
            return View(menuSet);
        }

        // GET: Menu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Menu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,nome,action,controller,route,ativo")] MenuSet menuSet)
        {
            if (ModelState.IsValid)
            {
                menuRepository.Inserir(menuSet);
                return RedirectToAction("Index");
            }

            return View(menuSet);
        }

        // GET: Menu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuSet menuSet = menuRepository.ObterPorId(id.Value);
            if (menuSet == null)
            {
                return HttpNotFound();
            }
            return View(menuSet);
        }

        // POST: Menu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,nome,action,controller,route,ativo")] MenuSet menuSet)
        {
            if (ModelState.IsValid)
            {
                menuRepository.Atualizar(menuSet);
                return RedirectToAction("Index");
            }
            return View(menuSet);
        }

        // GET: Menu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuSet menuSet = menuRepository.ObterPorId(id.Value);
            if (menuSet == null)
            {
                return HttpNotFound();
            }
            return View(menuSet);
        }

        // POST: Menu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MenuSet menuSet = menuRepository.ObterPorId(id);
            menuRepository.Apagar(menuSet);
            return RedirectToAction("Index");
        }
    }
}
