using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Shared
{
    public class ReservaSimplificadaShared
    {
        public int AcomodacaoId { get; set; }
        public decimal Valor { get; set; }
        public string CodigoLocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
    }
}
