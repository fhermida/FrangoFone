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
    public class ItemPedidoController : Controller
    {
        private IItemPedidoRepository itemPedidoRepository = new ItemPedidoRepository();
        private IProdutoRepository produtoRepository = new ProdutoRepository();
        private IPedidoRepository pedidoRepository = new PedidoRepository();

        // GET: ItemPedido
        public ActionResult Index()
        {
            var itemPedidoSet = itemPedidoRepository.ObterTodos();
            return View(itemPedidoSet.ToList());
        }

        // GET: ItemPedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedidoSet itemPedidoSet = itemPedidoRepository.ObterPorId(id.Value);
            if (itemPedidoSet == null)
            {
                return HttpNotFound();
            }
            return View(itemPedidoSet);
        }

        // GET: ItemPedido/Create
        public ActionResult Create()
        {
            ViewBag.PedidoId = new SelectList(pedidoRepository.ObterTodos(), "Id", "Id");
            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: ItemPedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PedidoId,ProdutoId,ValorUnitario,Quantidade")] ItemPedidoSet itemPedidoSet)
        {
            if (ModelState.IsValid)
            {
                itemPedidoRepository.Inserir(itemPedidoSet);
                return RedirectToAction("Index");
            }

            ViewBag.PedidoId = new SelectList(pedidoRepository.ObterTodos(), "Id", "Id", itemPedidoSet.PedidoId);
            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome", itemPedidoSet.ProdutoId);
            return View(itemPedidoSet);
        }

        // GET: ItemPedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedidoSet itemPedidoSet = itemPedidoRepository.ObterPorId(id.Value);
            if (itemPedidoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PedidoId = new SelectList(pedidoRepository.ObterTodos(), "Id", "Id", itemPedidoSet.PedidoId);
            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome", itemPedidoSet.ProdutoId);
            return View(itemPedidoSet);
        }

        // POST: ItemPedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PedidoId,ProdutoId,ValorUnitario,Quantidade")] ItemPedidoSet itemPedidoSet)
        {
            if (ModelState.IsValid)
            {
                itemPedidoRepository.Atualizar(itemPedidoSet);
                return RedirectToAction("Index");
            }
            ViewBag.PedidoId = new SelectList(pedidoRepository.ObterTodos(), "Id", "Id", itemPedidoSet.PedidoId);
            ViewBag.ProdutoId = new SelectList(produtoRepository.ObterTodos(), "Id", "Nome", itemPedidoSet.ProdutoId);
            return View(itemPedidoSet);
        }

        // GET: ItemPedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ItemPedidoSet itemPedidoSet = itemPedidoRepository.ObterPorId(id.Value);
            if (itemPedidoSet == null)
            {
                return HttpNotFound();
            }
            return View(itemPedidoSet);
        }

        // POST: ItemPedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ItemPedidoSet itemPedidoSet = itemPedidoRepository.ObterPorId(id);
            return RedirectToAction("Index");
        }
                                                                              
    }
}
