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
    public partial class ItAnh : Form
    {
        public ItAnh(Image image)
        {
            InitializeComponent();
            guna2PictureBox1.Image = image;
        }
    
    }
}
