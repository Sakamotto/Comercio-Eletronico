using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Interfaces.Repositories
{
    public interface IHotelRepository : IRepositoryBase<Hotel>
    {
        object GetHoteisPorData(DateTime dataInicio, DateTime dataTermino, int? enderecoId, string cidade, int guests);
    }
}
