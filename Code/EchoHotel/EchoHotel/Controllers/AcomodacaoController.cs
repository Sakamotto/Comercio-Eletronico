using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EchoHotel.Controllers
{
    public class AcomodacaoController : ApiController
    {
        private readonly IAcomodacaoService _service;

        public AcomodacaoController(IAcomodacaoService service)
        {
            this._service = service;
        }

        // GET: api/Acomodacao
        public HttpResponseMessage Get()
        {
            var acomodacoes = this._service.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, acomodacoes, "application/json");
        }

        // GET: api/Acomodacao/5
        public HttpResponseMessage Get(int id)
        {
            var acomodacao = this._service.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, acomodacao, "application/json");
        }

        // POST: api/Acomodacao
        public void Post([FromBody]Acomodacao acomodacao)
        {
            this._service.Add(acomodacao);
        }

        // PUT: api/Acomodacao/5
        public void Put([FromBody]Acomodacao acomodacao)
        {
            this._service.Update(acomodacao);
        }

        // DELETE: api/Acomodacao/5
        public void Delete(int id)
        {
            this._service.Remove(this._service.GetById(id));
        }
    }
}
