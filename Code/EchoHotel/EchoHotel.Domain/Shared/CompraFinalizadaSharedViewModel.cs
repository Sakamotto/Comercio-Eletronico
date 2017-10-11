using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Shared
{
    public class CompraFinalizadaSharedViewModel
    {
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public List<ReservaSimplificadaShared> reservas { get; set; }
    }
}
