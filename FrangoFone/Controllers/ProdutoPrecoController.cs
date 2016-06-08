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
    public class ProdutoPrecoController : Controller
    {
        private IProdutoPrecoRepository produtoPrecoRepository = new ProdutoPrecoRepository();
        private IProdutoRepository produtoRepository = new ProdutoRepository();

        // GET: ProdutoPreco
        public ActionResult Index()
        {
            var produtoPrecoSet = produtoPrecoRepository.ObterTodos();
            return View(produtoPrecoSet.ToList());
        }

        // GET: ProdutoPreco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoPrecoSet produtoPrecoSet = produtoPrecoRepository.ObterPorId(id.Value);
            if (produtoPrecoSet == null)
            {
                return HttpNotFound();
            }
            return View(produtoPrecoSet);
        }

        // GET: ProdutoPreco/Create
        public ActionResult Create()
        {
            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: ProdutoPreco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ProdutoId,Valor,InicioVigencia,FimVigencia")] ProdutoPrecoSet produtoPrecoSet)
        {
            if (ModelState.IsValid)
            {
                produtoPrecoRepository.Inserir(produtoPrecoSet);
                return RedirectToAction("Index");
            }

            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome", produtoPrecoSet.ProdutoId);
            return View(produtoPrecoSet);
        }

        // GET: ProdutoPreco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoPrecoSet produtoPrecoSet = produtoPrecoRepository.ObterPorId(id.Value);
            if (produtoPrecoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome", produtoPrecoSet.ProdutoId);
            return View(produtoPrecoSet);
        }

        // POST: ProdutoPreco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ProdutoId,Valor,InicioVigencia,FimVigencia")] ProdutoPrecoSet produtoPrecoSet)
        {
            if (ModelState.IsValid)
            {
                produtoPrecoRepository.Atualizar(produtoPrecoSet);
                return RedirectToAction("Index");
            }
            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome", produtoPrecoSet.ProdutoId);
            return View(produtoPrecoSet);
        }

        // GET: ProdutoPreco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoPrecoSet produtoPrecoSet =  produtoPrecoRepository.ObterPorId(id.Value);
            if (produtoPrecoSet == null)
            {
                return HttpNotFound();
            }
            return View(produtoPrecoSet);
        }

        // POST: ProdutoPreco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoPrecoSet produtoPrecoSet = produtoPrecoRepository.ObterPorId(id);
            produtoPrecoRepository.Apagar(produtoPrecoSet);
            return RedirectToAction("Index");
        }
                                                                                  
    }
}
