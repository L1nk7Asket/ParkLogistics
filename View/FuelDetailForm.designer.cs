namespace CargoTransportationView
{
    partial class FuelDetailForm
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
            this.lbCode = new System.Windows.Forms.Label();
            this.tbCode = new System.Windows.Forms.TextBox();
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDensity = new System.Windows.Forms.Label();
            this.tbDensity = new System.Windows.Forms.NumericUpDown();
            this.lbFuelUnit = new System.Windows.Forms.Label();
            this.tbFuelUnit = new System.Windows.Forms.TextBox();
            this.flpButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).BeginInit();
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
            this.tableLayoutPanel1.Controls.Add(this.lbCode, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbCode, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbDensity, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbDensity, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbFuelUnit, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbFuelUnit, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.flpButtonPanel, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(500, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbCode
            // 
            this.lbCode.AutoSize = true;
            this.lbCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCode.Location = new System.Drawing.Point(33, 13);
            this.lbCode.Name = "lbCode";
            this.lbCode.Size = new System.Drawing.Size(121, 29);
            this.lbCode.TabIndex = 0;
            this.lbCode.Text = "Код ГСМ:";
            this.lbCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCode
            // 
            this.tbCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbCode.Location = new System.Drawing.Point(160, 16);
            this.tbCode.Name = "tbCode";
            this.tbCode.Size = new System.Drawing.Size(126, 23);
            this.tbCode.TabIndex = 0;
            this.tbCode.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Location = new System.Drawing.Point(33, 42);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(121, 29);
            this.lbName.TabIndex = 1;
            this.lbName.Text = "Наименование ГСМ:";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(160, 45);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(306, 23);
            this.tbName.TabIndex = 1;
            this.tbName.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbDensity
            // 
            this.lbDensity.AutoSize = true;
            this.lbDensity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDensity.Location = new System.Drawing.Point(33, 71);
            this.lbDensity.Name = "lbDensity";
            this.lbDensity.Size = new System.Drawing.Size(121, 29);
            this.lbDensity.TabIndex = 2;
            this.lbDensity.Text = "Плотность:";
            this.lbDensity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDensity
            // 
            this.tbDensity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDensity.DecimalPlaces = 3;
            this.tbDensity.Location = new System.Drawing.Point(160, 74);
            this.tbDensity.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.tbDensity.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.tbDensity.Name = "tbDensity";
            this.tbDensity.Size = new System.Drawing.Size(126, 23);
            this.tbDensity.TabIndex = 2;
            this.tbDensity.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbFuelUnit
            // 
            this.lbFuelUnit.AutoSize = true;
            this.lbFuelUnit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFuelUnit.Location = new System.Drawing.Point(33, 100);
            this.lbFuelUnit.Name = "lbFuelUnit";
            this.lbFuelUnit.Size = new System.Drawing.Size(121, 29);
            this.lbFuelUnit.TabIndex = 3;
            this.lbFuelUnit.Text = "Ед.изм.  ГСМ:";
            this.lbFuelUnit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbFuelUnit
            // 
            this.tbFuelUnit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbFuelUnit.Location = new System.Drawing.Point(160, 103);
            this.tbFuelUnit.Name = "tbFuelUnit";
            this.tbFuelUnit.Size = new System.Drawing.Size(50, 23);
            this.tbFuelUnit.TabIndex = 3;
            this.tbFuelUnit.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // flpButtonPanel
            // 
            this.flpButtonPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flpButtonPanel, 2);
            this.flpButtonPanel.Controls.Add(this.btnOk);
            this.flpButtonPanel.Controls.Add(this.btnCancel);
            this.flpButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpButtonPanel.Location = new System.Drawing.Point(286, 132);
            this.flpButtonPanel.Name = "flpButtonPanel";
            this.flpButtonPanel.Size = new System.Drawing.Size(180, 31);
            this.flpButtonPanel.TabIndex = 4;
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
            // FuelDetailForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(500, 180);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FuelDetailForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ГСМ";
            this.Load += new System.EventHandler(this.FuelDetailForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbDensity)).EndInit();
            this.flpButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpButtonPanel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbCode;
        private System.Windows.Forms.TextBox tbCode;
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbDensity;
        private System.Windows.Forms.NumericUpDown tbDensity;
        private System.Windows.Forms.Label lbFuelUnit;
        private System.Windows.Forms.TextBox tbFuelUnit;
    }
}
