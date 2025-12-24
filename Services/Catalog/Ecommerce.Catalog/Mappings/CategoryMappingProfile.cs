using AutoMapper;
using Ecommerce.Catalog.DTOs.CategoryDTOs;
using Ecommerce.Catalog.Entities;

namespace Ecommerce.Catalog.Mappings
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CreateCategoryDto, Category>();
            CreateMap<UpdateCategoryDto, Category>();
            CreateMap<Category, GetCategoryDto>();
        }
    }
}
