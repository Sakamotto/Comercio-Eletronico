using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Data.Repositories
{
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {

        public object GetHoteisPorData(DateTime dataInicio, DateTime dataTermino, int enderecoId, string cidade, int guests)
        {
            //return this.Db.Hotel.SelectMany(h => h.Acomodacoes).Where(a => a.Valor > 60);
            var result = this.GetContext().Database.SqlQuery<Retorno>(@"
                    SELECT
	                    h.Id as HotelId,
	                    h.QtdAcomodacoes,
	                    h.Descricao,
	                    h.Nome,
	                    a.Valor,
	                    a.Capacidade,
	                    a.Descricao,
	                    a.Id as AcomodacaoId,
	                    e.Cep,
	                    e.Rua,
	                    e.Bairro,
	                    e.Cidade,
	                    e.Numero

                    FROM Hotel h
                    INNER JOIN Acomodacao a ON(h.Id = a.HotelId)
                    LEFT JOIN Reserva r ON(r.AcomodacaoId = a.Id) and 
	                    (@dataInicio is null or r.DataInicio < @dataInicio) and
	                    (@dataTermino is null or r.DataTermino > @dataTermino)

                    INNER JOIN Endereco e ON(e.Id = h.EnderecoId)

                    WHERE (@cidade is null or e.Cidade like '%' + @cidade + '%') and
                    (@guests is null or a.Capacidade >= @guests) and 
	(@dataInicio is null or r.DataInicio is null or r.DataInicio < @dataInicio) and
	(@dataTermino is null or r.DataTermino is null or r.DataTermino > @dataTermino)",
                    new SqlParameter("@dataInicio", dataInicio),
                    new SqlParameter("@dataTermino", dataTermino),
                    new SqlParameter("@enderecoId", enderecoId),
                    new SqlParameter("@cidade", cidade),
                    new SqlParameter("@guests", guests)).ToList();



            return result;
            //return this.Db.Hotel.SelectMany(h => h.Acomodacoes).
            //    Where(a => !(dataInicio > a.Reserva.DataTermino && dataTermino < a.Reserva.DataInicio)|| a.Reserva == null);
        }

        class Retorno
        {
            public int? HotelId { get; set; }
            public int? QtdAcomodacoes { get; set; }
            public string DescricaoHotel { get; set; }
	        public string Nome { get; set; }
	        public decimal? Valor { get; set; }
	        public int? Capacidade { get; set; }
	        public string DescricaoAcomodacao { get; set; }
	        public int? AcomodacaoId { get; set; }
            public string Cep { get; set; }
            public string Rua { get; set; }
            public string Bairro { get; set; }
            public string Cidade { get; set; }
            public int? Numero { get; set; }
        }
    }
}
