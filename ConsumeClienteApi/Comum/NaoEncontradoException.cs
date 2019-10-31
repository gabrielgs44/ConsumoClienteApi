using System;
using System.Collections.Generic;
using System.Text;

namespace ConsumeClienteApi.Comum
{
    public class NaoEncontradoException : Exception
    {
        public NaoEncontradoException(string mensagem): base(mensagem)
        {
        }
    }
}
