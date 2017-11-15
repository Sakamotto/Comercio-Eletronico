using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EchoHotel.Domain.Interfaces.Repositories;

namespace EchoHotel.Domain.Services
{
    public class ClienteService : ServiceBase<Cliente>, IClienteService
    {
        private readonly IClienteRepository _repository;
        public ClienteService(IClienteRepository repository) : base(repository)
        {
            this._repository = repository;
        }

        public object AutenticarUsuario(string Email, string Senha)
        {
            var resultado = this._repository.GetAll().Where(c => c.Email == Email && c.Senha == Senha);
            return new { retorno = resultado.FirstOrDefault(), sucesso = resultado.Count() > 0 };
        }

        //public object UsuarioJaExiste(string email)
        //{
        //    var erros = this.GetAll().Where(c => c.Email == email);
        //}

        public object CadastrarUsuario(Cliente cliente)
        {
            // verificações
            var erros = this._repository.GetAll().Where(c => c.Email == cliente.Email);

            if (erros.Count() > 0)
            {
                return new { sucesso = false, mensagem = "Este usuário já existe"};
            }

            if (cliente.Endereco == null)
            {
                return new { sucesso = false, mensagem = "Endereço não está preenchido" };
            }

            this.Add(cliente);

            return new { sucesso = true, mensagem = "Usuário registrado com sucesso" };
            
        }
    }
}
