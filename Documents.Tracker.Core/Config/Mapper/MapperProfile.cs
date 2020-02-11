using Application.XIdentity.Core.DTO;
using AutoMapper;
using Documents.Tracker.Core.DTO;
using Documents.Tracker.Core.DTO.Orders;
using Documents.Tracking.Data.Entities;
using General.Services.Core.DTO;
using General.Services.Core.Entity;
using Orders.Core;

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
                .ForMember(x => x.Id, o => o.MapFrom(s => s.RefId));

            CreateMap<ConsumerDTO, ConsumerOTO>()
                .ReverseMap();

            CreateMap<ConsumerAddressDTO, ConsumerAddressOTO>().ReverseMap();

            CreateMap<DocStatus, DocStatusDTO>()
                .ForMember(x => x.RefId, o => o.Ignore()).ReverseMap();


            CreateMap<CountryDTO, CountriesOTO>().ReverseMap();
            CreateMap<GovernmentDTO, GovernmentOTO>().ReverseMap();
            CreateMap<LocationAreaDTO, LocationAreasOTO>().ReverseMap();
            CreateMap<CategoryDTO, CategoriesOTO>().ReverseMap();


            CreateMap<Category, CategoriesOTO>().ForMember(x => x.RefId, o => o.Ignore()).ReverseMap();
            CreateMap<Product, ProductOTO>()
                .ForMember(x => x.ProductUKey, o => o.MapFrom(s => s.UKey))
                .ForMember(x => x.RefId, o => o.Ignore())
                .ReverseMap();
            CreateMap<ProductDTO, ProductOTO>().ReverseMap();


            CreateMap<OrderDTO, OrderOTO>().ReverseMap();
            CreateMap<OrderItemDTO, OrderItemOTO>().ReverseMap();

        }

    }
}
