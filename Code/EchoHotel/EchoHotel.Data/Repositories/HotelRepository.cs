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

        public object GetHoteisPorData(DateTime dataInicio, DateTime dataTermino, int? enderecoId, string cidade, int guests)
        {
            var result = this.GetContext().Database.SqlQuery<Retorno>(@"
                    SELECT distinct a.Id as AcomodacaoId,
	                    h.Id as HotelId,
	                    h.QtdAcomodacoes,
	                    h.Descricao,
	                    h.Nome,
	                    a.Valor,
	                    a.Capacidade,
	                    a.Descricao,
	                    e.Cep,
	                    e.Rua,
	                    e.Bairro,
	                    e.Cidade,
	                    e.Numero

                    FROM Hotel h
                    INNER JOIN Endereco e ON(e.Id = h.EnderecoId)
                    INNER JOIN Acomodacao a ON(h.Id = a.HotelId)
                    LEFT JOIN Reserva r ON(a.Id = r.AcomodacaoId) and
	                    (	(r.DataInicio is null or (@dataInicio between r.DataInicio and r.DataTermino)) or
		                    (r.DataTermino is null or (@dataTermino between r.DataInicio and r.DataTermino)) or
		                    (r.DataInicio is null or (r.DataInicio between  @dataInicio and @dataTermino)) or
		                    (r.DataTermino is null or (r.DataTermino between  @dataInicio and @dataTermino))
	                    )

                    WHERE
	                    (@cidade is null or e.Cidade like '%' + @cidade + '%') and
	                    (@guests is null or a.Capacidade >= @guests)
	                    and
	                    (
		                    ( (r.DataInicio is null or (r.DataInicio < @dataInicio and r.DataTermino < @dataInicio)) or
		                    (r.DataTermino is null or (r.DataInicio > @dataTermino and r.DataTermino > @dataTermino )) )		
	                    )",
                    new SqlParameter("@dataInicio", dataInicio),
                    new SqlParameter("@dataTermino", dataTermino),
                    new SqlParameter("@enderecoId", enderecoId),
                    new SqlParameter("@cidade", cidade),
                    new SqlParameter("@guests", guests)).ToList();



            return result;
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
