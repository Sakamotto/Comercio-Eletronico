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
    public class AdicionalService : ServiceBase<Adicional>, IAdicionalService
    {
        private readonly IAdicionalRepository _repository;
        public AdicionalService(IAdicionalRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
