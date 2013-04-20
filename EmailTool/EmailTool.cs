using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AlSkin.AlForm;
using System.IO;

namespace EmailTool
{
    delegate void UpdateDataGridCallback(Linker c);
    public partial class EmailTool: AlBaseForm
    {
        private Linker Linker;
        private Collector Collector;
        //关键词
        public static string[] wd = { };
        public EmailTool()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.toolStripButton_Stop.Enabled = false;
        }

        private void toolStrip_Click(object sender, EventArgs e)
        {
            ToolStripButton control = (ToolStripButton)sender;
            switch (control.Name)
            {
                //设置
                case "toolStripButton_Set":
                    Setting set = new Setting();
                    set.ShowDialog(this);
                    break;
                //导入
                case "toolStripButton_ImportKeyword":
                    OpenFileDialog dlg = new OpenFileDialog();
                    dlg.Multiselect = true;
                    dlg.Title = "选择要导入的文本";
                    dlg.Filter = "txt files|*.*";
                    if (DialogResult.OK == dlg.ShowDialog())
                    {
                        this.ImportKeyword(dlg.FileName);
                    }
                    break;
                //开始
                case "toolStripButton_Start":
                    if (this.listBox_Keyword.Items.Count == 0)
                    {
                        MessageBox.Show("请导入关键字，再进行操作");
                        return;
                    }
                    this.toolStripButton_Start.Enabled = false;
                    this.toolStripButton_Set.Enabled = false;
                    this.toolStripButton_ImportKeyword.Enabled = false;
                    this.toolStripButton_Stop.Enabled = true;
                    this.Start();
                    break;
                //停止
                case "toolStripButton_Stop":
                    break;
                //退出
                case "toolStripButton_Exit":
                    this.Close();
                    break;
                //关于
                case "toolStripButton_About":
                    About about = new About();
                    about.ShowDialog(this);
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 导入搜索关键词
        /// </summary>
        /// <param name="filePath"></param>
        public void ImportKeyword(string filePath)
        {
            wd = File.ReadAllLines(filePath, Encoding.Default);
            int index = 0;
            foreach (string item in wd)
            {
                this.listBox_Keyword.Items.Add(item);
                index++;
            }
            this.label2.Text = index.ToString();
        }
        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            string[] searchLink = LinkHelper.CreateBaiduSearchLink(wd);
            SettingInfo info = SettingConfig.GetConfig();
            Linker = new Linker(info.ThreadCount);
            //注册状态改变事件
            Linker.LinkerCallbacked += new LinkerCallbacked(LinkerCallbacked);
            Linker.InitSeeds(searchLink);
            Linker.Start();
        }
        /// <summary>
        /// 线程执行完一次url采集后回调
        /// </summary>
        /// <param name="sender"></param>
        public void LinkerCallbacked(object sender)
        {
            Linker c = (Linker)sender;
            UpdateDataGrid(c);
        }
        /// <summary>
        /// 更新表格
        /// </summary>
        /// <param name="c"></param>
        private void UpdateDataGrid(Linker c)
        {
            try
            {
                if (this.xyDataGridView1.InvokeRequired)
                {
                    UpdateDataGridCallback callback = new UpdateDataGridCallback(UpdateDataGrid);
                    this.Invoke(callback, new object[] { c });
                }
                else
                {
                    try
                    {
                        //lock (xyDataGridView1)
                        //{
                        //    xyDataGridView1.DataSource = null;
                        //    xyDataGridView1.DataSource = LinkHelper.dtEmail;
                        //    xyDataGridView1.Columns["Email"].Width = 150;
                        //    //this.xyDataGridView1.FirstDisplayedScrollingRowIndex = this.xyDataGridView1.Rows.Count - 1;
                        //    //this.xyDataGridView1.Rows[this.xyDataGridView1.Rows.Count - 1].Selected = true;
                        //    //this.xyDataGridView1.CurrentCell = this.xyDataGridView1[0, this.xyDataGridView1.Rows.Count - 1];
                        //}
                        //for (int i = this.xyDataGridView1.Rows.Count; i < LinkHelper.dtEmail.Rows.Count; ++i)
                        //{
                        //    int index = this.xyDataGridView1.Rows.Add();
                        //    this.xyDataGridView1.Rows[index].Cells[0].Value = LinkHelper.dtEmail.Rows[i]["Email"].ToString();
                        //    this.xyDataGridView1.Rows[index].Cells[1].Value = LinkHelper.dtEmail.Rows[i]["Url"].ToString();
                        //}
                        //this.xyDataGridView1.DataSource = null;
                        this.xyDataGridView1.DataSource = LinkHelper.dtEmail;
                        this.label4.Text = LinkHelper.dtEmail.Rows.Count.ToString();
                        //this.xyDataGridView1.FirstDisplayedScrollingRowIndex = this.xyDataGridView1.Rows.Count - 1;
                        //this.xyDataGridView1.Rows[this.xyDataGridView1.Rows.Count - 1].Selected = true;
                        //this.xyDataGridView1.CurrentCell = this.xyDataGridView1[0, this.xyDataGridView1.Rows.Count - 1];
                    }
                    catch (Exception ex)
                    {
                        throw new Exception(ex.Message);
                    }
                }
            }
            catch (ObjectDisposedException)
            {
            }
        }
    }
}
