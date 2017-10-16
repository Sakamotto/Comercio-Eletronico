using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

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
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, result, "application/json");
        }

        [Route("ObterCarros")]
        [HttpGet]
        public HttpResponseMessage ObterCarros()
        {
            //var req = new
            //{
            //    Inicial = new DateTime(2017, 10, 01),
            //    Final = new DateTime(2017, 10, 15),
            //    Token = "CorrectHorseBatteryStaple"
            //};

            //var uri = new Uri("http://www.topgearapi.azurewebsites.net/api/carro");
            //var cliente = new HttpClient();

            //return await cliente.GetAsync(uri);

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://topgearapi.azurewebsites.net/api/carro");

            var dados = new RequisicaoCarros
            {
                Inicial = new DateTime(2017, 10, 13),
                Final = new DateTime(2017, 10, 15),
                AgenciaId = 1,
                Token = "CorrectHorseBatteryStaple"
            };

            //MemoryStream memmoryStream = new MemoryStream();
            //BinaryFormatter binayformator = new BinaryFormatter();
            //binayformator.Serialize(memmoryStream, dados);
            //string postString = string.Format("Inicial={0}&Final={1}&Token={2}", dados.Inicial, dados.Final, dados.Token);


            //request.ContentLength = postString.Length;
            request.Method = "GET";
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json";

            //StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
            //requestWriter.Write(postString);
            //requestWriter.Close();

            //Stream reqStream = request.GetRequestStream();
            ////Write the memory stream data into stream object before send it.
            //byte[] buffer = new byte[memmoryStream.Length];
            //int count = memmoryStream.Read(buffer, 0, buffer.Length);
            //reqStream.Write(buffer, 0, buffer.Length);

            try
            {
                // Get the response.
                WebResponse response = request.GetResponse();
                // Display the status.
                // Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                // Get the stream containing content returned by the server.
                Stream dataStream = response.GetResponseStream();
                // Open the stream using a StreamReader for easy access.
                StreamReader reader = new StreamReader(dataStream);
                // Read the content.
                //var res = reader.ReadToEnd();
                string responseFromServer = reader.ReadToEnd();
                // Display the content.
                Console.WriteLine(responseFromServer);
                // Clean up the streams and the response.
                reader.Close();
                response.Close();
                return Request.CreateResponse(HttpStatusCode.OK, responseFromServer, "application/json");
            }
            catch (Exception e)
            {

            }
            

            return Request.CreateResponse(HttpStatusCode.OK, new { }, "application/json");

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
