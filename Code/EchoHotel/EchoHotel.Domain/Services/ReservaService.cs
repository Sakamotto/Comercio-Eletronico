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

        public object FinalizarCompra(CompraFinalizadaSharedViewModel reserva, int clienteId, DateTime dataInicio, DateTime dataTermino)
        {

            // Validações ...
            if (dataInicio == null || dataTermino == null)
            {
                return new { sucesso = false, mensagem = "As datas não devem estar vazias" };
            }

            var conflitos = this._repository.GetAll().Where(r => r.AcomodacaoId == reserva.AcomodacaoId)
                .Where(r => r.TemConflito(dataInicio, dataTermino));

            if (conflitos.Count() > 0)
            {
                return new { sucesso = false, mensagem = "Já existe uma reserva para essa acomodação na data informada" };
            }
            
            // Cadastros ...
            var compra = new Compra();
            compra.ClienteId = clienteId;
            compra.CodigoCompra = Guid.NewGuid().ToString();
            compra.TotalCompra = reserva.Valor;

            try
            {
                var compraAdicionada = this._compraRepository.Add(compra);
                var novaReserva = new Reserva();

                novaReserva.AcomodacaoId = reserva.AcomodacaoId;
                novaReserva.DataInicio = dataInicio;
                novaReserva.DataTermino = dataTermino;
                novaReserva.Ativa = true;
                novaReserva.CompraId = compraAdicionada.Id;
                novaReserva.Valor = reserva.Valor;

                this._repository.Add(novaReserva);
            }
            catch (Exception e)
            {
                return new { sucesso = false, mensagem = e.Message };
            }

            return new { sucesso = true, mensagem = "Reserva efetuada com sucesso!" };
        }
    }
}
