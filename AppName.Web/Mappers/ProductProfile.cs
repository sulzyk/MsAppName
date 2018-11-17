using AppName.Models;
using AppName.Web.ViewModels.Products;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppName.Web.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>()
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Category))
                .ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.CategoryId));
        }
    }
}