using System.Linq;
using AutoMapper;
using SIENN.DbAccess.Entities;

namespace SIENN.Services.DTO
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Unit, UnitDto>().ReverseMap();
            CreateMap<ProductType, ProductTypeDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(des => des.UnitCode,opt => opt.MapFrom(src => src.Unit.Code))
                .ForMember(des => des.TypeCode, opt => opt.MapFrom(src => src.ProductType.Code))
                .ForMember(des => des.Categories, opt => opt.MapFrom(src => src.ProductCategories.Select(pc => pc.Category.Code).ToArray()))
                .ReverseMap();
        }
    }
}
