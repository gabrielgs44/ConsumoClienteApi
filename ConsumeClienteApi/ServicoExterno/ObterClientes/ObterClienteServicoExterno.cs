using ConsumeClienteApi.Comum.Dto;
using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.Ioc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;

namespace ConsumeClienteApi.ServicoExterno.ObterClientes
{
    public class ObterClienteServicoExterno : IObterClienteServicoExterno
    {
        private const string UriString = "https://localhost:44300/api/clientes";
        private const string RequestUri = "https://localhost:44300/api/clientes/Cliente?id=";
        private readonly HttpClient _httpClient;

        public ObterClienteServicoExterno(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public IEnumerable<Cliente> Executar(int? id)
        {
            if (_httpClient.BaseAddress == null)
            {
                _httpClient.BaseAddress = new Uri(UriString);
            }

            HttpResponseMessage responseCliente;

            if (id.HasValue)
            {
                responseCliente = _httpClient.GetAsync(RequestUri + id.Value).Result;
            }
            else
            {
                responseCliente = _httpClient.GetAsync(RequestUri).Result;
            }

            var clientesDto = JsonConvert.DeserializeObject<List<ClienteDto>>(responseCliente.Content.ReadAsStringAsync().Result);
            
            var mapper = InjecaoDeDependencia.Map();
            var clientes = mapper.Map<List<ClienteDto>, List<Cliente>>(clientesDto);
            return clientes;
        }
    }
}
