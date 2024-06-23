namespace CargoTransportation
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tsslMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.tspbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbBack = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.miDatabase = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTuningConnection = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.miTools = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiTransportVehicleTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiTransportVehicleBrands = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDriverCards = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFuels = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDivisions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiTransportVehicles = new System.Windows.Forms.ToolStripMenuItem();
            this.miWaybills = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiOrganizations = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoutes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRates = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiServices = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiOrders = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiWaybills = new System.Windows.Forms.ToolStripMenuItem();
            this.miPayments = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiPaymentTypes = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiPayments = new System.Windows.Forms.ToolStripMenuItem();
            this.miReports = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiReport1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReport2 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReport3 = new System.Windows.Forms.ToolStripMenuItem();
            this.backControlTimer = new System.Windows.Forms.Timer(this.components);
            this.loginTimer = new System.Windows.Forms.Timer(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1229, 427);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.RightToolStripPanelVisible = false;
            this.toolStripContainer1.Size = new System.Drawing.Size(1229, 474);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMessage,
            this.tspbProgress});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1229, 22);
            this.statusStrip1.TabIndex = 0;
            // 
            // tsslMessage
            // 
            this.tsslMessage.Name = "tsslMessage";
            this.tsslMessage.Size = new System.Drawing.Size(16, 17);
            this.tsslMessage.Text = "...";
            // 
            // tspbProgress
            // 
            this.tspbProgress.Name = "tspbProgress";
            this.tspbProgress.Size = new System.Drawing.Size(500, 16);
            this.tspbProgress.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.tspbProgress.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 267F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.pnlMenu, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1229, 427);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoScroll = true;
            this.pnlMenu.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMenu.Enabled = false;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Margin = new System.Windows.Forms.Padding(0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(267, 427);
            this.pnlMenu.TabIndex = 1;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Location = new System.Drawing.Point(267, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(962, 25);
            this.toolStrip2.TabIndex = 2;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBack,
            this.toolStripSeparator1,
            this.miDatabase,
            this.miTools,
            this.miWaybills,
            this.miPayments,
            this.miReports});
            this.toolStrip1.Location = new System.Drawing.Point(3, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(496, 25);
            this.toolStrip1.TabIndex = 0;
            // 
            // tsbBack
            // 
            this.tsbBack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbBack.Image = global::CargoTransportation.Properties.Resources.undo;
            this.tsbBack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBack.Name = "tsbBack";
            this.tsbBack.Size = new System.Drawing.Size(23, 22);
            this.tsbBack.Text = "Назад";
            this.tsbBack.Click += new System.EventHandler(this.tsbBack_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // miDatabase
            // 
            this.miDatabase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miDatabase.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLogin,
            this.tsmiTuningConnection,
            this.toolStripMenuItem1,
            this.tsmiExit});
            this.miDatabase.Image = ((System.Drawing.Image)(resources.GetObject("miDatabase.Image")));
            this.miDatabase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miDatabase.Name = "miDatabase";
            this.miDatabase.Size = new System.Drawing.Size(88, 22);
            this.miDatabase.Text = "База данных";
            this.miDatabase.Click += new System.EventHandler(this.miDatabase_Click);
            // 
            // tsmiLogin
            // 
            this.tsmiLogin.Name = "tsmiLogin";
            this.tsmiLogin.Size = new System.Drawing.Size(221, 22);
            this.tsmiLogin.Text = "Вход в систему...";
            this.tsmiLogin.Click += new System.EventHandler(this.tsmiLogin_Click);
            // 
            // tsmiTuningConnection
            // 
            this.tsmiTuningConnection.Name = "tsmiTuningConnection";
            this.tsmiTuningConnection.Size = new System.Drawing.Size(221, 22);
            this.tsmiTuningConnection.Text = "Настройка подключения...";
            this.tsmiTuningConnection.Click += new System.EventHandler(this.tsmiTuningConnection_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(218, 6);
            // 
            // tsmiExit
            // 
            this.tsmiExit.Name = "tsmiExit";
            this.tsmiExit.Size = new System.Drawing.Size(221, 22);
            this.tsmiExit.Text = "Завершение работы";
            this.tsmiExit.Click += new System.EventHandler(this.tsmiExit_Click);
            // 
            // miTools
            // 
            this.miTools.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiTransportVehicleTypes,
            this.tsmiTransportVehicleBrands,
            this.tsmiDriverCards,
            this.tsmiFuels,
            this.tsmiDivisions,
            this.toolStripMenuItem2,
            this.tsmiTransportVehicles});
            this.miTools.Image = ((System.Drawing.Image)(resources.GetObject("miTools.Image")));
            this.miTools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miTools.Name = "miTools";
            this.miTools.Size = new System.Drawing.Size(80, 22);
            this.miTools.Text = "Подбор ТС";
            this.miTools.Click += new System.EventHandler(this.miTools_Click);
            // 
            // tsmiTransportVehicleTypes
            // 
            this.tsmiTransportVehicleTypes.Name = "tsmiTransportVehicleTypes";
            this.tsmiTransportVehicleTypes.Size = new System.Drawing.Size(198, 22);
            this.tsmiTransportVehicleTypes.Text = "Типы ТС";
            this.tsmiTransportVehicleTypes.Click += new System.EventHandler(this.tsmiTransportVehicleTypes_Click);
            // 
            // tsmiTransportVehicleBrands
            // 
            this.tsmiTransportVehicleBrands.Name = "tsmiTransportVehicleBrands";
            this.tsmiTransportVehicleBrands.Size = new System.Drawing.Size(198, 22);
            this.tsmiTransportVehicleBrands.Text = "Марки ТС";
            this.tsmiTransportVehicleBrands.Click += new System.EventHandler(this.tsmiTransportVehicleBrands_Click);
            // 
            // tsmiDriverCards
            // 
            this.tsmiDriverCards.Name = "tsmiDriverCards";
            this.tsmiDriverCards.Size = new System.Drawing.Size(198, 22);
            this.tsmiDriverCards.Text = "Картотека водителей";
            this.tsmiDriverCards.Click += new System.EventHandler(this.tsmiDriverCards_Click);
            // 
            // tsmiFuels
            // 
            this.tsmiFuels.Name = "tsmiFuels";
            this.tsmiFuels.Size = new System.Drawing.Size(198, 22);
            this.tsmiFuels.Text = "Топливо";
            this.tsmiFuels.Click += new System.EventHandler(this.tsmiFuels_Click);
            // 
            // tsmiDivisions
            // 
            this.tsmiDivisions.Name = "tsmiDivisions";
            this.tsmiDivisions.Size = new System.Drawing.Size(198, 22);
            this.tsmiDivisions.Text = "Подразделения";
            this.tsmiDivisions.Click += new System.EventHandler(this.tsmiDivisions_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(195, 6);
            // 
            // tsmiTransportVehicles
            // 
            this.tsmiTransportVehicles.Name = "tsmiTransportVehicles";
            this.tsmiTransportVehicles.Size = new System.Drawing.Size(198, 22);
            this.tsmiTransportVehicles.Text = "Траспортные средства";
            this.tsmiTransportVehicles.Click += new System.EventHandler(this.tsmiTransportVehicles_Click);
            // 
            // miWaybills
            // 
            this.miWaybills.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miWaybills.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOrganizations,
            this.tsmiRoutes,
            this.tsmiRates,
            this.tsmiServices,
            this.toolStripMenuItem4,
            this.tsmiOrders,
            this.tsmiWaybills});
            this.miWaybills.Image = ((System.Drawing.Image)(resources.GetObject("miWaybills.Image")));
            this.miWaybills.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miWaybills.Name = "miWaybills";
            this.miWaybills.Size = new System.Drawing.Size(104, 22);
            this.miWaybills.Text = "Путевые листы";
            this.miWaybills.Click += new System.EventHandler(this.miWaybills_Click);
            // 
            // tsmiOrganizations
            // 
            this.tsmiOrganizations.Name = "tsmiOrganizations";
            this.tsmiOrganizations.Size = new System.Drawing.Size(158, 22);
            this.tsmiOrganizations.Text = "Организации";
            this.tsmiOrganizations.Click += new System.EventHandler(this.tsmiOrganizations_Click);
            // 
            // tsmiRoutes
            // 
            this.tsmiRoutes.Name = "tsmiRoutes";
            this.tsmiRoutes.Size = new System.Drawing.Size(158, 22);
            this.tsmiRoutes.Text = "Маршруты";
            this.tsmiRoutes.Click += new System.EventHandler(this.tsmiRoutes_Click);
            // 
            // tsmiRates
            // 
            this.tsmiRates.Name = "tsmiRates";
            this.tsmiRates.Size = new System.Drawing.Size(158, 22);
            this.tsmiRates.Text = "Тарифы";
            this.tsmiRates.Click += new System.EventHandler(this.tsmiRates_Click);
            // 
            // tsmiServices
            // 
            this.tsmiServices.Name = "tsmiServices";
            this.tsmiServices.Size = new System.Drawing.Size(158, 22);
            this.tsmiServices.Text = "Услуги";
            this.tsmiServices.Click += new System.EventHandler(this.tsmiServices_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(155, 6);
            // 
            // tsmiOrders
            // 
            this.tsmiOrders.Name = "tsmiOrders";
            this.tsmiOrders.Size = new System.Drawing.Size(158, 22);
            this.tsmiOrders.Text = "Заказы";
            this.tsmiOrders.Click += new System.EventHandler(this.tsmiOrders_Click);
            // 
            // tsmiWaybills
            // 
            this.tsmiWaybills.Name = "tsmiWaybills";
            this.tsmiWaybills.Size = new System.Drawing.Size(158, 22);
            this.tsmiWaybills.Text = "Путевые листы";
            this.tsmiWaybills.Click += new System.EventHandler(this.tsmiWaybills_Click);
            // 
            // miPayments
            // 
            this.miPayments.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miPayments.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPaymentTypes,
            this.toolStripMenuItem3,
            this.tsmiPayments});
            this.miPayments.Image = ((System.Drawing.Image)(resources.GetObject("miPayments.Image")));
            this.miPayments.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miPayments.Name = "miPayments";
            this.miPayments.Size = new System.Drawing.Size(122, 22);
            this.miPayments.Text = "Оплата водителям";
            this.miPayments.Click += new System.EventHandler(this.miPayments_Click);
            // 
            // tsmiPaymentTypes
            // 
            this.tsmiPaymentTypes.Name = "tsmiPaymentTypes";
            this.tsmiPaymentTypes.Size = new System.Drawing.Size(176, 22);
            this.tsmiPaymentTypes.Text = "Виды оплат";
            this.tsmiPaymentTypes.Click += new System.EventHandler(this.tsmiPaymentTypes_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(173, 6);
            // 
            // tsmiPayments
            // 
            this.tsmiPayments.Name = "tsmiPayments";
            this.tsmiPayments.Size = new System.Drawing.Size(176, 22);
            this.tsmiPayments.Text = "Оплата водителям";
            this.tsmiPayments.Click += new System.EventHandler(this.tsmiPayments_Click);
            // 
            // miReports
            // 
            this.miReports.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.miReports.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiReport1,
            this.tsmiReport2,
            this.tsmiReport3});
            this.miReports.Image = ((System.Drawing.Image)(resources.GetObject("miReports.Image")));
            this.miReports.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.miReports.Name = "miReports";
            this.miReports.Size = new System.Drawing.Size(61, 22);
            this.miReports.Text = "Отчёты";
            this.miReports.Click += new System.EventHandler(this.miReports_Click);
            // 
            // tsmiReport1
            // 
            this.tsmiReport1.Name = "tsmiReport1";
            this.tsmiReport1.Size = new System.Drawing.Size(211, 22);
            this.tsmiReport1.Text = "Ведомость ЗП";
            this.tsmiReport1.Click += new System.EventHandler(this.tsmiReport1_Click);
            // 
            // tsmiReport2
            // 
            this.tsmiReport2.Name = "tsmiReport2";
            this.tsmiReport2.Size = new System.Drawing.Size(211, 22);
            this.tsmiReport2.Text = "Журнал регистрации ПЛ";
            this.tsmiReport2.Click += new System.EventHandler(this.tsmiReport2_Click);
            // 
            // tsmiReport3
            // 
            this.tsmiReport3.Name = "tsmiReport3";
            this.tsmiReport3.Size = new System.Drawing.Size(211, 22);
            this.tsmiReport3.Text = "Реестр по заказчикам";
            this.tsmiReport3.Click += new System.EventHandler(this.tsmiReport3_Click);
            // 
            // backControlTimer
            // 
            this.backControlTimer.Enabled = true;
            this.backControlTimer.Tick += new System.EventHandler(this.checkActionStack_Tick);
            // 
            // loginTimer
            // 
            this.loginTimer.Tick += new System.EventHandler(this.loginTimer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1229, 474);
            this.Controls.Add(this.toolStripContainer1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(1232, 513);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParKargo Logistic";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton miDatabase;
        private System.Windows.Forms.ToolStripMenuItem tsmiLogin;
        private System.Windows.Forms.ToolStripMenuItem tsmiTuningConnection;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExit;
        private System.Windows.Forms.ToolStripButton tsbBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer backControlTimer;
        private System.Windows.Forms.Timer loginTimer;
        private System.Windows.Forms.ToolStripDropDownButton miTools;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransportVehicleTypes;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransportVehicleBrands;
        private System.Windows.Forms.ToolStripMenuItem tsmiDriverCards;
        private System.Windows.Forms.ToolStripMenuItem tsmiFuels;
        private System.Windows.Forms.ToolStripMenuItem tsmiDivisions;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem tsmiTransportVehicles;
        private System.Windows.Forms.ToolStripDropDownButton miWaybills;
        private System.Windows.Forms.ToolStripDropDownButton miPayments;
        private System.Windows.Forms.ToolStripDropDownButton miReports;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport1;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport2;
        private System.Windows.Forms.ToolStripMenuItem tsmiReport3;
        private System.Windows.Forms.ToolStripMenuItem tsmiPaymentTypes;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiPayments;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrganizations;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoutes;
        private System.Windows.Forms.ToolStripMenuItem tsmiRates;
        private System.Windows.Forms.ToolStripMenuItem tsmiServices;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem tsmiOrders;
        private System.Windows.Forms.ToolStripMenuItem tsmiWaybills;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslMessage;
        private System.Windows.Forms.ToolStripProgressBar tspbProgress;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.ToolStrip toolStrip2;
    }
}