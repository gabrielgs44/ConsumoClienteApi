using ConsumeClienteApi.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeClienteApi.Services
{
    public interface IClienteServices
    {
        public IEnumerable<Cliente> ObterClientes(int? id = null);
        public Cliente CadastrarCliente(int id, string nome, string login, string senha);
        public string DeletarCliente(int? id);
    }
}
