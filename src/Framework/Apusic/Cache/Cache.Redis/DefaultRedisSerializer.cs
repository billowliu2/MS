using MS.Lib.Utils.Core.Attributes;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;

namespace MS.Lib.Cache.Redis
{
    [Singleton]
    public class DefaultRedisSerializer : IRedisSerializer
    {
        public string Serialize<T>(T value)
        {
            if (IsNotBaseType<T>())
            {
                return JsonConvert.SerializeObject(value);
            }

            return value.ToString();
        }

        public T Deserialize<T>(RedisValue value)
        {
            if (IsNotBaseType<T>())
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return value.To<T>();
        }

        public object Deserialize(RedisValue value, Type type)
        {
            if (Type.GetTypeCode(type) == TypeCode.Object)
            {
                return JsonConvert.DeserializeObject(value, type);
            }

            return value;
        }

        /// <summary>
        /// 是否是基础类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private bool IsNotBaseType<T>()
        {
            return Type.GetTypeCode(typeof(T)) == TypeCode.Object;
        }
    }
}