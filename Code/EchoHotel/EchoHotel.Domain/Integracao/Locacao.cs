using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Integracao
{
    public class Locacao
    {
        public int Id { get; set; }

        [Required]
        public DateTime Retirada { get; set; }
        public DateTime Entrega { get; set; }
        public DateTime? Entrega_Real { get; set; }

        public int ClienteId { get; set; }
        public int CarroId { get; set; }
        public int? Agencia_RetiradaId { get; set; }
        public int? Agencia_EntregaId { get; set; }
    }
}
