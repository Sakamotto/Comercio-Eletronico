using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    class Acomodacao
    {
        [Key]
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int Capacidade { get; set; }
        public string Descricao { get; set; }

        public IEnumerable<Adicional> Adicionais { get; set; }

    }
}
