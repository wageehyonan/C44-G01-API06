using AutoMapper;
using Ecommerce_G02.Domain.Models.Baskets;
using Ecommerce_G02.Domain.Models.Products;
using Ecommerce_G02.Presistence.Identity.Models;
using Ecommerce_G02.Shared.DTOs.BasketsDtos;
using Ecommerce_G02.Shared.DTOs.IdentityDtos;
using Ecommerce_G02.Shared.DTOs.ProductsDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Ecommerce_G02.Services.MappingProfiles
{
    public class ProjectProfile:Profile
    {
        public ProjectProfile()
        {
            CreateMap<Product, ProductDto>()
                    .ForMember(dist => dist.BrandName, options => options.MapFrom(src => src.Brand.Name))
                    .ForMember(dist => dist.TypeName, options => options.MapFrom(src => src.Type.Name));
                               
            CreateMap<ProductBrand,BrandDto>();
            CreateMap<ProductType,TypeDto>();
            CreateMap<CustomerBasket, CustomerBasketDto>().ReverseMap();
            CreateMap<BasketItem, BasketItemDto>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
        }
    }
}
