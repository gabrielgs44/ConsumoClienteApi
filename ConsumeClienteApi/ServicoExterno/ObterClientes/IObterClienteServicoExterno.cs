using ConsumeClienteApi.Dominio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeClienteApi.ServicoExterno.ObterClientes
{
    public interface IObterClienteServicoExterno
    {
        public IEnumerable<Cliente> Executar(int? id);
    }
}
