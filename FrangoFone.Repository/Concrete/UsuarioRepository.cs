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
    public class UsuarioRepository : IUsuarioRepository
    {
        private Domain.FrangoFone dbContext;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public UsuarioRepository()
        {
            dbContext = new Domain.FrangoFone();
        }

        ~UsuarioRepository()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Apagar(UsuarioSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbContext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    dbContext.UsuarioSet.Remove(entity);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }
        }

        public void Atualizar(UsuarioSet entity)
        {
            try
            {
                dbContext.UsuarioSet.Add(entity);
                dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;       
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

        }
        
        public void Inserir(UsuarioSet entity)
        {
            try
            {
                dbContext.UsuarioSet.Add(entity);
                dbContext.Entry(entity).State = System.Data.Entity.EntityState.Added;
                dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public UsuarioSet ObterPorId(int id)
        {
            return dbContext.UsuarioSet.FirstOrDefault(p => p.Id == id);
        }

        public UsuarioSet ObterPorLogin(string login)
        {            
            return dbContext.UsuarioSet.Include("PermissaoSet").FirstOrDefault(p => p.Login == login);
        }

        public List<UsuarioSet> ObterPorNome(string nome)
        {
            return dbContext.UsuarioSet.Where(p => p.Nome.Contains(nome)).ToList();
        }

        public List<UsuarioSet> ObterTodos()
        {
            return dbContext.UsuarioSet.ToList();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~UsuarioRepository() {
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
