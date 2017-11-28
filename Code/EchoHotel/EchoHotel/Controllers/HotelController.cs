using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using EchoHotel.Domain.Integracao;
using EchoHotel.Domain.Util;

namespace EchoHotel.Controllers
{
    [RoutePrefix("api/Hotel")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HotelController : ApiController
    {

        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }

        // GET: api/Hotel
        public HttpResponseMessage Get()
        {
            var hoteis = this.hotelService.GetAll().ToList();
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, hoteis, "application/json");
        }

        // GET: api/Hotel/5
        public HttpResponseMessage Get(int id)
        {
            var hotel = this.hotelService.GetById(id);
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, hotel, "application/json");
        }        

        [Route("GetHoteisPorData")]
        [ActionName("GetHoteisPorData")]
        [HttpGet]
        public HttpResponseMessage GetHoteisPorData(DateTime dataInicio, DateTime dataTermino, int? enderecoId, string cidade, int guests)
        {
            var result = this.hotelService.GetHoteisPorData(dataInicio, dataTermino, enderecoId, cidade, guests);
            //EmailService email = new EmailService();
            //email.SendMail("");
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
        }

        [Route("GetHoteisPorDataLocal")]
        [HttpGet]
        public HttpResponseMessage GetHoteisPorDataLocal(DateTime dataInicio, DateTime dataTermino, string sigla, int guests)
        {
            var result = this.hotelService.GetHoteisPorDataLocal(dataInicio, dataTermino, sigla, guests);
            return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
        }

        [Route("ObterCarrosDisponiveis")]
        [HttpGet]
        public Response<List<Carro>> ObterCarrosDisponiveis()
        {
            HttpClient client = new HttpClient {
                BaseAddress = new Uri("http://topgearapi.azurewebsites.net/api/")
            };

            RequestCarrosDisponiveis req = new RequestCarrosDisponiveis
            {
                Inicial = new DateTime(2017, 10, 20),
                Final = new DateTime(2017, 10, 21),
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
            else return new Response<List<Carro>> { Sucesso = false};
        }

        [Route("GetCarro/{id}")]
        [HttpGet]
        public Response<Carro> GetCarro(int id)
        {
            HttpClient client = new HttpClient
            {
                BaseAddress = new Uri("http://topgearapi.azurewebsites.net/api/" + $"carro/porid/{id}")
            };

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<Carro>>().Result;
                return result;
            }
            else return new Response<Carro> { Sucesso = false };
        }


        // POST: api/Hotel
        public void Post([FromBody]Hotel hotel)
        {
            this.hotelService.Add(hotel);
        }

        // PUT: api/Hotel/5
        public void Put([FromBody]Hotel hotel)
        {
            this.hotelService.Update(hotel);
        }

        // DELETE: api/Hotel/5
        public void Delete(int id)
        {
            this.hotelService.Remove(this.hotelService.GetById(id));
        }

        [Serializable]
        class RequisicaoCarros
        {
            public DateTime Inicial { get; set; }
            public DateTime Final { get; set; }
            public int AgenciaId { get; set; }
            public string Token { get; set; }
        }
    }
}
