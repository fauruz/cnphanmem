using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vidu2.Models;

namespace vidu2
{
    public partial class ChamCong : Form
    {
        List<Employees> cclst;
        List<Department> ccldp;

        public ChamCong()
        {
            cclst = new List<Employees>();
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public bool Require()
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Vui lòng điền họ và tên nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Focus();
                return false;
            }
            if (cbGender.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn giới tính của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbGender.Focus();
                return false;
            }
            if (cbbDepartment.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn phòng ban của nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbbDepartment.Focus();
                return false;
            }
            return true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(Require())
            {
                ConnectEmployee obj = new ConnectEmployee();
                Employees emp = new Employees();
                emp.Name = txtName.Text;
                if(txtId.Text != string.Empty)
                    emp.Id = Convert.ToInt32(txtId.Text);
                emp.Gender = cbGender.SelectedIndex;
                emp.DepartmentId = cbbDepartment.SelectedIndex;
                obj.addData(emp);
                lblNotice.ForeColor = Color.ForestGreen;
                lblNotice.Text = "Thêm thành công!";
                btnRefresh_Click(sender, e);
            }
        }
        private void Department()
        {
            ConnectDepartment obj = new ConnectDepartment();
            ccldp = obj.getData();
            foreach(var item in ccldp)
            {
                cbbDepartment.Items.Add(item.Name);
            }
        }

        private void ChamCong_Load(object sender, EventArgs e)
        {
            Department();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtId.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtId.Focus();
            }
            else
            {
                bool b = true;
                ConnectEmployee obj = new ConnectEmployee();
                int i = Convert.ToInt32(txtId.Text);
                Employees emp = obj.getDataDetail(i);
                txtName.Text = emp.Name;
                cbGender.SelectedIndex = emp.Gender;
                cbbDepartment.SelectedIndex = emp.DepartmentId;
                if (!b)
                {
                    MessageBox.Show("Không tìm thấy mã nhân viên!");
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtPad.Text = string.Empty;
            txtNpad.Text = string.Empty;
            txtLd.Text = string.Empty;
            txtName.Text = string.Empty;
            cbbDepartment.SelectedIndex = -1;
            cbGender.SelectedIndex = -1 ;
            txtId.Text = string.Empty;
            txtWd.Text = null;
            dataGridView1.DataSource = null;
            dataGridView1.Refresh();
        }

        private void txtAuto_TextChanged(object sender, EventArgs e)
        {
            //bool b = false;
            //    foreach(Employees cc in cclst)
            //    {
            //        if (Convert.ToInt32(txtAuto.Text) == cc.Id)
            //        {
            //            txtId.Text = txtAuto.Text;
            //            txtName.Text = cc.Name;
            //            txtDp.Text = cc.Department;
            //            cbGender.SelectedIndex = cc.Gender;
            //            txtWd.Text = cc.WorkDay.ToString();
            //            txtPad.Text = cc.PAbsentDay.ToString();
            //            txtNpad.Text = cc.NPAbsentDay.ToString();
            //            txtLd.Text = cc.LateDay.ToString();
            //            b = true;
            //        }
            //    }
            //    if (!b)
            //    {
            //        MessageBox.Show("Không tìm thấy mã nhân viên!");
            //    }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }
        
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (Require())
            //{
            //    using (SqlConnection conn = new SqlConnection(ConnectionString.connectionString))
            //    {
            //        conn.Open();
            //        string query = "Select count(*) from NhanVien where Id = '" + txtId.Text + "' ";
            //        SqlCommand cmd = new SqlCommand(query, conn);
            //        int kt = (int)cmd.ExecuteScalar();
            //        if (kt == 0)
            //        {
            //            string Strcmd = "insert into NhanVien values('" + txtId.Text + "','" + txtName.Text + "','" + txtDp.Text + "','" + txtEmail.Text + "','" + txtPhone.Text + "')";
            //            cmd.CommandText = Strcmd;
            //            int rs = cmd.ExecuteNonQuery();
            //            if (rs == 1)
            //            {
            //                lblAdd.Text = "Thêm Thành công!";
            //            }
            //        }
            //        else
            //            lblAdd.Text = "Trùng mã nhân viên!";
            //        conn.Close();
            //    }
            //    getData();
            //}

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ConnectEmployee obj = new ConnectEmployee();
            dataGridView1.DataSource = obj.getTable();
            lblShowData.Text = obj.getRow();
        }

        private void btnPaying_Click(object sender, EventArgs e)
        {
            TinhLuong tl = new TinhLuong();
            tl.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
