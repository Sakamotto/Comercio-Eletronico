using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using EchoHotel.Domain.Interfaces.Services;
using EchoHotel.Domain.Shared;
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

        public object FinalizarCompra(List<CompraFinalizadaShared> reservas, int clienteId, DateTime dataInicio, DateTime dataTermino)
        {
            return this._repository.FinalizarCompra(reservas, clienteId, dataInicio, dataTermino);
        }
    }
}
