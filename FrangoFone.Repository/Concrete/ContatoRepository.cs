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
    public class ContatoRepository : IContatoRepository
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private Domain.FrangoFone dbcontext;

        public ContatoRepository()
        {
            dbcontext = new Domain.FrangoFone();
        }

        ~ContatoRepository()
        {
            Dispose(true);
        }

        public void Apagar(ContatoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.ContatoSet.Remove(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public void Atualizar(ContatoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.ContatoSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                }  
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public void Inserir(ContatoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.ContatoSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public ContatoSet ObterPorId(int id)
        {
            return dbcontext.ContatoSet.FirstOrDefault(p => p.Id == id);
        }

        public List<ContatoSet> ObterTodos()
        {
            return dbcontext.ContatoSet.ToList();
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
        // ~ContatoRepository() {
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
