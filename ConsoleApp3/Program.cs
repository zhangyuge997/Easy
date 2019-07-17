using Newtonsoft.Json;
using RedisInstance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            CommonCache.Remove("store");
            CommonCache.Remove("name");
            CommonCache.SetValue("store", 10);
            CommonCache.Remove("9999:uid");
            List<Task> tasks = new List<Task>();
            for (int i = 0; i < 100000; i++)
            {
                int k = i;
                Task.Run(() =>
                {

                    long j = CommonCache.Incr("9999:uid");
                    if (j == 1)
                    {
                        Console.WriteLine("**********");
                        string name = "章鱼哥";
                        if (!string.IsNullOrWhiteSpace(CommonCache.GetValue<string>(name)))
                        {
                            Console.WriteLine("不能重复抢购");
                        }
                        if (CommonCache.Decr("store") >= 0 && string.IsNullOrWhiteSpace(CommonCache.GetValue<string>(name)))
                        {
                            CommonCache.HashSet("9999", "uid", k.ToString());
                            Console.WriteLine($"{name}抢购成功");
                            Console.WriteLine($"库存剩余1：{CommonCache.GetValue("store")}");
                        }
                        else
                        {
                            Console.WriteLine("商品已被抢购完毕");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"等待抢票{k}：{j}");
                    }

                });
            }
            Console.WriteLine(CommonCache.HashGet("9999", "uid"));
            Console.ReadKey();
        }
    }
}
