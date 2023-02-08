using AutoMapper;
using Warehouse.Business.Dtos.Get.Main;
using Warehouse.Business.Dtos.Get.User;
using Warehouse.Business.Dtos.Post.Main;
using Warehouse.Business.Dtos.Post.User;
using Warehouse.DataAccess.Entities.Main;
using Warehouse.DataAccess.Entities.Users;
using Warehouse.DataAccess.Models;

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
            CreateMap<ProductSeachModel, ProductSearchModelDto>().ReverseMap();

            CreateMap<Category, AddCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryDto>().ReverseMap();
            CreateMap<Category, GetCategoryNameDto>().ReverseMap();

            CreateMap<MeasureType, AddMeasureTypeDto>().ReverseMap();
            CreateMap<MeasureType, GetMeasureTypeDto>().ReverseMap();
            CreateMap<MeasureType, GetMeasureTypeNameDto>().ReverseMap();


            CreateMap<Selling, AddSellingDto>().ReverseMap();
            CreateMap<Selling, GetSellingDto>().ReverseMap();

            CreateMap<Buying, AddBuyingDto>().ReverseMap();
            CreateMap<Buying, GetBuyingDto>().ReverseMap();

            CreateMap<Depot, GetDepotDto>().ReverseMap();
            CreateMap<Stock, GetStockDto>().ReverseMap();


            CreateMap<ApplicationUser, ApplicationUserDto>().ReverseMap();
            CreateMap<RegisterUserDto, ApplicationUser>().ReverseMap();
            CreateMap<ApplicationUser, RegisterUserDto>().ReverseMap();
            CreateMap<ApplicationUser, LoginUserDto>().ReverseMap();
            CreateMap<LoginUserDto, ApplicationUser>().ReverseMap();
        }
    }
}
