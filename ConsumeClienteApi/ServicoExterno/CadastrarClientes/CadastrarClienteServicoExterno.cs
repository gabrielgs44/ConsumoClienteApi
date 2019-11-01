using ConsumeClienteApi.Comum;
using ConsumeClienteApi.Comum.Dto;
using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.Ioc;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace ConsumeClienteApi.ServicoExterno.CadastrarClientes
{
    public class CadastrarClienteServicoExterno : ICadastrarClienteServicoExterno
    {
        private const string RequestUri = "https://localhost:44300/api/clientes/CadastrarCliente";
        private readonly IClienteHttp _clienteHttp;

        public CadastrarClienteServicoExterno(IClienteHttp httpClient)
        {
            _clienteHttp = httpClient;
        }

        public Cliente Executar(Cliente cliente)
        {
            var mapper = InjecaoDeDependencia.Map();
            var clienteDto = mapper.Map<Cliente, ClienteDto>(cliente);

            var jsonContent = JsonConvert.SerializeObject(clienteDto);
            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = _clienteHttp.HttpClient.PostAsync(RequestUri, contentString);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var clienteObtido = JsonConvert.DeserializeObject<ClienteDto>(content);

            return mapper.Map<ClienteDto, Cliente>(clienteObtido);
        }
    }
}
