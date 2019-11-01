using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsumeClienteApi
{
    public static class OpcaoCliente
    {
        public static void CadastrarCliente(IClienteServices clienteService)
        {
            Console.Clear();
            Console.Write("Digite o id: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Digite o nome: ");
            string nome = Console.ReadLine();
            Console.Write("Digite o login: ");
            string login = Console.ReadLine();
            Console.Write("Digite a senha: ");
            string senha = Console.ReadLine();

            var cliente = clienteService.CadastrarCliente(id, nome, login, senha);
            Console.WriteLine(cliente);
        }

        public static void ObterCliente(IClienteServices clienteService)
        {
            Console.Clear();
            Console.Write("Informe o id, caso queria um cliente específico: ");
            var idString = Console.ReadLine();
            int? id;

            if (idString == string.Empty)
            {
                id = null;
            }
            else
            {
                id = int.Parse(idString);
            }

            var clientes = clienteService.ObterClientes(id);
            foreach (Cliente x in clientes)
            {
                Console.WriteLine(x);
            }
        }

        public static void DeletarCliente(IClienteServices clienteService)
        {
            Console.Clear();
            Console.Write("Digite o id do cliente que deseja deletar: ");
            var idString = Console.ReadLine();
            int? id;

            if (idString == string.Empty)
            {
                id = null;
            }
            else
            {
                id = int.Parse(idString);
            }

            Console.WriteLine(clienteService.DeletarCliente(id));
        }

        public static void AtualizarCliente(IClienteServices clienteService)
        {
            Console.Clear();
            Console.Write("Digite o id do cliente que deseja atualizar: ");
            var idString = Console.ReadLine();
            int? id;

            if (idString == string.Empty)
            {
                id = null;
            }
            else
            {
                id = int.Parse(idString);
            }

            var cliente = clienteService.ObterClientes(id).First();
            Console.WriteLine(cliente);

            Console.Write("Digite o novo nome(digite nada para não alterar): ");
            string nome = Console.ReadLine();
            Console.Write("Digite o novo login(digite nada para não alterar): ");
            string login = Console.ReadLine();
            Console.Write("Digite a nova senha(digite nada para não alterar): ");
            string senha = Console.ReadLine();

            nome = nome != string.Empty ? nome : cliente.Nome;
            login = login != string.Empty ? login : cliente.Login;
            senha = senha != string.Empty ? senha : cliente.Senha;

            Console.WriteLine(clienteService.AtualizarCliente(id.Value, nome, login, senha));
        }
    }
}
