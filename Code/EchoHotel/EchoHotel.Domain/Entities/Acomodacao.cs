using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Acomodacao
    {

        [Key]
        public int Id { get; set; }

        public int? ReservaId { get; set; }
        public int HotelId { get; set; }

        [Required]
        public decimal Valor { get; set; }
        [Required]
        public bool Disponivel { get; set; }
        [Required]
        public int Capacidade { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }

        public virtual ICollection<Adicional> Adicionais { get; set; }

        public virtual Reserva Reserva { get; set; }
        public virtual Hotel Hotel { get; set; }

    }
}
