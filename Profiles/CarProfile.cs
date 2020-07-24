using AutoMapper;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Profiles
{
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            CreateMap<Car, CarDetailDTO>();

            CreateMap<CarCreateDTO, Car>()
                .ForMember(
                    dest => dest.Model,
                    opt => opt.MapFrom(src => (src.Company + src.Type)));

            // CreateMap<Pokemon, PokemonDetailDTO>();
        }
    }
}