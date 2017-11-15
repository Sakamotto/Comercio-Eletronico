using EchoHotel.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Interfaces.Services
{
    public interface IClienteService : IServiceBase<Cliente>
    {
        object AutenticarUsuario(string Email, string Senha);
        object CadastrarUsuario(Cliente cliente);
    }
}
