using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrangoFone.Repository.Concrete;
using FrangoFone.Repository.Interface;
using FrangoFone.Providers;
using FrangoFone.Domain;
using FrangoFone.Models;         
using System.Web.Security;
using FrangoFone.EntryPoint.SignalR;

namespace FrangoFone.EntryPoint.Controllers
{

    [PermissionFilter(Roles = "Administrador,Usuario,UsuarioEspecial")]
    public class PedidoClienteController : Controller
    {
        private IProdutoRepository produtoRepository;
        private IClienteRepository clienteRepository;
        private IEnderecoRepository enderecoRepository;
        private ITipoEntregaRepository tipoEntregaRepository;
        private ITipoPagamentoRepository tipoPagamentoRepository;
        private IPedidoRepository pedidoRepository;
        private IUsuarioRepository usuarioRepository;

        public PedidoClienteController()
        {
            produtoRepository = new ProdutoRepository();
            clienteRepository = new ClienteRepository();
            enderecoRepository = new EnderecoRepository();
            tipoEntregaRepository = new TipoEntregaRepository();
            tipoPagamentoRepository = new TipoPagamentoRepository();
            pedidoRepository = new PedidoRepository();
            usuarioRepository = new UsuarioRepository();
        }

        // GET: PedidoCliente
        [HttpGet]
        public ActionResult Index()
        {
            List<ListaPedidoClienteViewModel> model = pedidoRepository.ObterTodos()
                             .Select(p => new ListaPedidoClienteViewModel
                             {
                                 IdPedido = p.Id,
                                 NomeCliente = p.ClienteSet.Nome,
                                 DataPedido = p.DataPedido,
                                 EnderecoEntrega = p.EnderecoSet.Logradouro,
                                 Status = p.Status,
                                 TipoEntrega = p.TipoEntregaSet.Nome,
                                 TipoPagamento = p.TipoPagamentoSet.Nome,
                                 Login = p.UsuarioSet.Login,
                                 ValorTotal = p.ItemPedidoSet.Where(i => i.PedidoId == p.Id).Sum(v => v.Quantidade * v.ProdutoSet.Valor),
                                 ListaDetalhesItensPedido = p.ItemPedidoSet.Where(j => j.PedidoId == p.Id)
                                                                             .Select(k => new DetalheItemPedidoVeiwModel
                                                                             {
                                                                                 NomeProduto = k.ProdutoSet.Nome,
                                                                                 Quantidade = k.Quantidade,
                                                                                 ValorProduto = k.ProdutoSet.Valor,
                                                                                 Valor = (k.Quantidade * k.ProdutoSet.Valor)
                                                                             }).ToList()
                             }).OrderByDescending(d=> d.IdPedido).ToList();

            return View(model);
        }

        
        public JsonResult ObterEnderecos(int? Cliente)
        {

            List<EnderecoSet> enderecos = null;

            if (Cliente.HasValue)
            {
                enderecos = enderecoRepository.ObterTodos().Where(p => p.ClienteId == Cliente).Select(p => new EnderecoSet
                {
                    Bairro = p.Bairro,
                    CEP = p.CEP,
                    Complemento = p.Complemento,
                    ClienteId = p.ClienteId,
                    Estado = p.Estado,
                    Id = p.Id,
                    Logradouro = p.Logradouro,
                    Municipio = p.Municipio,
                    Numero = p.Numero,    
                }).ToList();
            }
            
            return Json(enderecos, JsonRequestBehavior.AllowGet);

        }

        [HttpGet]
        public ActionResult Create()
        {
            CarregarDropDown(null);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoClienteViewModel model)
        {

            if (model.Cliente <= 0)
            {
                ModelState.AddModelError("Cliente", "O campo Cliente é obrigatório.");
            }

            if (model.Endereco <= 0)
            {
                ModelState.AddModelError("Endereco", "O campo Endereço é obrigatório.");
            }

            if (!model.ItensPedido.Any(p => p.Quantidade > 0))
            {
                ModelState.AddModelError("ProdutosPedido", "A Quantidade dos itens do pedido deve ser maior que zero!");
            }
           
            if (ModelState.IsValid)
            {
                IPedidoRepository pedidoRepository = new PedidoRepository();
                IItemPedidoRepository itemPedidoRepository = new ItemPedidoRepository();

                PedidoSet pedido = new PedidoSet();
                pedido.ClienteId = model.Cliente;
                pedido.DataPedido = DateTime.Now;
                pedido.Endereco_Id = model.Endereco;
                pedido.TipoEntregaId = model.TipoEntrega;
                pedido.TipoPagamentoId = model.TipoPagamento;
                pedido.Status = StatusPedidoEnum.Aberto;
                pedido.Obs = model.Obs;
                pedido.UsuarioId = usuarioRepository.ObterPorLogin(FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name).Id;


                List<ItemPedidoSet> itensPedido = new List<ItemPedidoSet>();
                foreach (var item in model.ItensPedido)
                {
                    if (item.Quantidade == 0) continue;

                    ItemPedidoSet itemPedido = new ItemPedidoSet();
                    itemPedido.PedidoId = pedido.Id;
                    itemPedido.ProdutoId = item.Produto;
                    itemPedido.Quantidade = item.Quantidade;
                    itensPedido.Add(itemPedido);
                }

                pedido.ItemPedidoSet = itensPedido;
                pedidoRepository.Inserir(pedido);

                //Imprimindo cupom não fiscal
                //ImpressaoCupom imprimir = new ImpressaoCupom();
                //imprimir.EscreverNoDispositivo(pedido.Obs);

                PedidosCozinha pedidosNaCozinha = new PedidosCozinha();
                pedidosNaCozinha.AtualizarPedidos(model);

                return RedirectToAction("Create");
            }

            CarregarDropDown(model);
            return View(model);
        }


        private void CarregarDropDown(PedidoClienteViewModel model)
        {
            ViewBag.Produtos = produtoRepository.ObterTodos().Where(p=> p.Ativo == true).ToList();
            ViewBag.Clientes = clienteRepository.ObterTodos().Where(c => c.Ativo == true).ToList();             

            if (model != null)
            {
                ViewBag.Enderecos = enderecoRepository.ObterTodos().Where(p => p.ClienteId == model.Cliente).ToList();
                ViewBag.TipoEntrega = new SelectList(tipoEntregaRepository.ObterTodos(), "Id", "Nome", model.TipoEntrega);
                ViewBag.TipoPagamento = new SelectList(tipoPagamentoRepository.ObterTodos(), "Id", "Nome", model.TipoPagamento);
            }   
            else
            {                                                                                   
                ViewBag.TipoEntrega = new SelectList(tipoEntregaRepository.ObterTodos(), "Id", "Nome");
                ViewBag.TipoPagamento = new SelectList(tipoPagamentoRepository.ObterTodos(), "Id", "Nome");
            }
        }

        public JsonResult AtualizaStatusPedido(int idPedido, StatusPedidoEnum status)
        {
            bool sucesso = false;

            try
            {
                var pedido = pedidoRepository.ObterPorId(idPedido);

                pedido.Status = status;

                pedidoRepository.Atualizar(pedido);

                sucesso = true;
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return Json(new {sucesso}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObterListaStatusPedido()
        {
            var listEnums = Enum.GetNames(typeof(StatusPedidoEnum)).ToList();

            return Json(listEnums, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult PedidosCozinha()
        {
            return View("PedidosCozinha");
        }


    }
}