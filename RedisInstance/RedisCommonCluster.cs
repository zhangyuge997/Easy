using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace RedisInstance
{
    public static class RedisCommonCluster
    {
        private static object _lock = new object();
        //private static string _conn= ConfigurationManager.ConnectionStrings["WycRedisConnectionString"].ToString();
        //ConfigurationManager.ConnectionStrings["RedisConnectionString"].ToString();
        private static ConnectionMultiplexer _multiplexer;

        private static ConnectionMultiplexer Connection(string _conn)
        {
           
                if (_multiplexer != null && _multiplexer.IsConnected)
                {
                    return _multiplexer;
                }

                lock (_lock)
                {
                    if (_multiplexer != null && _multiplexer.IsConnected)
                    {
                        return _multiplexer;
                    }

                    _multiplexer = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(_conn)).Value;
                    _multiplexer.PreserveAsyncOrder = true;
                }

                return _multiplexer;
            
        }

        public static IDatabase Database(string connectionStr="")
        {
            if (string.IsNullOrWhiteSpace(connectionStr))
            {
                connectionStr = "127.0.0.1";
            }
            return Connection(connectionStr).GetDatabase();
        }

        //public static IList<IServer> Servers
        //{
        //    get
        //    {
        //        var servers = new List<IServer>();
        //        foreach (var ep in Connection().GetEndPoints())
        //        {
        //            var server = Connection().GetServer(ep);

        //            servers.Add(server);
        //        }
        //        return servers;
        //    }
        //}
    }
}
