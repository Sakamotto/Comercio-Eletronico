using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Endereco
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Cep { get; set; }
        public string Rua { get; set; }

        [Required]
        public string Bairro { get; set; }

        public int? Numero { get; set; }

        [Required]
        public string Cidade { get; set; }

        public string Sigla { get; set; }

        [Required]
        public string Estado { get; set; }

        [MaxLength(2)]
        public string UF { get; set; }
    }
}
