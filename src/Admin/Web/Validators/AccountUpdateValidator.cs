using FluentValidation;
using MS.Module.Admin.Application.AccountService.ViewModels;

namespace MS.Module.Admin.Web.Validators
{
    public class AccountUpdateValidator : AbstractValidator<AccountUpdateModel>
    {
        public AccountUpdateValidator()
        {
            RuleFor(x => x.Email).EmailAddress().When(x => x.Email.NotNull()).WithMessage("请输入正确的邮箱地址");
        }
    }
}