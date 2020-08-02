using MS.Module.Admin.Domain.Menu;
using System.Collections.Generic;

namespace MS.Module.Admin.Infrastructure.AccountPermissionResolver
{
    /// <summary>
    /// 菜单比较器
    /// </summary>
    public class MenuComparer : IEqualityComparer<MenuEntity>
    {
        public bool Equals(MenuEntity x, MenuEntity y)
        {
            if (x == null || y == null)
                return false;

            return x.Id == y.Id;
        }

        public int GetHashCode(MenuEntity obj)
        {
            return 1;
        }
    }
}