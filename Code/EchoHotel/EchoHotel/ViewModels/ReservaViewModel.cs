using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EchoHotel.ViewModels
{
    public class ReservaViewModel
    {
        public int Id { get; set; }

        public int CompraId { get; set; }
        public int AcomodacaoId { get; set; }
        public decimal Valor { get; set; }
        public string CodigoLocacao { get; set; }
        public string UrlImgHotel { get; set; }
        public string UrlImgAcomodacao { get; set; }
        public decimal TotalCompra { get; set; }
        public string NomeHotel { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataTermino { get; set; }
        public bool Ativa { get; set; }
    }
}