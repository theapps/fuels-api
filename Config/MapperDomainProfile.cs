using System;
using api.Domain;
using api.ViewModels;
using AutoMapper;

namespace api.Config
{
    public class MapperDomainProfile:Profile
    {
        public MapperDomainProfile()
        {
            CreateMap<VehicleCreateDto, Vehicle>(MemberList.Source);
            CreateMap< VehicleDashboardDto, Vehicle>();
            CreateMap< VehicleEditDto, Vehicle>();            
            CreateMap<FuelCreateDto, Fuel>(MemberList.Source);
            CreateMap<FuelEditDto, Fuel>(MemberList.Source);

            CreateMap<Fuel, FuelListItemDto>()
                .ForMember(x=>x.Date,opt => 
                    opt.MapFrom(src => src.Date.ToString("dd.MM.yyyy")));
        }
    }
}