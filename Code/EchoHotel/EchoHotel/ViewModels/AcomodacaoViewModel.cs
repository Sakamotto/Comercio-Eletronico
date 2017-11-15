using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoHotel.ViewModels
{
    public class AcomodacaoViewModel
    {

        public int Id { get; set; }

        public int HotelId { get; set; }

        public decimal Valor { get; set; }
        public bool Disponivel { get; set; }
        public int Capacidade { get; set; }

        public string Descricao { get; set; }

        public ICollection<Adicional> Adicionais { get; set; }

        public Hotel Hotel { get; set; }

    }
}