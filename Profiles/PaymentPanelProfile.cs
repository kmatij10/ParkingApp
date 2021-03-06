using AutoMapper;
using ParkingApp.Model;
using ParkingApp.Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingApp.Profiles
{
    public class PaymentPanelProfile : Profile
    {
        public PaymentPanelProfile()
        {
            CreateMap<PaymentPanel, PaymentPanelDetailDTO>();

            CreateMap<PaymentPanelCreateDTO, PaymentPanel>();
        }
    }
}