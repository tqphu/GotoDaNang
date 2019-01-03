using AutoMapper;
using GotoDaNang.Model.Model;
using GotoDaNang.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GotoDaNang.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Admin, AdminViewModel>().MaxDepth(2);
                cfg.CreateMap<Category, CategoryViewModel>().MaxDepth(2);
                cfg.CreateMap<City, CityViewModel>().MaxDepth(2);
                cfg.CreateMap<Place, PlaceViewModel>().MaxDepth(2);
                cfg.CreateMap<Province, ProvinceViewModel>().MaxDepth(2);
                cfg.CreateMap<Service, ServiecViewModel>().MaxDepth(2);
            });
        }
    }
}