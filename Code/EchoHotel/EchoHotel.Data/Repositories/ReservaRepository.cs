using EchoHotel.Domain.Entities;
using EchoHotel.Domain.Interfaces.Repositories;
using EchoHotel.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
                var compraAdicionada = this._compraRepository.Add(compra);  //_compraRepository.Add(compra); //this.Db.Compra.Add(compra);
                //this.Db.SaveChanges();

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

                    var tempReserva = this.GetContext().Set<Reserva>().Add(novaReserva);
                    //this.Db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                return new { sucesso = false};
            }

            return new {sucesso = true};
        }

        public List<Reserva> GetAllFromCliente(int clienteId)
        {
            List<Reserva> res = this.GetContext().Database.SqlQuery<Reserva>(@"
                        SELECT r.Id, c.Id as CompraId, AcomodacaoId, ClienteId, DataInicio,
		                        DataTermino, h.Nome as NomeHotel, h.UrlImg as UrlImgHotel,
		                        a.UrlImg as UrlImgAcomodacao, a.Valor, TotalCompra
                        FROM Reserva r
                        inner join Compra c ON(r.CompraId = c.Id)
                        inner join Cliente cl ON(c.ClienteId = cl.Id)
                        inner join Acomodacao a ON(a.Id = r.AcomodacaoId)
                        inner join Hotel h ON(h.Id = a.HotelId)
                        WHERE cl.Id = @clienteId", 
                        new SqlParameter("@clienteId", clienteId)).ToList();

            return res;
        }
    }
}
