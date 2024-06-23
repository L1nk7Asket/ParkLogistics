namespace CargoTransportation
{
    partial class MenuUC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuUC));
            this.flpMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTransportVehicleFilesMenu = new System.Windows.Forms.Button();
            this.btnWaybillsMenu = new System.Windows.Forms.Button();
            this.btnPaymentToDriversMenu = new System.Windows.Forms.Button();
            this.btnReports = new System.Windows.Forms.Button();
            this.flpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpMenu
            // 
            this.flpMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.flpMenu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flpMenu.Controls.Add(this.btnTransportVehicleFilesMenu);
            this.flpMenu.Controls.Add(this.btnWaybillsMenu);
            this.flpMenu.Controls.Add(this.btnPaymentToDriversMenu);
            this.flpMenu.Controls.Add(this.btnReports);
            this.flpMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpMenu.Location = new System.Drawing.Point(0, 0);
            this.flpMenu.Name = "flpMenu";
            this.flpMenu.Size = new System.Drawing.Size(267, 397);
            this.flpMenu.TabIndex = 7;
            // 
            // btnTransportVehicleFilesMenu
            // 
            this.btnTransportVehicleFilesMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnTransportVehicleFilesMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnTransportVehicleFilesMenu.FlatAppearance.BorderSize = 0;
            this.btnTransportVehicleFilesMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTransportVehicleFilesMenu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnTransportVehicleFilesMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnTransportVehicleFilesMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnTransportVehicleFilesMenu.Image")));
            this.btnTransportVehicleFilesMenu.ImageAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.btnTransportVehicleFilesMenu.Location = new System.Drawing.Point(20, 20);
            this.btnTransportVehicleFilesMenu.Margin = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.btnTransportVehicleFilesMenu.Name = "btnTransportVehicleFilesMenu";
            this.btnTransportVehicleFilesMenu.Size = new System.Drawing.Size(247, 100);
            this.btnTransportVehicleFilesMenu.TabIndex = 1;
            this.btnTransportVehicleFilesMenu.Text = "Список транспортных средств";
            this.btnTransportVehicleFilesMenu.UseVisualStyleBackColor = false;
            this.btnTransportVehicleFilesMenu.Click += new System.EventHandler(this.btnTransportVehicleFilesMenu_Click);
            // 
            // btnWaybillsMenu
            // 
            this.btnWaybillsMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWaybillsMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnWaybillsMenu.FlatAppearance.BorderSize = 0;
            this.btnWaybillsMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaybillsMenu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnWaybillsMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnWaybillsMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnWaybillsMenu.Image")));
            this.btnWaybillsMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWaybillsMenu.Location = new System.Drawing.Point(20, 140);
            this.btnWaybillsMenu.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnWaybillsMenu.Name = "btnWaybillsMenu";
            this.btnWaybillsMenu.Size = new System.Drawing.Size(247, 40);
            this.btnWaybillsMenu.TabIndex = 1;
            this.btnWaybillsMenu.Text = "Путевые листы";
            this.btnWaybillsMenu.UseVisualStyleBackColor = false;
            this.btnWaybillsMenu.Click += new System.EventHandler(this.btnWaybillsMenu_Click);
            // 
            // btnPaymentToDriversMenu
            // 
            this.btnPaymentToDriversMenu.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPaymentToDriversMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnPaymentToDriversMenu.FlatAppearance.BorderSize = 0;
            this.btnPaymentToDriversMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentToDriversMenu.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPaymentToDriversMenu.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnPaymentToDriversMenu.Image = ((System.Drawing.Image)(resources.GetObject("btnPaymentToDriversMenu.Image")));
            this.btnPaymentToDriversMenu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPaymentToDriversMenu.Location = new System.Drawing.Point(20, 200);
            this.btnPaymentToDriversMenu.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnPaymentToDriversMenu.Name = "btnPaymentToDriversMenu";
            this.btnPaymentToDriversMenu.Size = new System.Drawing.Size(247, 40);
            this.btnPaymentToDriversMenu.TabIndex = 1;
            this.btnPaymentToDriversMenu.Text = "Оплата водителям";
            this.btnPaymentToDriversMenu.UseVisualStyleBackColor = false;
            this.btnPaymentToDriversMenu.Click += new System.EventHandler(this.btnPaymentToDriversMenu_Click);
            // 
            // btnReports
            // 
            this.btnReports.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnReports.FlatAppearance.BorderSize = 0;
            this.btnReports.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReports.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnReports.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnReports.Image = ((System.Drawing.Image)(resources.GetObject("btnReports.Image")));
            this.btnReports.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnReports.Location = new System.Drawing.Point(20, 260);
            this.btnReports.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(247, 40);
            this.btnReports.TabIndex = 1;
            this.btnReports.Text = "Отчёты";
            this.btnReports.UseVisualStyleBackColor = false;
            this.btnReports.Click += new System.EventHandler(this.btnReports_Click);
            // 
            // MenuUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Controls.Add(this.flpMenu);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "MenuUC";
            this.Size = new System.Drawing.Size(267, 397);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.flpMenu_Paint);
            this.flpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpMenu;
        private System.Windows.Forms.Button btnTransportVehicleFilesMenu;
        private System.Windows.Forms.Button btnWaybillsMenu;
        private System.Windows.Forms.Button btnPaymentToDriversMenu;
        private System.Windows.Forms.Button btnReports;
    }
}
