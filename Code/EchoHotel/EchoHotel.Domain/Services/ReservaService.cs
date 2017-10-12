using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using EchoHotel.Domain.Interfaces.Services;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Domain.Services
{
    public class ReservaService : ServiceBase<Reserva>, IReservaService
    {
        private readonly IReservaRepository _repository;
        private readonly ICompraRepository _compraRepository;
        private readonly IClienteRepository _clienteRepository;
        private readonly IAcomodacaoRepository _acomodacaoRepository;

        public ReservaService(IReservaRepository repository,
            ICompraRepository compraRepository,
            IClienteRepository clienteRepository,
            IAcomodacaoRepository acomodacaoRepository
            ) : base(repository)
        {
            this._repository = repository;
            this._compraRepository = compraRepository;
            this._clienteRepository = clienteRepository;
            this._acomodacaoRepository = acomodacaoRepository;
        }

        public object FinalizarCompra(List<ReservaSimplificadaShared> reservas, int clienteId, DateTime dataInicio, DateTime dataTermino)
        {
            var compra = new Compra();
            var totalCompra = reservas.Sum(r => r.Valor);
            var reservasAdicionadas = new List<Reserva>();

            //compra.Cliente = _clienteRepository.GetById(clienteId);
            compra.ClienteId = clienteId;
            compra.CodigoCompra = Guid.NewGuid().ToString();
            compra.TotalCompra = totalCompra;

            try
            {
                //this._compraRepository.Add(compra);
                var compraAdicionada = this._compraRepository.Add(compra);
                //this._repository.SaveChanges();

                foreach (var reserva in reservas)
                {
                    var novaReserva = new Reserva();
                    //novaReserva.Acomodacao = _acomodacaoRepository.GetById(reserva.AcomodacaoId);
                    novaReserva.AcomodacaoId = reserva.AcomodacaoId;
                    novaReserva.DataInicio = dataInicio;
                    novaReserva.DataTermino = dataTermino;
                    novaReserva.Ativa = true;
                    novaReserva.CompraId = compraAdicionada.Id;
                    //novaReserva.Compra = compraAdicionada;
                    novaReserva.Valor = reserva.Valor;

                    var tempReserva = this._repository.Add(novaReserva);
                    //this._repository.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return new { sucesso = false };
            }

            return new { sucesso = true };
        }
    }
}
