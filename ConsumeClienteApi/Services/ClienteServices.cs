using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.ServicoExterno.ObterClientes;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ConsumeClienteApi.ServicoExterno.CadastrarClientes;
using ConsumeClienteApi.Comum.Exceptions;
using ConsumeClienteApi.ServicoExterno.DeletarClientes;

namespace ConsumeClienteApi.Services
{
    public class ClienteServices : IClienteServices
    {
        private readonly IObterClienteServicoExterno _obterCliente;
        private readonly ICadastrarClienteServicoExterno _cadastrarCliente;
        private readonly IDeletarClienteServicoExterno _deletarCliente;

        public ClienteServices(IObterClienteServicoExterno obterCliente, ICadastrarClienteServicoExterno cadastrarCliente, IDeletarClienteServicoExterno deletarCliente)
        {
            _obterCliente = obterCliente;
            _cadastrarCliente = cadastrarCliente;
            _deletarCliente = deletarCliente;
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

        public string DeletarCliente(int? id)
        {
            return _deletarCliente.Executar(id);
        }
    }
}
