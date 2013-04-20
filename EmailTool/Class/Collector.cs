using System;
using System.Collections.Generic;
using System.Text;

namespace EmailTool
{
    /// <summary>
    /// 状态改变委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void CollectorCallback(object sender);
    /// <summary>
    /// 采集主体
    /// </summary>
    public class Collector
    {
        //状态改变委托实例
        public event CollectorCallback CollectorCallbacked;
        /// <summary>
        /// 尚未访问的URL列表,使用先进先出 （First-in-first-out, FIFO) 的队列
        /// </summary>
        public UrlQueue urlQueue = new UrlQueue();
        /// <summary>
        /// 爬取历史(维护已访问过的URL)
        /// </summary>
        public HashSet<string> HSCollectorUrl = new HashSet<string>();       
        /// <summary>
        /// 每次执行的线程数
        /// </summary>
        public int ThreadCount=10;
        private CollectorThread[] _collectorThreads;
        /// <summary>
        /// 爬虫线程数组
        /// </summary>
        public CollectorThread[] CrawlerThreads
        {
            get
            {
                return _collectorThreads;
            }
        }
        /// <summary>
        /// 构造函数(指定线程数)
        /// </summary>
        /// <param name="threadCount">线程数</param>
        public Collector(int threadCount)
        {
            ThreadCount = threadCount;
        }
        /// <summary>
        /// 通常爬虫是从一系列种子(Seed)网页开始,然后使用这些网页中的链接去获取其他页面.（）
        /// </summary>
        /// <param name="seeds">
        /// </param>
        public void InitSeeds(string[] seeds)
        {
            urlQueue.Clear();
            // 使用种子URL进行队列初始化
            foreach (string s in seeds)
                urlQueue.Enqueue(s);
        }
        /// <summary>
        /// 爬虫开始（按配置的线程数创建线程进行抓取）
        /// </summary>
        public void Start()
        {
            //创建线程
            _collectorThreads = new CollectorThread[ThreadCount];
            for (int i = 0; i < ThreadCount; i++)
            {
                CollectorThread cThread = new CollectorThread(this);
                cThread.Name = i.ToString();
                //为每个线程注册委托
                cThread.CollectotThreadCallbacked += new CollectorThreadCallback(CollectorThreadStatusChanged);
                cThread.Start();
                CrawlerThreads[i] = cThread;
            }
        }
        /// <summary>
        /// 暂停爬行
        /// </summary>
        public void Suspend()
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                if (null != _collectorThreads[i])
                    _collectorThreads[i].Suspend();
            }
        }
        /// <summary>
        /// 重新开始爬行(销毁)
        /// </summary>
        public void Resume()
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                if (null != _collectorThreads[i])
                    _collectorThreads[i].Resume();
            }
        }
        /// <summary>
        /// 中止爬行
        /// </summary>
        public void Abort()
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                if (null != _collectorThreads[i])
                    _collectorThreads[i].Abort();
            }
        }
        /// <summary>
        /// 状态改变委托调用方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CollectorThreadStatusChanged(object sender)
        {
            //状态改变，委托事件执行方法MainForm.DownloaderStatusChanged
            CollectorCallbacked(this);
        }
    }
}
