using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlSkin.AlForm;

namespace EmailTool
{
    public partial class Setting : AlBaseForm
    {
        public Setting()
        {
            InitializeComponent();
        }

        private void Setting_Load(object sender, EventArgs e)
        {
            SettingInfo info = new SettingInfo();
            info = SettingConfig.GetConfig();
            this.textBox_ThreadCount.Text = info.ThreadCount.ToString();
            this.textBox_BaiduPage.Text = info.BaiduPage.ToString();
        }

        private void Button_Setting_Click(object sender, EventArgs e)
        {
            try
            {
                if (!RegexHelper.IsNumber(this.textBox_ThreadCount.Text))
                {
                    MessageBox.Show("线程最大数必须输入整数！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (!RegexHelper.IsNumber(this.textBox_BaiduPage.Text))
                {
                    MessageBox.Show("百度最大页数必须输入整数！", "温馨提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                SettingInfo info = SettingConfig.GetConfig();
                info.ThreadCount = int.Parse(this.textBox_ThreadCount.Text);
                info.BaiduPage = int.Parse(this.textBox_BaiduPage.Text);
                SettingConfig.SaveConfig(info);
                MessageBox.Show("设置成功","操作提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
