using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace h2h
{
    public partial class frmItemDetail : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public frmItemDetail()
        {
            InitializeComponent();
            cn.ConnectionString = conn.MyCon();
            LoadItems();
        }
        private void LoadItems()
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
            cmbAccessory.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select Description from tbl_Accessory order by Description ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmbAccessory.Items.Add(dr[0].ToString());


            }
            cn.Close();
            cmbOperations.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select OppName from tbl_Operations order by OppName ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmbOperations.Items.Add(dr[0].ToString());


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
            LoadRecords();
            LoadOperations();
            cmbAccessory.Focus();
        }

        private void cmbAccessory_SelectedValueChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("select Id,Price from tbl_Accessory where Description like '" + cmbAccessory.Text + "'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                lblAccsID.Text = dr[0].ToString();
                lblPrice.Text = dr[1].ToString();
            }
            cn.Close();
            txtQty.Focus();
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                try
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_ItemAccs (ItemID, AccsID, Quantity)Values(@ItemID, @AccsID, @Quantity)", cn);
                    cm.Parameters.AddWithValue("@ItemID",lblID.Text);
                    cm.Parameters.AddWithValue("@AccsID",lblAccsID.Text);
                    //cm.Parameters.AddWithValue("@Price",lblPrice.Text);
                    cm.Parameters.AddWithValue("@Quantity",txtQty.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadRecords();
                    cmbAccessory.Focus();

                }
                catch (Exception ex) 
                {
                    MessageBox.Show(ex.Message);
                }
               
            }
        }
        private void LoadRecords()
        {
            dgvAccs.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select Description, Price, Quantity, Total, ItemID, tableid from tbl_Accessory inner join tbl_ItemAccs on tbl_Accessory.Id = tbl_ItemAccs.AccsID where ItemID like '"+lblID.Text+"'", cn);
            dr = cm.ExecuteReader();
            int i = 0;
            while (dr.Read()) 
            {
                i++;
                dgvAccs.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[5].ToString());
            }
            cn.Close();
        }

        private void cmbOperations_SelectedValueChanged(object sender, EventArgs e)
        {
            cn.Open();
            cm = new SqlCommand("select Id,Price from tbl_Operations where OppName like '" + cmbOperations.Text + "'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                lblOppID.Text = dr[0].ToString();
                lblOppPrice.Text = dr[1].ToString();
            }
            cn.Close();
            btnAdd.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                cn.Open();
                cm = new SqlCommand("insert into tbl_ItemOpp (ItemID, OppID)Values(@ItemID, @OppID)", cn);
                cm.Parameters.AddWithValue("@ItemID", lblID.Text);
                cm.Parameters.AddWithValue("@OppID", lblOppID.Text);
                cm.ExecuteNonQuery();
                cn.Close();
                LoadOperations();
                cmbOperations.Focus();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void LoadOperations()
        {
            dgvOpp.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select id1,OppName,Price,ItemID from tbl_Operations inner join tbl_ItemOpp on tbl_Operations.Id = tbl_ItemOpp.OppID where itemID like'"+lblID.Text+"'", cn);
            dr = cm.ExecuteReader();
            int i = 0;
            while (dr.Read())
            {
                i++;
                dgvOpp.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
            }
            cn.Close();
        }

        private void dgvAccs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvAccs.Columns[e.ColumnIndex].Name;
            if (colName == "Delete")
            {
                if (MessageBox.Show("Confirm Delete?", "h2h", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) 
                {
                    cn.Open();
                    cm = new SqlCommand("Delete from tbl_itemAccs where tableid like '" + dgvAccs.Rows[e.RowIndex].Cells[5].Value.ToString() +"'",cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadRecords();
                    MessageBox.Show("Deleted","h2h");
                }
                
            }
        }

        private void dgvOpp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvOpp.Columns[e.ColumnIndex].Name;
            if (colName == "DeleteOpp")
            {

                if (MessageBox.Show("Confirm Delete?", "h2h", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    cn.Open();
                    cm = new SqlCommand("Delete from tbl_itemOpp where id1 like '" + dgvOpp.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", cn);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    LoadOperations();
                    MessageBox.Show("Deleted", "h2h");
                }
            }
        }
    }
}
