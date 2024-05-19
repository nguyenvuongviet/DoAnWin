
namespace QuanLyLuanVan
{
    partial class ItChat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItChat));
            this.txtNoiDung = new Guna.UI2.WinForms.Guna2TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblnhom = new System.Windows.Forms.Label();
            this.lbltask = new System.Windows.Forms.Label();
            this.pn_Chua = new System.Windows.Forms.FlowLayoutPanel();
            this.btnGui = new Guna.UI2.WinForms.Guna2PictureBox();
            this.btnThemAnh = new Guna.UI2.WinForms.Guna2PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.btnGui)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThemAnh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtNoiDung
            // 
            this.txtNoiDung.AutoRoundedCorners = true;
            this.txtNoiDung.BorderRadius = 17;
            this.txtNoiDung.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNoiDung.DefaultText = "";
            this.txtNoiDung.DisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(208)))), ((int)(((byte)(208)))));
            this.txtNoiDung.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.txtNoiDung.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.DisabledState.PlaceholderForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(138)))), ((int)(((byte)(138)))), ((int)(((byte)(138)))));
            this.txtNoiDung.FocusedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.txtNoiDung.ForeColor = System.Drawing.Color.Black;
            this.txtNoiDung.HoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(94)))), ((int)(((byte)(148)))), ((int)(((byte)(255)))));
            this.txtNoiDung.Location = new System.Drawing.Point(5, 432);
            this.txtNoiDung.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtNoiDung.Name = "txtNoiDung";
            this.txtNoiDung.PasswordChar = '\0';
            this.txtNoiDung.PlaceholderText = "Nhập tin nhắn";
            this.txtNoiDung.SelectedText = "";
            this.txtNoiDung.Size = new System.Drawing.Size(462, 37);
            this.txtNoiDung.TabIndex = 110;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Black", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(2, 5);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 28);
            this.label3.TabIndex = 109;
            this.label3.Text = "Khung Chat";
            // 
            // lblnhom
            // 
            this.lblnhom.AutoSize = true;
            this.lblnhom.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblnhom.Location = new System.Drawing.Point(510, 43);
            this.lblnhom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblnhom.Name = "lblnhom";
            this.lblnhom.Size = new System.Drawing.Size(25, 21);
            this.lblnhom.TabIndex = 108;
            this.lblnhom.Text = "01";
            // 
            // lbltask
            // 
            this.lbltask.AutoSize = true;
            this.lbltask.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltask.Location = new System.Drawing.Point(16, 43);
            this.lbltask.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbltask.Name = "lbltask";
            this.lbltask.Size = new System.Drawing.Size(40, 21);
            this.lbltask.TabIndex = 107;
            this.lbltask.Text = "Task";
            // 
            // pn_Chua
            // 
            this.pn_Chua.AutoScroll = true;
            this.pn_Chua.Location = new System.Drawing.Point(7, 71);
            this.pn_Chua.Name = "pn_Chua";
            this.pn_Chua.Size = new System.Drawing.Size(550, 351);
            this.pn_Chua.TabIndex = 114;
            // 
            // btnGui
            // 
            this.btnGui.Image = global::QuanLyLuanVan.Properties.Resources.sent;
            this.btnGui.ImageRotate = 0F;
            this.btnGui.Location = new System.Drawing.Point(514, 432);
            this.btnGui.Name = "btnGui";
            this.btnGui.Size = new System.Drawing.Size(33, 37);
            this.btnGui.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGui.TabIndex = 116;
            this.btnGui.TabStop = false;
            this.btnGui.Click += new System.EventHandler(this.btnGui_Click);
            // 
            // btnThemAnh
            // 
            this.btnThemAnh.Image = global::QuanLyLuanVan.Properties.Resources.image;
            this.btnThemAnh.ImageRotate = 0F;
            this.btnThemAnh.Location = new System.Drawing.Point(472, 432);
            this.btnThemAnh.Name = "btnThemAnh";
            this.btnThemAnh.Size = new System.Drawing.Size(36, 37);
            this.btnThemAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnThemAnh.TabIndex = 0;
            this.btnThemAnh.TabStop = false;
            this.btnThemAnh.Click += new System.EventHandler(this.btnThemAnh_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.label1.Location = new System.Drawing.Point(451, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 21);
            this.label1.TabIndex = 117;
            this.label1.Text = "Nhóm:";
            // 
            // ItChat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(569, 478);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnThemAnh);
            this.Controls.Add(this.btnGui);
            this.Controls.Add(this.pn_Chua);
            this.Controls.Add(this.txtNoiDung);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblnhom);
            this.Controls.Add(this.lbltask);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ItChat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormChat_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnGui)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnThemAnh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Guna.UI2.WinForms.Guna2TextBox txtNoiDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblnhom;
        private System.Windows.Forms.Label lbltask;
        private System.Windows.Forms.FlowLayoutPanel pn_Chua;
        private Guna.UI2.WinForms.Guna2PictureBox btnGui;
        private Guna.UI2.WinForms.Guna2PictureBox btnThemAnh;
        private System.Windows.Forms.Label label1;
    }
}