using AutoMapper;
using Sam.CarInfo.Models;
using Sam.CarInfo.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sam.CarInfo
{
    public class DomainProfile : Profile
    {
        public DomainProfile()
        {
            CreateMap<Car, CarDisplayDto>()
               .ForMember(dest => dest.CarMakeName, opt => opt.ResolveUsing(sour => sour.CarModel.CarMake.CarMakeName))
               .ForMember(dest => dest.CarModelName, opt => opt.ResolveUsing(sour => sour.CarModel.CarModelName));

            CreateMap<CarMake, CarMakeDto>();
            CreateMap<CarModel, CarModelDto>();

        }
    }
}
