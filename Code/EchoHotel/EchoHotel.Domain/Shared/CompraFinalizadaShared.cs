using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Shared
{
    public class CompraFinalizadaShared
    {
        public int AcomodacaoId { get; set; }
        //public string CodigoCompra { get; set; }
        //public int ClienteId { get; set; }
        //public decimal TotalCompra { get; set; } // acho que não é necessário
        public decimal Valor { get; set; }
        public string CodigoLocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
