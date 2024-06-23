namespace CargoTransportationView
{
    partial class OrderDetailForm
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
            this.lbRoute = new System.Windows.Forms.Label();
            this.tbRoute = new System.Windows.Forms.ComboBox();
            this.lbDivision = new System.Windows.Forms.Label();
            this.tbDivision = new System.Windows.Forms.ComboBox();
            this.lbСustomer = new System.Windows.Forms.Label();
            this.tbСustomer = new System.Windows.Forms.ComboBox();
            this.lbService = new System.Windows.Forms.Label();
            this.tbService = new System.Windows.Forms.ComboBox();
            this.lbRate = new System.Windows.Forms.Label();
            this.tbRate = new System.Windows.Forms.ComboBox();
            this.flpButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbOrderNumber = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
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
            this.tableLayoutPanel1.Controls.Add(this.lbRoute, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbRoute, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbDivision, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbDivision, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbСustomer, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbСustomer, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbService, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.tbService, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbRate, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.tbRate, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.flpButtonPanel, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbOrderNumber, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 13;
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(561, 210);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbRoute
            // 
            this.lbRoute.AutoSize = true;
            this.lbRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRoute.Location = new System.Drawing.Point(9, 33);
            this.lbRoute.Name = "lbRoute";
            this.lbRoute.Size = new System.Drawing.Size(136, 27);
            this.lbRoute.TabIndex = 0;
            this.lbRoute.Text = "Маршрут:";
            this.lbRoute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbRoute
            // 
            this.tbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbRoute.FormattingEnabled = true;
            this.tbRoute.Location = new System.Drawing.Point(151, 36);
            this.tbRoute.Name = "tbRoute";
            this.tbRoute.Size = new System.Drawing.Size(401, 23);
            this.tbRoute.TabIndex = 0;
            this.tbRoute.SelectionChangeCommitted += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbDivision
            // 
            this.lbDivision.AutoSize = true;
            this.lbDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDivision.Location = new System.Drawing.Point(9, 60);
            this.lbDivision.Name = "lbDivision";
            this.lbDivision.Size = new System.Drawing.Size(136, 27);
            this.lbDivision.TabIndex = 1;
            this.lbDivision.Text = "Подразделение:";
            this.lbDivision.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDivision
            // 
            this.tbDivision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbDivision.FormattingEnabled = true;
            this.tbDivision.Location = new System.Drawing.Point(151, 63);
            this.tbDivision.Name = "tbDivision";
            this.tbDivision.Size = new System.Drawing.Size(306, 23);
            this.tbDivision.TabIndex = 1;
            this.tbDivision.SelectionChangeCommitted += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbСustomer
            // 
            this.lbСustomer.AutoSize = true;
            this.lbСustomer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbСustomer.Location = new System.Drawing.Point(9, 87);
            this.lbСustomer.Name = "lbСustomer";
            this.lbСustomer.Size = new System.Drawing.Size(136, 27);
            this.lbСustomer.TabIndex = 2;
            this.lbСustomer.Text = "Заказчик:";
            this.lbСustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbСustomer
            // 
            this.tbСustomer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbСustomer.FormattingEnabled = true;
            this.tbСustomer.Location = new System.Drawing.Point(151, 90);
            this.tbСustomer.Name = "tbСustomer";
            this.tbСustomer.Size = new System.Drawing.Size(306, 23);
            this.tbСustomer.TabIndex = 2;
            this.tbСustomer.SelectionChangeCommitted += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbService
            // 
            this.lbService.AutoSize = true;
            this.lbService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbService.Location = new System.Drawing.Point(9, 114);
            this.lbService.Name = "lbService";
            this.lbService.Size = new System.Drawing.Size(136, 27);
            this.lbService.TabIndex = 3;
            this.lbService.Text = "Наименование услуги:";
            this.lbService.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbService
            // 
            this.tbService.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbService.FormattingEnabled = true;
            this.tbService.Location = new System.Drawing.Point(151, 117);
            this.tbService.Name = "tbService";
            this.tbService.Size = new System.Drawing.Size(306, 23);
            this.tbService.TabIndex = 3;
            this.tbService.SelectionChangeCommitted += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbRate
            // 
            this.lbRate.AutoSize = true;
            this.lbRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRate.Location = new System.Drawing.Point(9, 141);
            this.lbRate.Name = "lbRate";
            this.lbRate.Size = new System.Drawing.Size(136, 27);
            this.lbRate.TabIndex = 4;
            this.lbRate.Text = "Наименование тарифа:";
            this.lbRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbRate
            // 
            this.tbRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tbRate.FormattingEnabled = true;
            this.tbRate.Location = new System.Drawing.Point(151, 144);
            this.tbRate.Name = "tbRate";
            this.tbRate.Size = new System.Drawing.Size(306, 23);
            this.tbRate.TabIndex = 4;
            this.tbRate.SelectionChangeCommitted += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // flpButtonPanel
            // 
            this.flpButtonPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flpButtonPanel, 2);
            this.flpButtonPanel.Controls.Add(this.btnOk);
            this.flpButtonPanel.Controls.Add(this.btnCancel);
            this.flpButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpButtonPanel.Location = new System.Drawing.Point(372, 171);
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
            this.label1.Location = new System.Drawing.Point(9, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер заказа:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbOrderNumber
            // 
            this.tbOrderNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.tbOrderNumber.Location = new System.Drawing.Point(151, 4);
            this.tbOrderNumber.Name = "tbOrderNumber";
            this.tbOrderNumber.Size = new System.Drawing.Size(85, 29);
            this.tbOrderNumber.TabIndex = 0;
            this.tbOrderNumber.Text = "(будет позже)";
            this.tbOrderNumber.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OrderDetailForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(561, 210);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrderDetailForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Заказ";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flpButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flpButtonPanel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lbRoute;
        private System.Windows.Forms.ComboBox tbRoute;
        private System.Windows.Forms.Label lbDivision;
        private System.Windows.Forms.ComboBox tbDivision;
        private System.Windows.Forms.Label lbСustomer;
        private System.Windows.Forms.ComboBox tbСustomer;
        private System.Windows.Forms.Label lbService;
        private System.Windows.Forms.ComboBox tbService;
        private System.Windows.Forms.Label lbRate;
        private System.Windows.Forms.ComboBox tbRate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label tbOrderNumber;
    }
}
