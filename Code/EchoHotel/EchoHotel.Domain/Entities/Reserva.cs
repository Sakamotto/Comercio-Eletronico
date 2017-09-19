using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    class Reserva
    {
        [Key]
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public string CodigoLocacao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataTermino { get; set; }
        public bool Ativa { get; set; }

    }
}
