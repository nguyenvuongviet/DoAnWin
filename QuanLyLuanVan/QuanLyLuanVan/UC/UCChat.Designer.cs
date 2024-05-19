
namespace QuanLyLuanVan
{
    partial class UCChat
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ptbHienThiAnh = new System.Windows.Forms.PictureBox();
            this.guna2HtmlLabel3 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNoiDung = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblNguoigui = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ptbHienThiAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // ptbHienThiAnh
            // 
            this.ptbHienThiAnh.Location = new System.Drawing.Point(14, 37);
            this.ptbHienThiAnh.Margin = new System.Windows.Forms.Padding(2);
            this.ptbHienThiAnh.Name = "ptbHienThiAnh";
            this.ptbHienThiAnh.Size = new System.Drawing.Size(339, 163);
            this.ptbHienThiAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ptbHienThiAnh.TabIndex = 104;
            this.ptbHienThiAnh.TabStop = false;
            this.ptbHienThiAnh.Click += new System.EventHandler(this.ptbHienThiAnh_Click);
            // 
            // guna2HtmlLabel3
            // 
            this.guna2HtmlLabel3.AutoSize = false;
            this.guna2HtmlLabel3.BackColor = System.Drawing.Color.Silver;
            this.guna2HtmlLabel3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel3.Location = new System.Drawing.Point(13, 30);
            this.guna2HtmlLabel3.Name = "guna2HtmlLabel3";
            this.guna2HtmlLabel3.Size = new System.Drawing.Size(736, 1);
            this.guna2HtmlLabel3.TabIndex = 103;
            this.guna2HtmlLabel3.Text = "guna2HtmlLabel3";
            // 
            // lblNoiDung
            // 
            this.lblNoiDung.AutoSize = false;
            this.lblNoiDung.BackColor = System.Drawing.Color.Transparent;
            this.lblNoiDung.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblNoiDung.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.lblNoiDung.ForeColor = System.Drawing.Color.Black;
            this.lblNoiDung.Location = new System.Drawing.Point(14, 36);
            this.lblNoiDung.Name = "lblNoiDung";
            this.lblNoiDung.Size = new System.Drawing.Size(340, 164);
            this.lblNoiDung.TabIndex = 102;
            this.lblNoiDung.Text = "lblNoiDung";
            // 
            // lblNguoigui
            // 
            this.lblNguoigui.AutoSize = true;
            this.lblNguoigui.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNguoigui.Location = new System.Drawing.Point(10, 6);
            this.lblNguoigui.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNguoigui.Name = "lblNguoigui";
            this.lblNguoigui.Size = new System.Drawing.Size(111, 20);
            this.lblNguoigui.TabIndex = 101;
            this.lblNguoigui.Text = "Tên Người Gửi";
            // 
            // UCChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblNoiDung);
            this.Controls.Add(this.ptbHienThiAnh);
            this.Controls.Add(this.guna2HtmlLabel3);
            this.Controls.Add(this.lblNguoigui);
            this.Name = "UCChat";
            this.Size = new System.Drawing.Size(368, 219);
            ((System.ComponentModel.ISupportInitialize)(this.ptbHienThiAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox ptbHienThiAnh;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel3;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblNoiDung;
        private System.Windows.Forms.Label lblNguoigui;
    }
}
