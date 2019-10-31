using ConsumeClienteApi.Dominio;
using ConsumeClienteApi.Ioc;
using ConsumeClienteApi.Services;
using ConsumeClienteApi.ServicoExterno.CadastrarClientes;
using ConsumeClienteApi.ServicoExterno.ObterClientes;
using System;
using System.Collections.Generic;

namespace ConsumeClienteApi
{
    class Program
    {
        static void Main(string[] args)
        {
            InjecaoDeDependencia.Executar();

            IClienteServices clienteServices = new ClienteServices(new ObterClienteServicoExterno(new System.Net.Http.HttpClient()),
                                                                   new CadastrarClienteServicoExterno(new System.Net.Http.HttpClient()));

            var continuar = true;
            do
            {
                Console.WriteLine("1 - Cadastrar cliente");
                Console.WriteLine("2 - Obter cliente");
                Console.Write("Selecione o serviço: ");

                try
                {
                    
                    int opcao = int.Parse(Console.ReadLine());
                    switch (opcao)
                    {
                        case 1:
                            OpcaoCliente.CadastrarCliente(clienteServices);
                            break;
                        case 2:
                            OpcaoCliente.ObterCliente(clienteServices);
                            break;
                        default:
                            Console.WriteLine("Opcão inválida!");
                            break;
                    }

                    Console.Write("Deseja continuar? (S ou N)");
                    continuar = char.Parse(Console.ReadLine().ToUpper()) == 'S';
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continuar = false;
                }

            } while (continuar);

        }
    }
}
