using StackExchange.Redis;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisComm
{
    public class RedisHelper
    {
        private static ConfigurationOptions configurationOptions = ConfigurationOptions.Parse("192.168.124.12:6379,password=123456,connectTimeout=2000");

        //the lock for singleton
        private static readonly object Locker = new object();

        //singleton
        private static ConnectionMultiplexer redisConn =ConnectionMultiplexer.Connect(configurationOptions);

        public static int library = 0;
        #region 连接redis
        //singleton
        public static ConnectionMultiplexer getRedisConn()
        {

            if (redisConn == null)
            {
                lock (Locker)
                {
                    if (redisConn == null || !redisConn.IsConnected)
                    {
                        redisConn = ConnectionMultiplexer.Connect(configurationOptions);
                    }
                }
            }
            return redisConn;
        }
        #endregion

        public static string GetHashString(string  mainKey,string key)
        {
            var database = redisConn.GetDatabase(library);
            string hash = database.HashGet(mainKey,key);
            return hash;
        }

        public static void GetHashList(string mianKey)
        {
            Dictionary<string, string> myDictionary = new Dictionary<string, string>();
            var database = redisConn.GetDatabase(library);
            var hash = database.HashGetAll(mianKey);
            List<HashTables> hts = new List<HashTables>();
            foreach (var item in hash)
            {

            }


        }
    }

    public class HashTables
    {
        public string HashKey { get; set; }

        public string HashValue { get; set; }
    }
}
