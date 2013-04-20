using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace EmailTool
{
    /// <summary>
    /// 状态改变委托
    /// </summary>
    /// <param name="sender"></param>
    public delegate void CollectorThreadCallback(object sender);
    /// <summary>
    /// 采集线程
    /// </summary>
    public class CollectorThread
    {
        /// <summary>
        /// 线程状态改变委托实例
        /// </summary>
        public event CollectorThreadCallback CollectotThreadCallbacked;
        //线程
        private Thread m_thread;
        //线程名
        public string Name { get; set; }
        private string m_url;
        /// <summary>
        /// 当前爬行URl
        /// </summary>
        public string Url
        {
            get { return m_url; }
            set
            {
                if (m_url != value)
                {
                    m_url = value;
                    this.Dirty = true;
                }
            }
        }
        /// <summary>
        /// 每一个线程都包含一个采集主体
        /// </summary>
        private Collector Collector
        {
            get;
            set;
        }
        /// <summary>
        /// Dirty
        /// </summary>
        private bool Dirty
        {
            get;
            set;
        }

        /// <summary>
        /// 构造函数（为线程的采集主体赋值）
        /// </summary>
        /// <param name="collector"></param>
        public CollectorThread(Collector collector)
        {
            m_thread = new Thread(CollectorThread.DoWork);
            this.Collector = collector;
            this.Dirty = false;
        }
        //线程开始
        internal void Start()
        {
            m_thread.Start(this);
        }
        //线程中止
        internal void Abort()
        {
            m_thread.Abort();
        }
        //线程暂停（挂起）
        internal void Suspend()
        {
            m_thread.Suspend();
        }
        //线程销毁
        internal void Resume()
        {
            m_thread.Resume();
        }
        public static void DoWork(object data)
        {
            try
            {
                CollectorThread cThread = (CollectorThread)data; 
                //采集主体
                 Collector collector = cThread.Collector;
                //即将访问的URL队列
                UrlQueue urlQueue = collector.urlQueue;
                while (true)
                {
                    if (urlQueue.Count>0)
                    {
                        try
                        {
                            // 从队列中获取URL
                            string url = (string)urlQueue.Dequeue();
                            // 获取页面
                            cThread.Url = url;
                            if (cThread.Dirty)
                                cThread.CollectotThreadCallbacked(collector);
                            string html = HtmlHelper.GetHtml(url, "UTF-8");
                            //检索页面上的邮件
                            CollectHelper.CollectEmail(html);
                            if (cThread.Dirty)
                            {
                                cThread.CollectotThreadCallbacked(collector);
                            }
                        }
                        catch (InvalidOperationException)
                        {
                            SleepWhenQueueIsEmpty(cThread);
                        }
                    }
                    else
                    {
                        SleepWhenQueueIsEmpty(cThread);
                    }
                }
            }
            catch (ThreadAbortException)
            {
                // 线程被放弃
            }
        }
        /// <summary>
        /// foamliu, 2009/12/27.
        /// 这个方法主要做三件事: 1.获取页面. 2.提取URL并加入队列. 3.获取面上的邮件地址
        /// </summary>
        /// <param name="url"></param>
        private static void Fetch(CollectorThread collector, string url)
        {
            try
            {
                // 获取页面.
                collector.Url = url;
                if (collector.Dirty)
                    collector.CollectotThreadCallbacked(collector);
                string html = HtmlHelper.GetHtml(url,"UTF-8");
                string baseUri = UrlHelper.GetBaseUri(url);
                string[] links = UrlHelper.ExtractLinks(baseUri, html);
                // 提取URL并加入队列.
                UrlQueue urlQueue = collector.Collector.urlQueue;
                foreach (string link in links)
                {
                    //判断url过长，避免爬虫陷阱
                    if (link.Length > 256) continue;
                    //判断是否访问过，避免出现环
                    if (collector.Collector.HSCollectorUrl.Contains(link))
                        continue;
                    // 加入队列
                    urlQueue.Enqueue(link);
                }
                //检索页面上的邮件
                if (collector.Dirty)
                {                   
                    collector.CollectotThreadCallbacked(collector);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        /// <summary>
        /// 为避免挤占CPU, 队列为空时睡觉. 
        /// </summary>
        /// <param name="crawler"></param>

        private static void SleepWhenQueueIsEmpty(CollectorThread collector)
        {
            collector.Url = string.Empty;
            if (collector.Dirty)
                collector.CollectotThreadCallbacked(collector);
            Thread.Sleep(10 * 1000);
        }
    }
}
