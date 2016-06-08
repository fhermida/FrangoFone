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
using System.Web.Security;

namespace FrangoFone.EntryPoint.Controllers
{
    [PermissionFilter(Roles = "Administrador,Usuario,UsuarioEspecial")]
    public class ClienteController : Controller
    {
        private IClienteRepository clienteRepository;
        private IUsuarioRepository usuarioRepository ;


        public ClienteController()
        {
            clienteRepository = new ClienteRepository();
            usuarioRepository = new UsuarioRepository();
        }
        
        // GET: Cliente
        public ActionResult Index()
        {
            return View(clienteRepository.ObterTodos());
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSet clienteSet = clienteRepository.ObterPorId(id.Value);
            if (clienteSet == null)
            {
                return HttpNotFound();
            }
            return View(clienteSet);
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sobrenone,CPF,DataNascimento,DataCadastro,Ativo")] ClienteSet clienteSet)
        {
            if (clienteRepository.ObterPorCpf(clienteSet.CPF) != null)
            {
                ModelState.AddModelError("CPF", "Já existe um cliente com o mesmo CPF no sistema.");
            }

            clienteSet.UsuarioId = usuarioRepository.ObterPorLogin(FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).Id;

            if (ModelState.IsValid)
            {
                
                clienteRepository.Inserir(clienteSet);
                return RedirectToAction("Index");
            }

            return View(clienteSet);
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSet clienteSet = clienteRepository.ObterPorId(id.Value);
            if (clienteSet == null)
            {
                return HttpNotFound();
            }
            return View(clienteSet);
        }

        // POST: Cliente/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sobrenone,CPF,DataNascimento,DataCadastro,Ativo")] ClienteSet clienteSet)
        {
            ClienteSet clienteValid = clienteRepository.ObterPorCpf(clienteSet.CPF);

            if (clienteValid != null && clienteSet.Id != clienteValid.Id)
            {
                ModelState.AddModelError("CPF", "Já existe um cliente com o mesmo CPF no sistema.");
            }

            clienteSet.UsuarioId = usuarioRepository.ObterPorLogin(FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).Id;

            if (ModelState.IsValid)
            {
                
                clienteRepository.Atualizar(clienteSet);
                return RedirectToAction("Index");
            }
            return View(clienteSet);
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClienteSet clienteSet = clienteRepository.ObterPorId(id.Value);
            if (clienteSet == null)
            {
                return HttpNotFound();
            }
            return View(clienteSet);
        }

        // POST: Cliente/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClienteSet clienteSet = clienteRepository.ObterPorId(id);
            clienteRepository.Apagar(clienteSet);
            return RedirectToAction("Index");
        }
    }
}
