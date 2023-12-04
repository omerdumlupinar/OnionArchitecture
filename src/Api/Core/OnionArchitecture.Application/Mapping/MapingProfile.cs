using AutoMapper;
using OnionArchitecture.Common.Model.RequestModel.Category;
using OnionArchitecture.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchitecture.Application.Mapping
{
    public class MapingProfile : Profile
    {
        protected  MapingProfile()
        {
            CreateMap<Category,CreateCategoryModel>().ReverseMap();
        }
    }
}
