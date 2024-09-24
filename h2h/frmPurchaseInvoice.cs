using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace h2h
{
    public partial class frmPurchaseInvoice : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int GrandTotal = 0;
        public frmPurchaseInvoice()
        {
            InitializeComponent();
            cn.ConnectionString = conn.ConH2H();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            cmbSupplier.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select PartyName from tbl_parties where Type like '1'", cn);
            dr = cm.ExecuteReader();
            while(dr.Read())
            {
                cmbSupplier.Items.Add(dr[0].ToString()); 
            }
            cn.Close();
        }

        private void txtAccsID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                if(txtAccsID.Text == string.Empty)
                {
                    frmSearchAccs frmSearchAccs = new frmSearchAccs(this);
                    frmSearchAccs.ShowDialog();
                }
                else
                {
                    txtAccessory.Clear();
                    txtPrice.Clear();
                    txtQty.Clear();
                    txtStock.Clear();
                    txtUnit.Clear();
                    cn.Open();
                    cm = new SqlCommand("Select * from tbl_Accessory join tbl_Units on tbl_Accessory.AccsUnit = tbl_Units.UnitId where AccsId like '" + txtAccsID.Text + "'", cn);
                    dr = cm.ExecuteReader();
                    dr.Read();
                    txtAccessory.Text = dr[2].ToString();
                    txtPrice.Text = dr[4].ToString();
                    txtStock.Text = dr[6].ToString();
                    txtUnit.Text = dr[8].ToString();


                    cn.Close();

                    txtQty.Focus();
                }
            }
        }

        private void txtQty_KeyDown(object sender, KeyEventArgs e)
        {
            int RowID = -1;
            bool descion = false;
            if(e.KeyCode == Keys.Enter)
            {
                if(txtQty.Text == string.Empty)
                {
                    MessageBox.Show("Please Enter Quantity");
                    txtQty.Focus();
                }
                else
                {
                    for (int i = 0; i < dataGridView1.Rows.Count; i++) 
                    {
                        if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtAccsID.Text)
                        {
                            RowID = i;
                            descion = true;
                            break;
                        }
                        else
                        {
                            descion = false;
                        }
                    }

                    if(descion == false)
                    {
                        Double Total = 0;
                        Total = Double.Parse(txtQty.Text) * Double.Parse(txtPrice.Text);
                        dataGridView1.Rows.Add(txtAccsID.Text, txtAccessory.Text, txtStock.Text, txtPrice.Text, txtQty.Text, txtUnit.Text, string.Format("{0:n}", Total));
                        txtAccsID.Clear();
                        txtAccessory.Clear();
                        txtQty.Clear();
                        txtStock.Clear();
                        txtUnit.Clear();
                        txtPrice.Clear();
                        txtAccsID.Focus();
                        txtTotal.Text = string.Format("{0:n}", CalculateTotal());
                    }
                    else
                    {
                        dataGridView1.Rows[RowID].Cells[4].Value = (double.Parse(dataGridView1.Rows[RowID].Cells[4].Value.ToString()) + double.Parse(txtQty.Text)).ToString();
                        dataGridView1.Rows[RowID].Cells[6].Value = string.Format("{0:n}",double.Parse(dataGridView1.Rows[RowID].Cells[3].Value.ToString()) * double.Parse(dataGridView1.Rows[RowID].Cells[4].Value.ToString()));
                        txtAccsID.Clear();
                        txtAccessory.Clear();
                        txtQty.Clear();
                        txtStock.Clear();
                        txtUnit.Clear();
                        txtPrice.Clear();
                        txtAccsID.Focus();
                        txtTotal.Text = string.Format("{0:n}", CalculateTotal());
                    } 
                    
                }
            }
        }

        private int CalculateTotal()
        {
            GrandTotal = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                GrandTotal = GrandTotal + int.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString(),NumberStyles.Currency,CultureInfo.CurrentCulture);
            }
            return GrandTotal;
        }
    }
}
