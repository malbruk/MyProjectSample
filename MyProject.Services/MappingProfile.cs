using AutoMapper;
using MyProject.Common.Models;
using MyProject.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoleModel, Role>().ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Title)).ReverseMap();
        }
    }
}
