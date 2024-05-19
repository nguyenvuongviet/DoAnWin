using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanVan
{
    public class Mess
    {
        string tieudetask;
        string nguoigui;
        string nhom;
        string thoigiangui;
        string noidung;
        Image anh;
        string trangthai;

        public Mess(string tieudetask, string nguoigui, string nhom, string thoigiangui, string noidung, Image anh, string trangthai)
        {
            this.tieudetask = tieudetask;
            this.nguoigui = nguoigui;
            this.nhom = nhom;
            this.thoigiangui = thoigiangui;
            this.noidung = noidung;
            this.anh = anh;
            this.trangthai = trangthai;
        }

        public string Tieudetask { get => tieudetask; set => tieudetask = value; }
        public string Nguoigui { get => nguoigui; set => nguoigui = value; }
        public string Nhom { get => nhom; set => nhom = value; }
        public string Thoigiangui { get => thoigiangui; set => thoigiangui = value; }
        public string Noidung { get => noidung; set => noidung = value; }
        public Image Anh { get => anh; set => anh = value; }
        public string Trangthai { get => trangthai; set => trangthai = value; }
    }
}
