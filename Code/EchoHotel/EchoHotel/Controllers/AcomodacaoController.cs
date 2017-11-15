using AutoMapper;
using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using EchoHotel.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EchoHotel.Controllers
{
    [RoutePrefix("api/Acomodacao")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class AcomodacaoController : ApiController
    {
        private readonly IAcomodacaoService _service;
        private readonly IHotelService _serviceHotel;

        public AcomodacaoController(IAcomodacaoService service, IHotelService hotelService)
        {
            this._service = service;
            this._serviceHotel = hotelService;
        }

        [Route("GetAcomodacao")]
        [HttpGet]
        public HttpResponseMessage GetAcomodacao(int id)
        {
            AcomodacaoViewModel result = Mapper.Map<AcomodacaoViewModel>(this._service.GetAcomodacao(id));
            return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
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
            var acomodacao = this._service.GetAcomodacao(id);
            //acomodacao.Hotel = this._serviceHotel.GetById(acomodacao.HotelId);
            return Request.CreateResponse(HttpStatusCode.OK, acomodacao);
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
