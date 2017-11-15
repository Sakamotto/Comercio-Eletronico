using AutoMapper;
using EchoHotel.Application.Interfaces;
using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using EchoHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace EchoHotel.Controllers
{
    [RoutePrefix("api/Cliente")]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ClienteController : ApiController
    {

        private readonly IClienteService clienteService;

        public ClienteController(IClienteService clienteService)
        {
            this.clienteService = clienteService;
        }

        // retornar o usuario e o status
        [Route("AutenticarUsuario")]
        [HttpPost]
        public HttpResponseMessage AutenticarUsuario(ClienteAuthViewModel cliente)
        {
            //var cliente = Mapper.Map<Cliente>(vm);
            var resultado = this.clienteService.AutenticarUsuario(cliente.Email, cliente.Senha);
            return Request.CreateResponse(HttpStatusCode.OK, resultado, "application/json");
        }

        // GET: api/Cliente
        public HttpResponseMessage Get()
        {
            var clientes = this.clienteService.GetAll().ToList();
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, clientes, "application/json");
        }

        // GET: api/Cliente/5
        public HttpResponseMessage Get(int id)
        {
            var cliente = this.clienteService.GetById(id);
            //HttpContext.Current.Response.AddHeader("Access-Control-Allow-Origin", "*");
            return Request.CreateResponse(HttpStatusCode.OK, cliente, "application/json");
        }

        // POST: api/Cliente
        // Fazer verificação se o usuário é único pelo email
        public HttpResponseMessage Post([FromBody]Cliente cliente)
        {
            //this.clienteService.Add(cliente);
            var retorno = this.clienteService.CadastrarUsuario(cliente);
            return Request.CreateResponse(HttpStatusCode.OK, retorno);
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

    public class ClienteAuthViewModel
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
