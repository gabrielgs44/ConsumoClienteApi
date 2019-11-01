using ConsumeClienteApi.Comum;
using ConsumeClienteApi.ServicoExterno.ObterClientes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ConsumeClienteApi.ServicoExterno.DeletarClientes
{
    public class DeletarClienteServicoExterno : IDeletarClienteServicoExterno
    {
        private readonly IClienteHttp _clienteHttp;

        public DeletarClienteServicoExterno(IClienteHttp clienteHttp)
        {
            _clienteHttp = clienteHttp;
        }

        public string Executar(int? id)
        {
            if (!id.HasValue)
            {
                throw new Exception("É necessário um id para deletar o cliente!");
            }

            var result = _clienteHttp.HttpClient.DeleteAsync("https://localhost:44300/api/clientes/Cliente?id=" + id.Value).Result;

            if (result.IsSuccessStatusCode)
            {
                return result.Content.ReadAsStringAsync().Result;
            }
            var erro = (JObject)JsonConvert.DeserializeObject(result.Content.ReadAsStringAsync().Result);
            return erro.ToString();
        }
    }
}
