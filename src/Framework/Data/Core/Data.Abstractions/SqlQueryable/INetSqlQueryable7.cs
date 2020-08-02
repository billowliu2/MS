﻿using MS.Lib.Data.Abstractions.Entities;
using MS.Lib.Data.Abstractions.Enums;
using MS.Lib.Data.Abstractions.Pagination;
using MS.Lib.Data.Abstractions.SqlQueryable.GroupByQueryable;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MS.Lib.Data.Abstractions.SqlQueryable
{
    public interface INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> : INetSqlQueryable
        where TEntity : IEntity, new()
        where TEntity2 : IEntity, new()
        where TEntity3 : IEntity, new()
        where TEntity4 : IEntity, new()
        where TEntity5 : IEntity, new()
        where TEntity6 : IEntity, new()
        where TEntity7 : IEntity, new()
    {
        #region ==使用工作单元==

        /// <summary>
        /// 使用工作单元
        /// </summary>
        /// <param name="uow"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> UseUow(IUnitOfWork uow);

        #endregion ==使用工作单元==

        #region ==Sort==

        /// <summary>
        /// 升序
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> OrderBy(string colName);

        /// <summary>
        /// 降序
        /// </summary>
        /// <param name="colName"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> OrderByDescending(string colName);

        /// <summary>
        /// 升序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> OrderBy<TKey>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TKey>> expression);

        /// <summary>
        /// 降序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> OrderByDescending<TKey>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TKey>> expression);

        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="sort"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Order(Sort sort);

        /// <summary>
        /// 排序
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="expression"></param>
        /// <param name="sortType"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Order<TKey>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TKey>> expression, SortType sortType);

        #endregion ==Sort==

        #region ==Where==

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="expression">过滤条件</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Where(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> expression);

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="whereSql">过滤条件</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Where(string whereSql);

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="condition">添加条件</param>
        /// <param name="expression">条件</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereIf(bool condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> expression);

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="condition">添加条件</param>
        /// <param name="whereSql">条件</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereIf(bool condition, string whereSql);

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereIf(bool condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> ifExpression, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> elseExpression);

        /// <summary>
        /// 过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereIf(bool condition, string ifWhereSql, string elseWhereSql);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(string condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> expression);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(string condition, string whereSql);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(string condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> ifExpression, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> elseExpression);

        /// <summary>
        /// 字符串不为Null以及空字符串的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(string condition, string ifWhereSql, string elseWhereSql);

        /// <summary>
        /// 不为Null以及Empty的时候添加过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(object condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> expression);

        /// <summary>
        /// 不为Null以及Empty的时候添加过滤
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(object condition, string whereSql);

        /// <summary>
        /// 不为Null以及Empty的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(object condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> ifExpression, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> elseExpression);

        /// <summary>
        /// 不为Null以及Empty的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotNull(object condition, string ifWhereSql, string elseWhereSql);

        /// <summary>
        /// GUID不为空的时候添加过滤条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="expression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotEmpty(Guid condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> expression);

        /// <summary>
        /// GUID不为空的时候添加过滤条件
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="whereSql"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotEmpty(Guid condition, string whereSql);

        /// <summary>
        /// GUID不为空的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifExpression"></param>
        /// <param name="elseExpression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotEmpty(Guid condition, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> ifExpression, Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, bool>> elseExpression);

        /// <summary>
        /// GUID不为空的时候添加ifExpression，反之添加elseExpression
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="ifWhereSql"></param>
        /// <param name="elseWhereSql"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotEmpty(Guid condition, string ifWhereSql, string elseWhereSql);

        /// <summary>
        /// NotIn查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> WhereNotIn<TKey>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TKey>> key, IEnumerable<TKey> list);

        /// <summary>
        /// 子查询
        /// </summary>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="key">列</param>
        /// <param name="queryOperator">运算逻辑</param>
        /// <param name="queryable">子查询的查询构造器</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Where<TKey>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TKey>> key, QueryOperator queryOperator, INetSqlQueryable queryable);

        #endregion ==Where==

        #region ==Limit==

        /// <summary>
        /// 限制
        /// </summary>
        /// <param name="skip">跳过前几条数据</param>
        /// <param name="take">取前几条数据</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Limit(int skip, int take);

        #endregion ==Limit==

        #region ==Select==

        /// <summary>
        /// 查询指定列
        /// </summary>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Select<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> selectExpression);

        /// <summary>
        /// 查询排除指定列
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> SelectExclude<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        #endregion ==Select==

        #region ==Join==

        /// <summary>
        /// 左连接
        /// </summary>
        /// <typeparam name="TEntity8"></typeparam>
        /// <param name="onExpression"></param>
        /// <param name="tableName"></param>
        /// <param name="noLock">针对SqlServer的NoLock特性，默认开启</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TEntity8> LeftJoin<TEntity8>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TEntity8, bool>> onExpression, string tableName = null, bool noLock = true) where TEntity8 : IEntity, new();

        /// <summary>
        /// 内连接
        /// </summary>
        /// <typeparam name="TEntity8"></typeparam>
        /// <param name="onExpression"></param>
        /// <param name="tableName"></param>
        /// <param name="noLock">针对SqlServer的NoLock特性，默认开启</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TEntity8> InnerJoin<TEntity8>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TEntity8, bool>> onExpression, string tableName = null, bool noLock = true) where TEntity8 : IEntity, new();

        /// <summary>
        /// 右连接
        /// </summary>
        /// <typeparam name="TEntity8"></typeparam>
        /// <param name="onExpression"></param>
        /// <param name="tableName"></param>
        /// <param name="noLock">针对SqlServer的NoLock特性，默认开启</param>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TEntity8> RightJoin<TEntity8>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TEntity8, bool>> onExpression, string tableName = null, bool noLock = true) where TEntity8 : IEntity, new();

        #endregion ==Join==

        #region ==Max==

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        TResult Max<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        /// <summary>
        /// 获取最大值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TResult> MaxAsync<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        #endregion ==Max==

        #region ==Min==

        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        TResult Min<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        /// <summary>
        /// 获取最小值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TResult> MinAsync<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        #endregion ==Min==

        #region ==Sum==

        /// <summary>
        /// 求和
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        TResult Sum<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        /// <summary>
        /// 求和
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TResult> SumAsync<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        #endregion ==Sum==

        #region ==Avg==

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        TResult Avg<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        /// <summary>
        /// 求平均值
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        Task<TResult> AvgAsync<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        #endregion ==Avg==

        #region ==GroupBy==

        /// <summary>
        /// 分组
        /// </summary>
        /// <returns></returns>
        IGroupByQueryable7<TResult, TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> GroupBy<TResult>(Expression<Func<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7, TResult>> expression);

        /// <summary>
        /// 分组(group by 1)
        /// </summary>
        /// <returns></returns>
        IGroupByQueryable7<INetSqlGroupingKey7<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7>, TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> GroupBy();

        #endregion ==GroupBy==

        #region ==ToList==

        /// <summary>
        /// 查询列表，返回指定类型
        /// </summary>
        /// <returns></returns>
        new IList<TEntity> ToList();

        /// <summary>
        /// 查询列表，返回指定类型
        /// </summary>
        /// <returns></returns>
        new Task<IList<TEntity>> ToListAsync();

        #endregion ==ToList==

        #region ==Pagination==

        /// <summary>
        /// 分页查询，返回实体类型
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        new IList<TEntity> Pagination(Paging paging = null);

        /// <summary>
        /// 分页查询，返回实体类型
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        new Task<IList<TEntity>> PaginationAsync(Paging paging = null);

        #endregion ==Pagination==

        #region ==First==

        /// <summary>
        /// 查询第一条数据，返回指定类型
        /// </summary>
        /// <returns></returns>
        new TEntity First();

        /// <summary>
        /// 查询第一条数据，返回指定类型
        /// </summary>
        /// <returns></returns>
        new Task<TEntity> FirstAsync();

        #endregion ==First==

        #region ==IncludeDeleted==

        /// <summary>
        /// 包含已删除的数据
        /// </summary>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> IncludeDeleted();

        #endregion ==IncludeDeleted==

        #region ==NotFilterTenant==

        /// <summary>
        /// 不过滤租户
        /// </summary>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> NotFilterTenant();

        #endregion ==NotFilterTenant==

        #region ==Copy==

        /// <summary>
        /// 复制一个新的实例
        /// </summary>
        /// <returns></returns>
        INetSqlQueryable<TEntity, TEntity2, TEntity3, TEntity4, TEntity5, TEntity6, TEntity7> Copy();

        #endregion ==Copy==
    }
}