﻿using System;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace h2h
{
    public partial class frmPurchaseInvoice : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        int GrandTotal = 0;
        int serial = 0;
        int Party = 0;
        int TransType = 2;
        
        public frmPurchaseInvoice()
        {
            InitializeComponent();
            cn.ConnectionString = conn.ConH2H();
            LoadSuppliers();
            InvNO();
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
                else if (txtAccsID.Text == "0")
                {
                    txtAccsID.Clear();
                    txtPaid.Focus();
                }
                else
                {
                    try
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
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        cn.Close();
                    }
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
                        if (dataGridView1.Rows[i].Cells[1].Value.ToString() == txtAccsID.Text)
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
                        serial++;
                        dataGridView1.Rows.Add(serial,txtAccsID.Text, txtAccessory.Text, txtStock.Text, txtPrice.Text, txtQty.Text, txtUnit.Text, string.Format("{0:n}", Total));
                        txtAccsID.Clear();
                        txtAccessory.Clear();
                        txtQty.Clear();
                        txtStock.Clear();
                        txtUnit.Clear();
                        txtPrice.Clear();
                        txtAccsID.Focus();
                        if(cmbTransactionType.Text == "Cash")
                        {
                            txtTotal.Text = string.Format("{0:n}", CalculateTotal());
                            txtPaid.Text = txtTotal.Text;
                        }
                        else
                        {
                            txtTotal.Text = string.Format("{0:n}", CalculateTotal());
                        }
                        
                    }
                    else
                    {
                        dataGridView1.Rows[RowID].Cells[5].Value = (double.Parse(dataGridView1.Rows[RowID].Cells[5].Value.ToString()) + double.Parse(txtQty.Text)).ToString();
                        dataGridView1.Rows[RowID].Cells[7].Value = string.Format("{0:n}",double.Parse(dataGridView1.Rows[RowID].Cells[4].Value.ToString()) * double.Parse(dataGridView1.Rows[RowID].Cells[5].Value.ToString()));
                        txtAccsID.Clear();
                        txtAccessory.Clear();
                        txtQty.Clear();
                        txtStock.Clear();
                        txtUnit.Clear();
                        txtPrice.Clear();
                        txtAccsID.Focus();
                        if (cmbTransactionType.Text == "Cash")
                        {
                            txtTotal.Text = string.Format("{0:n}", CalculateTotal());
                            txtPaid.Text = txtTotal.Text;
                        }
                        else
                        {
                            txtTotal.Text = string.Format("{0:n}", CalculateTotal());
                        }
                    } 
                    
                }
            }
        }

        private int CalculateTotal()
        {
            GrandTotal = 0;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                GrandTotal = GrandTotal + int.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString(),NumberStyles.Currency,CultureInfo.CurrentCulture);
            }
            return GrandTotal;
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.Rows[e.RowIndex].Cells[7].Value = string.Format("{0:n}", double.Parse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString()) * double.Parse(dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString()));
            txtTotal.Text = string.Format("{0:n}",CalculateTotal());
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colNmae = dataGridView1.Columns[e.ColumnIndex].Name;
            if(colNmae == "Delete")
            {
                try
                {
                    dataGridView1.Rows.RemoveAt(e.RowIndex);
                    txtTotal.Text = string.Format("{0:n}",CalculateTotal());
                    updateSerial();


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    cn.Close();
                }
            }
        }

        private void cmbSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                // Clear the text selection
                cmbSupplier.SelectionLength = 0;

                // Move focus to the next control
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }));
            try
            {
                cn.Open();
                cm = new SqlCommand("select PartyID from tbl_Parties where PartyName like '"+cmbSupplier.Text+"'", cn);
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Party = int.Parse(dr[0].ToString());
                }
                else
                {
                    MessageBox.Show("Party doesn't exist");
                }

                cn.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                // Clear the text selection
                cmbSupplier.SelectionLength = 0;

                // Move focus to the next control
                this.SelectNextControl(ActiveControl, true, true, true, true);
            }));
            if(cmbTransactionType.Text == "Cash")
            {
                TransType = 0;
                txtPaid.ReadOnly = true;
            }
            else
            {
                TransType = 1;
                txtPaid.ReadOnly = false;
            }
        }

        private void txtPaid_TextChanged(object sender, EventArgs e)
        {
            if(txtPaid.Text != "")
            {
                
                
                txtRemaining.Text = string.Format("{0:n}", double.Parse(txtTotal.Text, NumberStyles.Currency) - double.Parse(txtPaid.Text, NumberStyles.Currency));

            }
            else
            {
                txtRemaining.Text = txtTotal.Text;
            }
        }

        private string GetInvNO()
        {


            string date = DateTime.Now.ToString("MM") + DateTime.Now.ToString("dd");
            string invNo;
            try
            {
                cn.Open();
                cm = new SqlCommand("Select * from tbl_Transactions where TransID like 'P-" + date + "%' order by transID DESC", cn);
                dr = cm.ExecuteReader();
                if (dr.HasRows)
                {

                    dr.Read();
                    string TempInvNo = dr[0].ToString();
                    int temp = int.Parse(TempInvNo.Substring(6, 4));
                    temp++;
                    invNo = "P-" + date + temp.ToString("D4");

                }
                else
                {
                    invNo = "P-" + date + "0001";
                }
                cn.Close();
                return invNo;
                
            }
            catch(Exception ex)
            {
                invNo = "0";
                MessageBox.Show(ex.Message);
                cn.Close();
                return invNo;
            }
            
            
        }
        private void InvNO()
        {
            if (GetInvNO() == "0")
            {
                MessageBox.Show("Error in ID");
                this.Dispose();
            }
            else
            {
                txtInvNo.Text = GetInvNO();
            }
        }

        private void updateSerial()
        {
            for(int i = 0; i < dataGridView1.Rows.Count;i++)
            {
                serial = i + 1;
                dataGridView1.Rows[i].Cells[0].Value = serial;
                
            }
            
        }

        private void txtTotal_TextChanged(object sender, EventArgs e)
        {
            if(txtTotal.Text != "")
            {
                if (txtPaid.Text != "")
                {


                    txtRemaining.Text = string.Format("{0:n}", double.Parse(txtTotal.Text, NumberStyles.Currency) - double.Parse(txtPaid.Text, NumberStyles.Currency));

                }
                else
                {
                    txtRemaining.Text = txtTotal.Text;
                }
            }
            
        }

        private void PurchaseInvInsert()
        {
            try
            {
                for (int i = 0;i < dataGridView1.Rows.Count; i++)
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_PurchaseInvoiceDetail(PurInvId,ItemCode,Price,Qty,Total)Values(@PurInvId,@ItemCode,@Price,@Qty,@Total)", cn);
                    cm.Parameters.AddWithValue("@PurInvId",txtInvNo.Text);
                    cm.Parameters.AddWithValue("@ItemCode",dataGridView1.Rows[i].Cells[1].Value.ToString());
                    cm.Parameters.AddWithValue("@Price",dataGridView1.Rows[i].Cells[4].Value.ToString());
                    cm.Parameters.AddWithValue("@Qty", dataGridView1.Rows[i].Cells[5].Value.ToString());
                    cm.Parameters.AddWithValue("@Total", decimal.Parse(dataGridView1.Rows[i].Cells[7].Value.ToString(),NumberStyles.Currency));
                    cm.ExecuteNonQuery();
                    cn.Close();
                }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }
        private void TransactionInsert()
        {
            try
            {
                if(txtPaid.Text != "")
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_Transactions(TransID,TransDate,TransParty,TransType,TransRemarks,TransTotal,TransPaid,TransRemaining)values(@TransID,@TransDate,@TransParty,@TransType,@TransRemarks,@TransTotal,@TransPaid,@TransRemaining)", cn);
                    cm.Parameters.AddWithValue("@TransID", txtInvNo.Text);
                    cm.Parameters.AddWithValue("@TransDate", dateTimePicker1.Value);
                    cm.Parameters.AddWithValue("@TransParty", Party);
                    cm.Parameters.AddWithValue("@TransType", TransType);
                    cm.Parameters.AddWithValue("@TransRemarks", txtRemarks.Text);
                    cm.Parameters.AddWithValue("@TransTotal", decimal.Parse(txtTotal.Text,NumberStyles.Currency));
                    cm.Parameters.AddWithValue("@TransPaid", decimal.Parse(txtPaid.Text, NumberStyles.Currency));
                    cm.Parameters.AddWithValue("@TransRemaining", decimal.Parse(txtRemaining.Text, NumberStyles.Currency));
                    cm.ExecuteNonQuery();
                    cn.Close();
                }
                else
                {
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_Transactions(TransID,TransDate,TransParty,TransType,TransRemarks,TransTotal,TransPaid,TransRemaining)values(@TransID,@TransDate,@TransParty,@TransType,@TransRemarks,@TransTotal,@TransPaid,@TransRemaining)", cn);
                    cm.Parameters.AddWithValue("@TransID", txtInvNo.Text);
                    cm.Parameters.AddWithValue("@TransDate", dateTimePicker1.Value);
                    cm.Parameters.AddWithValue("@TransParty", Party);
                    cm.Parameters.AddWithValue("@TransType", TransType);
                    cm.Parameters.AddWithValue("@TransRemarks", txtRemarks.Text);
                    cm.Parameters.AddWithValue("@TransTotal", decimal.Parse(txtTotal.Text, NumberStyles.Currency));
                    cm.Parameters.AddWithValue("@TransPaid", decimal.Parse(txtPaid.Text, NumberStyles.Currency));
                    cm.Parameters.AddWithValue("@TransRemaining", decimal.Parse(txtRemaining.Text, NumberStyles.Currency));
                    cm.ExecuteNonQuery();
                    cn.Close();
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                cn.Close();
            }
        }

        private void txtPaid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                TransactionInsert();
                PurchaseInvInsert();
            }
        }
    }
}
