using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Interfaces.Services
{
    public interface IHotelService : IServiceBase<Hotel>
    {
        object GetHoteisPorData(DateTime dataInicio, DateTime dataTermino, int? enderecoId, string cidade, int guests);
    }
}
