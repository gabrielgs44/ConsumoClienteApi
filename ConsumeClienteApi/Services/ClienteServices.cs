using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.ServicoExterno.ObterClientes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsumeClienteApi.Comum;
using ConsumeClienteApi.ServicoExterno.CadastrarClientes;

namespace ConsumeClienteApi.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IObterClienteServicoExterno _obterCliente;
        private readonly ICadastrarClienteServicoExterno _cadastrarCliente;

        public ClienteServices(IObterClienteServicoExterno obterCliente, ICadastrarClienteServicoExterno cadastrarCliente)
        {
            _obterCliente = obterCliente;
            _cadastrarCliente = cadastrarCliente;
        }

        public IEnumerable<Cliente> ObterClientes(int? id = null)
        {
            var clientes = _obterCliente.Executar(id);

            if (!clientes.Any())
            {
                throw new NaoEncontradoException("Nenhum cliente foi encontrado!");
            }

            return clientes;
        }

        public Cliente CadastrarCliente(int id, string nome, string login, string senha)
        {
            var cliente = Cliente.Criar(id, nome, login, senha);

            return _cadastrarCliente.Executar(cliente);
        }
    }
}
