using AutoMapper;
using sample_app.Models;
using sample_app.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sample_app.MappingProfile
{
    public class DomainMappingProfile : Profile
    {
        public DomainMappingProfile()
        {
            // Mapping Code
            CreateMap<Product, ProductEditModel>().ReverseMap();
            CreateMap<Product, ProductAddModel>().ReverseMap();
        }
    }
}
