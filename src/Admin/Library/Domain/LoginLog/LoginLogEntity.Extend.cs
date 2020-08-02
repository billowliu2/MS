using MS.Lib.Data.Abstractions.Attributes;

namespace MS.Module.Admin.Domain.LoginLog
{
    public partial class LoginLogEntity
    {
        [Ignore]
        public string PlatformName => Platform.ToDescription();

        [Ignore]
        public string LoginModeName => LoginMode.ToDescription();
    }
}