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
        public object FinalizarCompra(List<CompraFinalizadaShared> reservas, int clienteId, DateTime dataInicio, DateTime dataTermino)
        {
            var clienteRepository = new ClienteRepository();
            
            // Primeiro criamos inserimos a compra ...
            var compra = new Compra();
            var totalCompra = reservas.Sum(r => r.Valor);
            var reservasAdicionadas = new List<Reserva>();

            compra.Cliente = clienteRepository.GetById(clienteId);
            compra.ClienteId = clienteId;
            compra.CodigoCompra = Guid.NewGuid().ToString();
            compra.TotalCompra = totalCompra;

            try
            {
                var compraAdicionada = this.Db.Compra.Add(compra);
                this.Db.SaveChanges();

                foreach (var reserva in reservas)
                {
                    var novaReserva = new Reserva();
                    var acomodacao = new AcomodacaoRepository();
                    var listaAcomodacoes = new List<Acomodacao>();
                    listaAcomodacoes.Add(acomodacao.GetById(reserva.AcomodacaoId));
                    novaReserva.Acomodacoes = listaAcomodacoes;
                    novaReserva.DataInicio = dataInicio;
                    novaReserva.DataTermino = dataTermino;
                    novaReserva.Ativa = true;
                    novaReserva.CompraId = compraAdicionada.Id;
                    novaReserva.Compra = compraAdicionada;
                    novaReserva.Valor = reserva.Valor;

                    var tempReserva = this.Db.Reserva.Add(novaReserva);
                    this.Db.SaveChanges();
                    //novaReserva.Com
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
