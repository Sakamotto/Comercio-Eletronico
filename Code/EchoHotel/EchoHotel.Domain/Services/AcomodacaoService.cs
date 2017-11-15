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
    public class AcomodacaoService : ServiceBase<Acomodacao>, IAcomodacaoService
    {
        private readonly IAcomodacaoRepository _repository;
        private readonly IHotelRepository _hotelRepository;
        private readonly IAdicionalRepository _adicionalRepository;
        public AcomodacaoService(IAcomodacaoRepository repository,
            IHotelRepository hotelRepository,
            IAdicionalRepository adicionalRepository) : base(repository)
        {
            this._repository = repository;
            this._hotelRepository = hotelRepository;
            this._adicionalRepository = adicionalRepository;
        }

        public Acomodacao GetAcomodacao(int id)
        {
            return this.PrepararParaRetorno(this._repository.GetById(id));
        }

        private Acomodacao PrepararParaRetorno(Acomodacao acomodacao)
        {
            acomodacao.Hotel = this._hotelRepository.GetById(acomodacao.HotelId);
            acomodacao.Adicionais = this._adicionalRepository.GetAdicionaisAcomodacao(acomodacao.Id);
            return acomodacao;

        }

    }
}
