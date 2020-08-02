using MS.Lib.Data.Abstractions;
using MS.Module.Admin.Domain.Mime.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MS.Module.Admin.Domain.Mime
{
    /// <summary>
    ///
    /// </summary>
    public interface IMimeRepository : IRepository<MimeEntity>
    {
        /// <summary>
        /// 根据后缀名查找
        /// </summary>
        /// <param name="ext"></param>
        /// <returns></returns>
        Task<MimeEntity> Get(string ext);

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<IList<MimeEntity>> Query(MimeQueryModel model);

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <returns></returns>
        Task<bool> Exists(MimeEntity entity);
    }
}