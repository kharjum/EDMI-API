using AutoMapper;
using EMDI.API.Models;
using EMDI.Business.Entities;

namespace EMDI.API.Utils
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {

            CreateMap<ElectricMeterModel, ElectricMeter>()
                .ReverseMap();

            CreateMap<GatewaysModel, Gateways>()
                .ReverseMap();

            CreateMap<WaterMeterModel, WaterMeter>()
                .ReverseMap();

        }
    }
}
