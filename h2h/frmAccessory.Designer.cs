namespace h2h
{
    partial class frmAccessory
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
            this.txtAccsDescription = new System.Windows.Forms.TextBox();
            this.cmbAccsCategory = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAccsPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbUnit = new System.Windows.Forms.ComboBox();
            this.btnNewCategory = new System.Windows.Forms.Button();
            this.btnNewUnit = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinimumLvl = new System.Windows.Forms.TextBox();
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
            this.panel1.Size = new System.Drawing.Size(616, 49);
            this.panel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Define Accessory";
            // 
            // txtAccsDescription
            // 
            this.txtAccsDescription.Location = new System.Drawing.Point(168, 108);
            this.txtAccsDescription.Name = "txtAccsDescription";
            this.txtAccsDescription.Size = new System.Drawing.Size(182, 20);
            this.txtAccsDescription.TabIndex = 3;
            // 
            // cmbAccsCategory
            // 
            this.cmbAccsCategory.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbAccsCategory.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbAccsCategory.FormattingEnabled = true;
            this.cmbAccsCategory.Location = new System.Drawing.Point(168, 71);
            this.cmbAccsCategory.Name = "cmbAccsCategory";
            this.cmbAccsCategory.Size = new System.Drawing.Size(182, 21);
            this.cmbAccsCategory.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(79, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Category";
            // 
            // txtAccsPrice
            // 
            this.txtAccsPrice.Location = new System.Drawing.Point(168, 181);
            this.txtAccsPrice.Name = "txtAccsPrice";
            this.txtAccsPrice.Size = new System.Drawing.Size(182, 20);
            this.txtAccsPrice.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(74, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Description";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(79, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Price/Unit";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(275, 259);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(79, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Unit";
            // 
            // cmbUnit
            // 
            this.cmbUnit.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbUnit.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbUnit.FormattingEnabled = true;
            this.cmbUnit.Location = new System.Drawing.Point(168, 144);
            this.cmbUnit.Name = "cmbUnit";
            this.cmbUnit.Size = new System.Drawing.Size(182, 21);
            this.cmbUnit.TabIndex = 4;
            // 
            // btnNewCategory
            // 
            this.btnNewCategory.BackColor = System.Drawing.Color.LawnGreen;
            this.btnNewCategory.FlatAppearance.BorderSize = 0;
            this.btnNewCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewCategory.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewCategory.ForeColor = System.Drawing.Color.Black;
            this.btnNewCategory.Location = new System.Drawing.Point(356, 67);
            this.btnNewCategory.Name = "btnNewCategory";
            this.btnNewCategory.Size = new System.Drawing.Size(106, 27);
            this.btnNewCategory.TabIndex = 12;
            this.btnNewCategory.Text = "Add New Category";
            this.btnNewCategory.UseVisualStyleBackColor = false;
            this.btnNewCategory.Click += new System.EventHandler(this.btnNewCategory_Click);
            // 
            // btnNewUnit
            // 
            this.btnNewUnit.BackColor = System.Drawing.Color.LawnGreen;
            this.btnNewUnit.FlatAppearance.BorderSize = 0;
            this.btnNewUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewUnit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewUnit.ForeColor = System.Drawing.Color.Black;
            this.btnNewUnit.Location = new System.Drawing.Point(356, 140);
            this.btnNewUnit.Name = "btnNewUnit";
            this.btnNewUnit.Size = new System.Drawing.Size(106, 27);
            this.btnNewUnit.TabIndex = 13;
            this.btnNewUnit.Text = "Add New Unit ";
            this.btnNewUnit.UseVisualStyleBackColor = false;
            this.btnNewUnit.Click += new System.EventHandler(this.btnNewUnit_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(79, 223);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(108, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Minimum Stock Level";
            // 
            // txtMinimumLvl
            // 
            this.txtMinimumLvl.Location = new System.Drawing.Point(193, 220);
            this.txtMinimumLvl.Name = "txtMinimumLvl";
            this.txtMinimumLvl.Size = new System.Drawing.Size(71, 20);
            this.txtMinimumLvl.TabIndex = 6;
            // 
            // frmAccessory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 314);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtMinimumLvl);
            this.Controls.Add(this.btnNewUnit);
            this.Controls.Add(this.btnNewCategory);
            this.Controls.Add(this.cmbUnit);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtAccsPrice);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbAccsCategory);
            this.Controls.Add(this.txtAccsDescription);
            this.Controls.Add(this.panel1);
            this.Name = "frmAccessory";
            this.Text = "frmAccessory";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAccsDescription;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAccsPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnNewCategory;
        private System.Windows.Forms.Button btnNewUnit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinimumLvl;
        public System.Windows.Forms.ComboBox cmbAccsCategory;
        public System.Windows.Forms.ComboBox cmbUnit;
    }
}