using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Repository.Interface;
using FrangoFone.Domain;
using NLog;

namespace FrangoFone.Repository.Concrete
{
    public class ClienteRepository : IClienteRepository
    {

        private Domain.FrangoFone dbcontext;
        private Logger logger = LogManager.GetCurrentClassLogger();
        
        public ClienteRepository()
        {
            dbcontext = new Domain.FrangoFone();
        }

        ~ClienteRepository()
        {
            Dispose(true);
        }

        public void Apagar(ClienteSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.ClienteSet.Remove(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Deleted;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }

        public void Atualizar(ClienteSet entity)
        {
            try
            {
                if (entity != null)
                {
                    dbcontext.ClienteSet.Add(entity);
                    dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                    dbcontext.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                logger.Error(ex);
            }
        }
                  
        public void Inserir(ClienteSet entity)
        {
            if (entity != null)
            {
                dbcontext.ClienteSet.Add(entity);
                dbcontext.Entry(entity).State = System.Data.Entity.EntityState.Added;
                dbcontext.SaveChanges();
            }
        }

        public ClienteSet ObterPorId(int id)
        {
            return dbcontext.ClienteSet.FirstOrDefault(p => p.Id == id);
        }

        public List<ClienteSet> ObterPorNome(string nome)
        {
            return dbcontext.ClienteSet.Where(p => p.Nome.Contains(nome) || p.Sobrenone.Contains(nome)).ToList();
        }

        public List<ClienteSet> ObterTodos()
        {
            return dbcontext.ClienteSet.ToList();
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
        // ~ClienteRepository() {
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

        public ClienteSet ObterPorCpf(string cpf)
        {
            return dbcontext.ClienteSet.FirstOrDefault(p => p.CPF == cpf);
        }
        #endregion
    }
}
