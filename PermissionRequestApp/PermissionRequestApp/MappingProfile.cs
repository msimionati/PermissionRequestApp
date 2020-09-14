using AutoMapper;
using PermissionRequestApp.Contracts.ResponseDTO;
using PermissionRequestApp.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PermissionRequestApp
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionType, PermissionTypeDto>();
        }
    }
}
