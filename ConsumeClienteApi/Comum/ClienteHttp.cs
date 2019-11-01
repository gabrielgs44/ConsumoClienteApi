using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsumeClienteApi.Comum
{
    public class ClienteHttp : IClienteHttp
    {

        public ClienteHttp(string uri = null)
        {
            HttpClient = new HttpClient();
            HttpClient.BaseAddress = new Uri(uri ?? "https://localhost:44300/api/clientes");
        }

        public HttpClient HttpClient { get;}
    }
}
