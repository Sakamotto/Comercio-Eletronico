using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Acomodacao
    {
        public int Id { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public bool Disponivel { get; set; }
        [Required]
        public int Capacidade { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }

        public virtual ICollection<Adicional> Adicionais { get; set; }

    }
}
