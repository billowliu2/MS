using System.ComponentModel;

namespace MS.Lib.Quartz.Abstractions
{
    public enum QuartzSerializerType
    {
        [Description("JSON")]
        Json,

        [Description("XML")]
        Xml
    }
}