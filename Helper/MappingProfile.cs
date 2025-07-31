
using AutoMapper;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;


namespace ECommerceBackend.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UpdateCategoryDto, TblCategory>().ReverseMap();
            CreateMap<UpdateProductDto, TblProduct>().ReverseMap();
        }

    }
}
