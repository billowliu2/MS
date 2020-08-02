using MS.Lib.Auth.Abstractions;
using MS.Lib.Utils.Core.Attributes;
using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace MS.Module.Admin.Web.Core
{
    [Singleton]
    internal class DefaultLoginClaimsExtendProvider : ILoginClaimsExtendProvider
    {
        public List<Claim> GetExtendClaims(Guid accountId)
        {
            return null;
        }
    }
}