using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrangoFone.Infraestructure.BematechDLL
{
    public class Bematech32 : IBematechDLL
    {
        public int AcionaGuilhotina(int parcial_full)
        {
            return MP2032.AcionaGuilhotina(parcial_full);
        }

        public int BematechTX(string texto)
        {
            return MP2032.BematechTX(texto);
        }

        public int ConfiguraModeloImpressora(int model)
        {
            return MP2032.ConfiguraModeloImpressora(model);
        }

        public int FechaPorta()
        {
            return MP2032.FechaPorta();
        }

        public int IniciaPorta(string porta)
        {
            return MP2032.IniciaPorta(porta);
        }
    }
}
