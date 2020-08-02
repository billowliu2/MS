using MS.Lib.Data.Abstractions.Entities;
using MS.Lib.Utils.Core.Abstracts;

namespace MS.Lib.Data.Core.Entities
{
    /// <summary>
    /// 列信息集合
    /// </summary>
    public class ColumnDescriptorCollection : CollectionAbstract<IColumnDescriptor>, IColumnDescriptorCollection
    {
    }
}