using AutoMapper;
using ConsumeClienteApi.Comum;
using ConsumeClienteApi.Comum.Dto;
using ConsumeClienteApi.Services;
using ConsumeClienteApi.ServicoExterno.ObterClientes;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace ConsumeClienteApi.Ioc
{
    public static class InjecaoDeDependencia
    {
        public static void Executar()
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IObterClienteServicoExterno, ObterClienteServicoExterno>()
                .AddSingleton<IClienteServices, ClienteServices>()
                .AddSingleton<IClienteHttp, ClienteHttp>()
                .AddSingleton(new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new ClientePerfil());
                    cfg.AddProfile(new ClienteDtoPerfil());

                }).CreateMapper())
                .BuildServiceProvider();
        }

        public static Mapper Map()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ClientePerfil());
                cfg.AddProfile(new ClienteDtoPerfil());
            });

            return new Mapper(mapperConfig);
        }
    }
}
