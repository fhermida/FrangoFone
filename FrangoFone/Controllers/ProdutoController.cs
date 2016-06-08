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
    public class ProdutoController : Controller
    {
        private IProdutoRepository produtoRepository = new ProdutoRepository();
        private ICategoriaRepository categoriaRepository = new CategoriaRepository();

        // GET: Produto
        public ActionResult Index()
        {
            var produtoSet = produtoRepository.ObterTodos();
            return View(produtoSet.ToList());
        }

        // GET: Produto/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoSet produtoSet = produtoRepository.ObterPorId(id.Value);
            if (produtoSet == null)
            {
                return HttpNotFound();
            }
            return View(produtoSet);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(categoriaRepository.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: Produto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Descricao,Quantidade,Ativo,CategoriaId,Valor")] ProdutoSet produtoSet)
        {
            if (ModelState.IsValid)
            {
                produtoRepository.Inserir(produtoSet);
                return RedirectToAction("Index");
            }

            ViewBag.CategoriaId = new SelectList(categoriaRepository.ObterTodos(), "Id", "Nome", produtoSet.CategoriaId);
            return View(produtoSet);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoSet produtoSet = produtoRepository.ObterPorId(id.Value);
            if (produtoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(categoriaRepository.ObterTodos(), "Id", "Nome", produtoSet.CategoriaId);
            return View(produtoSet);
        }

        // POST: Produto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Descricao,Quantidade,Ativo,CategoriaId,Valor")] ProdutoSet produtoSet)
        {
            if (ModelState.IsValid)
            {
                produtoRepository.Atualizar(produtoSet);
                return RedirectToAction("Index");
            }
            ViewBag.CategoriaId = new SelectList(categoriaRepository.ObterTodos(), "Id", "Nome", produtoSet.CategoriaId);
            return View(produtoSet);
        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProdutoSet produtoSet = produtoRepository.ObterPorId(id.Value);
            if (produtoSet == null)
            {
                return HttpNotFound();
            }
            return View(produtoSet);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProdutoSet produtoSet = produtoRepository.ObterPorId(id);
            produtoRepository.Apagar(produtoSet);
            return RedirectToAction("Index");
        }
                                                 
    }
}
