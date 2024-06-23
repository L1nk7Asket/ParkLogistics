namespace CargoTransportation
{
    partial class WaybillsUC
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.flpWaybills = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOrganizations = new System.Windows.Forms.Button();
            this.btnRoutes = new System.Windows.Forms.Button();
            this.btnRates = new System.Windows.Forms.Button();
            this.btnServices = new System.Windows.Forms.Button();
            this.btnOrders = new System.Windows.Forms.Button();
            this.btnWaybills = new System.Windows.Forms.Button();
            this.flpWaybills.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpWaybills
            // 
            this.flpWaybills.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.flpWaybills.Controls.Add(this.btnOrganizations);
            this.flpWaybills.Controls.Add(this.btnRoutes);
            this.flpWaybills.Controls.Add(this.btnRates);
            this.flpWaybills.Controls.Add(this.btnServices);
            this.flpWaybills.Controls.Add(this.btnOrders);
            this.flpWaybills.Controls.Add(this.btnWaybills);
            this.flpWaybills.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpWaybills.Location = new System.Drawing.Point(0, 0);
            this.flpWaybills.Name = "flpWaybills";
            this.flpWaybills.Size = new System.Drawing.Size(267, 397);
            this.flpWaybills.TabIndex = 9;
            // 
            // btnOrganizations
            // 
            this.btnOrganizations.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOrganizations.BackColor = System.Drawing.Color.Tomato;
            this.btnOrganizations.FlatAppearance.BorderSize = 0;
            this.btnOrganizations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrganizations.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnOrganizations.ForeColor = System.Drawing.Color.Snow;
            this.btnOrganizations.Location = new System.Drawing.Point(20, 20);
            this.btnOrganizations.Margin = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.btnOrganizations.Name = "btnOrganizations";
            this.btnOrganizations.Size = new System.Drawing.Size(221, 40);
            this.btnOrganizations.TabIndex = 1;
            this.btnOrganizations.Text = "Организации";
            this.btnOrganizations.UseVisualStyleBackColor = false;
            this.btnOrganizations.Click += new System.EventHandler(this.btnOrganizations_Click);
            // 
            // btnRoutes
            // 
            this.btnRoutes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRoutes.BackColor = System.Drawing.Color.Tomato;
            this.btnRoutes.FlatAppearance.BorderSize = 0;
            this.btnRoutes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRoutes.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnRoutes.ForeColor = System.Drawing.Color.Snow;
            this.btnRoutes.Location = new System.Drawing.Point(20, 80);
            this.btnRoutes.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnRoutes.Name = "btnRoutes";
            this.btnRoutes.Size = new System.Drawing.Size(221, 40);
            this.btnRoutes.TabIndex = 1;
            this.btnRoutes.Text = "Маршруты";
            this.btnRoutes.UseVisualStyleBackColor = false;
            this.btnRoutes.Click += new System.EventHandler(this.btnRoutes_Click);
            // 
            // btnRates
            // 
            this.btnRates.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRates.BackColor = System.Drawing.Color.Tomato;
            this.btnRates.FlatAppearance.BorderSize = 0;
            this.btnRates.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRates.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnRates.ForeColor = System.Drawing.Color.Snow;
            this.btnRates.Location = new System.Drawing.Point(20, 140);
            this.btnRates.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnRates.Name = "btnRates";
            this.btnRates.Size = new System.Drawing.Size(221, 40);
            this.btnRates.TabIndex = 1;
            this.btnRates.Text = "Тарифы";
            this.btnRates.UseVisualStyleBackColor = false;
            this.btnRates.Click += new System.EventHandler(this.btnRates_Click);
            // 
            // btnServices
            // 
            this.btnServices.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnServices.BackColor = System.Drawing.Color.Tomato;
            this.btnServices.FlatAppearance.BorderSize = 0;
            this.btnServices.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnServices.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnServices.ForeColor = System.Drawing.Color.Snow;
            this.btnServices.Location = new System.Drawing.Point(20, 200);
            this.btnServices.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnServices.Name = "btnServices";
            this.btnServices.Size = new System.Drawing.Size(221, 40);
            this.btnServices.TabIndex = 1;
            this.btnServices.Text = "Услуги";
            this.btnServices.UseVisualStyleBackColor = false;
            this.btnServices.Click += new System.EventHandler(this.btnServices_Click);
            // 
            // btnOrders
            // 
            this.btnOrders.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOrders.BackColor = System.Drawing.Color.Tomato;
            this.btnOrders.FlatAppearance.BorderSize = 0;
            this.btnOrders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOrders.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnOrders.ForeColor = System.Drawing.Color.Snow;
            this.btnOrders.Location = new System.Drawing.Point(20, 260);
            this.btnOrders.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnOrders.Name = "btnOrders";
            this.btnOrders.Size = new System.Drawing.Size(221, 40);
            this.btnOrders.TabIndex = 1;
            this.btnOrders.Text = "Заказы";
            this.btnOrders.UseVisualStyleBackColor = false;
            this.btnOrders.Click += new System.EventHandler(this.btnOrders_Click);
            // 
            // btnWaybills
            // 
            this.btnWaybills.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWaybills.BackColor = System.Drawing.Color.Tomato;
            this.btnWaybills.FlatAppearance.BorderSize = 0;
            this.btnWaybills.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaybills.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnWaybills.ForeColor = System.Drawing.Color.Snow;
            this.btnWaybills.Location = new System.Drawing.Point(20, 320);
            this.btnWaybills.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnWaybills.Name = "btnWaybills";
            this.btnWaybills.Size = new System.Drawing.Size(221, 40);
            this.btnWaybills.TabIndex = 1;
            this.btnWaybills.Text = "Путевые листы";
            this.btnWaybills.UseVisualStyleBackColor = false;
            this.btnWaybills.Click += new System.EventHandler(this.btnWaybills_Click);
            // 
            // WaybillsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpWaybills);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "WaybillsUC";
            this.Size = new System.Drawing.Size(267, 397);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.WaybillsUC_Paint);
            this.flpWaybills.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpWaybills;
        private System.Windows.Forms.Button btnOrganizations;
        private System.Windows.Forms.Button btnRoutes;
        private System.Windows.Forms.Button btnRates;
        private System.Windows.Forms.Button btnServices;
        private System.Windows.Forms.Button btnOrders;
        private System.Windows.Forms.Button btnWaybills;
    }
}
