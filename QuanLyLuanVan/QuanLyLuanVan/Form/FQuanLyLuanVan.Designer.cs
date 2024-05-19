namespace QuanLyLuanVan
{
    partial class FQuanLyLuanVan
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
            this.btnThem = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoScroll = true;
            this.pn_Chua.Location = new System.Drawing.Point(6, 6);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(992, 596);
            this.pn_Chua.TabIndex = 38;
            // 
            // btnThem
            // 
            this.btnThem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThem.BorderRadius = 13;
            this.btnThem.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.btnThem.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.btnThem.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.btnThem.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(149)))), ((int)(((byte)(137)))));
            this.btnThem.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.Location = new System.Drawing.Point(20, 616);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(965, 37);
            this.btnThem.TabIndex = 41;
            this.btnThem.Text = "Thêm luận văn ";
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // FQuanLyLuanVan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1004, 669);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.pn_Chua);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FQuanLyLuanVan";
            this.Text = "FQuanLyLuanVan";
            this.Load += new System.EventHandler(this.FQuanLyLuanVan_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel pn_Chua;
        private Guna.UI2.WinForms.Guna2Button btnThem;
    }
}