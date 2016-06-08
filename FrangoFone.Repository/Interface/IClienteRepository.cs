using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Domain;

namespace FrangoFone.Repository.Interface
{
    public interface IClienteRepository:IRepository<ClienteSet>,IDisposable
    {
        List<ClienteSet> ObterPorNome(string nome);
        ClienteSet ObterPorCpf(string cpf);
    }
}
