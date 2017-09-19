using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    class Hotel
    {
        [Key]
        public int Id { get; set; }
        public int QtdAcomodacoes { get; set; }
        public int QtdEstrelas { get; set; }
        public string Descricao { get; set; }
        public Endereco EnderecoHotel { get; set; }
        public IEnumerable<Adicional> Adicionais { get; set; }

    }
}
