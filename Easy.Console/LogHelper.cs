using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Console
{
    public class LogHelper
    {
        public static void Writelog(string str)
        {
            Task.Run(() =>
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log.txt");
                string logContent = $"{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}:{str}\r\n";
                File.AppendAllText(filePath, logContent);
            });
        }
    }
}
