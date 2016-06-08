using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace FrangoFone.Infraestructure
{
    public class ServicoHttp
    {
        #region Atributos 

        private HttpClient httpClient;
        #endregion
        #region Construtores

        public ServicoHttp()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, certificate, chain, errors) => { return true; };
        }
        #endregion

        #region Metodos Publicos
        public Task<string> Get(string url)
        {
            using (httpClient = new HttpClient())
            {
                Uri uri = new Uri(url);

                httpClient.Timeout = new TimeSpan(0, 5, 0); // 5 minutos
                httpClient.BaseAddress = uri;
                
                Task<HttpResponseMessage> task = httpClient.GetAsync(uri);

                task.Wait();

                if (task.Result.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(task.Result.ReasonPhrase);
                }

                return task.Result.Content.ReadAsStringAsync();
            }
        }


        public Task<string> Get(string url, HttpClientHandler handler)
        {

            using (httpClient = new HttpClient(handler))
            {
                Uri uri = new Uri(url);

                httpClient.Timeout = new TimeSpan(0, 5, 0); // 5 minutos
                httpClient.BaseAddress = uri;

                Task<HttpResponseMessage> task = httpClient.GetAsync(uri);

                task.Wait();

                if (task.Result.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(task.Result.ReasonPhrase);
                }

                return task.Result.Content.ReadAsStringAsync();
            }
        }

        public Task<string> Post(string url, string conteudo)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Uri uri = new Uri(url);

                httpClient.Timeout = new TimeSpan(0, 5, 0); // 5 minutos
                httpClient.BaseAddress = uri;

                HttpContent httpContent = new StringContent(conteudo);
                httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                Task<HttpResponseMessage> task = httpClient.PostAsync(uri, httpContent);

                task.Wait();

                if (task.Result.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception(task.Result.ReasonPhrase);
                }

                return task.Result.Content.ReadAsStringAsync();
            }
        }
        #endregion
    }
}