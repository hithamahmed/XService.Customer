using AutoMapper;
using Documents.Tracker.Core.DTO;
using Documents.Tracking.Data.Entities;
using General.App.Consumers.Core.DTO;
using General.Services.Core.DTO;

namespace Documents.Tracker.Core.Config.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<DocRequirements, ServiceDocumentsRequirementsDTO>()
             .ForMember(x => x.RefId, o => o.MapFrom(s => s.Id)).ReverseMap()
             .ForMember(x => x.Id, o => o.MapFrom(s => s.RefId));

            CreateMap<DocFinal, ServiceIssuedDocumentsDTO>()
             .ForMember(x => x.RefId, o => o.MapFrom(s => s.Id)).ReverseMap()
             .ForMember(x => x.Id, o => o.MapFrom(s => s.RefId));

            CreateMap<ConsumerDTO, APPConsumerDTO>()
                .ReverseMap();
            CreateMap<ConsumerAddressDTO, AppConsumerAddressDTO>()
                //.ForMember(x=>x.CountriesList,o=>o.Ignore())
                //.ForMember(x=>x.FullLocation, o=>o.Ignore())
                .ReverseMap();
              


            CreateMap<CountryDTO, GeneralCountriesDTO>().ReverseMap();
            CreateMap<GovernmentDTO, GeneralGovernmentDTO>().ReverseMap();
            CreateMap<LocationAreaDTO, GeneralLocationAreasDTO>().ReverseMap();
            

        }

    }
}
