using FrangoFone.Repository.Interface;
using FrangoFone.Repository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FrangoFone.Models;

namespace FrangoFone.Controllers
{
    public class HomeController : Controller
    {
        private IPedidoRepository pedidoRepository;

        public HomeController()
        {
            pedidoRepository = new PedidoRepository();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            ViewBag.ListaVendasDiarias = pedidoRepository.ObterTodos().Where(s => s.Status != Domain.StatusPedidoEnum.Cancelado)
                .GroupBy(d => new DateTime(d.DataPedido.Year, d.DataPedido.Month, d.DataPedido.Day)).Select(p => new VendaDiariaViewModel { DataVendas = p.Key, QuantidadePedidos = p.Count(), ValorDiario = p.Sum(i => i.ItemPedidoSet.Where(k => k.PedidoId == i.Id).Sum(j => j.Quantidade * j.ProdutoSet.Valor)) }).OrderByDescending(o=> o.DataVendas).Take(10);

            return View();
        }


    }
}
