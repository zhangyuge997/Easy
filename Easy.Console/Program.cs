using Easy.Utility;
using Easy.Utility.AttributeExt;
using Easy.Utility.MappingExt;
using Easy.Utility.Request;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TEasy;
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
        public int Age { get; set; }
        public int Sex { get; set; }
        
        public string Name { get; set; }
        public bool IsDelete { get; set; }
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
        public static List<People> load()
        {
            var result = new List<People>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new People() { Id = i, Name = i.ToString() });
            }
            return result;
        }

        public static string taskTest(string i)
        {
            Thread.Sleep(new Random().Next(1000, 5000));
            System.Console.WriteLine(i);
            return i;
        }
        static void Main(string[] args)
        {
            string url = "https://summarize.5118.com/des";
            string postdata = @"s=在线智能原创工具是一款网编、SEO工作者和站长非常需要的工具，为降低文章重复度而生，一键生成智能原创文章可用于绕过一些重复度检测算法，用该智能原创工具可以把复制或采集的文章瞬间变成另一篇原创文章，并自带搜索引擎及新媒体相同的AI原创度检测即时提示。本工具主要针对百度、360、搜狐、神马、谷歌、公众号、头条等大型搜索引擎和新媒体引擎收录设计，通过本工具生成的智能原创文章，会被搜索引擎后台算法认为是低重复度文章。基础替换功能都是免费的，面向网络编辑、SEO从业者和站长等需要对内容进行加工、合并、降重的工作岗位，是搜索引擎优化和新媒体内容提交工作中不可缺少的一款工具。&m=100";
         string result=   HttpRequest.HttpPost(url, postdata, "application/x-www-form-urlencoded");
            System.Console.WriteLine(result);
            //Stopwatch stopwatch1 = new Stopwatch();
            //stopwatch1.Start();
            //var aaa=  Task.Run(() =>
            //  {
            //for (int j = 0; j < 10; j++)
            //{
            //    ParallelOptions options = new ParallelOptions();
            //    options.MaxDegreeOfParallelism = 3;
            //Parallel.For(0, 10, options, i => {
            //    System.Console.WriteLine(i);
            //    taskTest($"btnParallel_Click_{i}");
            //});


            //Parallel.ForEach(new int[] { 10, 1, 2, 3, 4 }, i => System.Console.WriteLine(i));
            ////}

            ////});

            //stopwatch1.Stop();
            //    System.Console.WriteLine($"总耗时：{stopwatch1.ElapsedMilliseconds}");
                //Parallel.ForEach<string>(data, (s, pls, l) =>
                //{
                //    System.Console.WriteLine("{0} {1}", s, l);
                //});






                //            string str = @"在线智能原创工具是一款网编、SEO工作者和站长非常需要的工具，为降低文章重复度而生，一键生成智能原创文章可用于绕过一些重复度检测算法，用该智能原创工具可以把复制或采集的文章瞬间变成另一篇原创文章，并自带搜索引擎及新媒体相同的AI原创度检测即时提示。
                //本工具主要针对百度、360、搜狐、神马、谷歌、公众号、头条等大型搜索引擎和新媒体引擎收录设计，通过本工具生成的智能原创文章，会被搜索引擎后台算法认为是低重复度文章。基础替换功能都是免费的，面向网络编辑、SEO从业者和站长等需要对内容进行加工、合并、降重的工作岗位，是搜索引擎优化和新媒体内容提交工作中不可缺少的一款工具。
                //基础替换功能都是免费的，面向网络编辑、SEO从业者和站长等需要对内容进行加工、合并、降重的工作岗位，是搜索引擎优化和新媒体内容提交工作中不可缺少的一款工具。";

                //            str = @"有专家表示，停止入库2G、3G手机就是升级2G、3G网络的第一步。有专家表示，停止入库2G、3G手机就是升级2G、3G网络的第一步

                //记者就2G、3G服务分别联系了中国电信、中国联通和中国移动客服，得到的回复是这样的：

                //三大运营商已经不再新售针对老年机的2G、3G卡；

                //现有的2G、3G卡还可以继续使用，目前没有接到停止服务的消息。

                //针对“在用2G、3G卡出现损坏如何处理”的问题，

                //中国电信客服表示，可到营业厅更换，也可以更换为4G卡；

                //中国联通客服表示，是否可以更换需要到营业厅去具体咨询；

                //中国移动客服则表示，可以到营业厅免费升级为4G卡，想再更换成2G、3G卡是不行了。

                //赛迪顾问通信产业研究中心高级分析师李朕在接受经济日报记者采访时表示，就目前情况来看，联通不太可能关闭3G网络，因为如果将2G、3G网络同时关闭，联通只剩下VOLTE的4G网络，产品线十分单一，这会让联通在运营商中处于不利之地，同时也会给用户带来不便。";

                //         var par=   str.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                //            for (int i = 0; i < par.Length; i++)
                //            {
                //                System.Console.WriteLine("*****************************************");
                //                var juzi = par[i].Replace("。", "。99999").Split(new string[] { "99999" }, StringSplitOptions.RemoveEmptyEntries);
                //                for (int j = 0; j < juzi.Length; j++)
                //                {

                //                    System.Console.WriteLine($"第{i + 1}段：第{j + 1}句：{juzi[j]}");
                //                    System.Console.WriteLine("---------------------------");

                //                }
                //            }





                // System.Console.WriteLine($"总耗时");
                //System.Console.ReadLine();


                //Stopwatch stopwatch = new Stopwatch();
                //stopwatch.Start();
                //List<Task<int>> tasks1 = new List<Task<int>>();
                //tasks1.Add(Task.Run(() => { return taskTest(1000); }));
                //tasks1.Add(Task.Run(() => { return taskTest(2000); }));
                //tasks1.Add(Task.Run(() => { return taskTest(3000); }));
                //tasks1.Add(Task.Run(() => { return taskTest(4000); }));
                //tasks1.Add(Task.Run(() => { return taskTest(5000); }));
                //tasks1.Add(Task.Run(() => { return taskTest(6000); }));
                //tasks1.Add(Task.Run(() => { return taskTest(7000); }));
                //tasks1.Add(Task.Run(() => { return taskTest(8000); }));
                //var m = tasks1.ToArray();
                //Task.WaitAll(m);
                //foreach (var item in m)
                //{
                //    System.Console.WriteLine(item.Result);
                //}
                //var task1 = Task.Run(() => { return taskTest(1000); });
                //var task2 = Task.Run(() => { return taskTest(2000); });
                //var task3 = Task.Run(() => { return taskTest(3000); });
                //var task4 = Task.Run(() => { return taskTest(4000); });
                //var task5 = Task.Run(() => { return taskTest(5000); });
                //var task6 = Task.Run(() => { return taskTest(6000); });
                //var task7 = Task.Run(() => { return taskTest(7000); });
                //var task8 = Task.Run(() => { return taskTest(8000); });
                //Task.WaitAll(task1, task2, task3, task4, task5, task6, task7, task8);

                //System.Console.WriteLine(task1.Result);
                //System.Console.WriteLine(task2.Result);
                //System.Console.WriteLine(task3.Result);
                //System.Console.WriteLine(task4.Result);
                //System.Console.WriteLine(task5.Result);
                //System.Console.WriteLine(task6.Result);
                //System.Console.WriteLine(task7.Result);
                //System.Console.WriteLine(task8.Result);

                //Task.WaitAll(task.ToArray());
                //stopwatch.Stop();
                //System.Console.WriteLine($"总耗时：{stopwatch.ElapsedMilliseconds}");
                //System.Console.ReadLine();







                //List<Task> a1 = new List<Task>();
                //for (int i = 0; i < 20; i++)
                //{
                //    Task.Run(() =>
                //    {
                //        Stopwatch stopwatch = new Stopwatch();
                //        stopwatch.Start();
                //        string postData = "activityGuid=8A3C976D-8199-E911-A4C7-D4AE52D0F72C&uid=18";
                //        string a = HttpRequest.HttpPost("http://d-account.5118.com/signin/aaaa", postData, "application/x-www-form-urlencoded", null);
                //        stopwatch.Stop();
                //        System.Console.WriteLine(a+ stopwatch.ElapsedMilliseconds);
                //    });
                //}
                // Task.WaitAll(a1.ToArray());
                //var result = load();
                //Expression<Func<People, bool>> expression = u => u.Age.ToString() == "20";
                //(string whereClause, Dictionary<string, object> parameters) = expression.ToWhereClause(false);
                //System.Console.WriteLine(whereClause);






                // var a=  ExpressionMapper<People, PeopleCopy>.Map(new People() { Id = 1, Name = "22" });


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

                // System.Console.ReadLine();
            }
        // static Tout Tran<Tout>

    
    }
}

