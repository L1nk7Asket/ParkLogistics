namespace CargoTransportationView
{
    partial class PaymentDetailForm
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
            this.lbWaybill = new System.Windows.Forms.Label();
            this.tbWaybill = new System.Windows.Forms.ComboBox();
            this.lbPaymentType = new System.Windows.Forms.Label();
            this.tbPaymentType = new System.Windows.Forms.ComboBox();
            this.flpButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbRouteCode = new System.Windows.Forms.TextBox();
            this.tbDriverName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbSumma = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1.SuspendLayout();
            this.flpButtonPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbSumma)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.lbWaybill, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbWaybill, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbPaymentType, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbPaymentType, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.flpButtonPanel, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbRouteCode, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbDriverName, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbSumma, 2, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(474, 197);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbWaybill
            // 
            this.lbWaybill.AutoSize = true;
            this.lbWaybill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbWaybill.Location = new System.Drawing.Point(12, 9);
            this.lbWaybill.Name = "lbWaybill";
            this.lbWaybill.Size = new System.Drawing.Size(127, 27);
            this.lbWaybill.TabIndex = 0;
            this.lbWaybill.Text = "Путевой лист:";
            this.lbWaybill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbWaybill
            // 
            this.tbWaybill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbWaybill.FormattingEnabled = true;
            this.tbWaybill.Location = new System.Drawing.Point(145, 12);
            this.tbWaybill.Name = "tbWaybill";
            this.tbWaybill.Size = new System.Drawing.Size(96, 23);
            this.tbWaybill.TabIndex = 0;
            this.tbWaybill.SelectedIndexChanged += new System.EventHandler(this.tbWaybill_SelectedIndexChanged);
            this.tbWaybill.SelectionChangeCommitted += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbPaymentType
            // 
            this.lbPaymentType.AutoSize = true;
            this.lbPaymentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbPaymentType.Location = new System.Drawing.Point(12, 36);
            this.lbPaymentType.Name = "lbPaymentType";
            this.lbPaymentType.Size = new System.Drawing.Size(127, 27);
            this.lbPaymentType.TabIndex = 1;
            this.lbPaymentType.Text = "Вид оплаты:";
            this.lbPaymentType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbPaymentType
            // 
            this.tbPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbPaymentType.FormattingEnabled = true;
            this.tbPaymentType.Location = new System.Drawing.Point(145, 39);
            this.tbPaymentType.Name = "tbPaymentType";
            this.tbPaymentType.Size = new System.Drawing.Size(223, 23);
            this.tbPaymentType.TabIndex = 1;
            this.tbPaymentType.SelectedIndexChanged += new System.EventHandler(this.tbWaybill_SelectedIndexChanged);
            this.tbPaymentType.SelectionChangeCommitted += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // flpButtonPanel
            // 
            this.flpButtonPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flpButtonPanel, 2);
            this.flpButtonPanel.Controls.Add(this.btnOk);
            this.flpButtonPanel.Controls.Add(this.btnCancel);
            this.flpButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpButtonPanel.Location = new System.Drawing.Point(281, 153);
            this.flpButtonPanel.Name = "flpButtonPanel";
            this.flpButtonPanel.Size = new System.Drawing.Size(180, 31);
            this.flpButtonPanel.TabIndex = 5;
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(12, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Код маршрута:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(12, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 29);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ф.И.О. водителя:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbRouteCode
            // 
            this.tbRouteCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbRouteCode.Location = new System.Drawing.Point(145, 66);
            this.tbRouteCode.Name = "tbRouteCode";
            this.tbRouteCode.ReadOnly = true;
            this.tbRouteCode.Size = new System.Drawing.Size(316, 23);
            this.tbRouteCode.TabIndex = 2;
            this.tbRouteCode.TabStop = false;
            // 
            // tbDriverName
            // 
            this.tbDriverName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDriverName.Location = new System.Drawing.Point(145, 95);
            this.tbDriverName.Name = "tbDriverName";
            this.tbDriverName.ReadOnly = true;
            this.tbDriverName.Size = new System.Drawing.Size(316, 23);
            this.tbDriverName.TabIndex = 3;
            this.tbDriverName.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(12, 121);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 29);
            this.label3.TabIndex = 1;
            this.label3.Text = "Сумма к оплате, руб.:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbSumma
            // 
            this.tbSumma.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbSumma.DecimalPlaces = 2;
            this.tbSumma.Location = new System.Drawing.Point(145, 124);
            this.tbSumma.Maximum = new decimal(new int[] {
            100000000,
            0,
            0,
            0});
            this.tbSumma.Minimum = new decimal(new int[] {
            100000000,
            0,
            0,
            -2147483648});
            this.tbSumma.Name = "tbSumma";
            this.tbSumma.Size = new System.Drawing.Size(96, 23);
            this.tbSumma.TabIndex = 4;
            // 
            // PaymentDetailForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 197);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PaymentDetailForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Оплата по путевому листу";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flpButtonPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tbSumma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpButtonPanel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbWaybill;
        private System.Windows.Forms.ComboBox tbWaybill;
        private System.Windows.Forms.Label lbPaymentType;
        private System.Windows.Forms.ComboBox tbPaymentType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbRouteCode;
        private System.Windows.Forms.TextBox tbDriverName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown tbSumma;
    }
}
