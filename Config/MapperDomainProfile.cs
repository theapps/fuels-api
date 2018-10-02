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
            CreateMap<FuelCreateDto, Fuel>(MemberList.Source);
        }
    }
}