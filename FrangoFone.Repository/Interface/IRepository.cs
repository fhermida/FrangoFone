using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrangoFone.Repository.Interface
{
   public interface IRepository<T> where T : class
    {
        T ObterPorId(int id);
        List<T> ObterTodos();
        void Atualizar(T entity);
        void Inserir(T entity);
        void Apagar(T entity);
    }
}
