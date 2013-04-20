using System;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace EmailTool
{
    public static class HtmlHelper
    {
        /// <summary>
        /// 传入URL返回网页的html代码【HttpWebRequest】
        /// </summary>
        /// <param name="url">网址--如：http://www.yunksoft.com</param>
        /// <returns>页面的源代码</returns>
        public static string GetPageHtml(string url, string encode)
        {
            try
            {
                string content = string.Empty;
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                //伪造浏览器数据，避免被防采集程序过滤
                request.UserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.0; .NET CLR 1.1.4322; .NET CLR 2.0.50215; CrazyCoder.cn;www.aligong.com)";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                // 获取输入流
                System.IO.Stream respStream = response.GetResponseStream();
                System.IO.StreamReader reader = new System.IO.StreamReader(respStream, Encoding.Default);
                content = reader.ReadToEnd();
                //获取网页字符编码描述信息
                Match charSetMatch = Regex.Match(content, "<meta([^<]*)charset=\"([^<]*)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                string charSet = charSetMatch.Groups[2].Value;
                //如果未获取到编码，则设置默认编码
                if (charSet == null || charSet == "")
                {
                    if (encode != "")
                    {
                        charSet = encode;
                    }
                    else
                    {
                        charSet = "UTF-8";
                    }
                }
                //重新用编码获取页面内容
                respStream = response.GetResponseStream();
                reader = new System.IO.StreamReader(respStream, Encoding.GetEncoding(charSet));
                content = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                return content;
            }
            catch (System.Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// 传入URL返回网页的html代码
        /// </summary>
        /// <param name="url">地址</param>
        /// <param name="encode">设置编码</param>
        /// <returns></returns>
        public static string GetHtml(string url,string encode)
        {
            try
            {
                string content = string.Empty;
                if (url != null || url.Trim() != "")
                {
                    WebClient webClient = new WebClient();
                    webClient.Credentials = CredentialCache.DefaultCredentials;
                    byte[] myDataBuffer = webClient.DownloadData(url);
                    //使用默认的编码获取内容
                    content = Encoding.Default.GetString(myDataBuffer);
                    //获取网页字符编码描述信息
                    Match charSetMatch = Regex.Match(content, "<meta([^<]*)charset=\"([^<]*)\"", RegexOptions.IgnoreCase | RegexOptions.Multiline);
                    string charSet = charSetMatch.Groups[2].Value;
                    //如果未获取到编码，则设置默认编码
                    if (charSet == null || charSet == "")
                    {
                        if (encode != "")
                        {
                            charSet = encode;
                        }
                        else
                        {
                            charSet = "UTF-8";
                        }
                    }
                    //重新用编码获取页面内容
                    content = Encoding.GetEncoding(charSet).GetString(myDataBuffer);
                }
                return content;
            }
            catch(Exception ex)
            {
                return ex.Message; ;
            }
        }
        
    }
}
