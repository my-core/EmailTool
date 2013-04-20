using System;
using System.Collections.Generic;
using System.Text;

namespace EmailTool
{
    /// <summary>
    /// 网站信息设置类
    /// </summary>
    public class SettingConfig
    {
        /// <summary>
        /// 锁对象
        /// </summary>
        private static object lockHelper = new object();
        /// <summary>
        /// 更新定时器
        /// </summary>
        private static System.Timers.Timer generalConfigTimer = new System.Timers.Timer(15000);
        /// <summary>
        /// 网站信息设置类对象
        /// </summary>
        private static SettingInfo _configinfo;
        /// <summary>
        /// 静态构造函数初始化相应实例和定时器
        /// </summary>
        static SettingConfig()
        {
            _configinfo = SettingConfigFileManager.LoadConfig();

            generalConfigTimer.AutoReset = true;
            generalConfigTimer.Enabled = true;
            generalConfigTimer.Elapsed += new System.Timers.ElapsedEventHandler(Timer_Elapsed);
            generalConfigTimer.Start();
        }

        private static void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            ResetConfig();
        }

        /// <summary>
        /// 重设配置类实例
        /// </summary>
        public static void ResetConfig()
        {
            _configinfo = SettingConfigFileManager.LoadConfig();
        }

        public static SettingInfo GetConfig()
        {
            return _configinfo;
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <param name="generalconfiginfo"></param>
        /// <returns></returns>
        public static bool SaveConfig(SettingInfo generalconfiginfo)
        {
            SettingConfigFileManager gcf = new SettingConfigFileManager();
            SettingConfigFileManager.ConfigInfo = generalconfiginfo;
            return gcf.SaveConfig();
        }

        #region Helper

        /// <summary>
        /// 序列化配置信息为XML
        /// </summary>
        /// <param name="configinfo">配置信息</param>
        /// <param name="configFilePath">配置文件完整路径</param>
        public static SettingInfo Serialiaze(SettingInfo configinfo, string configFilePath)
        {
            lock (lockHelper)
            {
                SerializationHelper.Save(configinfo, configFilePath);
            }
            return configinfo;
        }
        public static SettingInfo Deserialize(string configFilePath)
        {
            return (SettingInfo)SerializationHelper.Load(typeof(SettingInfo), configFilePath);
        }

        #endregion
    }
}
