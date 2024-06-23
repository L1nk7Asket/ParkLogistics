namespace CargoTransportationView
{
    partial class WaybillTableForm
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAppend = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lvTable = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIssueDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStateNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOrder = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDepartureDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReturnDateTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDrivingTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chService = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chRate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnWaybillFace = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lvTable, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1066, 557);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.btnAppend);
            this.flowLayoutPanel1.Controls.Add(this.btnUpdate);
            this.flowLayoutPanel1.Controls.Add(this.btnRemove);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(243, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // btnAppend
            // 
            this.btnAppend.Location = new System.Drawing.Point(3, 3);
            this.btnAppend.Name = "btnAppend";
            this.btnAppend.Size = new System.Drawing.Size(75, 23);
            this.btnAppend.TabIndex = 0;
            this.btnAppend.Text = "Добавить";
            this.btnAppend.UseVisualStyleBackColor = true;
            this.btnAppend.Click += new System.EventHandler(this.btnAppend_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(84, 3);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 2;
            this.btnUpdate.Text = "Изменить";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Enabled = false;
            this.btnRemove.Location = new System.Drawing.Point(165, 3);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "Удалить";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lvTable
            // 
            this.lvTable.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chIssueDate,
            this.chStateNumber,
            this.chOrder,
            this.chDepartureDateTime,
            this.chReturnDateTime,
            this.chDrivingTime,
            this.chService,
            this.chRate});
            this.tableLayoutPanel1.SetColumnSpan(this.lvTable, 2);
            this.lvTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvTable.FullRowSelect = true;
            this.lvTable.GridLines = true;
            this.lvTable.HideSelection = false;
            this.lvTable.Location = new System.Drawing.Point(3, 38);
            this.lvTable.MultiSelect = false;
            this.lvTable.Name = "lvTable";
            this.lvTable.ShowItemToolTips = true;
            this.lvTable.Size = new System.Drawing.Size(1060, 516);
            this.lvTable.TabIndex = 0;
            this.lvTable.UseCompatibleStateImageBehavior = false;
            this.lvTable.View = System.Windows.Forms.View.Details;
            this.lvTable.SelectedIndexChanged += new System.EventHandler(this.lvTable_SelectedIndexChanged);
            this.lvTable.DoubleClick += new System.EventHandler(this.lvTable_DoubleClick);
            // 
            // chId
            // 
            this.chId.Text = "Id";
            this.chId.Width = 0;
            // 
            // chIssueDate
            // 
            this.chIssueDate.Text = "Дата выдачи";
            this.chIssueDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chIssueDate.Width = 90;
            // 
            // chStateNumber
            // 
            this.chStateNumber.Text = "Гос.номер";
            this.chStateNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chStateNumber.Width = 90;
            // 
            // chOrder
            // 
            this.chOrder.Text = "Номер заказа (маршрут)";
            this.chOrder.Width = 210;
            // 
            // chDepartureDateTime
            // 
            this.chDepartureDateTime.Text = "Выезд";
            this.chDepartureDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chDepartureDateTime.Width = 120;
            // 
            // chReturnDateTime
            // 
            this.chReturnDateTime.Text = "Возвращение";
            this.chReturnDateTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chReturnDateTime.Width = 120;
            // 
            // chDrivingTime
            // 
            this.chDrivingTime.Text = "В пути (ч)";
            this.chDrivingTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.chDrivingTime.Width = 80;
            // 
            // chService
            // 
            this.chService.Text = "Услуга";
            this.chService.Width = 150;
            // 
            // chRate
            // 
            this.chRate.Text = "Тариф";
            this.chRate.Width = 180;
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.btnWaybillFace);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(252, 3);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(223, 29);
            this.flowLayoutPanel3.TabIndex = 6;
            // 
            // btnWaybillFace
            // 
            this.btnWaybillFace.Enabled = false;
            this.btnWaybillFace.Location = new System.Drawing.Point(3, 3);
            this.btnWaybillFace.Name = "btnWaybillFace";
            this.btnWaybillFace.Size = new System.Drawing.Size(211, 23);
            this.btnWaybillFace.TabIndex = 0;
            this.btnWaybillFace.Text = "Сформировать путевой лист";
            this.btnWaybillFace.UseVisualStyleBackColor = true;
            this.btnWaybillFace.Click += new System.EventHandler(this.btnWaybillFace_Click);
            // 
            // WaybillTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 557);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "WaybillTableForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Путевые листы";
            this.Load += new System.EventHandler(this.WaybillTableForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnAppend;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ListView lvTable;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chIssueDate;
        private System.Windows.Forms.ColumnHeader chStateNumber;
        private System.Windows.Forms.ColumnHeader chOrder;
        private System.Windows.Forms.ColumnHeader chDepartureDateTime;
        private System.Windows.Forms.ColumnHeader chReturnDateTime;
        private System.Windows.Forms.ColumnHeader chDrivingTime;
        private System.Windows.Forms.ColumnHeader chService;
        private System.Windows.Forms.ColumnHeader chRate;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Button btnWaybillFace;
    }
}