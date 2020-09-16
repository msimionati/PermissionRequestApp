using AutoMapper;
using PermissionRequestApp.Contracts.RequestDTO;
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
            //DOMAIN TO RESPONSE
            CreateMap<Permission, PermissionDto>();
            CreateMap<PermissionType, PermissionTypeDto>();

            //REQUEST TO DOMAIN
            CreateMap<PermissionAddDto, Permission>();
            CreateMap<PermissionUpdateDto, Permission>();
            CreateMap<PermissionTypeDto, PermissionType>();
            CreateMap<PermissionTypeAddDto, PermissionType>();
            CreateMap<PermissionTypeUpdateDto, PermissionType>();
        }
    }
}
