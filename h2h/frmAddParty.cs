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
    public partial class frmAddParty : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int TypeID = 0;
        public frmAddParty()
        {
            InitializeComponent();
            cn.ConnectionString = conn.ConH2H();
            LoadPartyTypes();
        }

        private void btnAddType_Click(object sender, EventArgs e)
        {
            frmAddPartyType frmAddPartyType = new frmAddPartyType(this);
            frmAddPartyType.ShowDialog();
        }

        public void LoadPartyTypes()
        {
            cmbType.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tbl_PartyTypes order by PartyType ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmbType.Items.Add(dr[1].ToString());
            }
            cn.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into tbl_Parties(PartyName,Type,PartyAdress,PartyContactNO) Values(@PartyName,@Type,@PartyAdress,@PartyContactNO)", cn);
                cm.Parameters.AddWithValue("@PartyName",txtName.Text);
                cm.Parameters.AddWithValue("@Type",TypeID);
                cm.Parameters.AddWithValue("@PartyAdress",txtAddress.Text);
                cm.Parameters.AddWithValue("@PartyContactNO",txtContactNo.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("saved");
                txtName.Clear();
                txtContactNo.Clear();
                txtAddress.Clear();
                txtName.Focus();
                   
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("select PartyTypeID from tbl_PartyTypes where PartyType like'"+cmbType.Text+"'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            TypeID = int.Parse(dr[0].ToString());

            cn.Close();
        }
    }
}
