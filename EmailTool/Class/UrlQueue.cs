using System;
using System.Collections.Generic;
using System.Text;

namespace EmailTool
{
    public class UrlQueue
    {
        public Queue<string> urlQueue = new Queue<string>();
        //队列数量
        public int Count
        {
            get
            {
                int count = 0;
                lock (this)
                {
                    count = urlQueue.Count;
                }
                return count;
            }
        }
        /// <summary>
        /// 清除队列
        /// </summary>
        public void Clear()
        {
            lock (this)
            {
                urlQueue.Clear();
            }
        }
        /// <summary>
        /// 进队列
        /// </summary>
        /// <param name="url"></param>
        public void Enqueue(string url)
        {
            urlQueue.Enqueue(url);
        }
        /// <summary>
        /// 出列队
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            string StrRes = "";
            lock (this)
            {
                if (urlQueue.Count > 0)
                {
                    StrRes = urlQueue.Dequeue();
                }
            }
            return StrRes;
        }
    }
}
