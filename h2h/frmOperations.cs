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
    public partial class frmOperations : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
    
        public frmOperations()
        {
            InitializeComponent();
            cn.ConnectionString = conn.MyCon();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm Save!", "h2h", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                cn.Open();
                cm = new SqlCommand("insert into tbl_Operations(OppName, Price)Values(@OppName, @Price)",cn);
                cm.Parameters.AddWithValue("@OppName",txtOppName.Text);
                cm.Parameters.AddWithValue("@Price", txtOppPrice.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("saved");
                txtOppPrice.Clear();
                txtOppName.Clear();
                txtOppName.Focus();

            }
                
        }
    }
}
