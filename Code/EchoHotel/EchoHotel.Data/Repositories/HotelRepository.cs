using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Data.Repositories
{
    public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
    {

        public object GetHoteisPorData(DateTime dataInicio, DateTime dataTermino, int guests)
        {
            return this.Db.Hotel.SelectMany(h => h.Acomodacoes).Where(a => a.Valor > 60);
        }
    }
}
