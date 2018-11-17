using AppName.Logic.Interfaces;
using AppName.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppName.Web.Controllers
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, int>()
                .ConvertUsing<CategoryToIntConverter>();

            CreateMap<int, Category>()
                .ConvertUsing<IntToCategoryConverter>();

            CreateMap<Category, SelectListItem>()
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id));

        }
    }

    public class CategoryToIntConverter : ITypeConverter<Category, int>
    {
        public int Convert(Category source, int destination, ResolutionContext context)
        {
            if (source == null)
            {
                return 0;
            }

            return source.Id;
        }
    }

    public class IntToCategoryConverter : ITypeConverter<int, Category>
    {
        public ICategoryLogic Logic { get; set; }

        public IntToCategoryConverter(ICategoryLogic logic)
        {
            Logic = logic;
        }

        public Category Convert(int source, Category destination, ResolutionContext context)
        {
            var result = Logic.GetById(source);

            if (result.Success == false)
            {
                return null;
            }

            return result.Value;
        }
    }
}