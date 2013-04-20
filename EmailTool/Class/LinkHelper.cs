using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using System.Data;
using System.Text.RegularExpressions;
using System.Web;

namespace EmailTool
{
    public static class LinkHelper
    {
        public static DataTable dtEmail = CreateEmailDT();
        public static List<string> hisEmail = new List<string>();
        private static string regEmail =@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*";// @"(?is)[a-z\d]\w+([-+.']\w+)*[@＠]\w+([-.]\w+)*[\.．][\w\s]*?([-.]\w+)*?(com(\.cn)?|org(\.cn)?|gov(\.cn)?|net(\.cn)?|com|cn|net|cc|org|hk|biz|name|in|mobi|ac|tw|cm)";
        private static int baiduPage = SettingConfig.GetConfig().BaiduPage;
        #region 百度
        /// <summary>
        /// 根据搜索关键词创建百度搜索的地址
        /// </summary>
        /// <returns></returns>
        public static string[] CreateBaiduSearchLink(string[] key )
        {
            StringBuilder sb = new StringBuilder();
            string url = "http://www.baidu.com/s?wd={0}&pn={1}rn=100";
            List<string> links = new List<string>();
            foreach (string s in key)
            {
                for (int i = 0; i < baiduPage; i++)
                {
                    sb.Length = 0;
                    sb.AppendFormat(url, HttpUtility.UrlEncode(s+ " 邮箱"), i * 10);
                    links.Add(sb.ToString());
                }
            }
            return links.ToArray();
        }
        /// <summary>
        /// 获取百度Link
        /// </summary>
        /// <param name="wd"></param>
        /// <returns></returns>
        public static List<string> GetBaiduSearchLink(string html)
        {
            List<string> links = new List<string>();
            string strTemp = "";
            string BaiduLinkXPath_Table = "//html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[2]/table";//百度a标签XPath
            string BaiduLinkXPath_A = "//a[1]";

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode rootNode = doc.DocumentNode;
            HtmlNodeCollection categoryNodeList = rootNode.SelectNodes(BaiduLinkXPath_Table); //百度a标签的节点集
            //html节点
            HtmlNode tempNode = null;
            if (categoryNodeList == null)
                return links;
            foreach (HtmlNode categoryNode in categoryNodeList)
            {
                tempNode = HtmlNode.CreateNode(categoryNode.OuterHtml);
                tempNode = tempNode.SelectSingleNode(BaiduLinkXPath_A);
                if (tempNode == null)
                    continue;
                strTemp = tempNode.Attributes["href"].Value.ToString();
                if (RegexHelper.IsURL(strTemp))
                {
                    links.Add(strTemp);
                }
            }
            return links;
        }
        /// <summary>
        /// 获取百度Link
        /// </summary>
        /// <param name="wd"></param>
        /// <returns></returns>
        public static List<string> GetBaiduLink(string url)
        {
            List<string> links = new List<string>();
            string strTemp = "";
            string html = HtmlHelper.GetHtml(url, "UTF-8");
            string BaiduLinkXPath_Table = "//html[1]/body[1]/div[1]/div[1]/div[1]/div[3]/div[2]/table";//百度a标签XPath
            string BaiduLinkXPath_A = "//a[1]";

            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(html);
            HtmlNode rootNode = doc.DocumentNode;
            HtmlNodeCollection categoryNodeList = rootNode.SelectNodes(BaiduLinkXPath_Table); //百度a标签的节点集
            //html节点
            HtmlNode tempNode = null;
            if (categoryNodeList == null)
                return links;
            foreach (HtmlNode categoryNode in categoryNodeList)
            {
                tempNode = HtmlNode.CreateNode(categoryNode.OuterHtml);
                tempNode = tempNode.SelectSingleNode(BaiduLinkXPath_A);
                if (tempNode == null)
                    continue;
                strTemp = tempNode.Attributes["href"].Value.ToString();
                if (RegexHelper.IsURL(strTemp))
                {
                    links.Add(strTemp);
                }
            }
            return links;
        }
        #endregion

        /// <summary>
        /// 获取邮箱
        /// </summary>
        /// <param name="txtFileName"></param>
        public static void CollectEmail(string url ,string htmlSource)
        {
            Regex reg = new Regex(regEmail, RegexOptions.IgnoreCase);
            Regex regHanzi = new Regex(@"[\u4e00-\u9fa5]+");
            MatchCollection mcs = reg.Matches(htmlSource);
            for (int i = 0; i < mcs.Count; i++)
            {
                string temp = regHanzi.Replace(mcs[i].Value.ToString().ToLower(), "");
                if (hisEmail.Contains(temp))
                    continue;
                hisEmail.Add(temp);
                lock (dtEmail)
                {
                    DataRow dr = dtEmail.NewRow();
                    dr["Email"] = temp;
                    dr["Url"] = url;
                    dtEmail.Rows.Add(dr);
                }

            }
        }       
        /// <summary>
        /// 创建邮件数据表
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateEmailDT()
        {
            DataTable dt = new DataTable();
            //添加列
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add("Url", typeof(string));
            return dt;
        }
    }
}
