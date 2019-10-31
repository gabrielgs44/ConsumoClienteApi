using System.Text;

namespace ConsumeClienteApi.Dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }

        private Cliente(int id, string nome, string login, string senha)
        {
            Id = id;
            Nome = nome;
            Login = login;
            Senha = senha;
        }

        public static Cliente Criar(int id, string nome, string login, string senha)
        {
            return new Cliente(id, nome, login, senha);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Id: " + Id);
            sb.AppendLine($"Nome: " + Nome);
            sb.AppendLine($"Login: " + Login);
            return sb.ToString();
        }
    }
}
