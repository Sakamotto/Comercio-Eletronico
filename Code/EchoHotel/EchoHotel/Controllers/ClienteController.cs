using EchoHotel.Application.Interfaces;
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
        public object Get()
        {
            var clientes = this.clienteService.GetAll();
            var res = Json(clientes);
            return Json(clientes);
            //return new string[] { "value1", "value2" };
        }

        // GET: api/Cliente/5
        public object Get(int id)
        {
            return Json(this.clienteService.GetById(id));
        }

        // POST: api/Cliente
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cliente/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cliente/5
        public void Delete(int id)
        {
        }
    }
}
