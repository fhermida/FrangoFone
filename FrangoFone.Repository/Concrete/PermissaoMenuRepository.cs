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
    public class PermissaoMenuRepository : IPermissaoMenuRepository
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private Domain.FrangoFone dbcontext;

        public PermissaoMenuRepository()
        {
            dbcontext = new Domain.FrangoFone();
        }

        ~PermissaoMenuRepository()
        {
            Dispose(true);
        }

        public void Apagar(PermissaoMenuSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    dbcontext.PermissaoMenuSet.Remove(entity);
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public void Atualizar(PermissaoMenuSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.PermissaoMenuSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public void Inserir(PermissaoMenuSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.PermissaoMenuSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Added;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public PermissaoMenuSet ObterPorId(int id)
        {
            return dbcontext.PermissaoMenuSet.FirstOrDefault(p => p.Id == id);
        }

        public List<PermissaoMenuSet> ObterTodos()
        {
            return dbcontext.PermissaoMenuSet.ToList();
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
        // ~PermissaoMenuRepository() {
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
