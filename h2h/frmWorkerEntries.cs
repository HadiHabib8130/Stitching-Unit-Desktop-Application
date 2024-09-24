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
    public partial class frmWorkerEntries : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public frmWorkerEntries()
        {
            InitializeComponent();
            cn.ConnectionString = conn.MyCon();
            LoadBoxes();
        }

        private void LoadBoxes()
        {
            LoadItems();
            LoadOperations();
            LoadSchools();
            LoadWorkers();
        }
        private void LoadWorkers()
        {
            cmbWorker.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select WorkerName from tbl_Workers order by WorkerName ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmbWorker.Items.Add(dr[0].ToString());
            }
            cn.Close();
        }
        private void LoadSchools()
        {
            cmbSchoolName.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select SchoolName from tbl_Schools order by SchoolName ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read()) 
            {
                cmbSchoolName.Items.Add(dr[0].ToString());
            }
            cn.Close();
        }
        private void LoadOperations()
        {
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
        }
        private void Loadrecords()
        {
            dgvWorkerEntries.Rows.Clear();
            cn.Open();
            cm = new SqlCommand("select * from tbl_WorkerEntries where Date = '"+dateTimePicker1.Value+"' and Worker like '"+cmbWorker.Text+"'",cn);
            dr = cm.ExecuteReader();
            int i = 0;
            while (dr.Read()) 
            {
                i++;
                dgvWorkerEntries.Rows.Add(dr[0].ToString(), i, dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
            }
            cn.Close();
        }

        private void Insert()
        {
            cn.Open();
            cm = new SqlCommand("insert into tbl_WorkerEntries(Date,Worker,SchoolName,Operation,Item,Size,Quantity,Rate)values(@Date,@Worker,@SchoolName,@Operation,@Item,@Size,@Quantity,@Rate)", cn);
            cm.Parameters.AddWithValue("@Date", dateTimePicker1.Value);
            cm.Parameters.AddWithValue("@Worker", cmbWorker.Text);
            cm.Parameters.AddWithValue("@SchoolName", cmbSchoolName.Text);
            cm.Parameters.AddWithValue("@Operation", cmbOperations.Text);
            cm.Parameters.AddWithValue("@Item", cmbItem.Text);
            cm.Parameters.AddWithValue("@Size", txtSize.Text);
            cm.Parameters.AddWithValue("@Quantity", txtQty.Text);
            cm.Parameters.AddWithValue("@Rate", txtPrice.Text);
            cm.ExecuteNonQuery();
            cn.Close();
            txtSize.Clear();
            txtQty.Clear();
            txtSize.Focus();
            Loadrecords();
        }

        private void btnADD_Click(object sender, EventArgs e)
        { 
           try
            {
                Insert();
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbWorker_SelectedValueChanged(object sender, EventArgs e)
        {
            Loadrecords();
        }

        private void dgvWorkerEntries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvWorkerEntries.Columns[e.ColumnIndex].Name;
            if (colName == "delete") 
            {
                try
                {
                    if (MessageBox.Show("Confirm Delete?", "H2H", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cn.Open();
                        cm = new SqlCommand("delete from tbl_WorkerEntries where id like '" + dgvWorkerEntries[0,e.RowIndex].Value.ToString() +"'", cn);
                        cm.ExecuteNonQuery();
                        cn.Close();

                        MessageBox.Show("Deleted!");
                        Loadrecords();
                    }


                }catch(Exception ex)
                {

                MessageBox.Show(ex.Message); }
            }
        }
    }
}
