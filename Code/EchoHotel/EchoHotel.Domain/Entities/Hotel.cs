using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Entities
{
    public class Hotel
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        public string CNPJ { get; set; }

        [Required]
        public int QtdAcomodacoes { get; set; }
        public int QtdEstrelas { get; set; }

        [MaxLength(500)]
        public string Descricao { get; set; }

        public int EnderecoId { get; set; }

        [Required]
        public virtual Endereco Endereco { get; set; }

        public virtual ICollection<Adicional> Adicionais { get; set; }

        public virtual ICollection<Acomodacao> Acomodacoes { get; set; }

    }
}
