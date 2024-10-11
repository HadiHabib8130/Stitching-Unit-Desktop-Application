namespace h2h
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAccsCategory = new System.Windows.Forms.Button();
            this.btnAddAccs = new System.Windows.Forms.Button();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.btnDefItem = new System.Windows.Forms.Button();
            this.btnItemCost = new System.Windows.Forms.Button();
            this.btnAddItem = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnAddWorker = new System.Windows.Forms.Button();
            this.btnWorkerEntries = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btnAddSchool = new System.Windows.Forms.Button();
            this.btnPaymentSlips = new System.Windows.Forms.Button();
            this.txtPurchaseAccs = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gray;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 49);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Main Form";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(166, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Accessory";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(292, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "Operation";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(435, 93);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 24);
            this.label4.TabIndex = 6;
            this.label4.Text = "Item";
            // 
            // btnAccsCategory
            // 
            this.btnAccsCategory.Location = new System.Drawing.Point(170, 141);
            this.btnAccsCategory.Name = "btnAccsCategory";
            this.btnAccsCategory.Size = new System.Drawing.Size(75, 35);
            this.btnAccsCategory.TabIndex = 7;
            this.btnAccsCategory.Text = "Accessory Category";
            this.btnAccsCategory.UseVisualStyleBackColor = true;
            this.btnAccsCategory.Click += new System.EventHandler(this.btnAccsCategory_Click);
            // 
            // btnAddAccs
            // 
            this.btnAddAccs.Location = new System.Drawing.Point(170, 201);
            this.btnAddAccs.Name = "btnAddAccs";
            this.btnAddAccs.Size = new System.Drawing.Size(75, 35);
            this.btnAddAccs.TabIndex = 8;
            this.btnAddAccs.Text = "Add Accessory";
            this.btnAddAccs.UseVisualStyleBackColor = true;
            this.btnAddAccs.Click += new System.EventHandler(this.btnAddAccs_Click);
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Location = new System.Drawing.Point(296, 141);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(75, 35);
            this.btnAddOperation.TabIndex = 9;
            this.btnAddOperation.Text = "Add Operation";
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // btnDefItem
            // 
            this.btnDefItem.Location = new System.Drawing.Point(414, 192);
            this.btnDefItem.Name = "btnDefItem";
            this.btnDefItem.Size = new System.Drawing.Size(75, 35);
            this.btnDefItem.TabIndex = 10;
            this.btnDefItem.Text = "Define Item";
            this.btnDefItem.UseVisualStyleBackColor = true;
            this.btnDefItem.Click += new System.EventHandler(this.btnDefItem_Click);
            // 
            // btnItemCost
            // 
            this.btnItemCost.Location = new System.Drawing.Point(414, 246);
            this.btnItemCost.Name = "btnItemCost";
            this.btnItemCost.Size = new System.Drawing.Size(75, 35);
            this.btnItemCost.TabIndex = 11;
            this.btnItemCost.Text = "Item Cost";
            this.btnItemCost.UseVisualStyleBackColor = true;
            this.btnItemCost.Click += new System.EventHandler(this.btnItemCost_Click);
            // 
            // btnAddItem
            // 
            this.btnAddItem.Location = new System.Drawing.Point(414, 141);
            this.btnAddItem.Name = "btnAddItem";
            this.btnAddItem.Size = new System.Drawing.Size(75, 35);
            this.btnAddItem.TabIndex = 12;
            this.btnAddItem.Text = "Add Item";
            this.btnAddItem.UseVisualStyleBackColor = true;
            this.btnAddItem.Click += new System.EventHandler(this.btnAddItem_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(516, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 24);
            this.label5.TabIndex = 13;
            this.label5.Text = "Worker";
            // 
            // btnAddWorker
            // 
            this.btnAddWorker.Location = new System.Drawing.Point(512, 141);
            this.btnAddWorker.Name = "btnAddWorker";
            this.btnAddWorker.Size = new System.Drawing.Size(75, 35);
            this.btnAddWorker.TabIndex = 14;
            this.btnAddWorker.Text = "Add Worker";
            this.btnAddWorker.UseVisualStyleBackColor = true;
            this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
            // 
            // btnWorkerEntries
            // 
            this.btnWorkerEntries.Location = new System.Drawing.Point(512, 192);
            this.btnWorkerEntries.Name = "btnWorkerEntries";
            this.btnWorkerEntries.Size = new System.Drawing.Size(75, 35);
            this.btnWorkerEntries.TabIndex = 15;
            this.btnWorkerEntries.Text = "Worker Enteries";
            this.btnWorkerEntries.UseVisualStyleBackColor = true;
            this.btnWorkerEntries.Click += new System.EventHandler(this.btnWorkerEntries_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(64, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "Schools";
            // 
            // btnAddSchool
            // 
            this.btnAddSchool.Location = new System.Drawing.Point(67, 141);
            this.btnAddSchool.Name = "btnAddSchool";
            this.btnAddSchool.Size = new System.Drawing.Size(75, 35);
            this.btnAddSchool.TabIndex = 17;
            this.btnAddSchool.Text = "Add School";
            this.btnAddSchool.UseVisualStyleBackColor = true;
            this.btnAddSchool.Click += new System.EventHandler(this.btnAddSchool_Click);
            // 
            // btnPaymentSlips
            // 
            this.btnPaymentSlips.Location = new System.Drawing.Point(512, 246);
            this.btnPaymentSlips.Name = "btnPaymentSlips";
            this.btnPaymentSlips.Size = new System.Drawing.Size(75, 35);
            this.btnPaymentSlips.TabIndex = 18;
            this.btnPaymentSlips.Text = "Payment Slips";
            this.btnPaymentSlips.UseVisualStyleBackColor = true;
            this.btnPaymentSlips.Click += new System.EventHandler(this.btnPaymentSlips_Click);
            // 
            // txtPurchaseAccs
            // 
            this.txtPurchaseAccs.Location = new System.Drawing.Point(170, 258);
            this.txtPurchaseAccs.Name = "txtPurchaseAccs";
            this.txtPurchaseAccs.Size = new System.Drawing.Size(75, 51);
            this.txtPurchaseAccs.TabIndex = 19;
            this.txtPurchaseAccs.Text = "Accessory Purchase Invoice";
            this.txtPurchaseAccs.UseVisualStyleBackColor = true;
            this.txtPurchaseAccs.Click += new System.EventHandler(this.txtPurchaseAccs_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 360);
            this.Controls.Add(this.txtPurchaseAccs);
            this.Controls.Add(this.btnPaymentSlips);
            this.Controls.Add(this.btnAddSchool);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnWorkerEntries);
            this.Controls.Add(this.btnAddWorker);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnAddItem);
            this.Controls.Add(this.btnItemCost);
            this.Controls.Add(this.btnDefItem);
            this.Controls.Add(this.btnAddOperation);
            this.Controls.Add(this.btnAddAccs);
            this.Controls.Add(this.btnAccsCategory);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panel1);
            this.Name = "frmMain";
            this.Text = "-";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAccsCategory;
        private System.Windows.Forms.Button btnAddAccs;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.Button btnDefItem;
        private System.Windows.Forms.Button btnItemCost;
        private System.Windows.Forms.Button btnAddItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnAddWorker;
        private System.Windows.Forms.Button btnWorkerEntries;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnAddSchool;
        private System.Windows.Forms.Button btnPaymentSlips;
        private System.Windows.Forms.Button txtPurchaseAccs;
    }
}