using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using ConsumeClienteApi.Comum;
using ConsumeClienteApi.Comum.Dto;
using Newtonsoft.Json;

namespace ConsumeClienteApi.ServicoExterno.AtualizarClientes
{
    public class AtualizarClienteServicoExterno : IAtualizarClienteServicoExterno
    {
        private readonly IClienteHttp _clienteHttp;
        private const string RequestUri = "https://localhost:44300/api/clientes/AtualizarCliente?id=";

        public AtualizarClienteServicoExterno(IClienteHttp httpClient)
        {
            _clienteHttp = httpClient;
        }

        public string Executar(ClienteDto clienteDto)
        {
            var jsonContent = JsonConvert.SerializeObject(clienteDto);

            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var resultado = _clienteHttp.HttpClient.PutAsync(RequestUri + clienteDto.Id, contentString);

            return resultado.Result.Content.ReadAsStringAsync().Result;
        }
    }
}
