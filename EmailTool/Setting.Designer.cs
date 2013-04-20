namespace EmailTool
{
    partial class Setting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setting));
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ThreadCount = new System.Windows.Forms.TextBox();
            this.Button_Setting = new AlSkin.AlControl.AlButton.AlButton();
            this.textBox_BaiduPage = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(29, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "线程最大数:";
            // 
            // textBox_ThreadCount
            // 
            this.textBox_ThreadCount.Location = new System.Drawing.Point(106, 51);
            this.textBox_ThreadCount.Name = "textBox_ThreadCount";
            this.textBox_ThreadCount.Size = new System.Drawing.Size(95, 21);
            this.textBox_ThreadCount.TabIndex = 5;
            // 
            // Button_Setting
            // 
            this.Button_Setting.BackColor = System.Drawing.Color.Transparent;
            this.Button_Setting.BackImg = ((System.Drawing.Bitmap)(resources.GetObject("Button_Setting.BackImg")));
            this.Button_Setting.BacklightLTRB = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.Button_Setting.Location = new System.Drawing.Point(72, 120);
            this.Button_Setting.Name = "Button_Setting";
            this.Button_Setting.Size = new System.Drawing.Size(75, 23);
            this.Button_Setting.TabIndex = 6;
            this.Button_Setting.Text = "设置";
            this.Button_Setting.UseVisualStyleBackColor = false;
            this.Button_Setting.Click += new System.EventHandler(this.Button_Setting_Click);
            // 
            // textBox_BaiduPage
            // 
            this.textBox_BaiduPage.Location = new System.Drawing.Point(106, 78);
            this.textBox_BaiduPage.Name = "textBox_BaiduPage";
            this.textBox_BaiduPage.Size = new System.Drawing.Size(95, 21);
            this.textBox_BaiduPage.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(18, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "百度最大页数:";
            // 
            // Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BacklightImg = global::EmailTool.Properties.Resources.all_inside_bkg;
            this.ClientSize = new System.Drawing.Size(227, 155);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_BaiduPage);
            this.Controls.Add(this.textBox_ThreadCount);
            this.Controls.Add(this.Button_Setting);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FormSystemBtnSet = AlSkin.AlForm.AlBaseForm.FormSystemBtn.btn_close;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Setting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.Setting_Load);
            this.Controls.SetChildIndex(this.Button_Setting, 0);
            this.Controls.SetChildIndex(this.textBox_ThreadCount, 0);
            this.Controls.SetChildIndex(this.textBox_BaiduPage, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ThreadCount;
        private AlSkin.AlControl.AlButton.AlButton Button_Setting;
        private System.Windows.Forms.TextBox textBox_BaiduPage;
        private System.Windows.Forms.Label label2;
    }
}