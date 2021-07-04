using System;
using AutoMapper;
using ShopAction.Application.Dtos;
using ShopAction.Domain.Entities;

namespace ShopAction.Application.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
