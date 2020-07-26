using AutoMapper;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Profiles
{
    public class RateProfile : Profile
    {
        public RateProfile()
        {
            CreateMap<Rate, RateDetailDTO>();

            CreateMap<RateCreateDTO, Rate>();
        }
    }
}