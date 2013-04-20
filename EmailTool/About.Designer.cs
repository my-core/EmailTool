namespace EmailTool
{
    partial class About
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
            this.alControl1 = new AlSkin.ALControl();
            this.SuspendLayout();
            // 
            // alControl1
            // 
            this.alControl1.BackColor = System.Drawing.Color.Transparent;
            this.alControl1.Location = new System.Drawing.Point(12, 47);
            this.alControl1.Name = "alControl1";
            this.alControl1.Size = new System.Drawing.Size(213, 81);
            this.alControl1.TabIndex = 4;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BacklightImg = global::EmailTool.Properties.Resources.all_inside_bkg;
            this.ClientSize = new System.Drawing.Size(234, 169);
            this.Controls.Add(this.alControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.FormSystemBtnSet = AlSkin.AlForm.AlBaseForm.FormSystemBtn.btn_close;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Setting";
            this.Load += new System.EventHandler(this.About_Load);
            this.Controls.SetChildIndex(this.alControl1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private AlSkin.ALControl alControl1;

    }
}