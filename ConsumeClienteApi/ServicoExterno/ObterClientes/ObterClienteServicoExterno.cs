using ConsumeClienteApi.Comum;
using ConsumeClienteApi.Comum.Dto;
using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.Ioc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

namespace ConsumeClienteApi.ServicoExterno.ObterClientes
{
    public class ObterClienteServicoExterno : IObterClienteServicoExterno
    {
        private const string RequestUri = "https://localhost:44300/api/clientes/Cliente?id=";
        private readonly IClienteHttp _clienteHttp;

        public ObterClienteServicoExterno(IClienteHttp httpClient)
        {
            _clienteHttp = httpClient;
        }

        public IEnumerable<Cliente> Executar(int? id)
        {
            HttpResponseMessage responseCliente;

            if (id.HasValue)
            {
                responseCliente = _clienteHttp.HttpClient.GetAsync(RequestUri + id.Value).Result;
            }
            else
            {
                responseCliente =  _clienteHttp.HttpClient.GetAsync(RequestUri).Result;
            }

            var clientesDto = JsonConvert.DeserializeObject<List<ClienteDto>>(responseCliente.Content.ReadAsStringAsync().Result);
            
            var mapper = InjecaoDeDependencia.Map();
            var clientes = mapper.Map<List<ClienteDto>, List<Cliente>>(clientesDto);
            return clientes;
        }
    }
}
