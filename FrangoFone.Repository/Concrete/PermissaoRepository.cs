using System;
using System.Collections.Generic;
using System.Linq;               
using FrangoFone.Domain;
using FrangoFone.Repository.Interface;
using NLog;

namespace FrangoFone.Repository.Concrete
{
    public class PermissaoRepository : IPermissaoRepository
    {
        private Domain.FrangoFone dbcontext;
        private Logger logger = LogManager.GetCurrentClassLogger();
        
           
        public PermissaoRepository()
        {
            dbcontext = new Domain.FrangoFone();
        }

        ~PermissaoRepository()
        {
            Dispose(true);
            GC.SuppressFinalize(this);    
        }

        public void Apagar(PermissaoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.PermissaoSet.Remove(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {   
                logger.Error(ex);
            }
        }

        public void Atualizar(PermissaoSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.PermissaoSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }
        
        public void Inserir(PermissaoSet entity)
        {
            try
            {             
                dbcontext.PermissaoSet.Add(entity);
                dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Added;
                dbcontext.SaveChanges();
            }
            catch (Exception ex)
            {                    
                logger.Error(ex);
            }
        }

        public PermissaoSet ObterPorId(int id)
        {
           return dbcontext.PermissaoSet.FirstOrDefault(p => p.Id == id);
        }

        public List<PermissaoSet> ObterPorNome(string nome)
        {
            return dbcontext.PermissaoSet.Where(p => p.Nome.Contains(nome)).ToList();
        }

        public List<PermissaoSet> ObterTodos()
        {
            return dbcontext.PermissaoSet.ToList();
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
        // ~PermissaoRepository() {
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
