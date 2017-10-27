using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Shared
{
    public class RequestCarrosDisponiveis
    {

        public DateTime Inicial { get; set; }
        public DateTime Final { get; set; }

        public int? AgenciaId { get; set; }
        public int? ItemId { get; set; }
        public string Token { get; set; }
    }
}
