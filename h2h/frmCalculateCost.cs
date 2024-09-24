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
    public partial class frmCalculateCost : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public frmCalculateCost()
        {
            InitializeComponent();
            cn.ConnectionString = conn.MyCon();
            LoadItem();
        }
        private void LoadItem()
        {
            cmbItem.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select ItemDesc from tbl_Items order by ItemDesc ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmbItem.Items.Add(dr[0].ToString());


            }
            cn.Close();
        }

        private void cmbItem_SelectedValueChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("select Id from tbl_Items where ItemDesc like '" + cmbItem.Text + "'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                lblID.Text = dr[0].ToString();
            }
            cn.Close();
        }

        private float calculate()
        {
            try
            {
                float TotalAccs = 0, TotalOpp = 0, Total = 0;
                cn.Open();
                cm = new SqlCommand("select Total from tbl_itemAccs where ItemID like '"+lblID.Text+"'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    TotalAccs = TotalAccs + float.Parse(dr[0].ToString());
                }
                dr.Close();
                cn.Close();

                cn.Open();
                cm = new SqlCommand("select price,itemID from tbl_Operations inner join tbl_ItemOpp on tbl_Operations.Id = tbl_ItemOpp.OppID where itemID like'" + lblID.Text + "'", cn);
                dr = cm.ExecuteReader();
                while (dr.Read())
                {
                    TotalOpp = TotalOpp + float.Parse(dr[0].ToString());
                }
                cn.Close();

                Total = TotalAccs + TotalOpp;
                return Total;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); return 0; }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            lblCost.Text = calculate().ToString();
        }
    }
}
