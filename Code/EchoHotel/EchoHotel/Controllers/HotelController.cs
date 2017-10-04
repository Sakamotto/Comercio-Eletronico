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
    public class HotelController : ApiController
    {

        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }

        // GET: api/Hotel
        public HttpResponseMessage Get()
        {
            var hoteis = this.hotelService.GetAll().ToList();
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, hoteis, "application/json");
        }

        // GET: api/Hotel/5
        public HttpResponseMessage Get(int id)
        {
            var hotel = this.hotelService.GetById(id);
            HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, hotel, "application/json");
        }

        [ActionName("GetHoteisPorData")]
        public object Get(DateTime dataInicio, DateTime dataTermino, int guests)
        {
            return this.hotelService.GetHoteisPorData(dataInicio, dataTermino, guests);
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
    }
}
