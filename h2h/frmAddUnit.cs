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
    public partial class frmAddUnit : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        frmAccessory frm;
        public frmAddUnit(frmAccessory frm)
        {
            InitializeComponent();
            cn.ConnectionString = conn.ConH2H();
            this.frm = frm;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Save!", "h2h", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_Units(Unit)Values(@Unit)", cn);
                    cm.Parameters.AddWithValue("@Unit", txtUnit.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Saved");
                    txtUnit.Clear();
                    txtUnit.Focus();
                    frm.LoadUnits();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }
    }
}
