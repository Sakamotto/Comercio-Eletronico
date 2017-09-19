using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    class Compra
    {
        [Key]
        public int Id { get; set; }
        public string CodigoCompra { get; set; } // ???
        public decimal TotalCompra { get; set; }

        public IEnumerable<Reserva> Reservas { get; set; }

    }
}
