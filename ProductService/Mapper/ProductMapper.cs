using AutoMapper;
using ProductService.Dto;
using ProductService.Models;

namespace ProductService.Mapper
{
    public class ProductMapper: Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
        }
    }
}