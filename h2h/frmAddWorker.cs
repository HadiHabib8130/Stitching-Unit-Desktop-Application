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
    public partial class frmAddWorker : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        public frmAddWorker()
        {
            InitializeComponent();
            cn.ConnectionString = conn.MyCon();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Confirm Save?","h2h",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_Workers(WorkerName)Values(@WorkerName)",cn);
                    cm.Parameters.AddWithValue("@WorkerName",txtWorkerName.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("saved!");
                    txtWorkerName.Clear();
                    txtWorkerName.Focus();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
