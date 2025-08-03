
using AutoMapper;
using ECommerceBackend.Models.ProductService;
using ECommerceBackend.Models.ProductService.DTOs;


namespace ECommerceBackend.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CategoryDto, TblCategory>().ReverseMap();
            CreateMap<ProductDto, TblProduct>().ReverseMap();
            CreateMap<ProductDescriptionDto, TblProductDescription>().ReverseMap();
            CreateMap<ProductCategoryDto,TblProductCategory>().ReverseMap();
            CreateMap<ProductImageDto, TblProductImage>().ReverseMap();
            CreateMap<ProductVariantDto , TblProductVariant>().ReverseMap();
        }

    }
}
