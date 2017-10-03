using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CodigoCompra { get; set; }
        public decimal TotalCompra { get; set; }

        public int ClienteId { get; set; }

        [Required]
        public virtual ICollection<Reserva> Reservas { get; set; }

        [Required]
        public virtual Cliente Cliente { get; set; }

    }
}
