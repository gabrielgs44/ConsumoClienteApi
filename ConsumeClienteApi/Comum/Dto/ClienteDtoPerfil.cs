using AutoMapper;
using ConsumeClienteApi.Dominio;

namespace ConsumeClienteApi.Comum.Dto
{
    class ClienteDtoPerfil : Profile
    {
        public ClienteDtoPerfil() => CreateMap<Cliente, ClienteDto>();
    }
}
