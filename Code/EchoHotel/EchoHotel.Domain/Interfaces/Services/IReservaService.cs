﻿using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Interfaces.Services
{
    public interface IReservaService : IServiceBase<Reserva>
    {
        object FinalizarCompra(List<ReservaSimplificadaShared> reservas, int clienteId, DateTime dataInicio, DateTime dataTermino);
    }
}
