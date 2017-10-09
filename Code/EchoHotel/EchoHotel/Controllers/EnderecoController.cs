using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace EchoHotel.Controllers
{
    [RoutePrefix("api/Endereco")]
    public class EnderecoController : ApiController
    {
        private readonly IEnderecoService _service;
        public EnderecoController(IEnderecoService service)
        {
            this._service = service;
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }


        [Route("Cidades")]
        [HttpGet]
        public HttpResponseMessage Cidades()
        {
            var cidades = this._service.GetCidades().ToList();
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, cidades, "application/json");
        }


        // GET: api/Endereco
        public IEnumerable<Endereco> Get()
        {
            return this._service.GetAll();
        }

        // GET: api/Endereco/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Endereco
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Endereco/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Endereco/5
        public void Delete(int id)
        {
        }
    }
}
