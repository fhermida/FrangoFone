using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
using System.Runtime.InteropServices;


namespace FrangoFone.Infraestructure
{
    
    public enum codigoRetonoMecaf
    {
        MECAFCOD_RET_SUCESSO = 0,
    }

    public class ImpressaoCupom    : IDisposable
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private bool portaAberta = false;

        [DllImport("MEGENCOM32.dll")]
        static extern int MEGENCOM32_AbrirDispositivo(string Porta, int Velocidade, byte Paridadee, int NumBits, int NumStopbits, int CtrlFluxo);

        [DllImport("MEGENCOM32.dll")]
         static extern int MEGENCOM32_FecharDispositivo(string Porta);

        [DllImport("MEGENCOM32.dll")]
         static extern int MEGENCOM32_EscrevernoDispositivo(string Porta, string Buffer, long NumBytes, ref long? BytesEscritos);

        public ImpressaoCupom()
        {
            AbrirDispositivo();
        }

        private void AbrirDispositivo()
        {
            long retorno;

            retorno = MEGENCOM32_AbrirDispositivo("COM4", 9600, Byte.Parse("S"), 8, 1, 1);

            if (retorno != (int) codigoRetonoMecaf.MECAFCOD_RET_SUCESSO)
            {
                logger.Error("Problema ao abrir comunicação com a impressora.Erro:{0}", retorno);
                return;
            }

            portaAberta = true;
        } 

        private void FecharDispositivo(string porta)
        {
            int retorno;

            retorno = MEGENCOM32_FecharDispositivo(porta);

            if (retorno != (int) codigoRetonoMecaf.MECAFCOD_RET_SUCESSO)
            {
                logger.Error("Problema ao fechar comunicação com a impressora.Erro:{0}", retorno);
                return;
            }

            portaAberta = false;
        }

        public void EscreverNoDispositivo(string texto)
        {
            int retorno;
            string buffer;
            long? bytesEscritos = null;
            string ativaNegrito;
            string desativaNegrito;

            desativaNegrito = ((char)27 + "E");
            ativaNegrito = ((char)27 + "F");

            buffer = ativaNegrito + texto + desativaNegrito + ((char)10);

            retorno = MEGENCOM32_EscrevernoDispositivo("COM4", buffer, 24, ref bytesEscritos);

            if (retorno != (int) codigoRetonoMecaf.MECAFCOD_RET_SUCESSO)
            {
                logger.Error("Problema ao escrever na impressora.Erro:{0}", retorno);
                return;
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    FecharDispositivo("COM4");
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~ImpressaoCupom() {
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
