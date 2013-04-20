using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Data;
using System.Text.RegularExpressions;
namespace EmailTool
{
    public static class CollectHelper
    {
        public static DataTable dtMobile = CreateMoboileDT();
        public static DataTable dtEmail = CreateEmailDT();
        public static List<string> hisEmail = new List<string>();
        private static string regMobile = @"^(13[0-9]|15[0|3|6|7|8|9]|18[8|9])\d{8}$";
        private static string regEmail = @"(?is)[a-z\d]\w+([-+.']\w+)*[@＠]\w+([-.]\w+)*[\.．][\w\s]*?([-.]\w+)*?(com(\.cn)?|org(\.cn)?|gov(\.cn)?|net(\.cn)?|com|cn|net|cc|org|hk|biz|name|in|mobi|ac|tw|cm)";
        private static FileStream fs;
        private static StreamWriter sw;
        /// <summary>
        /// 获取手机号码
        /// </summary>
        /// <param name="strSource"></param>
        public static void CollectMobile(string strSource)
        {
            
            while (strSource.IndexOf("1") != -1)
            {
                int index = strSource.IndexOf("1");
                //如果从索引到最后长度不够11时，能出循环
                if (strSource.Substring(index).Length > 11)
                {
                    string temp = strSource.Substring(index, 11);//截取11个字符
                    if (Regex.IsMatch(temp, regMobile))//验证字符是否为手机号
                    {
                        DataRow dr = dtMobile.NewRow();
                        dr["Mobile"] = temp;                        
                        dtMobile.Rows.Add(dr);
                    }
                    strSource = strSource.Substring(index + 11);//截取未检索的字符
                }
                else
                {
                    break;
                }
            }            
        }
        /// <summary>
        /// 获取邮箱
        /// </summary>
        /// <param name="txtFileName"></param>
        public static void CollectEmail(string htmlSource)
        {
            Regex reg = new Regex(regEmail,RegexOptions.IgnoreCase);
            MatchCollection mcs = reg.Matches(htmlSource);
            for (int i = 0; i < mcs.Count; i++)
            {
                string temp=mcs[i].Value.ToString().ToLower();
                if(hisEmail.Contains(temp))
                    continue;
                hisEmail.Add(temp);
                DataRow dr = dtEmail.NewRow();
                dr["Email"] = temp;
                dtEmail.Rows.Add(dr);
                
            }            
        }       
        /// <summary>
        /// 创建手机信息数据表
        /// </summary>
        /// <returns></returns>
        private static DataTable CreateMoboileDT()
        {
            DataTable dt = new DataTable();
            //添加列
            dt.Columns.Add("Mobile", typeof(string));
            return dt;
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
            return dt;
        }
        
    }
}
