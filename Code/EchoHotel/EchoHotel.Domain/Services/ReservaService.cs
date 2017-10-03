using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Services
{
    public class ReservaService: ServiceBase<Reserva>, IReservaService
    {
        private readonly IReservaRepository _repository;

        public ReservaService(IReservaRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
