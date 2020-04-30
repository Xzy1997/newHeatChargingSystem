using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HeatChargingSystem.utils
{
    public class HttpUtils
    {
       
        /// <summary>
        /// Http Post 请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string PostRequest(string url, string source, string token="")
        {
            byte[] data = Encoding.UTF8.GetBytes(source); 

            WebClient webClient = new WebClient();
            try
            {
                //采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可
                webClient.Headers.Add("Content-Type", "application/json;charset=UTF-8");
                if (!string.IsNullOrEmpty(token))
                {
                    webClient.Headers.Add("token", token);
                }
                //得到返回字符流  
                byte[] responseData = webClient.UploadData(url, "POST", data);
                //解码  
                String responseString = Encoding.UTF8.GetString(responseData);
                return responseString;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    Stream stream = ex.Response.GetResponseStream();
                    string m = ex.Response.Headers.ToString();
                    byte[] buf = new byte[256];
                    stream.Read(buf, 0, 256);
                    stream.Close();
                    int count = 0;
                    foreach (Byte b in buf)
                    {
                        if (b > 0)
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    return ex.Message + "\r\n\r\n" + Encoding.UTF8.GetString(buf, 0, count);
                }
                else
                {
                    return ex.Message;
                }
            }
        }

        /// <summary>  
        /// HTTP POST请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="dic">请求的参数</param>  
        /// <param name="requestEncode">请求的编码</param>  
        /// <param name="responseEncode">响应的编码</param>  
        /// <returns>响应的结果</returns>  
        public static String PostRequest(String url, IDictionary<String, String> dic, String requestEncode, String responseEncode)
        {
            StringBuilder strb = new StringBuilder();
            if (dic.Keys.Count > 1)
            {
                foreach (string key in dic.Keys)
                {
                    strb.AppendFormat("{0}={1}&", key, dic[key]);
                }
            }
            else
            {
                foreach (string key in dic.Keys)
                {
                    strb.AppendFormat("{0}", dic[key]);
                }
            }

            String queryString = strb.ToString();
            queryString = queryString.EndsWith("&") ? queryString.Remove(queryString.LastIndexOf('&')) : queryString;
            byte[] data = Encoding.GetEncoding(requestEncode.ToUpper()).GetBytes(queryString); ;

            WebClient webClient = new WebClient();
            try
            {
                //采取POST方式必须加的header，如果改为GET方式的话就去掉这句话即可
                webClient.Headers.Add("Content-Type", "application/json;charset=UTF-8");
                //得到返回字符流  
                byte[] responseData = webClient.UploadData(url, "POST", data);
                //解码  
                String responseString = Encoding.GetEncoding(responseEncode.ToUpper()).GetString(responseData);
                return responseString;
            }
            catch (WebException ex)
            {
                if (ex.Response != null)
                {
                    Stream stream = ex.Response.GetResponseStream();
                    string m = ex.Response.Headers.ToString();
                    byte[] buf = new byte[256];
                    stream.Read(buf, 0, 256);
                    stream.Close();
                    int count = 0;
                    foreach (Byte b in buf)
                    {
                        if (b > 0)
                        {
                            count++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    return ex.Message + "\r\n\r\n" + Encoding.GetEncoding(responseEncode.ToUpper()).GetString(buf, 0, count);
                }
                else
                {
                    return ex.Message;
                }
            }
        }
        /// <summary>  
        /// HTTP GET请求  
        /// </summary>  
        /// <param name="requestUrl">请求的URL</param>  
        /// <param name="requestEncode">请求的编码</param>  
        /// <param name="responseEncode">响应的编码</param>  
        /// <returns>响应的结果</returns>  
      

        public static String GetRequest(String requestUrl, string token = "")
        {

            WebClient webClient = new WebClient();
            webClient.Headers.Add("Content-Type", "application/json;charset=UTF-8");
            if (!string.IsNullOrEmpty(token))
            {
                webClient.Headers.Add("token", token);
            }
            try
            {
                //得到返回字符流  
                byte[] responseData = webClient.DownloadData(requestUrl);
                //解码  
                //String responseString = Encoding.GetEncoding(responseEncode.ToUpper()).GetString(responseData);
                String responseString = Encoding.UTF8.GetString(responseData);
                return responseString;
            }
            catch (WebException ex)
            {
                Stream stream = ex.Response.GetResponseStream();
                string m = ex.Response.Headers.ToString();
                byte[] buf = new byte[256];
                stream.Read(buf, 0, 256);
                stream.Close();
                int count = 0;
                foreach (Byte b in buf)
                {
                    if (b > 0)
                    {
                        count++;
                    }
                    else
                    {
                        break;
                    }
                }
                return ex.Message + "\r\n\r\n" + Encoding.UTF8.GetString(buf, 0, count);
            }
        }
    }
}
