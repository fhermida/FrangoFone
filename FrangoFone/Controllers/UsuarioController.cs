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
    public class UsuarioController : Controller
    {
        private IUsuarioRepository usuarioRepository = new UsuarioRepository();
        private IPermissaoRepository permissaoRepository = new PermissaoRepository(); 

        // GET: Usuario
        public ActionResult Index()
        {
            var usuarioSet = usuarioRepository.ObterTodos();
            return View(usuarioSet.ToList());
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioSet usuarioSet = usuarioRepository.ObterPorId(id.Value);
            if (usuarioSet == null)
            {
                return HttpNotFound();
            }
            return View(usuarioSet);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.Permissao_Id = new SelectList(permissaoRepository.ObterTodos(), "Id", "Nome");
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Login,Senha,Ativo,DataCadastro,Permissao_Id")] UsuarioSet usuarioSet)
        {
            if (ModelState.IsValid)
            {
                usuarioRepository.Inserir(usuarioSet);
                return RedirectToAction("Index");
            }

            ViewBag.Permissao_Id = new SelectList(permissaoRepository.ObterTodos(), "Id", "Nome", usuarioSet.Permissao_Id);
            return View(usuarioSet);
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioSet usuarioSet = usuarioRepository.ObterPorId(id.Value);
            if (usuarioSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.Permissao_Id = new SelectList(usuarioRepository.ObterTodos(), "Id", "Nome", usuarioSet.Permissao_Id);
            return View(usuarioSet);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Login,Senha,Ativo,DataCadastro,Permissao_Id")] UsuarioSet usuarioSet)
        {
            if (ModelState.IsValid)
            {
                usuarioRepository.Atualizar(usuarioSet);
                return RedirectToAction("Index");
            }
            ViewBag.Permissao_Id = new SelectList(usuarioRepository.ObterTodos(), "Id", "Nome", usuarioSet.Permissao_Id);
            return View(usuarioSet);
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsuarioSet usuarioSet = usuarioRepository.ObterPorId(id.Value);
            if (usuarioSet == null)
            {
                return HttpNotFound();
            }
            return View(usuarioSet);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsuarioSet usuarioSet = usuarioRepository.ObterPorId(id);
            usuarioRepository.Apagar(usuarioSet);
            return RedirectToAction("Index");
        }
        
    }
}
