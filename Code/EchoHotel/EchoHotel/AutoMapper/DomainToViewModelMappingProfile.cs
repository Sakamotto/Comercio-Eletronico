using AutoMapper;
using EchoHotel.Domain.Entities;
using EchoHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoHotel.AutoMapper
{
    public class DomainToViewModelMappingProfile: Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<AcomodacaoViewModel, Acomodacao>();
            CreateMap<ReservaViewModel, Reserva>();
        }

    }
}