﻿using Easy.Utility;
using Easy.Utility.AttributeExt;
using Easy.Utility.MappingExt;
using Easy.Utility.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Topshelf;

namespace Easy.Console
{
    public class PeopleCopy
    {
        [Column("Id")]
        public int Id1 { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Year { get; set; }
    }
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class People1
    {
        public string avatar { get; set; }
        public string uid { get; set; }
    }
    public static class a{

        public static int aaa(this int aaaa) {

            return aaaa + 1;
        }
}
    class Program
    {
     
        public static List<People> list { get; set; }
        static void Main(string[] args)
        {
          var a=  ExpressionMapper<People, PeopleCopy>.Trans(new People() { Id = 1, Name = "22" });

            string a1 = "{\"avatar\":\"https://thirdwx.qlogo.cn/mmopen/m8nmFV00P0cQK2z9jLkbzl8WAwqOCDSlLM18ibSeb8yVutn7AU2f0qaJCauy8uichTckoiaNJwqSzSDtO4iauxkQx7q0zvYz3ndB/132\",\"uid\":\"57CB47D7692F60FB\"}";

            var b = JsonConvertHelper.DeserializeObject<People1>(a1);
            System.Console.WriteLine(JsonConvertHelper.DeserializeObject<People1>(a1));

            //list = new List<People>();
            //for (int i = 0; i < 10; i++)
            //{
            //    list.Add(new People() { Id = i, Name = i.ToString() });
            //}
            //var b = list.AsQueryable().Where(m => m.Id.aaa() == 10).ToList();
            //System.Console.WriteLine(b);
            //var result= ExpressionMapper<People, PeopleCopy>.Trans(new People() { Id = 111, Name = "222" });


            //  System.Console.WriteLine(JsonConvertHelper.SerializeObject(result));


            // string url = "https://api.mysubmail.com/message/xsend.json";
            // string postData = "appid=34046&to=15919272960&project=29E8W&signature=7b32c2e94b301f3585505a578abc1a84&vars={\"code1\":\"3\",\"code2\":\"1500\"}";
            //string a= HttpRequest.HttpPost(url, postData, "application/x-www-form-urlencoded", null);


            // System.Console.WriteLine(a);


            //HostFactory.Run(x =>
            //{
            //    x.Service<QuartzServiceRunner>(s =>
            //    {
            //        s.ConstructUsing(name => new QuartzServiceRunner());
            //        s.WhenStarted(tc => tc.Start());
            //        s.WhenStopped(tc => tc.Stop());
            //    });
            //    x.RunAsLocalSystem();
            //    x.StartAutomatically();
            //    x.SetDescription("火虫网定时服务");
            //    x.SetDisplayName("火虫网定时服务");
            //    x.SetServiceName("火虫网定时服务");
            //});
            // #region 分段
            // //放配置的
            // string ParagraphFlags = "div,p,dt,dd,h1,h2,h3,h4,h5,h6,blockquote,br,section";
            // string[] paragraphFlagStr = ParagraphFlags.Split(',');
            // NSoup.Select.Elements elements = new NSoup.Select.Elements();
            // NSoup.Nodes.Document htmlDoc = NSoup.NSoupClient.Parse("文章内容");
            // foreach (var paragraphFlag in paragraphFlagStr)
            // {
            //     elements.AddRange(htmlDoc.GetElementsByTag(paragraphFlag).after("ゃωゃ").Before("ゃωゃ"));
            // }
            // elements.AddRange(htmlDoc.GetElementsByAttributeValueMatching("style", "block").after("ゃωゃ").Before("ゃωゃ"));

            // //paragraphStrs为每一篇文章拆分的段落
            // string[] paragraphStrs = htmlDoc.Text().Split(new string[] { "ゃωゃ" }, StringSplitOptions.RemoveEmptyEntries);
            // #endregion









            // //ConstantExpression constant = Expression.Constant(1);
            // //ConstantExpression constant2 = Expression.Constant(2);
            // //ParameterExpression m = Expression.Parameter(typeof(int), "m");
            // //ParameterExpression n = Expression.Parameter(typeof(int), "n");
            // //BinaryExpression binary = Expression.Add(constant, constant2);
            // //BinaryExpression binary2 = Expression.Multiply(m, n);
            // //var ex = Expression.Add(binary, binary2);
            // //var f = Expression.Lambda<Func<int, int, int>>(ex, new ParameterExpression[] { m, n });
            // //System.Console.WriteLine(f.Compile()(30, 30));
            // {
            //     Expression<Func<People, PeopleCopy>> expression1 = m => new PeopleCopy { Id = m.Id, Name = m.Name };
            // }
            // ParameterExpression parameterExpression = Expression.Parameter(typeof(People), "m");
            // List<MemberBinding> bindings = new List<MemberBinding>();

            // foreach (var item in typeof(PeopleCopy).GetProperties())
            // {
            //     bindings.Add( Expression.Bind(item, Expression.Property(parameterExpression, typeof(People).GetProperty(item.Name))));
            // }


            // //new MemberBinding[]
            // //{
            // //     Expression.Bind((MethodInfo)MethodBase.GetMethodFromHandle(ldtoken(set_Id())), Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(ldtoken(get_Id())))),
            // //     Expression.Bind((MethodInfo)MethodBase.GetMethodFromHandle(ldtoken(set_Name())), Expression.Property(parameterExpression, (MethodInfo)MethodBase.GetMethodFromHandle(ldtoken(get_Name()))))
            // //}
            // Expression<Func<People, PeopleCopy>> expression = Expression.Lambda<Func<People, PeopleCopy>>(Expression.MemberInit(Expression.New(typeof(PeopleCopy)), bindings.ToArray()), new ParameterExpression[]
            // {
            //     parameterExpression
            // });

            //var aaaaa= expression.Compile().Invoke(new People { Id = 1, Name = 12 });

            System.Console.ReadLine();
        }
        // static Tout Tran<Tout>

    }
}

