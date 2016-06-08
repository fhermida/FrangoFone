using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrangoFone.Models;
using FrangoFone.Repository.Interface;
using FrangoFone.Repository.Concrete;  
using System.Web.Security;

namespace FrangoFone.EntryPoint.Controllers
{

    public class LoginController : Controller
    {

        private IUsuarioRepository usuarioRepository = new UsuarioRepository();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {

                var usuario = usuarioRepository.ObterPorLogin(login.User);

                bool sucess = usuario.Senha == login.Password && usuario.Ativo == true;

                if (sucess)
                {
                    FormsAuthentication.RedirectFromLoginPage(login.User, true);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("Error", "Usuario ou Senha Incorretos!");
                }
                
            }

            return View();
        }

        [HttpGet]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}