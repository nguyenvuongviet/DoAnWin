namespace QuanLyLuanVan
{
    partial class FQuanLyTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FQuanLyTask));
            this.pn_Chua = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTaoTask = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoScroll = true;
            this.pn_Chua.Location = new System.Drawing.Point(6, 6);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(986, 593);
            this.pn_Chua.TabIndex = 39;
            // 
            // btnTaoTask
            // 
            this.btnTaoTask.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTaoTask.BorderRadius = 13;
            this.btnTaoTask.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoTask.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnTaoTask.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnTaoTask.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnTaoTask.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnTaoTask.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.btnTaoTask.ForeColor = System.Drawing.Color.White;
            this.btnTaoTask.Location = new System.Drawing.Point(20, 613);
            this.btnTaoTask.Name = "btnTaoTask";
            this.btnTaoTask.Size = new System.Drawing.Size(958, 37);
            this.btnTaoTask.TabIndex = 40;
            this.btnTaoTask.Text = "Tạo Task";
            this.btnTaoTask.Click += new System.EventHandler(this.btnTaoTask_Click);
            // 
            // FQuanLyTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 669);
            this.Controls.Add(this.btnTaoTask);
            this.Controls.Add(this.pn_Chua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FQuanLyTask";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FQuanLyTask_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pn_Chua;
        private Guna.UI2.WinForms.Guna2Button btnTaoTask;
    }
}