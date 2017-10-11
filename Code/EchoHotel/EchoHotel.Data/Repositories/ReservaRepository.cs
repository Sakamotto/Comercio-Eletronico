using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EchoHotel.Data.Repositories
{
    public class ReservaRepository : RepositoryBase<Reserva>, IReservaRepository
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IAcomodacaoRepository _acomodacaoRepository;
        private readonly ICompraRepository _compraRepository;
        public ReservaRepository(
            IClienteRepository clienteRepository, 
            IAcomodacaoRepository acomodacaoRepository,
            ICompraRepository compraRepository)
        {
            this._clienteRepository = clienteRepository;
            this._acomodacaoRepository = acomodacaoRepository;
            this._compraRepository = compraRepository;
        }

        public object FinalizarCompra(List<ReservaSimplificadaShared> reservas, int clienteId, DateTime dataInicio, DateTime dataTermino)
        {
            // Primeiro criamos inserimos a compra ...
            var compra = new Compra();
            var totalCompra = reservas.Sum(r => r.Valor);
            var reservasAdicionadas = new List<Reserva>();

            compra.Cliente = _clienteRepository.GetById(clienteId);
            compra.ClienteId = clienteId;
            compra.CodigoCompra = Guid.NewGuid().ToString();
            compra.TotalCompra = totalCompra;

            try
            {
                //this._compraRepository.Add(compra);
                var compraAdicionada = this.Db.Compra.Add(compra);  //_compraRepository.Add(compra); //this.Db.Compra.Add(compra);
                this.Db.SaveChanges();

                foreach (var reserva in reservas)
                {
                    var novaReserva = new Reserva();
                    novaReserva.Acomodacao = _acomodacaoRepository.GetById(reserva.AcomodacaoId);
                    novaReserva.AcomodacaoId = reserva.AcomodacaoId;
                    novaReserva.DataInicio = dataInicio;
                    novaReserva.DataTermino = dataTermino;
                    novaReserva.Ativa = true;
                    novaReserva.CompraId = compraAdicionada.Id;
                    novaReserva.Compra = compraAdicionada;
                    novaReserva.Valor = reserva.Valor;

                    var tempReserva = this.Db.Reserva.Add(novaReserva);
                    this.Db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return new { sucesso = false};
            }

            return new {sucesso = true};
        }
    }
}
