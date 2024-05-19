
namespace QuanLyLuanVan
{
    partial class UCThanhVien
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
            this.btnThem = new Guna.UI2.WinForms.Guna2PictureBox();
            this.lblHoTen = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.lblID = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnXoaThanhVien = new Guna.UI2.WinForms.Guna2PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.btnThem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaThanhVien)).BeginInit();
            this.SuspendLayout();
            // 
            // btnThem
            // 
            this.btnThem.Image = global::QuanLyLuanVan.Properties.Resources.add1;
            this.btnThem.ImageRotate = 0F;
            this.btnThem.Location = new System.Drawing.Point(261, 22);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(30, 30);
            this.btnThem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnThem.TabIndex = 113;
            this.btnThem.TabStop = false;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // lblHoTen
            // 
            this.lblHoTen.BackColor = System.Drawing.Color.Transparent;
            this.lblHoTen.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.ForeColor = System.Drawing.Color.Black;
            this.lblHoTen.Location = new System.Drawing.Point(86, 35);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(129, 23);
            this.lblHoTen.TabIndex = 112;
            this.lblHoTen.Text = "Nguyễn Văn Nam";
            // 
            // lblID
            // 
            this.lblID.BackColor = System.Drawing.Color.Transparent;
            this.lblID.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblID.ForeColor = System.Drawing.Color.Black;
            this.lblID.Location = new System.Drawing.Point(86, 7);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(19, 23);
            this.lblID.TabIndex = 111;
            this.lblID.Text = "ID";
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Image = global::QuanLyLuanVan.Properties.Resources.account;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(6, 3);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(60, 60);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.guna2PictureBox1.TabIndex = 110;
            this.guna2PictureBox1.TabStop = false;
            // 
            // btnXoaThanhVien
            // 
            this.btnXoaThanhVien.Image = global::QuanLyLuanVan.Properties.Resources.delete;
            this.btnXoaThanhVien.ImageRotate = 0F;
            this.btnXoaThanhVien.Location = new System.Drawing.Point(261, 22);
            this.btnXoaThanhVien.Name = "btnXoaThanhVien";
            this.btnXoaThanhVien.Size = new System.Drawing.Size(30, 30);
            this.btnXoaThanhVien.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnXoaThanhVien.TabIndex = 114;
            this.btnXoaThanhVien.TabStop = false;
            this.btnXoaThanhVien.Click += new System.EventHandler(this.btnXoaThanhVien_Click);
            // 
            // UCThanhVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.Controls.Add(this.btnXoaThanhVien);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.guna2PictureBox1);
            this.Name = "UCThanhVien";
            this.Size = new System.Drawing.Size(296, 66);
            ((System.ComponentModel.ISupportInitialize)(this.btnThem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnXoaThanhVien)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2HtmlLabel lblHoTen;
        private Guna.UI2.WinForms.Guna2HtmlLabel lblID;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
        public Guna.UI2.WinForms.Guna2PictureBox btnXoaThanhVien;
        public Guna.UI2.WinForms.Guna2PictureBox btnThem;
    }
}
