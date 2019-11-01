using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace ConsumeClienteApi.Comum
{
    public interface IClienteHttp
    {
        public HttpClient HttpClient { get; }
    }
}
