using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Integracao
{
    public class Response<T>
    {
        public bool Sucesso { get; set; }
        public string Mensagem { get; set; }
        public T Dados { get; set; }
    }
}
