using AutoMapper;
using MS.Lib.Mapper.AutoMapper;
using MS.Module.Admin.Application.RoleService.ViewModels;
using MS.Module.Admin.Domain.Role;

namespace MS.Module.Admin.Application.RoleService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<RoleAddModel, RoleEntity>();
            cfg.AddMap<RoleEntity, RoleUpdateModel>();
        }
    }
}