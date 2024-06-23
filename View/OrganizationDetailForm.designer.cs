namespace CargoTransportationView
{
    partial class OrganizationDetailForm
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
            this.lbName = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lbDirectorName = new System.Windows.Forms.Label();
            this.tbDirectorName = new System.Windows.Forms.TextBox();
            this.lbIndividualTaxNumber = new System.Windows.Forms.Label();
            this.tbIndividualTaxNumber = new System.Windows.Forms.TextBox();
            this.lbContactDetails = new System.Windows.Forms.Label();
            this.tbContactDetails = new System.Windows.Forms.TextBox();
            this.flpButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
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
            this.tableLayoutPanel1.Controls.Add(this.lbName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tbName, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbDirectorName, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tbDirectorName, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbIndividualTaxNumber, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.tbIndividualTaxNumber, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbContactDetails, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbContactDetails, 2, 4);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(675, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbName
            // 
            this.lbName.AutoSize = true;
            this.lbName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbName.Location = new System.Drawing.Point(15, 13);
            this.lbName.Name = "lbName";
            this.lbName.Size = new System.Drawing.Size(167, 29);
            this.lbName.TabIndex = 0;
            this.lbName.Text = "Наименование организации:";
            this.lbName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbName
            // 
            this.tbName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbName.Location = new System.Drawing.Point(188, 16);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(469, 23);
            this.tbName.TabIndex = 0;
            this.tbName.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbDirectorName
            // 
            this.lbDirectorName.AutoSize = true;
            this.lbDirectorName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDirectorName.Location = new System.Drawing.Point(15, 42);
            this.lbDirectorName.Name = "lbDirectorName";
            this.lbDirectorName.Size = new System.Drawing.Size(167, 29);
            this.lbDirectorName.TabIndex = 1;
            this.lbDirectorName.Text = "Ф.И.О. руководителя:";
            this.lbDirectorName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDirectorName
            // 
            this.tbDirectorName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbDirectorName.Location = new System.Drawing.Point(188, 45);
            this.tbDirectorName.Name = "tbDirectorName";
            this.tbDirectorName.Size = new System.Drawing.Size(306, 23);
            this.tbDirectorName.TabIndex = 1;
            this.tbDirectorName.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbIndividualTaxNumber
            // 
            this.lbIndividualTaxNumber.AutoSize = true;
            this.lbIndividualTaxNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbIndividualTaxNumber.Location = new System.Drawing.Point(15, 71);
            this.lbIndividualTaxNumber.Name = "lbIndividualTaxNumber";
            this.lbIndividualTaxNumber.Size = new System.Drawing.Size(167, 29);
            this.lbIndividualTaxNumber.TabIndex = 2;
            this.lbIndividualTaxNumber.Text = "ИНН:";
            this.lbIndividualTaxNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbIndividualTaxNumber
            // 
            this.tbIndividualTaxNumber.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbIndividualTaxNumber.Location = new System.Drawing.Point(188, 74);
            this.tbIndividualTaxNumber.Name = "tbIndividualTaxNumber";
            this.tbIndividualTaxNumber.Size = new System.Drawing.Size(126, 23);
            this.tbIndividualTaxNumber.TabIndex = 2;
            this.tbIndividualTaxNumber.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // lbContactDetails
            // 
            this.lbContactDetails.AutoSize = true;
            this.lbContactDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbContactDetails.Location = new System.Drawing.Point(15, 100);
            this.lbContactDetails.Name = "lbContactDetails";
            this.lbContactDetails.Size = new System.Drawing.Size(167, 29);
            this.lbContactDetails.TabIndex = 3;
            this.lbContactDetails.Text = "Контактные данные:";
            this.lbContactDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbContactDetails
            // 
            this.tbContactDetails.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbContactDetails.Location = new System.Drawing.Point(188, 103);
            this.tbContactDetails.Name = "tbContactDetails";
            this.tbContactDetails.Size = new System.Drawing.Size(472, 23);
            this.tbContactDetails.TabIndex = 3;
            this.tbContactDetails.TextChanged += new System.EventHandler(this.tbControl_TextChanged);
            // 
            // flpButtonPanel
            // 
            this.flpButtonPanel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.flpButtonPanel, 2);
            this.flpButtonPanel.Controls.Add(this.btnOk);
            this.flpButtonPanel.Controls.Add(this.btnCancel);
            this.flpButtonPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.flpButtonPanel.Location = new System.Drawing.Point(480, 132);
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
            // OrganizationDetailForm
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(675, 180);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OrganizationDetailForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Организация";
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
        private System.Windows.Forms.Label lbName;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lbDirectorName;
        private System.Windows.Forms.TextBox tbDirectorName;
        private System.Windows.Forms.Label lbIndividualTaxNumber;
        private System.Windows.Forms.TextBox tbIndividualTaxNumber;
        private System.Windows.Forms.Label lbContactDetails;
        private System.Windows.Forms.TextBox tbContactDetails;
    }
}
