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
    [PermissionFilter(Roles = "Administrador,UsuarioEspecial")]
    public class PedidoController : Controller
    {
        private IPedidoRepository pedidoRepository;
        private IClienteRepository clienteRepository;
        private IEnderecoRepository enderecoRepository;
        private ITipoEntregaRepository tipoEntregaRepository;
        private ITipoPagamentoRepository tipoPagamentoRepository;
        private IUsuarioRepository usuarioRepository;
        
        public PedidoController()
        {
            pedidoRepository = new PedidoRepository();
            clienteRepository = new ClienteRepository();
            enderecoRepository = new EnderecoRepository();
            tipoEntregaRepository = new TipoEntregaRepository();
            tipoPagamentoRepository = new TipoPagamentoRepository();
            usuarioRepository = new UsuarioRepository();
        }

        // GET: Pedido
        public ActionResult Index()
        {
            var pedidoSet = pedidoRepository.ObterTodos();
            return View(pedidoSet.ToList());
        }

        // GET: Pedido/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoSet pedidoSet = pedidoRepository.ObterPorId(id.Value);
            if (pedidoSet == null)
            {
                return HttpNotFound();
            }
            return View(pedidoSet);
        }

        // GET: Pedido/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos().Select(c=> new ClienteSet { Id = c.Id, Nome = string.Concat(c.Nome, " ", c.Sobrenone)  }), "Id", "Nome");
            ViewBag.Endereco_Id = new SelectList(enderecoRepository.ObterTodos(), "Id", "Logradouro");
            ViewBag.TipoEntregaId = new SelectList(tipoEntregaRepository.ObterTodos(), "Id", "Nome");
            ViewBag.TipoPagamentoId = new SelectList(tipoPagamentoRepository.ObterTodos(), "Id", "Nome");
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(StatusPedidoEnum)).Cast<StatusPedidoEnum>().Select(p => new SelectListItem { Text = ((int)p).ToString(), Value = p.ToString() }), "Text", "Value");
            return View();
        }

        // POST: Pedido/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClienteId,DataPedido,TipoEntregaId,TipoPagamentoId,Endereco_Id,Status,Obs")] PedidoSet pedidoSet)
        {
            pedidoSet.UsuarioId = usuarioRepository.ObterPorLogin(FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).Id;
            if (ModelState.IsValid)
            {
                pedidoRepository.Inserir(pedidoSet);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos().Select(c => new ClienteSet { Id = c.Id, Nome = string.Concat(c.Nome, " ", c.Sobrenone) }), "Id", "Nome", pedidoSet.ClienteId);
            ViewBag.Endereco_Id = new SelectList(enderecoRepository.ObterTodos(), "Id", "Logradouro", pedidoSet.Endereco_Id);
            ViewBag.TipoEntregaId = new SelectList(tipoEntregaRepository.ObterTodos(), "Id", "Nome", pedidoSet.TipoEntregaId);
            ViewBag.TipoPagamentoId = new SelectList(tipoPagamentoRepository.ObterTodos(), "Id", "Nome", pedidoSet.TipoPagamentoId);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(StatusPedidoEnum)).Cast<StatusPedidoEnum>().Select(p => new SelectListItem { Text = p.ToString(), Value = p.ToString() }), "Text", "Value", pedidoSet.Status);
            return View(pedidoSet);
        }

        // GET: Pedido/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoSet pedidoSet = pedidoRepository.ObterPorId(id.Value);
            if (pedidoSet == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos().Select(c => new ClienteSet { Id = c.Id, Nome = string.Concat(c.Nome, " ", c.Sobrenone) }), "Id", "Nome", pedidoSet.ClienteId);
            ViewBag.Endereco_Id = new SelectList(enderecoRepository.ObterTodos(), "Id", "Logradouro", pedidoSet.Endereco_Id);
            ViewBag.TipoEntregaId = new SelectList(tipoEntregaRepository.ObterTodos(), "Id", "Nome", pedidoSet.TipoEntregaId);
            ViewBag.TipoPagamentoId = new SelectList(tipoPagamentoRepository.ObterTodos(), "Id", "Nome", pedidoSet.TipoPagamentoId);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(StatusPedidoEnum)).Cast<StatusPedidoEnum>().Select(p => new SelectListItem { Text = p.ToString(), Value = p.ToString() }), "Text", "Value", pedidoSet.Status);
            return View(pedidoSet);
        }

        // POST: Pedido/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClienteId,DataPedido,TipoEntregaId,TipoPagamentoId,Endereco_Id,Status,Obs")] PedidoSet pedidoSet)
        {
            pedidoSet.UsuarioId = usuarioRepository.ObterPorLogin(FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).Id;

            if (ModelState.IsValid)
            {
                pedidoRepository.Atualizar(pedidoSet);
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(clienteRepository.ObterTodos().Select(c => new ClienteSet { Id = c.Id, Nome = string.Concat(c.Nome, " ", c.Sobrenone) }), "Id", "Nome", pedidoSet.ClienteId);
            ViewBag.Endereco_Id = new SelectList(enderecoRepository.ObterTodos(), "Id", "Logradouro", pedidoSet.Endereco_Id);
            ViewBag.TipoEntregaId = new SelectList(tipoEntregaRepository.ObterTodos(), "Id", "Nome", pedidoSet.TipoEntregaId);
            ViewBag.TipoPagamentoId = new SelectList(tipoPagamentoRepository.ObterTodos(), "Id", "Nome", pedidoSet.TipoPagamentoId);
            ViewBag.Status = new SelectList(Enum.GetValues(typeof(StatusPedidoEnum)).Cast<StatusPedidoEnum>().Select(p => new SelectListItem { Text = p.ToString(), Value = p.ToString() }), "Text", "Value", pedidoSet.Status);
            return View(pedidoSet);
        }

        // GET: Pedido/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PedidoSet pedidoSet = pedidoRepository.ObterPorId(id.Value);
            if (pedidoSet == null)
            {
                return HttpNotFound();
            }
            return View(pedidoSet);
        }

        // POST: Pedido/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PedidoSet pedidoSet = pedidoRepository.ObterPorId(id);
            pedidoRepository.Apagar(pedidoSet);
            return RedirectToAction("Index");
        }
                                               
    }
}
