using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace h2h
{
    public partial class frmAddSchool : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        public frmAddSchool()
        {
            InitializeComponent();
            cn.ConnectionString = conn.MyCon();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Save?", "h2h", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_Schools(SchoolName)Values(@SchoolName)", cn);
                    cm.Parameters.AddWithValue("@SchoolName", txtSchoolName.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("saved!");
                    txtSchoolName.Clear();
                    txtSchoolName.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
