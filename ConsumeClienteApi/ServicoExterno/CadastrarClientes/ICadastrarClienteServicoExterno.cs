using ConsumeClienteApi.Dominio;

namespace ConsumeClienteApi.ServicoExterno.CadastrarClientes
{
    public interface ICadastrarClienteServicoExterno
    {
        public Cliente Executar(Cliente cliente);
    }
}
