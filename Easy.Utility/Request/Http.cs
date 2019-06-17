using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Utility.Request
{
   public class HttpRequest
    {
        /// <summary>
        /// http请求
        /// </summary>
        /// <param name="url">请求地址</param>
        /// <param name="postData">参数,有参数则以&隔开，例如id=1&age=2</param>
        /// <param name="contentType">类型，一般为application/x-www-form-urlencoded和application/json</param>
        /// <param name="headers">头部信息</param>
        /// <returns></returns>
        public static string HttpPost(string url, string postData = null, string contentType = null, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }
    
    }
}
