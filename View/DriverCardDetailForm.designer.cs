namespace CargoTransportationView
{
    partial class DriverCardDetailForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbServiceNumber = new System.Windows.Forms.Label();
            this.tbServiceNumber = new System.Windows.Forms.TextBox();
            this.lbFullName = new System.Windows.Forms.Label();
            this.tbFullName = new System.Windows.Forms.TextBox();
            this.lbGrade = new System.Windows.Forms.Label();
            this.tbGrade = new System.Windows.Forms.TextBox();
            this.lbCategory = new System.Windows.Forms.Label();
            this.tbCategory = new System.Windows.Forms.TextBox();
            this.lbIdentityCardNumber = new System.Windows.Forms.Label();
            this.tbIdentityCardNumber = new System.Windows.Forms.TextBox();
            this.lbHourlyTariffRate = new System.Windows.Forms.Label();
            this.tbHourlyTariffRate = new System.Windows.Forms.NumericUpDown();
            this.flpButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHourlyTariffRate)).BeginInit();
            this.flpButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbServiceNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbServiceNumber, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbFullName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbFullName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbGrade, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbGrade, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCategory, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbCategory, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbIdentityCardNumber, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbIdentityCardNumber, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbHourlyTariffRate, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbHourlyTariffRate, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.flpButtonPanel, 1, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 14;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(578, 229);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbServiceNumber
            // 
            this.lbServiceNumber.AutoSize = true;
            this.lbServiceNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbServiceNumber.Location = new System.Drawing.Point(11, 9);
            this.lbServiceNumber.Name = "lbServiceNumber";
            this.lbServiceNumber.Size = new System.Drawing.Size(178, 29);
            this.lbServiceNumber.TabIndex = 0;
            this.lbServiceNumber.Text = "Табельный номер:";
            this.lbServiceNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbServiceNumber
            // 
            this.tbServiceNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbServiceNumber.Location = new System.Drawing.Point(195, 12);
            this.tbServiceNumber.Name = "tbServiceNumber";
            this.tbServiceNumber.Size = new System.Drawing.Size(126, 23);
            this.tbServiceNumber.TabIndex = 0;
            this.tbServiceNumber.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbFullName
            // 
            this.lbFullName.AutoSize = true;
            this.lbFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFullName.Location = new System.Drawing.Point(11, 38);
            this.lbFullName.Name = "lbFullName";
            this.lbFullName.Size = new System.Drawing.Size(178, 29);
            this.lbFullName.TabIndex = 1;
            this.lbFullName.Text = "Фимилия И.О.:";
            this.lbFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFullName
            // 
            this.tbFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFullName.Location = new System.Drawing.Point(195, 41);
            this.tbFullName.Name = "tbFullName";
            this.tbFullName.Size = new System.Drawing.Size(372, 23);
            this.tbFullName.TabIndex = 1;
            this.tbFullName.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbGrade
            // 
            this.lbGrade.AutoSize = true;
            this.lbGrade.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbGrade.Location = new System.Drawing.Point(11, 67);
            this.lbGrade.Name = "lbGrade";
            this.lbGrade.Size = new System.Drawing.Size(178, 29);
            this.lbGrade.TabIndex = 2;
            this.lbGrade.Text = "Класс:";
            this.lbGrade.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbGrade
            // 
            this.tbGrade.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbGrade.Location = new System.Drawing.Point(195, 70);
            this.tbGrade.Name = "tbGrade";
            this.tbGrade.Size = new System.Drawing.Size(126, 23);
            this.tbGrade.TabIndex = 2;
            this.tbGrade.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbCategory
            // 
            this.lbCategory.AutoSize = true;
            this.lbCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCategory.Location = new System.Drawing.Point(11, 96);
            this.lbCategory.Name = "lbCategory";
            this.lbCategory.Size = new System.Drawing.Size(178, 29);
            this.lbCategory.TabIndex = 3;
            this.lbCategory.Text = "Категория водительских прав:";
            this.lbCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCategory
            // 
            this.tbCategory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCategory.Location = new System.Drawing.Point(195, 99);
            this.tbCategory.Name = "tbCategory";
            this.tbCategory.Size = new System.Drawing.Size(40, 23);
            this.tbCategory.TabIndex = 3;
            this.tbCategory.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbIdentityCardNumber
            // 
            this.lbIdentityCardNumber.AutoSize = true;
            this.lbIdentityCardNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIdentityCardNumber.Location = new System.Drawing.Point(11, 125);
            this.lbIdentityCardNumber.Name = "lbIdentityCardNumber";
            this.lbIdentityCardNumber.Size = new System.Drawing.Size(178, 29);
            this.lbIdentityCardNumber.TabIndex = 4;
            this.lbIdentityCardNumber.Text = "Номер удостоверения:";
            this.lbIdentityCardNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbIdentityCardNumber
            // 
            this.tbIdentityCardNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIdentityCardNumber.Location = new System.Drawing.Point(195, 128);
            this.tbIdentityCardNumber.Name = "tbIdentityCardNumber";
            this.tbIdentityCardNumber.Size = new System.Drawing.Size(126, 23);
            this.tbIdentityCardNumber.TabIndex = 4;
            this.tbIdentityCardNumber.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbHourlyTariffRate
            // 
            this.lbHourlyTariffRate.AutoSize = true;
            this.lbHourlyTariffRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbHourlyTariffRate.Location = new System.Drawing.Point(11, 154);
            this.lbHourlyTariffRate.Name = "lbHourlyTariffRate";
            this.lbHourlyTariffRate.Size = new System.Drawing.Size(178, 29);
            this.lbHourlyTariffRate.TabIndex = 5;
            this.lbHourlyTariffRate.Text = "Часовая тарифная ставка, руб.:";
            this.lbHourlyTariffRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbHourlyTariffRate
            // 
            this.tbHourlyTariffRate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbHourlyTariffRate.DecimalPlaces = 2;
            this.tbHourlyTariffRate.Location = new System.Drawing.Point(195, 157);
            this.tbHourlyTariffRate.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.tbHourlyTariffRate.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.tbHourlyTariffRate.Name = "tbHourlyTariffRate";
            this.tbHourlyTariffRate.Size = new System.Drawing.Size(126, 23);
            this.tbHourlyTariffRate.TabIndex = 5;
            this.tbHourlyTariffRate.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // flpButtonPanel
            // 
            this.flpButtonPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flpButtonPanel, 2);
            this.flpButtonPanel.Controls.Add(this.btnOk);
            this.flpButtonPanel.Controls.Add(this.btnCancel);
            this.flpButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpButtonPanel.Location = new System.Drawing.Point(387, 186);
            this.flpButtonPanel.Name = "flpButtonPanel";
            this.flpButtonPanel.Size = new System.Drawing.Size(180, 31);
            this.flpButtonPanel.TabIndex = 6;
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Enabled = false;
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Location = new System.Drawing.Point(3, 3);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(84, 25);
            this.btnOk.TabIndex = 0;
            this.btnOk.Text = "Ввод";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(93, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // DriverCardDetailForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(578, 229);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DriverCardDetailForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Карточка водителя";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbHourlyTariffRate)).EndInit();
            this.flpButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpButtonPanel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbServiceNumber;
        private System.Windows.Forms.TextBox tbServiceNumber;
        private System.Windows.Forms.Label lbFullName;
        private System.Windows.Forms.TextBox tbFullName;
        private System.Windows.Forms.Label lbGrade;
        private System.Windows.Forms.TextBox tbGrade;
        private System.Windows.Forms.Label lbCategory;
        private System.Windows.Forms.TextBox tbCategory;
        private System.Windows.Forms.Label lbIdentityCardNumber;
        private System.Windows.Forms.TextBox tbIdentityCardNumber;
        private System.Windows.Forms.Label lbHourlyTariffRate;
        private System.Windows.Forms.NumericUpDown tbHourlyTariffRate;
    }
}
