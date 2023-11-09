using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace vidu2
{
    public partial class TTNV : Form
    {
        public TTNV()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtId.Text == "")
            //{
            //    MessageBox.Show("Vui lòng nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    txtId.Focus();
            //}
            //else
            //{
            //    bool b = true;
            //    ConnectEmployee obj = new ConnectEmployee();
            //    int i = Convert.ToInt32(txtId.Text);
            //    Employees emp = obj.getDataDetail(i);
            //    txtName.Text = emp.Name;
            //    cbGender.SelectedIndex = emp.Gender;
            //    cbbDepartment.SelectedIndex = emp.DepartmentId;
            //    if (!b)
            //    {
            //        MessageBox.Show("Không tìm thấy mã nhân viên!");
            //    }
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {

        }
    }
}
