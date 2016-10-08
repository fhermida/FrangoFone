using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrangoFone.Infraestructure.BematechDLL
{
    public interface IBematechDLL
    {
        int ConfiguraModeloImpressora(int model);
        int IniciaPorta(String porta);
        int FechaPorta();
        int BematechTX(String texto);
        int AcionaGuilhotina(int parcial_full);
    }
}
