using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vidu2
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnChamCong_Click(object sender, EventArgs e)
        {
            ChamCong cc = new ChamCong();
            cc.Show();
        }

        private void btnTinhLuong_Click(object sender, EventArgs e)
        {
            TinhLuong tl = new TinhLuong();
            tl.Show();
        }

        private void btnDanhGia_Click(object sender, EventArgs e)
        {
            DanhGia dg = new DanhGia();
            dg.Show();
        }

        private void btnTTNV_Click(object sender, EventArgs e)
        {
            TTNV ttnv = new TTNV();
            ttnv.Show();
        }
    }
}
