namespace QuanLyLuanVan
{
    partial class FDangKyLuanVan
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
            this.pn_Chua = new System.Windows.Forms.FlowLayoutPanel();
            this.btnDeXuat = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoScroll = true;
            this.pn_Chua.Location = new System.Drawing.Point(6, 6);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(992, 597);
            this.pn_Chua.TabIndex = 37;
            // 
            // btnDeXuat
            // 
            this.btnDeXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeXuat.BorderRadius = 13;
            this.btnDeXuat.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnDeXuat.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnDeXuat.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnDeXuat.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnDeXuat.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnDeXuat.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.btnDeXuat.ForeColor = System.Drawing.Color.White;
            this.btnDeXuat.Location = new System.Drawing.Point(20, 615);
            this.btnDeXuat.Name = "btnDeXuat";
            this.btnDeXuat.Size = new System.Drawing.Size(965, 37);
            this.btnDeXuat.TabIndex = 38;
            this.btnDeXuat.Text = "Đề xuất";
            this.btnDeXuat.Click += new System.EventHandler(this.btnDeXuat_Click);
            // 
            // FDangKyLuanVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 669);
            this.Controls.Add(this.btnDeXuat);
            this.Controls.Add(this.pn_Chua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FDangKyLuanVan";
            this.Text = "FDangKyLuanVan";
            this.Load += new System.EventHandler(this.FDangKyLuanVan_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pn_Chua;
        private Guna.UI2.WinForms.Guna2Button btnDeXuat;
    }
}