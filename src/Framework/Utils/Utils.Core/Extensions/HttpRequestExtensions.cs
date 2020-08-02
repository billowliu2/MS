using Microsoft.AspNetCore.Http;

namespace MS
{
    public static class HttpRequestExtensions
    {
        /// <summary>
        /// 获取根地址
        /// </summary>
        /// <param name="request"></param>
        /// <param name="path">附加路径</param>
        /// <returns></returns>
        public static string GetHost(this HttpRequest request, string path = null)
        {
            return request.Scheme + "://" + request.Host.Value + (path ?? string.Empty);
        }
    }
}