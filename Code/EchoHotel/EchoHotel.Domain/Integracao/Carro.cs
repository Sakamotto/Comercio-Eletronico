using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Shared
{
    public class Carro
    {
        public int Id { get; set; }

        public string Modelo { get; set; }
        public string Marca { get; set; }
        public string Placa { get; set; }
        public int Ano { get; set; }
        public string UrlImagem { get; set; }

        public int AgenciaId { get; set; }
        public int CategoriaId { get; set; }

        //public virtual Agencia Agencia { get; set; }
        //public virtual Categoria Categoria { get; set; }
        //public virtual ICollection<Item> Itens { get; set; }
    }
}
