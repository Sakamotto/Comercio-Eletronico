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
    public class CompraService : ServiceBase<Compra>, ICompraService
    {
        private readonly ICompraRepository _repository;

        public CompraService(ICompraRepository repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
