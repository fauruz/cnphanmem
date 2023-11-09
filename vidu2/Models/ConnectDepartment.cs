using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using vidu2.Models;

namespace vidu2
{
    internal class ConnectDepartment
    {
        public List<Department> getData()
        {
            List<Department> ldp = new List<Department>();
            string constr = ConfigurationManager.ConnectionStrings["conStr"].ConnectionString;
            SqlConnection con = new SqlConnection(constr);
            SqlDataAdapter da = new SqlDataAdapter();
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                da.SelectCommand = new SqlCommand();
                da.SelectCommand.CommandText = "select * from Department";
                da.SelectCommand.Connection = con;
                da.Fill(dt);
                foreach (DataRow row in dt.Rows)
                {
                    Department dp = new Department();
                    dp.Id = Convert.ToInt32(row["DpId"].ToString());
                    dp.Name = row["DpName"].ToString();
                    ldp.Add(dp);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ldp;
        }
    }
}
