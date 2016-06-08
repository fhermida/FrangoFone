using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Domain;

namespace FrangoFone.Repository.Interface
{
    public interface IUsuarioRepository:IRepository<UsuarioSet>, IDisposable
    {
        List<UsuarioSet> ObterPorNome(string nome);
        UsuarioSet ObterPorLogin(string login);
    }
}
