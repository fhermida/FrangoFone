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
    [PermissionFilter(Roles = "Administrador,Usuario,UsuarioEspecial")]
    public class ContatoController : Controller
    {
        private IContatoRepository contatoRepository;
        private IClienteRepository clienteRepository;
        private ITipoContatoRepository tipoContatoRepository;

        public ContatoController()
        {
            contatoRepository = new ContatoRepository();
            clienteRepository = new ClienteRepository();
            tipoContatoRepository = new TipoContatoRepository();
        }

        // GET: Contato
        public ActionResult Index()
        {   
            return View(contatoRepository.ObterTodos());
        }

        // GET: Contato/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoSet contatoSet = contatoRepository.ObterPorId(id.Value);
            if (contatoSet == null)
            {
                return HttpNotFound();
            }
            return View(contatoSet);
        }

        // GET: Contato/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos(), "Id", "Nome");
            ViewBag.TipoContatoId = new SelectList(tipoContatoRepository.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: Contato/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,Valor,TipoContatoId")] ContatoSet contatoSet)
        {
            if (ModelState.IsValid)
            {
                contatoRepository.Inserir(contatoSet);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos(), "Id", "Nome", contatoSet.ClienteId);
            ViewBag.TipoContatoId = new SelectList(tipoContatoRepository.ObterTodos(), "Id", "Nome", contatoSet.TipoContatoId);
            return View(contatoSet);
        }

        // GET: Contato/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoSet contatoSet = contatoRepository.ObterPorId(id.Value);
            if (contatoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos(), "Id", "Nome", contatoSet.ClienteId);
            ViewBag.TipoContatoId = new SelectList(tipoContatoRepository.ObterTodos(), "Id", "Nome", contatoSet.TipoContatoId);
            return View(contatoSet);
        }

        // POST: Contato/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,Valor,TipoContatoId")] ContatoSet contatoSet)
        {
            if (ModelState.IsValid)
            {
                contatoRepository.Atualizar(contatoSet);
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos(), "Id", "Nome", contatoSet.ClienteId);
            ViewBag.TipoContatoId = new SelectList(tipoContatoRepository.ObterTodos(), "Id", "Nome", contatoSet.TipoContatoId);
            return View(contatoSet);
        }

        // GET: Contato/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContatoSet contatoSet = contatoRepository.ObterPorId(id.Value);
            if (contatoSet == null)
            {
                return HttpNotFound();
            }
            return View(contatoSet);
        }

        // POST: Contato/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContatoSet contatoSet = contatoRepository.ObterPorId(id);
            contatoRepository.Apagar(contatoSet);
            return RedirectToAction("Index");
        }
    }
}
