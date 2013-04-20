using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EmailTool
{
    public class SettingInfo : IConfigInfo
    {
        private int _ThreadCount = 10;
        public int ThreadCount
        {
            get { return _ThreadCount; }
            set { _ThreadCount = value; }
        }
        private int _BaiduPage = 10;
        public int BaiduPage
        {
            get { return _BaiduPage; }
            set { _BaiduPage = value; }
        }
    }
}
