namespace CargoTransportation
{
    partial class ReportsUC
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
            this.flpReports = new System.Windows.Forms.FlowLayoutPanel();
            this.btnSalaryStatement = new System.Windows.Forms.Button();
            this.btnWaybillsRegistrationJournal = new System.Windows.Forms.Button();
            this.btnCustomersRegister = new System.Windows.Forms.Button();
            this.flpReports.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpReports
            // 
            this.flpReports.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.flpReports.Controls.Add(this.btnSalaryStatement);
            this.flpReports.Controls.Add(this.btnWaybillsRegistrationJournal);
            this.flpReports.Controls.Add(this.btnCustomersRegister);
            this.flpReports.Dock = System.Windows.Forms.DockStyle.Left;
            this.flpReports.Location = new System.Drawing.Point(0, 0);
            this.flpReports.Margin = new System.Windows.Forms.Padding(0);
            this.flpReports.Name = "flpReports";
            this.flpReports.Size = new System.Drawing.Size(267, 397);
            this.flpReports.TabIndex = 11;
            // 
            // btnSalaryStatement
            // 
            this.btnSalaryStatement.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSalaryStatement.BackColor = System.Drawing.Color.Tomato;
            this.btnSalaryStatement.FlatAppearance.BorderSize = 0;
            this.btnSalaryStatement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSalaryStatement.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnSalaryStatement.ForeColor = System.Drawing.Color.Snow;
            this.btnSalaryStatement.Location = new System.Drawing.Point(20, 20);
            this.btnSalaryStatement.Margin = new System.Windows.Forms.Padding(20, 20, 20, 10);
            this.btnSalaryStatement.Name = "btnSalaryStatement";
            this.btnSalaryStatement.Size = new System.Drawing.Size(227, 40);
            this.btnSalaryStatement.TabIndex = 1;
            this.btnSalaryStatement.Text = "Ведомость ЗП";
            this.btnSalaryStatement.UseVisualStyleBackColor = false;
            this.btnSalaryStatement.Click += new System.EventHandler(this.btnSalaryStatement_Click);
            // 
            // btnWaybillsRegistrationJournal
            // 
            this.btnWaybillsRegistrationJournal.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnWaybillsRegistrationJournal.BackColor = System.Drawing.Color.Tomato;
            this.btnWaybillsRegistrationJournal.FlatAppearance.BorderSize = 0;
            this.btnWaybillsRegistrationJournal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWaybillsRegistrationJournal.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnWaybillsRegistrationJournal.ForeColor = System.Drawing.Color.Snow;
            this.btnWaybillsRegistrationJournal.Location = new System.Drawing.Point(20, 80);
            this.btnWaybillsRegistrationJournal.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnWaybillsRegistrationJournal.Name = "btnWaybillsRegistrationJournal";
            this.btnWaybillsRegistrationJournal.Size = new System.Drawing.Size(227, 67);
            this.btnWaybillsRegistrationJournal.TabIndex = 1;
            this.btnWaybillsRegistrationJournal.Text = "Журнал регистрации путевых листов ";
            this.btnWaybillsRegistrationJournal.UseVisualStyleBackColor = false;
            this.btnWaybillsRegistrationJournal.Click += new System.EventHandler(this.btnWaybillsRegistrationJournal_Click);
            // 
            // btnCustomersRegister
            // 
            this.btnCustomersRegister.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCustomersRegister.BackColor = System.Drawing.Color.Tomato;
            this.btnCustomersRegister.FlatAppearance.BorderSize = 0;
            this.btnCustomersRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCustomersRegister.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCustomersRegister.ForeColor = System.Drawing.Color.Snow;
            this.btnCustomersRegister.Location = new System.Drawing.Point(20, 167);
            this.btnCustomersRegister.Margin = new System.Windows.Forms.Padding(20, 10, 20, 10);
            this.btnCustomersRegister.Name = "btnCustomersRegister";
            this.btnCustomersRegister.Size = new System.Drawing.Size(227, 40);
            this.btnCustomersRegister.TabIndex = 1;
            this.btnCustomersRegister.Text = "Реестр по заказчикам";
            this.btnCustomersRegister.UseVisualStyleBackColor = false;
            this.btnCustomersRegister.Click += new System.EventHandler(this.btnCustomersRegister_Click);
            // 
            // ReportsUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flpReports);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ReportsUC";
            this.Size = new System.Drawing.Size(267, 397);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ReportsUC_Paint);
            this.flpReports.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpReports;
        private System.Windows.Forms.Button btnSalaryStatement;
        private System.Windows.Forms.Button btnWaybillsRegistrationJournal;
        private System.Windows.Forms.Button btnCustomersRegister;
    }
}
