namespace CargoTransportation
{
    partial class PaymentToDriversUC
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
            this.flpPaymentToDrivers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPaymentTypes = new System.Windows.Forms.Button();
            this.btnPaymentToDrivers = new System.Windows.Forms.Button();
            this.flpPaymentToDrivers.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpPaymentToDrivers
            // 
            this.flpPaymentToDrivers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.flpPaymentToDrivers.Controls.Add(this.btnPaymentTypes);
            this.flpPaymentToDrivers.Controls.Add(this.btnPaymentToDrivers);
            this.flpPaymentToDrivers.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpPaymentToDrivers.Location = new System.Drawing.Point(0, 0);
            this.flpPaymentToDrivers.Margin = new System.Windows.Forms.Padding(0);
            this.flpPaymentToDrivers.Name = "flpPaymentToDrivers";
            this.flpPaymentToDrivers.Size = new System.Drawing.Size(267, 397);
            this.flpPaymentToDrivers.TabIndex = 10;
            // 
            // btnPaymentTypes
            // 
            this.btnPaymentTypes.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPaymentTypes.BackColor = System.Drawing.Color.Tomato;
            this.btnPaymentTypes.FlatAppearance.BorderSize = 0;
            this.btnPaymentTypes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentTypes.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPaymentTypes.ForeColor = System.Drawing.Color.Snow;
            this.btnPaymentTypes.Location = new System.Drawing.Point(20, 20);
            this.btnPaymentTypes.Margin = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.btnPaymentTypes.Name = "btnPaymentTypes";
            this.btnPaymentTypes.Size = new System.Drawing.Size(221, 40);
            this.btnPaymentTypes.TabIndex = 1;
            this.btnPaymentTypes.Text = "Виды оплат";
            this.btnPaymentTypes.UseVisualStyleBackColor = false;
            this.btnPaymentTypes.Click += new System.EventHandler(this.btnPaymentTypes_Click);
            // 
            // btnPaymentToDrivers
            // 
            this.btnPaymentToDrivers.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnPaymentToDrivers.BackColor = System.Drawing.Color.Tomato;
            this.btnPaymentToDrivers.FlatAppearance.BorderSize = 0;
            this.btnPaymentToDrivers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPaymentToDrivers.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPaymentToDrivers.ForeColor = System.Drawing.Color.Snow;
            this.btnPaymentToDrivers.Location = new System.Drawing.Point(20, 80);
            this.btnPaymentToDrivers.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnPaymentToDrivers.Name = "btnPaymentToDrivers";
            this.btnPaymentToDrivers.Size = new System.Drawing.Size(221, 40);
            this.btnPaymentToDrivers.TabIndex = 1;
            this.btnPaymentToDrivers.Text = "Оплата водителям";
            this.btnPaymentToDrivers.UseVisualStyleBackColor = false;
            this.btnPaymentToDrivers.Click += new System.EventHandler(this.btnPaymentToDrivers_Click);
            // 
            // PaymentToDriversUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpPaymentToDrivers);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "PaymentToDriversUC";
            this.Size = new System.Drawing.Size(267, 397);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.PaymentToDriversUC_Paint);
            this.flpPaymentToDrivers.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpPaymentToDrivers;
        private System.Windows.Forms.Button btnPaymentTypes;
        private System.Windows.Forms.Button btnPaymentToDrivers;
    }
}
