using System;

namespace MS.Lib.Utils.Core.Attributes
{
    /// <summary>
    /// 忽略属性
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class IgnorePropertyAttribute : Attribute
    {
    }
}