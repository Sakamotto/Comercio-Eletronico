using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Compra
    {
        public int Id { get; set; }
        public string CodigoCompra { get; set; } // ???
        public decimal TotalCompra { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }

    }
}
