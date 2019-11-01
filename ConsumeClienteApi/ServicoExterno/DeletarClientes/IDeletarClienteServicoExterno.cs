using System.Threading.Tasks;

namespace ConsumeClienteApi.ServicoExterno.DeletarClientes
{
    public interface IDeletarClienteServicoExterno
    {
        public string Executar(int? id);
    }
}
