using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace h2h
{
    public partial class frmReport : Form
    {
        Connection conn = new Connection();
        SqlConnection cn = new SqlConnection();
        SqlCommand cm = new SqlCommand();
        SqlDataReader dr;
        public frmReport()
        {
            InitializeComponent();
            cn.ConnectionString = conn.MyCon();
            LoadWorkers();
        }

        private void frmReport_Load(object sender, EventArgs e)
        {

            this.RptPaymentSlip.RefreshReport();
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

        private void loadReport()
        {
            ReportDataSource rptDataSource;
            try
            {
                this.RptPaymentSlip.LocalReport.ReportPath = Path.Combine(Application.StartupPath, "Reports", "PaymentSlip1.rdlc"); /*@"D:\vs code\projects\h2h\h2h\PaymentSlip1.rdlc";*/ /*@"Reports\PaymentSlip1.rdlc";*/
                string reportpath = Path.Combine(Application.StartupPath, "Reports", "PaymentSlip1.rdlc");
                this.RptPaymentSlip.LocalReport.DataSources.Clear();

                DataSet1 ds = new DataSet1();
                SqlDataAdapter da = new SqlDataAdapter();

                cn.Open();
                da.SelectCommand = new SqlCommand("select SchoolName,Operation,Item,Size,Quantity,Rate,Total from tbl_WorkerEntries where Date>='"+dtStartdate.Value+"' and Date <= '"+dtEndDate.Value+"' and Worker like '"+cmbWorker.Text+"'", cn);
                da.Fill(ds.Tables["dtWorkerSlip"]);
                cn.Close();

                ReportParameter WorkerNmae = new ReportParameter("WorkerName", cmbWorker.Text);
                ReportParameter StartDate = new ReportParameter("StartDate", dtStartdate.Value.ToShortDateString());
                ReportParameter EndDate = new ReportParameter("EndDate", dtEndDate.Value.ToShortDateString());

                RptPaymentSlip.LocalReport.SetParameters(WorkerNmae);
                RptPaymentSlip.LocalReport.SetParameters(StartDate);
                RptPaymentSlip.LocalReport.SetParameters(EndDate);

                rptDataSource = new ReportDataSource("DataSet1", ds.Tables["dtWorkerSlip"]);
                RptPaymentSlip.LocalReport.DataSources.Add(rptDataSource);
                RptPaymentSlip.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.Normal);
                //RptPaymentSlip.ZoomMode = ZoomMode.Percent;
                //RptPaymentSlip.ZoomPercent = 30;

            }
            catch (Exception ex) 
            {
                cn.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            loadReport();
            //RptPaymentSlip.Refresh();
        }
    }
}
