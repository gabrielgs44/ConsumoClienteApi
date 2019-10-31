using AutoMapper;
using ConsumeClienteApi.Dominio;

namespace ConsumeClienteApi.Comum.Dto
{
    public class ClientePerfil : Profile
    {
        public ClientePerfil() => CreateMap<ClienteDto, Cliente>();
    }
}
