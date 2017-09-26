using EchoHotel.Application.Interfaces;
using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EchoHotel.Controllers
{
    public class ClienteController : ApiController
    {

        private readonly IClienteAppService clienteService;

        public ClienteController(IClienteAppService clienteService)
        {
            this.clienteService = clienteService;
        }

        // GET: api/Cliente
        public HttpResponseMessage Get()
        {
            var clientes = this.clienteService.GetAll().ToList();
            return Request.CreateResponse(HttpStatusCode.OK, clientes, "application/json");
        }

        // GET: api/Cliente/5
        public HttpResponseMessage Get(int id)
        {
            var cliente = this.clienteService.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, cliente, "application/json");
        }

        // POST: api/Cliente
        public void Post([FromBody]Cliente cliente)
        {
            this.clienteService.Add(cliente);
        }

        // PUT: api/Cliente/5
        public void Put([FromBody]Cliente cliente)
        {
            this.clienteService.Update(cliente);
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
            Cliente clienteRemover = this.clienteService.GetById(id);
            this.clienteService.Remove(clienteRemover);
        }
    }
}
