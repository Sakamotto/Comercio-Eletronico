﻿using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Interfaces.Repositories
{
    public interface IReservaRepository : IRepositoryBase<Reserva>
    {
        object FinalizarCompra(List<ReservaSimplificadaShared> reservas, int clienteId, DateTime dataInicio, DateTime dataTermino);
        List<Reserva> GetAllFromCliente(int clienteId);
    }
}
