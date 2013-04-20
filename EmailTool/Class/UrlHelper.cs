using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;

namespace EmailTool
{
    public static class UrlHelper
    {      
        /// <summary>
        /// foamliu, 2009/12/27.
        /// 爬虫需要两个URL是否指向相同的页面这一点可以被迅速检测出来, 这就需要URL规范化.
        /// URL规范化做的主要的事情:
        /// 转换为小写
        /// 相对URL转换成绝对URL
        /// 删除默认端口号
        /// 根目录添加斜杠
        /// 猜测的目录添加尾部斜杠
        /// 删除分块
        /// 解析路径
        /// 删除缺省名字
        /// 解码禁用字符
        /// 
        /// 更多信息参照RFC3986:
        /// http://tools.ietf.org/html/rfc3986
        /// </summary>
        /// <param name="strURL"></param>
        public static void Normalize(string baseUri, ref string strUri)
        {
            // 相对URL转换成绝对URL
            if (strUri.StartsWith("/"))
            {
                strUri = baseUri + strUri.Substring(1);
            }
            // 当查询字符串为空时去掉问号"?"
            if (strUri.EndsWith("?"))
                strUri = strUri.Substring(0, strUri.Length - 1);
            // 转换为小写
            strUri = strUri.ToLower();
            // 删除默认端口号
            // 解析路径
            // 解码转义字符
            Uri tempUri = new Uri(strUri);
            strUri = tempUri.ToString();
            // 根目录添加斜杠
            int posTailingSlash = strUri.IndexOf("/", 8);
            if (posTailingSlash == -1)
                strUri += '/';
            // 猜测的目录添加尾部斜杠
            if (posTailingSlash != -1 && !strUri.EndsWith("/") && strUri.IndexOf(".", posTailingSlash) == -1)
                strUri += '/';
            // 删除分块
            int posFragment = strUri.IndexOf("#");
            if (posFragment != -1)
            {
                strUri = strUri.Substring(0, posFragment);
            }
            // 删除缺省名字
            string[] DefaultDirectoryIndexes = 
            {
                "index.html",
                "default.asp",
                "default.aspx",
            };
            foreach (string index in DefaultDirectoryIndexes)
            {
                if (strUri.EndsWith(index))
                {
                    strUri = strUri.Substring(0, (strUri.Length - index.Length));
                    break;
                }
            }
        }
        /// <summary>
        /// URL规范化
        /// </summary>
        /// <param name="strUri"></param>
        public static void Normalize(ref string strUri)
        {
            Normalize(string.Empty, ref strUri);
        }
        /// <summary>
        /// 获取基地址
        /// </summary>
        /// <param name="strUri"></param>
        /// <returns></returns>
        public static string GetBaseUri(string strUri)
        {
            string baseUri;
            Uri uri = new Uri(strUri);
            string port = string.Empty;
            if (!uri.IsDefaultPort)
                port = ":" + uri.Port;
            baseUri = uri.Scheme + "://" + uri.Host + port + "/";
            return baseUri;
        }
        /// <summary>
        /// 页面解析(提取URL)
        /// </summary>
        /// <param name="baseUri"></param>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string[] ExtractLinks(string baseUri, string html)
        {
            List<string> urls = new List<string>();
            try
            {
                string strRef = @"(href|HREF|src|SRC)[ ]*=[ ]*[""'][^""'#>]+[""']";
                MatchCollection matches = new Regex(strRef).Matches(html);
                foreach (Match match in matches)
                {
                    strRef = match.Value.Substring(match.Value.IndexOf('=') + 1).Trim('"', '\'', '#', ' ', '>');
                    try
                    {
                        if (IsGoodUri(strRef))
                        {
                            Normalize(baseUri, ref strRef);
                            urls.Add(strRef);
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
            return urls.ToArray();
        }
        /// <summary>
        /// 是否是正确的URI
        /// </summary>
        /// <param name="strUri"></param>
        /// <returns></returns>
        static bool IsGoodUri(string strUri)
        {
            if (strUri.ToLower().StartsWith("javascript:"))
                return false;
            return true;
        }
    }
}
