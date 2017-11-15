using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Adicional
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [Required]
        public int Tipo { get; set; }

        [IgnoreDataMember]
        public ICollection<Acomodacao> Acomodacoes { get; set; }
        [IgnoreDataMember]
        public ICollection<Hotel> Hoteis { get; set; }
    }
}
