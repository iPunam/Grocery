using AutoMapper;
using Grocery.Models;
using Grocery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grocery.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ProductCategory, ProductConfig>()
                .ForMember(dest => dest.ID, options => options.MapFrom(src => src.ProdCategoryID))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.ProdCategoryName))
                .ForMember(dest => dest.Desc, options => options.MapFrom(src => src.ProdCategoryDesc))
                .ForMember(dest => dest.Index, options => options.MapFrom(src => src.ProdCategoryIndex));

            CreateMap<ProductConfig, ProductCategory>()
                .ForMember(dest => dest.ProdCategoryID, options => options.MapFrom(src => src.ID))
                .ForMember(dest => dest.ProdCategoryName, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProdCategoryDesc, options => options.MapFrom(src => src.Desc))
                .ForMember(dest => dest.ProdCategoryIndex, options => options.MapFrom(src => src.Index));

            CreateMap<ProductBrand, ProductConfig>()
                .ForMember(dest => dest.ID, options => options.MapFrom(src => src.ProdBrandID))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.ProdBrandName))
                .ForMember(dest => dest.Desc, options => options.MapFrom(src => src.ProdBrandDesc))
                .ForMember(dest => dest.Index, options => options.MapFrom(src => src.ProdBrandIndex));

            CreateMap<ProductConfig, ProductBrand>()
                .ForMember(dest => dest.ProdBrandID, options => options.MapFrom(src => src.ID))
                .ForMember(dest => dest.ProdBrandName, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.ProdBrandDesc, options => options.MapFrom(src => src.Desc))
                .ForMember(dest => dest.ProdBrandIndex, options => options.MapFrom(src => src.Index));


            CreateMap<UnitsOfMeasurement, ProductConfig>()
                .ForMember(dest => dest.ID, options => options.MapFrom(src => src.UOMID))
                .ForMember(dest => dest.Name, options => options.MapFrom(src => src.UOMName))
                .ForMember(dest => dest.Desc, options => options.MapFrom(src => src.UOMDesc))
                .ForMember(dest => dest.Index, options => options.MapFrom(src => src.UOMIndex));

            CreateMap<ProductConfig, UnitsOfMeasurement>()
                .ForMember(dest => dest.UOMID, options => options.MapFrom(src => src.ID))
                .ForMember(dest => dest.UOMName, options => options.MapFrom(src => src.Name))
                .ForMember(dest => dest.UOMDesc, options => options.MapFrom(src => src.Desc))
                .ForMember(dest => dest.UOMIndex, options => options.MapFrom(src => src.Index));

        }
    }
}
