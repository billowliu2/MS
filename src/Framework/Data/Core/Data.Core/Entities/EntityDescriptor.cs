using MS.Lib.Data.Abstractions;
using MS.Lib.Data.Abstractions.Attributes;
using MS.Lib.Data.Abstractions.Entities;
using MS.Lib.Data.Abstractions.Options;
using MS.Lib.Data.Core.Entities.Extend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MS.Lib.Data.Core.Entities
{
    /// <summary>
    /// 实体描述
    /// </summary>
    public class EntityDescriptor : IEntityDescriptor
    {
        #region ==属性==

        public IDbContext DbContext { get; }

        public IDbSet DbSet { get; set; }

        /// <summary>
        /// 数据库配置
        /// </summary>
        public DbModuleOptions DbOptions { get; }

        /// <summary>
        /// 数据库名称
        /// </summary>
        public string Database { get; }

        /// <summary>
        /// 模块名称
        /// </summary>
        public string ModuleName { get; }

        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// 不创建表
        /// </summary>
        public bool Ignore { get; private set; }

        /// <summary>
        /// 实体类型
        /// </summary>
        public Type EntityType { get; }

        /// <summary>
        /// 列
        /// </summary>
        public IColumnDescriptorCollection Columns { get; private set; }

        /// <summary>
        /// 主键
        /// </summary>
        public IPrimaryKeyDescriptor PrimaryKey { get; private set; }

        /// <summary>
        /// 是否包含软删除
        /// </summary>
        public bool SoftDelete { get; }

        public EntitySql Sql { get; }

        public ISqlAdapter SqlAdapter { get; }

        public bool IsEntityBase { get; }

        public bool IsTenant { get; }

        #endregion ==属性==

        #region ==构造器==

        public EntityDescriptor(IDbContext dbContext, Type entityType)
        {
            DbContext = dbContext;

            DbOptions = dbContext.Options.DbModuleOptions;

            SqlAdapter = dbContext.Options.SqlAdapter;

            ModuleName = DbOptions.Name;

            EntityType = entityType;

            Database = SqlAdapter.Database;

            PrimaryKey = new PrimaryKeyDescriptor();

            SoftDelete = EntityType.IsSubclassOfGeneric(typeof(EntityWithSoftDelete<,>));

            SetTableName();

            SetIgnore();

            SetColumns();

            var sqlBuilder = new EntitySqlBuilder(this, dbContext.Options.DbOptions);
            Sql = sqlBuilder.Build();

            IsEntityBase = EntityType.IsSubclassOfGeneric(typeof(EntityBase<>)) || EntityType.IsSubclassOfGeneric(typeof(EntityBaseWithSoftDelete<,>));

            IsTenant = typeof(ITenant).IsAssignableFrom(EntityType);
        }

        #endregion ==构造器==

        #region ==私有方法==

        /// <summary>
        /// 设置表名
        /// </summary>
        private void SetTableName()
        {
            var tableArr = EntityType.GetCustomAttribute<TableAttribute>(false);

            if (tableArr != null)
            {
                TableName = tableArr.Name;
            }
            else
            {
                TableName = EntityType.Name;
                //去掉Entity后缀
                if (TableName.EndsWith("Entity"))
                {
                    TableName = TableName.Substring(0, TableName.Length - 6);
                }
            }

            //判断有没有设置前缀
            if (SqlAdapter.Options.Prefix.NotNull())
            {
                var prefixIgnoreArr = EntityType.GetCustomAttribute<TableAttribute>(false);
                if (prefixIgnoreArr != null)
                {
                    TableName = SqlAdapter.Options.Prefix + TableName;
                }
            }

            if (SqlAdapter.ToLower)
            {
                TableName = TableName.ToLower();
            }
        }

        /// <summary>
        /// 设置是否不创建表
        /// </summary>
        private void SetIgnore()
        {
            var ignoreArr = EntityType.GetCustomAttribute<IgnoreAttribute>(false);
            Ignore = ignoreArr != null;
        }

        /// <summary>
        /// 设置属性列表
        /// </summary>
        private void SetColumns()
        {
            Columns = new ColumnDescriptorCollection();

            //加载属性列表
            var properties = new List<PropertyInfo>();
            foreach (var p in EntityType.GetProperties())
            {
                var type = p.PropertyType;
                if ((!type.IsGenericType || type.IsNullable()) && (type.IsGuid() || type.IsNullable() || Type.GetTypeCode(type) != TypeCode.Object)
                    && Attribute.GetCustomAttributes(p).All(attr => attr.GetType() != typeof(IgnoreAttribute)))
                {
                    properties.Add(p);
                }
            }

            foreach (var p in properties)
            {
                var column = new ColumnDescriptor(p, SqlAdapter);
                if (column.IsPrimaryKey)
                {
                    PrimaryKey = new PrimaryKeyDescriptor(p);
                    Columns.Insert(0, column);
                }
                else
                {
                    Columns.Add(column);
                }
            }
        }

        #endregion ==私有方法==
    }
}