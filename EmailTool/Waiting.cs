using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EmailTool
{
    public partial class Waiting : Form
    {
        public Waiting()
        {
            InitializeComponent();
        }
        public string msg = "正在进行预处理，请稍后";
        int index = 0;
        private void Waiting_Load(object sender, EventArgs e)
        {
            this.timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string temp = "";
            if (index < 6)
                index++;
            else
                index = 0;
            for (int i = 0; i < index; i++)
            {
                temp += ".";
            }
            this.label1.Text = msg + temp;
        }

        private void Waiting_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.label1.Text = "";
            this.timer1.Stop();
            this.timer1.Dispose();
        }
    }
}
