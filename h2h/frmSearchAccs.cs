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
    public partial class frmSearchAccs : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int CategoryID;
        frmPurchaseInvoice frmPurchaseInvoice;
        public frmSearchAccs(frmPurchaseInvoice frm)
        {
            InitializeComponent();
            cn.ConnectionString = conn.ConH2H();
            LoadTypes();
            LoadAccs();
            frmPurchaseInvoice = frm;
        }

       
        public void LoadTypes()
        {
            cmbType.Items.Clear();
            cn.Open();
            cm = new SqlCommand("Select AccessoryCategory from tbl_Categories", cn);
            dr = cm.ExecuteReader();
            while (dr.Read()) 
            {
                cmbType.Items.Add(dr[0].ToString());
            }
            cn.Close();
        }
        public void LoadAccs()
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("Select AccsId,AccsName,AccsPrice,AccsStock from tbl_Accessory Order by AccsName ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            cn.Close();
        }

        private void cmbType_SelectedValueChanged(object sender, EventArgs e)
        {
            
            cn.Open();
            cm = new SqlCommand("select CategoryId from tbl_Categories where AccessoryCategory like '"+cmbType.Text+"'", cn);
            dr = cm.ExecuteReader();
            dr.Read();
            CategoryID = int.Parse(dr[0].ToString());
            cn.Close();
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select AccsId,AccsName,AccsPrice,AccsStock from tbl_Accessory Where AccsCategory like'"+CategoryID+ "' Order by AccsName ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            cn.Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select AccsId,AccsName,AccsPrice,AccsStock from tbl_Accessory Where AccsCategory like'" + CategoryID + "' and AccsName like '%"+txtSearch.Text+"%' Order by AccsName ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString());
            }
            cn.Close();
        }

       

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                frmPurchaseInvoice.txtAccsID.Text = dataGridView1.SelectedCells[0].Value.ToString();
                this.Dispose();
            }

            if (e.KeyCode == Keys.Down)
            {
                

                dataGridView1.Focus();
                dataGridView1.Rows[1].Selected = true;
                dataGridView1.CurrentCell = dataGridView1.Rows[1].Cells[0];
                
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                frmPurchaseInvoice.txtAccsID.Text = dataGridView1.SelectedCells[0].Value.ToString();
                this.Dispose();
            }
        }
    }
}
