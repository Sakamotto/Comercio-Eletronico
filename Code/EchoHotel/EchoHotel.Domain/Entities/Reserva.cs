using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Reserva
    {

        [Key]
        public int Id { get; set; }

        public int CompraId { get; set; }

        public decimal Valor { get; set; }
        public string CodigoLocacao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        [Required]
        public bool Ativa { get; set; }

        [Required]
        public virtual ICollection<Acomodacao> Acomodacoes { get; set; }

        [Required]
        public virtual Compra Compra { get; set; }
    }
}
