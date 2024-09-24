using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace h2h
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnAccsCategory_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddAccs_Click(object sender, EventArgs e)
        {
            frmAccessory frmAccessory = new frmAccessory();
            frmAccessory.ShowDialog();
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            frmOperations frmOperations = new frmOperations();
            frmOperations.ShowDialog();
        }

        private void btnDefItem_Click(object sender, EventArgs e)
        {
            frmItemDetail frmItemDetail = new frmItemDetail(); 
            frmItemDetail.ShowDialog();
        }

        private void btnItemCost_Click(object sender, EventArgs e)
        {
            frmCalculateCost frmCalculateCost = new frmCalculateCost();
            frmCalculateCost.ShowDialog();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            frmItems frmItems = new frmItems();
            frmItems.ShowDialog();
        }

        private void btnWorkerEntries_Click(object sender, EventArgs e)
        {
            frmWorkerEntries frmWorkerEntries = new frmWorkerEntries();
            frmWorkerEntries.ShowDialog();
        }

        private void btnAddWorker_Click(object sender, EventArgs e)
        {
            frmAddWorker frmAddWorker = new frmAddWorker();
            frmAddWorker.ShowDialog();
        }

        private void btnAddSchool_Click(object sender, EventArgs e)
        {
            frmAddSchool frmAddSchool = new frmAddSchool();
            frmAddSchool.ShowDialog();
        }

        private void btnPaymentSlips_Click(object sender, EventArgs e)
        {
            frmReport frmReport = new frmReport();
            frmReport.ShowDialog();
        }
    }
}
