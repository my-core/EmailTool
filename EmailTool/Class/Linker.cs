using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailTool
{
    /// <summary>
    /// 状态改变委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void LinkerCallbacked(object sender);
    public class Linker
    {
        //状态改变委托实例
        public event LinkerCallbacked LinkerCallbacked;
        /// <summary>
        /// 搜索地址列表,使用先进先出 （First-in-first-out, FIFO) 的队列
        /// </summary>
        public UrlQueue urlQueue = new UrlQueue();
        /// <summary>
        /// 搜索页面取得的内容链接
        /// </summary>
        public List<string> urlList = new List<string>();
        /// <summary>
        /// 每次执行的线程数
        /// </summary>
        public int ThreadCount = 10;
        public LinkerThread[] _linkerThreads;
        /// <summary>
        /// 线程数组
        /// </summary>
        public LinkerThread[] LinkerThreads
        {
            get { return _linkerThreads; }
        }
        /// <summary>
        /// 构造函数(指定线程数)
        /// </summary>
        /// <param name="threadCount">线程数</param>
        public Linker(int threadCount)
        {
            ThreadCount = threadCount;
        }
        /// <summary>
        /// 初始化队列
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
        /// 开始（按配置的线程数创建线程进行抓取）
        /// </summary>
        public void Start()
        {
            //创建线程
            _linkerThreads = new LinkerThread[ThreadCount];
            for (int i = 0; i < ThreadCount; i++)
            {
                LinkerThread linkerThread = new LinkerThread(this);
                linkerThread.Name = i.ToString();
                //为每个线程注册委托
                linkerThread.LinkerThreadStatusChanged += new LinkerThreadStatusChangedEventHandler(LinkerThreadCallbacked);
                linkerThread.Start();
                LinkerThreads[i] = linkerThread;
            }
        }
        /// <summary>
        /// 状态改变委托调用方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkerThreadCallbacked(object sender)
        {
            //状态改变，委托事件执行方法MainForm.DownloaderStatusChanged
            LinkerCallbacked(this);
        }
        /// <summary>
        /// 暂停爬行
        /// </summary>
        public void Suspend()
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                if (null != _linkerThreads[i])
                    _linkerThreads[i].Suspend();
            }
        }
        /// <summary>
        /// 重新开始爬行(销毁)
        /// </summary>
        public void Resume()
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                if (null != _linkerThreads[i])
                    _linkerThreads[i].Resume();
            }
        }
        /// <summary>
        /// 中止爬行
        /// </summary>
        public void Abort()
        {
            for (int i = 0; i < ThreadCount; i++)
            {
                if (null != _linkerThreads[i])
                    _linkerThreads[i].Abort();
            }
        }
    }
}
