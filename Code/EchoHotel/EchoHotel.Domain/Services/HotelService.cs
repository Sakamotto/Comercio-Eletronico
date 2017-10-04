using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EchoHotel.Domain.Interfaces.Repositories;

namespace EchoHotel.Domain.Services
{
    public class HotelService : ServiceBase<Hotel>, IHotelService
    {
        private readonly IHotelRepository hotelRepository;

        public HotelService(IHotelRepository repository) : base(repository)
        {
            this.hotelRepository = repository;
        }

        public object GetHoteisPorData(DateTime dataInicio, DateTime dataTermino, int guests)
        {
            return this.hotelRepository.GetHoteisPorData(dataInicio, dataTermino, guests);
        }
    }
}
