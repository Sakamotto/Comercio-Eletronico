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
    public class HotelController : ApiController
    {

        private readonly IHotelService hotelService;

        public HotelController(IHotelService hotelService)
        {
            this.hotelService = hotelService;
        }

        // GET: api/Hotel
        public HttpResponseMessage Get()
        {
            var hoteis = this.hotelService.GetAll();
            return Request.CreateResponse(HttpStatusCode.OK, hoteis, "application/json");
        }

        // GET: api/Hotel/5
        public HttpResponseMessage Get(int id)
        {
            var hotel = this.hotelService.GetById(id);
            return Request.CreateResponse(HttpStatusCode.OK, hotel, "application/json");
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
