using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Domain;
using FrangoFone.Repository.Interface;
using NLog;

namespace FrangoFone.Repository.Concrete
{
    public class ItemPedidoRepository : IItemPedidoRepository
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private Domain.FrangoFone dbcontext;

        public ItemPedidoRepository()
        {
            dbcontext = new Domain.FrangoFone();
        }

        ~ItemPedidoRepository()
        {
            Dispose(true);
        }

        public void Apagar(ItemPedidoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    dbcontext.ItemPedidoSet.Remove(entity);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public void Atualizar(ItemPedidoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.ItemPedidoSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public void Inserir(ItemPedidoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.ItemPedidoSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public ItemPedidoSet ObterPorId(int id)
        {
            return dbcontext.ItemPedidoSet.FirstOrDefault(p => p.Id == id);
        }

        public List<ItemPedidoSet> ObterPorIdPedido(int idPedido)
        {
            return dbcontext.ItemPedidoSet.Include("ProdutoSet").Where(p => p.PedidoId == idPedido).ToList();
        }

        public List<ItemPedidoSet> ObterTodos()
        {
            return dbcontext.ItemPedidoSet.ToList();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbcontext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ItemPedidoRepository() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
