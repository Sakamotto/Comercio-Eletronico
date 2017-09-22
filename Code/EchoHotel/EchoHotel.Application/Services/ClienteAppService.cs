using EchoHotel.Application.Interfaces;
using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EchoHotel.Domain.Interfaces.Services;

namespace EchoHotel.Application.Services
{
    public class ClienteAppService : AppServiceBase<Cliente>, IClienteAppService
    {
        private readonly IClienteService _serviceBase;
        public ClienteAppService(IClienteService serviceBase) : base(serviceBase)
        {
            this._serviceBase = serviceBase;
        }
    }
}
