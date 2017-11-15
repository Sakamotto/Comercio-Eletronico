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
    public class AdicionalRepository : RepositoryBase<Adicional>, IAdicionalRepository
    {
        public ICollection<Adicional> GetAdicionaisAcomodacao(int id)
        {
            return this.GetContext().Database.SqlQuery<Adicional>(@"
            select * from Adicional a
              inner join AdicionalAcomodacao aa ON(a.Id = aa.Adicional_Id)
              where Acomodacao_Id = @acomodacaoId", new SqlParameter("@acomodacaoId", id)).ToList();
        }
    }
}
