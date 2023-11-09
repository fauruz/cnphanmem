using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using vidu2.Models;

namespace vidu2
{
    internal class ConnectEmployee
    {
        public void getData(List<Employees> lEmp)
        {
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "select emp.*,dp.DpName from Employee emp,Department dp where emp.DpId = dp.DpId";
                da.SelectCommand.Connection = con;
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Employees emp = new Employees();
                    emp.Id = Convert.ToInt32(row["EmpId"].ToString());
                    emp.Name = row["EmpName"].ToString();
                    emp.Gender = Convert.ToInt32(row["Gender"]);
                    emp.DepartmentId = Convert.ToInt32(row["DpId"]);
                    lEmp.Add(emp);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public Employees getDataDetail(int maloai)
        {
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            string sql = "select emp.*,dp.DpName from Employee emp,Department dp where emp.DpId = dp.DpId and emp.EmpId = "+ maloai;
            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            con.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            Employees emp = new Employees();
            while (rdr.Read())
            {
                emp.Id = maloai;
                emp.Name = rdr.GetValue(1).ToString();
                emp.Gender = Convert.ToInt32(rdr.GetValue(2).ToString());
                emp.DepartmentId = Convert.ToInt32(rdr.GetValue(3).ToString());
            }
            con.Close();
            return (emp);
        }
        public DataTable getTable()
        {
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                string sql = "select emp.*,dp.DpName from Employee emp inner join Department dp on emp.DpId = dp.DpId"; 
                da = new SqlDataAdapter(sql, con);
                da.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return dt;
        }
        public void addData(Employees emp)
        {
            int kt = 0;
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            if(emp.Id != 0)
            {
                string sql = "select count(*) from Employee where EmpId = '" + emp.Id + "';";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                kt = (int)cmd.ExecuteScalar();
                if (kt == 0)
                {
                    string sql2 = "insert into dbo.Employee values('" + emp.Id + "',N'" + emp.Name + "','" + emp.Gender + "','" + emp.DepartmentId + "')";
                    SqlCommand cmd2 = new SqlCommand(sql2, con);
                    cmd2.ExecuteNonQuery();
                }
            }
            else
            {
                string sql2 = "insert into dbo.Employee values(N'" + emp.Name + "','" + emp.Gender + "','" + emp.DepartmentId + "')";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.CommandType = CommandType.Text;
                cmd2.ExecuteNonQuery();
            }
            con.Close();
        }
        public string getRow()
        {
            string b = "";
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "select EmpName from Employee";
                da.SelectCommand.Connection = con;
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    b += row["EmpName"].ToString();
                    b += "\n";
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return b;
        }
    }
}
