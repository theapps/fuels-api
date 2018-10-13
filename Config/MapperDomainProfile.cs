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
            CreateMap< Vehicle, VehicleListItemDto>()
                    .ForMember(x=>x.Rca,opt => 
                            opt.MapFrom(src => src.Rca.HasValue ? src.Rca.Value.ToString("dd.MM.yyyy") : null)) 
                     .ForMember(x=>x.Itp,opt => 
                            opt.MapFrom(src => src.Itp != null ? src.Itp.Value.ToString("dd.MM.yyyy") : null));
                
            CreateMap< VehicleEditDto, Vehicle>();            
            CreateMap<FuelCreateDto, Fuel>(MemberList.Source);
            CreateMap<FuelEditDto, Fuel>(MemberList.Source);

            CreateMap<Fuel, FuelListItemDto>()
                .ForMember(x=>x.Date,opt => 
                    opt.MapFrom(src => src.Date.ToString("dd.MM.yyyy")));
        }
    }
}