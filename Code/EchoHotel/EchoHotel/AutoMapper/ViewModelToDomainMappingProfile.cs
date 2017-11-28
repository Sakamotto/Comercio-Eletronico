using AutoMapper;
using EchoHotel.Domain.Entities;
using EchoHotel.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EchoHotel.AutoMapper
{
    public class ViewModelToDomainMappingProfile: Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Cliente, ClienteViewModel>();
            CreateMap<Acomodacao, AcomodacaoViewModel>();
            CreateMap<Reserva, ReservaViewModel>();
        }

    }
}