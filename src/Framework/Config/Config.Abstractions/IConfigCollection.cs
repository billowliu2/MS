using System.Collections.Generic;

namespace MS.Lib.Config.Abstractions
{
    /// <summary>
    /// 配置集合
    /// </summary>
    public interface IConfigCollection : IList<ConfigDescriptor>
    {
    }
}