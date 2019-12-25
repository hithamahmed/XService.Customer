using AutoMapper;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.Core.FrontDTO;
using Documents.Tracking.Data.Entities;
using General.App.Consumers.Core.DTO;
using General.App.Consumers.Core.Entities;
using General.Services.Core.DTO;
using General.Services.Core.Entity;

namespace Documents.Tracker.Core.Config.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {

            CreateMap<DocRequirements, ProductDocumentsRequirementsOTO>()
                .ForMember(x => x.RefId, o => o.MapFrom(s => s.Id))
                .ReverseMap()
                .ForMember(x => x.Id, o => o.MapFrom(s => s.RefId));

            CreateMap<DocIssued, ProductIssuedDocumentsOTO>()
                .ForMember(x => x.RefId, o => o.MapFrom(s => s.Id))
                .ReverseMap()
                .ForMember(x=>x.Id , o=>o.MapFrom(s=>s.RefId));

            CreateMap<ConsumerDTO, ConsumerOTO>().ReverseMap();
            CreateMap<ConsumerAddressDTO, ConsumerAddressOTO>().ReverseMap();

            CreateMap<Consumer, ConsumerDTO>()
                .ForMember(x => x.RefId, o => o.Ignore()).ReverseMap();

            CreateMap<DocStatus, DocStatusDTO>()
                .ForMember(x => x.RefId, o => o.Ignore()).ReverseMap();

            CreateMap<ConsumerServices, ConsumerProductsOTO>()
                .ForMember(x => x.RefId, o => o.Ignore())
                .ForMember(x => x.DocStatus, o => o.MapFrom(s=>s.CurrentServiceStatus))
                .ReverseMap()
                .ForMember(x => x.CurrentServiceStatus, o => o.MapFrom(s => s.DocStatus));
            
            //CreateMap<ServiceCategory, ServiceCategoryDTO>()
            //    .ForMember(x => x.RefId, o => o.MapFrom(s => s.Id))
            //    .ReverseMap()
            //    .ForMember(x => x.Id, o => o.MapFrom(s => s.RefId));

            CreateMap<CountryDTO, CountriesOTO>().ReverseMap();
            CreateMap<GovernmentDTO, GovernmentOTO>().ReverseMap();
            CreateMap<LocationAreaDTO, LocationAreasOTO>().ReverseMap();
            CreateMap<CategoryDTO, CategoriesOTO>().ReverseMap();
            //CreateMap<ProductDTO, ServicesOTO>()
            //    .ForMember(x => x.ProductId, o => o.MapFrom(s => s.RefId))
            //    .ReverseMap();

            CreateMap<Category, CategoriesOTO>().ForMember(x => x.RefId, o => o.Ignore()).ReverseMap();
            CreateMap<Product, ProductOTO>()
                .ForMember(x => x.ProductUKey, o => o.MapFrom(s => s.UKey))
                .ForMember(x => x.RefId, o => o.Ignore())
                .ReverseMap();
            CreateMap<ProductDTO, ProductOTO>().ReverseMap();

        }

    }
}
