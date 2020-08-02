using AutoMapper;
using MS.Lib.Mapper.AutoMapper;
using MS.Module.Admin.Application.AccountService.ViewModels;
using MS.Module.Admin.Domain.Account;

namespace MS.Module.Admin.Application.AccountService
{
    public class MapperConfig : IMapperConfig
    {
        public void Bind(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<AccountAddModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());
            cfg.CreateMap<AccountSyncModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());

            cfg.CreateMap<AccountEntity, AccountUpdateModel>();
            cfg.CreateMap<AccountUpdateModel, AccountEntity>().ForMember(m => m.Roles, opt => opt.Ignore());
        }
    }
}