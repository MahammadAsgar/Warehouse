using AutoMapper;
using Warehouse.Business.Dtos.Get;
using Warehouse.Business.Dtos.Post;
using Warehouse.DataAccess.Entities.Main;

namespace Warehouse.Business.Mappings
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Product, AddProductDto>().ReverseMap();
            CreateMap<Product, GetProductDto>().ReverseMap();
            CreateMap<Product, GetProductNameDto>().ReverseMap();
            CreateMap<ProductFile, GetProductFileDto>().ReverseMap();

            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryNameDto>().ReverseMap();

            CreateMap<MeatureType, AddMeatureTypeDto>().ReverseMap();
            CreateMap<MeatureType, GetMeatureTypeDto>().ReverseMap();
            CreateMap<MeatureType, GetMeatureTypeNameDto>().ReverseMap();
        }
    }
}
