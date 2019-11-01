using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.Services;
using System;
using System.Collections.Generic;
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
    }
}
