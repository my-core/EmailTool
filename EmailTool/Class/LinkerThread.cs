using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace EmailTool
{
    /// <summary>
    /// 状态改变委托
    /// </summary>
    /// <param name="sender"></param>
    public delegate void LinkerThreadStatusChangedEventHandler(object sender);
    public class LinkerThread
    {
        /// <summary>
        /// 线程状态改变委托实例
        /// </summary>
        public event LinkerThreadStatusChangedEventHandler LinkerThreadStatusChanged;
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
                    this.IsComplete = true;
                }
            }
        }
        /// <summary>
        /// 每一个线程都包含一个主体
        /// </summary>
        private Linker Linker
        {
            get;
            set;
        }
        /// <summary>
        /// 线程状态
        /// </summary>
        private bool IsComplete
        {
            get;
            set;
        }
        /// <summary>
        /// 构造函数（为线程的采集主体赋值）
        /// </summary>
        /// <param name="Linker"></param>
        public LinkerThread(Linker Linker)
        {
            m_thread = new Thread(LinkerThread.DoWork);
            m_thread.IsBackground = true;
            this.Linker = Linker;
            this.IsComplete = false;
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
        /// <summary>
        /// 开始线程
        /// </summary>
        /// <param name="data"></param>
        public static void DoWork(object data)
        {
            try
            {
                LinkerThread LinkerThread = (LinkerThread)data;
                //主体
                Linker Linker = LinkerThread.Linker;
                //即将访问的URL队列
                UrlQueue urlQueue = Linker.urlQueue;
                while (true)
                {
                    if (urlQueue.Count > 0)
                    {
                        try
                        {
                            // 从队列中获取URL
                            string url = (string)urlQueue.Dequeue();
                            // 获取页面
                            LinkerThread.Url = url;
                            if (LinkerThread.IsComplete)
                                LinkerThread.LinkerThreadStatusChanged(Linker);
                            string html = HtmlHelper.GetHtml(url, "UTF-8");
                            LinkHelper.CollectEmail(url,html);
                            if (LinkerThread.IsComplete)
                                LinkerThread.LinkerThreadStatusChanged(Linker);
                        }
                        catch (InvalidOperationException)
                        {
                            SleepWhenQueueIsEmpty(LinkerThread);
                        }
                    }
                    else
                    {
                        SleepWhenQueueIsEmpty(LinkerThread);
                    }
                }
            }
            catch (ThreadAbortException)
            {
                // 线程被放弃
            }
        }
        /// <summary>
        /// 为避免挤占CPU, 队列为空时睡觉. 
        /// </summary>
        /// <param name="crawler"></param>
        private static void SleepWhenQueueIsEmpty(LinkerThread linkerThread)
        {
            linkerThread.Url = string.Empty;
            if (linkerThread.IsComplete)
                linkerThread.LinkerThreadStatusChanged(linkerThread);
            Thread.Sleep(10 * 1000);
        }
    }
}
