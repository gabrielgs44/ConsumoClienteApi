using ConsumeClienteApi.Comum.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeClienteApi.ServicoExterno.AtualizarClientes
{
    public interface IAtualizarClienteServicoExterno
    {
        public string Executar(ClienteDto clienteDto);
    }
}
