using RedisInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        //private static readonly HttpClient _client = new HttpClient(new HttpClientHandler()
        //{
        //    UseProxy = false
        //});
        //public async Task<string> Sample()
        //{
        //    string result = "";
        //    using (var res = new StringContent("a=1", Encoding.UTF8, "application/x-www-form-urlencoded"))
        //    {
        //        try
        //        {
        //            var postasync = await _client.PostAsync("url", res);
        //            postasync.EnsureSuccessStatusCode();
        //            result = await postasync.Content.ReadAsStringAsync();
        //        }
        //        catch (Exception ex)
        //        {
        //        }
        //    }
        //    return result;
        //}

        public static string a()
        {
            string b = @"
       private static readonly HttpClient _client = new HttpClient(new HttpClientHandler()
        {
            UseProxy = false
        });
        public async Task<string> Sample()
        {
            string result = """";
            using (var res = new StringContent(""txt=新闻"", Encoding.UTF8,""application/x-www-form-urlencoded""))" + "\n" + "{" + "\n" +    
                 "try"+ "\n" +
                "{" + "\n" + "_client.DefaultRequestHeaders.Add(\"Authorization\", \"APIKEY BF7FE7FD48EA46BD982C252029AB1646\");" + "\n" +
                  "   var postasync = await _client.PostAsync(\"http://apis.5118.com/wyc/akey\", res); " + "\n" +
                   " postasync.EnsureSuccessStatusCode(); " + "\n" +
                  "  result = await postasync.Content.ReadAsStringAsync(); " + "\n" +
               " }" + "\n" +
                "catch (Exception ex)" + "\n" +
                "{" + "\n" +
               " }" + "\n" +
           " }" + "\n" +
            "return result; " + "\n" +
        "}";
            return b;
        }

        private static readonly HttpClient _client = new HttpClient(new HttpClientHandler()
        {
            UseProxy = false,
        });
        public static async Task<string> Sample()
        {
            string result = "";
            using (var res = new StringContent("txt=新闻", Encoding.UTF8, "application/x-www-form-urlencoded"))
            {
                try
                {
                    _client.DefaultRequestHeaders.Add("Authorization", "APIKEY BF7FE7FD48EA46BD982C252029AB1646");
                    var postasync = await _client.PostAsync("http://apis.5118.com/wyc/akey", res);
                    postasync.EnsureSuccessStatusCode();
                    result = await postasync.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {

                }
            }
            return result;
        }

    
        static void Main(string[] args)
        {
            CommonCache.Remove("store");
            CommonCache.Remove("name");
            CommonCache.SetValue("store", 10);
            CommonCache.Remove("9999:uid");
            for (int i = 0; i < 1000; i++)
            {
                Task.Run(() =>
                {

                    long j = CommonCache.Incr("9999:uid");
                    if (j == 1)
                    {
                        string name = "章鱼哥";
                        if (!string.IsNullOrWhiteSpace(CommonCache.GetValue<string>(name)))
                        {
                            Console.WriteLine("不能重复抢购");
                        }
                        if (CommonCache.Decr("store") >= 0 && string.IsNullOrWhiteSpace(CommonCache.GetValue<string>(name)))
                        {
                            CommonCache.HashSet("9999", "uid", "1");
                            Console.WriteLine($"{name}抢购成功");
                        }
                        else
                        {
                            Console.WriteLine("商品已被抢购完毕");
                        }
                    }

                });
            }
            Console.WriteLine(CommonCache.GetValue("store"));
        }

    }
}
