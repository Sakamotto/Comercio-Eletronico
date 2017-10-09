using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Data.Repositories
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public IEnumerable<object> GetCidades()
        {
            return this.Db.Database.SqlQuery<Endereco>("SELEC * FROM ENDERECO");
        }
    }
}
