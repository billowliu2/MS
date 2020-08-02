namespace MS.Lib.OSS.Abstractions
{
    /// <summary>
    /// OSSConfig
    /// </summary>
    public class OSSConfig
    {
        /// <summary>
        /// OSS提供器
        /// </summary>
        public OSSProvider Provider { get; set; } = OSSProvider.Local;
    }
}