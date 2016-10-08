using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrangoFone.Infraestructure.BematechDLL
{
    public class FactoryBematechDLL
    {
        private static volatile FactoryBematechDLL instancia;

        public static FactoryBematechDLL Instancia
        {
            get { return instancia ?? new FactoryBematechDLL(); }
        }

        private FactoryBematechDLL() { }

        public IBematechDLL Criar(string contexto)
        {
            switch (contexto)
            {
                case "32":
                    return new Bematech32();
                case "64":
                    return new Bematech64();
                default:
                    return null;

            }
        }
    }
}
