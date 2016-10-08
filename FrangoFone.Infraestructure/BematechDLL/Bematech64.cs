using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrangoFone.Infraestructure.BematechDLL
{
    public class Bematech64 :  IBematechDLL
    {
        public int AcionaGuilhotina(int parcial_full)
        {
            return MP2064.AcionaGuilhotina(parcial_full);
        }

        public int BematechTX(string texto)
        {
            return MP2064.BematechTX(texto);
        }

        public int ConfiguraModeloImpressora(int model)
        {
            return MP2064.ConfiguraModeloImpressora(model);
        }

        public int FechaPorta()
        {
            return MP2064.FechaPorta();
        }

        public int IniciaPorta(string porta)
        {
            return MP2064.IniciaPorta(porta);
        }
    }
}
