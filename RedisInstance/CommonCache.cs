using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisInstance
{
    public class CommonCache
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expiry"></param>
        /// <param name="connectionStr">不填默认为伪原创链接</param>
        /// <returns></returns>
        public static bool SetValue(string key, object value, TimeSpan? expiry = null, string connectionStr = "")
        {
            if (value == null)
            {
                return false;
            }
            var _value = JsonConvert.SerializeObject(value);

            int retryCounter = 0;
            Retry:
            try
            {
                return RedisCommonCluster.Database(connectionStr).StringSet(key, _value, expiry);
            }
            catch (Exception ex)
            {
  
                if (retryCounter <= 3)
                {
                    System.Threading.Thread.Sleep(100);
                    retryCounter++;
                    goto Retry;
                }
            }

            return false;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="ifNullFunc"></param>
        /// <param name="connectionStr">不填默认为伪原创链接</param>
        /// <returns></returns>
        public static object GetValue(string key, Func<Task<object>> ifNullFunc = null, string connectionStr = "")
        {
            var value = RedisCommonCluster.Database(connectionStr).StringGet(key);

            if (value.IsNull)
            {
                return null;
            }

            if (ifNullFunc != null)
            {
                return ifNullFunc.Invoke().GetAwaiter().GetResult();
            }

            return JsonConvert.DeserializeObject(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="key"></param>
        /// <param name="ifNullFunc"></param>
        /// <param name="connectionStr">不填默认为伪原创链接</param>
        /// <returns></returns>
        public static TValue GetValue<TValue>(string key, Func<Task<TValue>> ifNullFunc = null, string connectionStr = "")
        {
            int retryCounter = 0;
            Retry:
            try
            {
                var value = RedisCommonCluster.Database(connectionStr).StringGet(key);
                if (value.IsNull)
                {
                    return default(TValue);
                }

                if (ifNullFunc != null)
                {
                    return ifNullFunc.Invoke().GetAwaiter().GetResult();
                }

                return JsonConvert.DeserializeObject<TValue>(value);
            }
            catch (Exception ex)
            {
                if (retryCounter <= 3)
                {
                    System.Threading.Thread.Sleep(100);
                    retryCounter++;
                    goto Retry;
                }
            }
            return default(TValue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="connectionStr">不填默认为伪原创链接</param>
        /// <returns></returns>
        public static bool Remove(string key, string connectionStr = "")
        {
            return RedisCommonCluster.Database(connectionStr).KeyDelete(key);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="connectionStr">不填默认为伪原创链接</param>
        /// <returns></returns>
        public static bool KeyExists(string key, string connectionStr = "")
        {
            return RedisCommonCluster.Database(connectionStr).KeyExists(key);
        }
        /// <summary>
        /// connectionStr
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="connectionStr">不填默认为伪原创链接</param>
        /// <returns></returns>
        public static long ListRightPush(string key, string value, string connectionStr = "")
        {
            return RedisCommonCluster.Database(connectionStr).ListRightPush(key, value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="isAddEnv"></param>
        /// <param name="connectionStr">不填默认为伪原创链接</param>
        /// <returns></returns>
        public static string ListRightPop(string key, string connectionStr = "")
        {
            var rValue = RedisCommonCluster.Database(connectionStr).ListRightPop(key);
            return rValue;
        }
        public static T ListRightPop<T>(string key, string connectionStr = "")
        {
            var rValue = RedisCommonCluster.Database(connectionStr).ListRightPop(key);
           var t= JsonConvert.DeserializeObject<T>(rValue);
            return t;
        }
        public static long ListLength(string key, string connectionStr = "")
        {
            return RedisCommonCluster.Database(connectionStr).ListLength(key);
        }
        /// <summary>
        /// 数字增长1，返回自增后的值
        /// </summary>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <param name="isAddEnv"></param>
        /// <returns></returns>
        public static long Incr(string key, string connectionStr = "")
        {
           
            return RedisCommonCluster.Database(connectionStr).StringIncrement(key);
        }
        public static long Decr(string key, string connectionStr = "")
        {
            
            return RedisCommonCluster.Database(connectionStr).StringDecrement(key);
        }
        ///// <summary>
        ///// 删除指定前缀的key
        ///// </summary>
        ///// <param name="key"></param>
        ///// <param name="isAddEnv"></param>
        //public static void DeleteLikeKeys(string key)
        //{
        //    var serverlis = RedisCommonCluster.Servers;

        //    foreach (var server in serverlis)
        //    {
        //        var keys = server.Keys(pattern: "*" + key + "*");
        //        foreach (var item in keys)
        //            RedisCommonCluster.Database.KeyDelete(item);
        //    }
        //}
        public static bool SortedSetAdd(string key,string a,int b, string connectionStr = "")
        {

            return RedisCommonCluster.Database(connectionStr).SortedSetAdd(key,a,b);
        }
        public static bool HashSet(string key, string dataKey, string value, string connectionStr = "")
        {
        
            return RedisCommonCluster.Database(connectionStr).HashSet(key, dataKey, value);
        }
        public static StackExchange.Redis.HashEntry[] HashGetAll(string key, string connectionStr = "")
        {
           
            return RedisCommonCluster.Database(connectionStr).HashGetAll(key);
        }
        public static StackExchange.Redis.RedisValue HashGet(string key, string dataKey, string connectionStr = "")
        {
            
            return RedisCommonCluster.Database(connectionStr).HashGet(key, dataKey);
        }
        public static StackExchange.Redis.RedisValue HashDelete(string key, string dataKey, string connectionStr = "")
        {
           
            return RedisCommonCluster.Database(connectionStr).HashDelete(key, dataKey);
        }



    }
}
