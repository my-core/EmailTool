namespace EmailTool
{
    partial class EmailTool
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_Set = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_ImportKeyword = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Start = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Stop = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_Exit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_About = new System.Windows.Forms.ToolStripButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_Keyword = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.xyDataGridView1 = new YK.Controls.XYDataGridView();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Url = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.openFileDialog_Import = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.radioButton_Google = new System.Windows.Forms.RadioButton();
            this.radioButton_Baidu = new System.Windows.Forms.RadioButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xyDataGridView1)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.BackColor = System.Drawing.Color.Transparent;
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_Set,
            this.toolStripButton_ImportKeyword,
            this.toolStripButton_Start,
            this.toolStripButton_Stop,
            this.toolStripButton_Exit,
            this.toolStripButton_About});
            this.toolStrip1.Location = new System.Drawing.Point(24, 38);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(444, 70);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_Set
            // 
            this.toolStripButton_Set.AutoSize = false;
            this.toolStripButton_Set.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripButton_Set.Image = global::EmailTool.Properties.Resources.ico_自定义属性设置;
            this.toolStripButton_Set.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Set.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.toolStripButton_Set.Name = "toolStripButton_Set";
            this.toolStripButton_Set.Size = new System.Drawing.Size(50, 70);
            this.toolStripButton_Set.Text = "设置";
            this.toolStripButton_Set.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolStripButton_Set.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.toolStripButton_Set.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Set.Click += new System.EventHandler(this.toolStrip_Click);
            // 
            // toolStripButton_ImportKeyword
            // 
            this.toolStripButton_ImportKeyword.AutoSize = false;
            this.toolStripButton_ImportKeyword.Image = global::EmailTool.Properties.Resources.ico_增加产品;
            this.toolStripButton_ImportKeyword.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_ImportKeyword.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_ImportKeyword.Name = "toolStripButton_ImportKeyword";
            this.toolStripButton_ImportKeyword.Size = new System.Drawing.Size(50, 70);
            this.toolStripButton_ImportKeyword.Text = "导入";
            this.toolStripButton_ImportKeyword.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_ImportKeyword.ToolTipText = "导入搜索关键诩";
            this.toolStripButton_ImportKeyword.Click += new System.EventHandler(this.toolStrip_Click);
            // 
            // toolStripButton_Start
            // 
            this.toolStripButton_Start.AutoSize = false;
            this.toolStripButton_Start.Image = global::EmailTool.Properties.Resources.ico_普通消费;
            this.toolStripButton_Start.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Start.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Start.Name = "toolStripButton_Start";
            this.toolStripButton_Start.Size = new System.Drawing.Size(50, 70);
            this.toolStripButton_Start.Text = "开始";
            this.toolStripButton_Start.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Start.Click += new System.EventHandler(this.toolStrip_Click);
            // 
            // toolStripButton_Stop
            // 
            this.toolStripButton_Stop.AutoSize = false;
            this.toolStripButton_Stop.Image = global::EmailTool.Properties.Resources.ico_增加会员;
            this.toolStripButton_Stop.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Stop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Stop.Name = "toolStripButton_Stop";
            this.toolStripButton_Stop.Size = new System.Drawing.Size(50, 70);
            this.toolStripButton_Stop.Text = "停止";
            this.toolStripButton_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Stop.Click += new System.EventHandler(this.toolStrip_Click);
            // 
            // toolStripButton_Exit
            // 
            this.toolStripButton_Exit.AutoSize = false;
            this.toolStripButton_Exit.Image = global::EmailTool.Properties.Resources.ico_会员退货;
            this.toolStripButton_Exit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_Exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_Exit.Name = "toolStripButton_Exit";
            this.toolStripButton_Exit.Size = new System.Drawing.Size(50, 70);
            this.toolStripButton_Exit.Text = "退出";
            this.toolStripButton_Exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_Exit.Click += new System.EventHandler(this.toolStrip_Click);
            // 
            // toolStripButton_About
            // 
            this.toolStripButton_About.AutoSize = false;
            this.toolStripButton_About.Image = global::EmailTool.Properties.Resources.ico_员工管理;
            this.toolStripButton_About.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_About.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_About.Name = "toolStripButton_About";
            this.toolStripButton_About.Size = new System.Drawing.Size(50, 70);
            this.toolStripButton_About.Text = "关于";
            this.toolStripButton_About.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton_About.Click += new System.EventHandler(this.toolStrip_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(11, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(520, 1);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.listBox_Keyword);
            this.groupBox1.Location = new System.Drawing.Point(17, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 195);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "搜索关键字";
            // 
            // listBox_Keyword
            // 
            this.listBox_Keyword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listBox_Keyword.FormattingEnabled = true;
            this.listBox_Keyword.ItemHeight = 12;
            this.listBox_Keyword.Location = new System.Drawing.Point(8, 20);
            this.listBox_Keyword.Name = "listBox_Keyword";
            this.listBox_Keyword.Size = new System.Drawing.Size(138, 170);
            this.listBox_Keyword.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.White;
            this.groupBox2.Controls.Add(this.xyDataGridView1);
            this.groupBox2.Location = new System.Drawing.Point(181, 158);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(352, 251);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "采集结果";
            // 
            // xyDataGridView1
            // 
            this.xyDataGridView1.AllowUserToAddRows = false;
            this.xyDataGridView1.AllowUserToDeleteRows = false;
            this.xyDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.xyDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Email,
            this.Url});
            this.xyDataGridView1.Location = new System.Drawing.Point(6, 20);
            this.xyDataGridView1.Name = "xyDataGridView1";
            this.xyDataGridView1.ReadOnly = true;
            this.xyDataGridView1.RowTemplate.Height = 23;
            this.xyDataGridView1.Size = new System.Drawing.Size(340, 225);
            this.xyDataGridView1.TabIndex = 0;
            // 
            // Email
            // 
            this.Email.DataPropertyName = "Email";
            this.Email.HeaderText = "邮箱地址";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            this.Email.Width = 150;
            // 
            // Url
            // 
            this.Url.DataPropertyName = "Url";
            this.Url.HeaderText = "采集地址";
            this.Url.Name = "Url";
            this.Url.ReadOnly = true;
            this.Url.Width = 140;
            // 
            // openFileDialog_Import
            // 
            this.openFileDialog_Import.FileName = "openFileDialog1";
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Transparent;
            this.groupBox3.Controls.Add(this.radioButton_Google);
            this.groupBox3.Controls.Add(this.radioButton_Baidu);
            this.groupBox3.Location = new System.Drawing.Point(25, 359);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(148, 50);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "搜索引擎";
            // 
            // radioButton_Google
            // 
            this.radioButton_Google.AutoSize = true;
            this.radioButton_Google.Location = new System.Drawing.Point(82, 21);
            this.radioButton_Google.Name = "radioButton_Google";
            this.radioButton_Google.Size = new System.Drawing.Size(47, 16);
            this.radioButton_Google.TabIndex = 0;
            this.radioButton_Google.Text = "谷歌";
            this.radioButton_Google.UseVisualStyleBackColor = true;
            // 
            // radioButton_Baidu
            // 
            this.radioButton_Baidu.AutoSize = true;
            this.radioButton_Baidu.Checked = true;
            this.radioButton_Baidu.Location = new System.Drawing.Point(11, 22);
            this.radioButton_Baidu.Name = "radioButton_Baidu";
            this.radioButton_Baidu.Size = new System.Drawing.Size(47, 16);
            this.radioButton_Baidu.TabIndex = 0;
            this.radioButton_Baidu.TabStop = true;
            this.radioButton_Baidu.Text = "百度";
            this.radioButton_Baidu.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Location = new System.Drawing.Point(17, 112);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(514, 40);
            this.groupBox4.TabIndex = 9;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "提示";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "导入关键词：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(91, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(135, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "搜索到邮箱数：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(228, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "0";
            // 
            // EmailTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(174)))), ((int)(((byte)(233)))));
            this.BacklightImg = global::EmailTool.Properties.Resources.all_inside_bkg;
            this.ClientSize = new System.Drawing.Size(547, 460);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FormSystemBtnSet = AlSkin.AlForm.AlBaseForm.FormSystemBtn.btn_miniAndbtn_close;
            this.IsResize = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EmailTool";
            this.Text = "云客邮箱采集软件--云客科技";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.toolStrip1, 0);
            this.Controls.SetChildIndex(this.pictureBox1, 0);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.Controls.SetChildIndex(this.groupBox2, 0);
            this.Controls.SetChildIndex(this.groupBox3, 0);
            this.Controls.SetChildIndex(this.groupBox4, 0);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xyDataGridView1)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_Set;
        private System.Windows.Forms.ToolStripButton toolStripButton_Start;
        private System.Windows.Forms.ToolStripButton toolStripButton_Stop;
        private System.Windows.Forms.ToolStripButton toolStripButton_Exit;
        private System.Windows.Forms.ToolStripButton toolStripButton_About;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_Keyword;
        private System.Windows.Forms.OpenFileDialog openFileDialog_Import;
        private System.Windows.Forms.ToolStripButton toolStripButton_ImportKeyword;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton radioButton_Google;
        private System.Windows.Forms.RadioButton radioButton_Baidu;
        private YK.Controls.XYDataGridView xyDataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn Url;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
    }
}

