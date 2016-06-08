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
    [PermissionFilter(Roles ="Administrador,UsuarioEspecial")]
    public class CategoriaController : Controller
    {
        private ICategoriaRepository categoriaRepository;

        public CategoriaController()
        {
            categoriaRepository = new CategoriaRepository();
        }

        // GET: Categoria
        public ActionResult Index()
        {
            return View(categoriaRepository.ObterTodos());
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaSet categoriaSet = categoriaRepository.ObterPorId(id.Value);
            if (categoriaSet == null)
            {
                return HttpNotFound();
            }
            return View(categoriaSet);
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
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Ativa")] CategoriaSet categoriaSet)
        {
            if (ModelState.IsValid)
            {
                categoriaRepository.Inserir(categoriaSet);
                return RedirectToAction("Index");
            }

            return View(categoriaSet);
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaSet categoriaSet = categoriaRepository.ObterPorId(id.Value);
            if (categoriaSet == null)
            {
                return HttpNotFound();
            }
            return View(categoriaSet);
        }

        // POST: Categoria/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Ativa")] CategoriaSet categoriaSet)
        {
            if (ModelState.IsValid)
            {
                categoriaRepository.Atualizar(categoriaSet);
                return RedirectToAction("Index");
            }
            return View(categoriaSet);
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CategoriaSet categoriaSet = categoriaRepository.ObterPorId(id.Value);
            if (categoriaSet == null)
            {
                return HttpNotFound();
            }
            return View(categoriaSet);
        }

        // POST: Categoria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CategoriaSet categoriaSet = categoriaRepository.ObterPorId(id);
            categoriaRepository.Apagar(categoriaSet);
            return RedirectToAction("Index");
        }
         
    }
}
