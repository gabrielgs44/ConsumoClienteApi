using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeClienteApi.Comum.Dto
{
    public class ClienteDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
