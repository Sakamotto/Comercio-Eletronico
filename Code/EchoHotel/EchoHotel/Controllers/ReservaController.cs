using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EchoHotel.Controllers
{
    [RoutePrefix("api/Reserva")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ReservaController : ApiController
    {

        private readonly IReservaService _reservaService;

        public ReservaController(IReservaService reservaService)
        {
            this._reservaService = reservaService;
        }

        [Route("FinalizarCompra")]
        [HttpPost]
        public object FinalizarCompra(List<CompraFinalizadaShared> reservas, int clienteId, DateTime dataInicio, DateTime dataTermino)
        {
            return this._reservaService.FinalizarCompra(reservas, clienteId, dataInicio, dataTermino);
        }

        // GET: api/Reserva
        public IEnumerable<Reserva> Get()
        {
            return this._reservaService.GetAll();
        }

        // GET: api/Reserva/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Reserva
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Reserva/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Reserva/5
        public void Delete(int id)
        {
        }
    }
}
