using AutoMapper;
using Ecommerce.Catalog.DTOs.ProductDTOs;
using Ecommerce.Catalog.Entities;

namespace Ecommerce.Catalog.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<CreateProductDto, Product>();
            CreateMap<UpdateProductDto, Product>();
            CreateMap<Product, GetProductDto>();
        }
    }
}
