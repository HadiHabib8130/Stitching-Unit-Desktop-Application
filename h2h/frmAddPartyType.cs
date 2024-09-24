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
    public partial class frmAddPartyType : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        frmAddParty frmAddParty;
        public frmAddPartyType(frmAddParty frmAddParty)
        {
            InitializeComponent();
            cn.ConnectionString = conn.ConH2H();
            this.frmAddParty = frmAddParty;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into tbl_PartyTypes(PartyType) Values(@PartyType)", cn);
                cm.Parameters.AddWithValue("@PartyType",txtNewType.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Saved!");
                frmAddParty.LoadPartyTypes();
                this.Dispose();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
