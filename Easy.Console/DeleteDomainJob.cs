using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Console
{

    public class DeleteDomainJob : IJob
    {

       public void Execute(IJobExecutionContext context)
        {
            LogHelper.Writelog($"任务开始{DateTime.Now}");
            //这里是业务处理，我就简单记录下日志  
        }
    }
}
