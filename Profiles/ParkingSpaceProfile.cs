using AutoMapper;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Profiles
{
    public class ParkingSpaceProfile : Profile
    {
        public ParkingSpaceProfile()
        {
            CreateMap<ParkingSpace, ParkingSpaceDetailDTO>();

            CreateMap<ParkingSpaceCreateDTO, ParkingSpace>();
        }
    }
}