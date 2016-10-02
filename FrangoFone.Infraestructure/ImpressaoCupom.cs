using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NLog;
using System.Runtime.InteropServices;
using FrangoFone.Infraestructure.MP2032DLL;
using System.Configuration;

namespace FrangoFone.Infraestructure
{
   
    public class ImpressaoCupom : IDisposable
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        private int Retorno = 0;
        private string porta = ConfigurationManager.AppSettings["PortaImpressao"];
        private string ipImpressora = ConfigurationManager.AppSettings["IpImpressora"];

        public ImpressaoCupom()
        {
            
        }

        private void AbrirDispositivo()
        {


            Retorno = MP2032.ConfiguraModeloImpressora(7);

            if (Retorno <= 0)
            {
                logger.Error("Não foi possivel Configurar a impressora.");
                return;
            }

            if (!Enum.IsDefined(typeof(EnumPortas), porta))
            {
                logger.Error("Problema ao abrir comunicação com a impressora. Porta não configurada!");
                return;
            }

            if (porta == "ETHERNET")
            {
                Retorno = MP2032.IniciaPorta(ipImpressora); //inicia a porta com o IP digitado
            }
            else
            {
                Retorno = MP2032.IniciaPorta(porta);//inicia a porta com o valor da combo (exceto ethernet)
            }

            if (Retorno <= 0) //testa se a conexão da porta foi bem sucedido
            {
                logger.Error("Não foi possivel conectar na impressora.");
                return;
            }
            else
            {
                logger.Info("Impressora conectada com sucesso.");
            }       
        } 

        private void FecharDispositivo()
        {
            Retorno = MP2032.FechaPorta();

            if (Retorno <= 0)
            {
                logger.Error("Não foi possivel fechar a porta da impressora.");
                return;
            }

            logger.Error("Porta da impressora fechada com sucesso.");
        }

        public void EscreverNoDispositivo(string texto)
        {
            AbrirDispositivo();

            Retorno = MP2032.BematechTX(texto + "\r\n\r\n");      

            if (Retorno <= 0) //testa se a conexão da porta foi bem sucedido
            {
                logger.Error("Não foi possivel imprimir na impressora.");
                return;
            }
            
        }


        public void AcionarGuilhotinaTotal()
        {
            Retorno = MP2032.AcionaGuilhotina(1);

            if (Retorno <= 0) //testa se a conexão da porta foi bem sucedido
            {
                logger.Error("Não foi possivel acionar a guilhotina total.");
                return;
            }
        }

        public void AcionarGuilhotinaParcial()
        {
            Retorno = MP2032.AcionaGuilhotina(0);

            if (Retorno <= 0) //testa se a conexão da porta foi bem sucedido
            {
                logger.Error("Não foi possivel acionar a guilhotina parcial.");
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
                    FecharDispositivo();
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
