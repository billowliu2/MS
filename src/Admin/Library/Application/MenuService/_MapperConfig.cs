using AutoMapper;
using MS.Lib.Mapper.AutoMapper;
using MS.Module.Admin.Application.MenuService.ResultModels;
using MS.Module.Admin.Application.MenuService.ViewModels;
using MS.Module.Admin.Domain.Menu;

namespace MS.Module.Admin.Application.MenuService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<MenuAddModel, MenuEntity>();
            cfg.AddMap<MenuEntity, MenuUpdateModel>();
            cfg.CreateMap<MenuEntity, MenuTreeResultModel>();
        }
    }
}