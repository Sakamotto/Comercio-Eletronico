using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Integracao;
using EchoHotel.Domain.Interfaces.Services;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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

        //[Route("FinalizarCompra")]
        //[HttpPost]
        //public object FinalizarCompra(CompraFinalizadaSharedViewModel reservas)
        //{
        //    var dataInicio = reservas.reservas.First().DataInicio;
        //    return this._reservaService.FinalizarCompra(reservas.reservas, 1, dataInicio, reservas.DataTermino);
        //}

        [Route("FinalizarCompra")]
        [HttpPost]
        public object FinalizarCompra(CompraFinalizadaSharedViewModel reserva)
        {
            var dataInicio = reserva.DataInicio;
            return this._reservaService.FinalizarCompra(reserva, reserva.ClienteId, dataInicio, reserva.DataTermino);
        }

        [Route("ObterCarrosDisponiveis")]
        [HttpGet]
        public Response<List<Carro>> ObterCarrosDisponiveis(DateTime dataInicio, DateTime dataTermino)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://topgearapi.azurewebsites.net/api/")
            };

            RequestCarrosDisponiveis req = new RequestCarrosDisponiveis
            {
                Inicial = dataInicio,
                Final = dataTermino,
                AgenciaId = 15,
                Token = "CorrectHorseBatteryStaple"
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("carro/obterdisponiveis", req).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<List<Carro>>>().Result;
                return result;
            }
            else return new Response<List<Carro>> { Sucesso = false };
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
