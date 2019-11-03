using AutoMapper;
using Documents.Tracker.Core.DTO;
using Documents.Tracking.Data.Entities;
using General.App.Consumers.Core.DTO;

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

            CreateMap<ConsumerDTO, APPConsumerDTO>().ReverseMap();

        }

    }
}
