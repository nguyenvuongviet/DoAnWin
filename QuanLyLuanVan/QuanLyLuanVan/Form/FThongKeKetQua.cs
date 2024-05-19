using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyLuanVan
{
    public partial class FThongKeKetQua : Form
    {
        readonly TaiKhoan taiKhoan = Const.TaiKhoan;
        readonly GiangVienDao gvDao = new GiangVienDao();

        public FThongKeKetQua()
        {
            InitializeComponent();
        }

        private void FThongKeKetQua_Load(object sender, EventArgs e)
        {
            GiangVien gv = gvDao.ThongTin(taiKhoan.ID);

            lblDaDuyet.Text = gvDao.DemLuanVan(gv.HoTen, "2").ToString();
            lblChuaDuyet.Text = gvDao.DemLuanVan(gv.HoTen, "0").ToString();
            lblChoDuyet.Text = gvDao.DemLuanVan(gv.HoTen, "1").ToString();
            lblTong.Text = gvDao.DemLuanVan(gv.HoTen, null).ToString();

            DiemNhom(gv.HoTen);
            SoLuongDiem(gv.HoTen);
        }

        void DiemNhom(string tenGV)
        {
            DataTable dataTable = gvDao.TKDiemNhom(tenGV);

            chart1.ChartAreas["ChartArea1"].AxisX.Title = "Nhóm";
            chart1.ChartAreas["ChartArea1"].AxisY.Title = "Số Điểm";
            chart1.ChartAreas["ChartArea1"].AxisX.Interval = 1;
            chart1.ChartAreas["ChartArea1"].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Red;
            chart1.ChartAreas[0].AxisY.Maximum = 10;
            chart1.Series["Điểm"]["DrawingStyle"] = "Cylinder";
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.LineWidth = 0;
            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Diem"] != DBNull.Value && !string.IsNullOrEmpty(row["Diem"].ToString()))
                {
                    chart1.Series["Điểm"].Points.AddXY(row["Nhom"], row["Diem"]);
                }
            }
        }

        void SoLuongDiem (string tenGV)
        {
            DataTable bang = gvDao.TKSoLuongDiem(tenGV);

            chart2.ChartAreas["ChartArea2"].AxisX.Title = "Số Điểm";
            chart2.ChartAreas["ChartArea2"].AxisY.Title = "Số Lượng";
            chart2.ChartAreas["ChartArea2"].AxisY.Interval = 1;
            chart2.ChartAreas["ChartArea2"].AxisX.LabelStyle.ForeColor = System.Drawing.Color.Red;
            chart2.Series["Số Lượng"]["DrawingStyle"] = "Cylinder";
            chart2.ChartAreas["ChartArea2"].AxisX.MajorGrid.LineWidth = 0;
            foreach (DataRow row in bang.Rows)
            {
                if (row["Diem"] != DBNull.Value && !string.IsNullOrEmpty(row["Diem"].ToString()))
                {
                    chart2.Series["Số Lượng"].Points.AddXY(row["Diem"], row["Count"]);
                }
            }
        }

        private void rbBieuDoDuong_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Điểm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart2.Series["Số Lượng"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
        }

        private void rbBieuDoCot_CheckedChanged(object sender, EventArgs e)
        {
            chart1.Series["Điểm"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            chart2.Series["Số Lượng"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }
    }
}
