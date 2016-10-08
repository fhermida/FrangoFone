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
using FrangoFone.Infraestructure;
using System.Threading.Tasks;
using System.Configuration;
using FrangoFone.Models;
using Newtonsoft.Json;

namespace FrangoFone.EntryPoint.Controllers
{

    [PermissionFilter(Roles = "Administrador,Usuario,UsuarioEspecial")]
    public class EnderecoController : Controller
    {
        private IEnderecoRepository enderecoRepository;
        private IClienteRepository clienteRepository;

        public EnderecoController()
        {
            enderecoRepository = new EnderecoRepository();
            clienteRepository = new ClienteRepository();
        }

        // GET: Endereco
        public ActionResult Index()
        {
            var enderecoSet = enderecoRepository.ObterTodos();
            return View(enderecoSet.ToList());
        }

        // GET: Endereco/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoSet enderecoSet = enderecoRepository.ObterPorId(id.Value);
            if (enderecoSet == null)
            {
                return HttpNotFound();
            }

            return View(enderecoSet);
        }

        // GET: Endereco/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = clienteRepository.ObterTodos();
            return View();
        }

        // POST: Endereco/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,Logradouro,Numero,Complemento,CEP,Bairro,Municipio,Estado")] EnderecoSet enderecoSet)
        {
            if (enderecoSet.ClienteId <= 0)
            {
                ModelState.AddModelError("ClienteId", "O campo ClienteId é obrigatório.");
            }

            if (ModelState.IsValid)
            {
                enderecoRepository.Inserir(enderecoSet);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = clienteRepository.ObterTodos();
            return View(enderecoSet);
        }

        // GET: Endereco/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoSet enderecoSet = enderecoRepository.ObterPorId(id.Value);
            if (enderecoSet == null)
            {
                return HttpNotFound();
            }                                                   

            return View(enderecoSet);
        }

        // POST: Endereco/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,Logradouro,Numero,Complemento,CEP,Bairro,Municipio,Estado")] EnderecoSet enderecoSet)
        {
            if (ModelState.IsValid)
            {
                enderecoRepository.Atualizar(enderecoSet);
                return RedirectToAction("Index");
            }                                                                                                        
            return View(enderecoSet);
        }

        // GET: Endereco/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EnderecoSet enderecoSet = enderecoRepository.ObterPorId(id.Value);
            if (enderecoSet == null)
            {
                return HttpNotFound();
            }
            return View(enderecoSet);
        }

        // POST: Endereco/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EnderecoSet enderecoSet = enderecoRepository.ObterPorId(id);
            enderecoRepository.Apagar(enderecoSet);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public JsonResult ObterEndereco(string cep)
        {
            ViewBag.ClienteId = clienteRepository.ObterTodos();

            string url = string.Format(ConfigurationManager.AppSettings["WsCEP"], cep);
            
            string conteudo = "";
            Task<string> retorno;
            EnderecoViaCep enderecoViaCep;
            EnderecoSet endereco;

            ServicoHttp servicoHttp = new ServicoHttp();
            retorno = servicoHttp.Post(url, conteudo);

            enderecoViaCep = JsonConvert.DeserializeObject<EnderecoViaCep>(retorno.Result);
            
            if(enderecoViaCep.erro)
            {                                                           
                return Json(new { erro = true }, JsonRequestBehavior.AllowGet);
            }
                                          
                endereco = new EnderecoSet
                {
                    Bairro = enderecoViaCep.bairro,
                    CEP = Int32.Parse(enderecoViaCep.cep.Replace("-", "")),
                    Logradouro = enderecoViaCep.logradouro,
                    Complemento = enderecoViaCep.complemento,
                    Estado = enderecoViaCep.uf,
                    Municipio = enderecoViaCep.localidade,
                };
                                          
            return Json(endereco, JsonRequestBehavior.AllowGet);
        }
           
    }
}
