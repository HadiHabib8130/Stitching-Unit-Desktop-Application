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
    public partial class frmAccessory : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public frmAccessory()
        {
            InitializeComponent();
            cn.ConnectionString = conn.ConH2H();
            LoadCategory();
            LoadUnits();
        }

        public void LoadCategory()
        {
            cn.Close();
            cmbAccsCategory.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select AccessoryCategory from tbl_Categories order by AccessoryCategory ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read()) 
            {
                cmbAccsCategory.Items.Add(dr[0].ToString());
                
                
            }
            cn.Close();
        }
        public void LoadUnits()
        {
            cmbUnit.Items.Clear();
            cn.Open();
            cm = new SqlCommand("select Unit from tbl_Units order by Unit ASC", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                cmbUnit.Items.Add(dr[0].ToString());
            }
            cn.Close();
        }
        private int Id(string IdColumn,string TableName,string ColumnName,string Name)
        {
            int id = 0;
            cn.Open();
            cm = new SqlCommand("select "+IdColumn+"Id from "+TableName+" where "+ColumnName+" like'"+Name+"'", cn);
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                id = int.Parse(dr[0].ToString());
            }
            cn.Close();
            return id;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Confirm Save!", "h2h", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int idCategory = Id("Category","tbl_Categories","AccessoryCategory",cmbAccsCategory.Text);
                    int idUnit = Id("Unit","tbl_Units","Unit",cmbUnit.Text);
                    cn.Open();
                    cm = new SqlCommand("insert into tbl_Accessory(AccsCategory,AccsName,AccsUnit,AccsPrice,AccsLevel)Values(@AccsCategory,@AccsName,@AccsUnit,@AccsPrice,@AccsLevel)", cn);
                    cm.Parameters.AddWithValue("@AccsCategory", idCategory);
                    cm.Parameters.AddWithValue("@AccsName",txtAccsDescription.Text);
                    cm.Parameters.AddWithValue("@AccsUnit", idUnit);
                    cm.Parameters.AddWithValue("@AccsPrice",txtAccsPrice.Text);
                    cm.Parameters.AddWithValue("@AccsLevel", txtMinimumLvl.Text);
                    cm.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Save");
                    txtAccsDescription.Clear();
                    txtAccsPrice.Clear();
                    cmbAccsCategory.Focus();
                }
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

   

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnNewCategory_Click(object sender, EventArgs e)
        {
            frmAccessoryCategory frmAccessoryCategory = new frmAccessoryCategory(this);
            frmAccessoryCategory.ShowDialog();
        }

        private void btnNewUnit_Click(object sender, EventArgs e)
        {
            frmAddUnit frmAddUnit = new frmAddUnit(this);
            frmAddUnit.ShowDialog();
        }
    }
}
