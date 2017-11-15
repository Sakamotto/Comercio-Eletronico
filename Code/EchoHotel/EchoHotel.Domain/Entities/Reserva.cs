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
        public int AcomodacaoId { get; set; }

        public decimal Valor { get; set; }
        public string CodigoLocacao { get; set; }

        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        [Required]
        public bool Ativa { get; set; }

        public Acomodacao Acomodacao { get; set; }

        public virtual Compra Compra { get; set; }

        public bool isAtiva()
        {
            return this.DataTermino < DateTime.Now;
        }

        public bool Conflitante(DateTime dataInicio, DateTime dataTermino)
        {
            return ((dataInicio < this.DataInicio) && (dataTermino < this.DataTermino)) ||
                (dataInicio == this.DataInicio && dataTermino == this.DataTermino) ||
                (dataInicio > this.DataInicio && dataTermino > this.DataTermino);
        }

        public bool TemConflito(DateTime dataInicio, DateTime dataTermino)
        {
            return !(
                        ((dataInicio < this.DataInicio) && (dataTermino < this.DataInicio)) ||
                        (dataInicio > this.DataTermino)
                    );
        }


    }
}
