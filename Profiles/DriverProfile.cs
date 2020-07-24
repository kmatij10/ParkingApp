using AutoMapper;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile()
        {
            CreateMap<Driver, DriverDetailDTO>();

            CreateMap<DriverCreateDTO, Driver>();

            // CreateMap<Pokemon, PokemonDetailDTO>();
        }
    }
}