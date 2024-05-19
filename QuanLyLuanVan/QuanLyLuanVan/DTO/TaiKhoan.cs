using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLuanVan
{
    public class TaiKhoan
    {
        private string iD;
        private string chucVu;
        private string matKhau;

        public string ID { get => iD; set => iD = value; }
        public string ChucVu { get => chucVu; set => chucVu = value; }
        public string MatKhau { get => matKhau; set => matKhau = value; }
        public TaiKhoan(string iD, string chucVu, string matKhau)
        {
            this.iD = iD;
            this.chucVu = chucVu;
            this.matKhau = matKhau;
        }
    }
}
