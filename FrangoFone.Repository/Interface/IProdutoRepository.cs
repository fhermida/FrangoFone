using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrangoFone.Repository.Interface;
using FrangoFone.Domain;

namespace FrangoFone.Repository.Interface
{
    public interface IProdutoRepository:IRepository<ProdutoSet>,IDisposable
    {
    }
}
