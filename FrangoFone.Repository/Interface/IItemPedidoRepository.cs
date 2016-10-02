using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Domain;

namespace FrangoFone.Repository.Interface
{
    public interface IItemPedidoRepository:IRepository<ItemPedidoSet>,IDisposable
    {
        List<ItemPedidoSet> ObterPorIdPedido(int idPedido);
    }
}
