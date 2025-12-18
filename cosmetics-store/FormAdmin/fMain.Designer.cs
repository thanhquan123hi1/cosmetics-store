namespace cosmetics_store.Forms
{
    partial class fMain
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
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.topMenuPanel = new System.Windows.Forms.Panel();
            this.flowMenu = new System.Windows.Forms.FlowLayoutPanel();
            this.btnTrangChu = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnDoiTac = new System.Windows.Forms.Button();
            this.btnNhanSu = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.contentContainer = new System.Windows.Forms.Panel();
            this.pnlReports = new System.Windows.Forms.Panel();
            this.lblReports = new System.Windows.Forms.Label();
            this.pnlPOS = new System.Windows.Forms.Panel();
            this.lblPOS = new System.Windows.Forms.Label();
            this.pnlStaff = new System.Windows.Forms.Panel();
            this.lblStaff = new System.Windows.Forms.Label();
            this.pnlSuppliers = new System.Windows.Forms.Panel();
            this.lblSuppliers = new System.Windows.Forms.Label();
            this.pnlProducts = new System.Windows.Forms.Panel();
            this.lblProducts = new System.Windows.Forms.Label();
            this.pnlDashboard = new System.Windows.Forms.Panel();
            this.lblDash = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            this.topMenuPanel.SuspendLayout();
            this.flowMenu.SuspendLayout();
            this.contentContainer.SuspendLayout();
            this.pnlReports.SuspendLayout();
            this.pnlPOS.SuspendLayout();
            this.pnlStaff.SuspendLayout();
            this.pnlSuppliers.SuspendLayout();
            this.pnlProducts.SuspendLayout();
            this.pnlDashboard.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(139);
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.Margin = new System.Windows.Forms.Padding(15);
            this.ribbon.MaxItemId = 1;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsMenuMinWidth = 1571;
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.Size = new System.Drawing.Size(900, 193);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Click += new System.EventHandler(this.ribbon_Click);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "ribbonPage1";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 575);
            this.ribbonStatusBar.Margin = new System.Windows.Forms.Padding(15);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(900, 30);
            // 
            // topMenuPanel
            // 
            this.topMenuPanel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.topMenuPanel.Controls.Add(this.flowMenu);
            this.topMenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topMenuPanel.Location = new System.Drawing.Point(0, 193);
            this.topMenuPanel.Name = "topMenuPanel";
            this.topMenuPanel.Size = new System.Drawing.Size(900, 40);
            this.topMenuPanel.TabIndex = 2;
            // 
            // flowMenu
            // 
            this.flowMenu.Controls.Add(this.btnTrangChu);
            this.flowMenu.Controls.Add(this.btnBanHang);
            this.flowMenu.Controls.Add(this.btnSanPham);
            this.flowMenu.Controls.Add(this.btnDoiTac);
            this.flowMenu.Controls.Add(this.btnNhanSu);
            this.flowMenu.Controls.Add(this.btnBaoCao);
            this.flowMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowMenu.Location = new System.Drawing.Point(0, 0);
            this.flowMenu.Name = "flowMenu";
            this.flowMenu.Padding = new System.Windows.Forms.Padding(8);
            this.flowMenu.Size = new System.Drawing.Size(900, 40);
            this.flowMenu.TabIndex = 0;
            this.flowMenu.WrapContents = false;
            // 
            // btnTrangChu
            // 
            this.btnTrangChu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTrangChu.Location = new System.Drawing.Point(11, 11);
            this.btnTrangChu.Name = "btnTrangChu";
            this.btnTrangChu.Size = new System.Drawing.Size(100, 24);
            this.btnTrangChu.TabIndex = 0;
            this.btnTrangChu.Text = "Trang chu";
            this.btnTrangChu.Click += new System.EventHandler(this.btnTrangChu_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.Location = new System.Drawing.Point(117, 11);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(100, 24);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "Ban hang";
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Location = new System.Drawing.Point(223, 11);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(100, 24);
            this.btnSanPham.TabIndex = 2;
            this.btnSanPham.Text = "San pham";
            // 
            // btnDoiTac
            // 
            this.btnDoiTac.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiTac.Location = new System.Drawing.Point(329, 11);
            this.btnDoiTac.Name = "btnDoiTac";
            this.btnDoiTac.Size = new System.Drawing.Size(100, 24);
            this.btnDoiTac.TabIndex = 3;
            this.btnDoiTac.Text = "Doi tac";
            // 
            // btnNhanSu
            // 
            this.btnNhanSu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanSu.Location = new System.Drawing.Point(435, 11);
            this.btnNhanSu.Name = "btnNhanSu";
            this.btnNhanSu.Size = new System.Drawing.Size(100, 24);
            this.btnNhanSu.TabIndex = 4;
            this.btnNhanSu.Text = "Nhan su";
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Location = new System.Drawing.Point(541, 11);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(100, 24);
            this.btnBaoCao.TabIndex = 5;
            this.btnBaoCao.Text = "Bao cao";
            // 
            // contentContainer
            // 
            this.contentContainer.Controls.Add(this.pnlReports);
            this.contentContainer.Controls.Add(this.pnlPOS);
            this.contentContainer.Controls.Add(this.pnlStaff);
            this.contentContainer.Controls.Add(this.pnlSuppliers);
            this.contentContainer.Controls.Add(this.pnlProducts);
            this.contentContainer.Controls.Add(this.pnlDashboard);
            this.contentContainer.Location = new System.Drawing.Point(0, 233);
            this.contentContainer.Name = "contentContainer";
            this.contentContainer.Size = new System.Drawing.Size(900, 342);
            this.contentContainer.TabIndex = 3;
            // 
            // pnlReports
            // 
            this.pnlReports.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlReports.Controls.Add(this.lblReports);
            this.pnlReports.Location = new System.Drawing.Point(0, 0);
            this.pnlReports.Name = "pnlReports";
            this.pnlReports.Size = new System.Drawing.Size(900, 342);
            this.pnlReports.TabIndex = 0;
            this.pnlReports.Visible = false;
            // 
            // lblReports
            // 
            this.lblReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblReports.Location = new System.Drawing.Point(0, 0);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(900, 342);
            this.lblReports.TabIndex = 0;
            this.lblReports.Text = "Reports - placeholder";
            this.lblReports.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblReports.Click += new System.EventHandler(this.lblReports_Click);
            // 
            // pnlPOS
            // 
            this.pnlPOS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlPOS.Controls.Add(this.lblPOS);
            this.pnlPOS.Location = new System.Drawing.Point(0, 0);
            this.pnlPOS.Name = "pnlPOS";
            this.pnlPOS.Size = new System.Drawing.Size(900, 342);
            this.pnlPOS.TabIndex = 1;
            this.pnlPOS.Visible = false;
            // 
            // lblPOS
            // 
            this.lblPOS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPOS.Location = new System.Drawing.Point(0, 0);
            this.lblPOS.Name = "lblPOS";
            this.lblPOS.Size = new System.Drawing.Size(900, 342);
            this.lblPOS.TabIndex = 0;
            this.lblPOS.Text = "POS - placeholder";
            this.lblPOS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStaff
            // 
            this.pnlStaff.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlStaff.Controls.Add(this.lblStaff);
            this.pnlStaff.Location = new System.Drawing.Point(0, 0);
            this.pnlStaff.Name = "pnlStaff";
            this.pnlStaff.Size = new System.Drawing.Size(900, 342);
            this.pnlStaff.TabIndex = 2;
            this.pnlStaff.Visible = false;
            // 
            // lblStaff
            // 
            this.lblStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStaff.Location = new System.Drawing.Point(0, 0);
            this.lblStaff.Name = "lblStaff";
            this.lblStaff.Size = new System.Drawing.Size(900, 342);
            this.lblStaff.TabIndex = 0;
            this.lblStaff.Text = "Staff - placeholder";
            this.lblStaff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSuppliers
            // 
            this.pnlSuppliers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlSuppliers.Controls.Add(this.lblSuppliers);
            this.pnlSuppliers.Location = new System.Drawing.Point(0, 0);
            this.pnlSuppliers.Name = "pnlSuppliers";
            this.pnlSuppliers.Size = new System.Drawing.Size(900, 342);
            this.pnlSuppliers.TabIndex = 3;
            this.pnlSuppliers.Visible = false;
            // 
            // lblSuppliers
            // 
            this.lblSuppliers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSuppliers.Location = new System.Drawing.Point(0, 0);
            this.lblSuppliers.Name = "lblSuppliers";
            this.lblSuppliers.Size = new System.Drawing.Size(900, 342);
            this.lblSuppliers.TabIndex = 0;
            this.lblSuppliers.Text = "Suppliers - placeholder";
            this.lblSuppliers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProducts
            // 
            this.pnlProducts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlProducts.Controls.Add(this.lblProducts);
            this.pnlProducts.Location = new System.Drawing.Point(0, 0);
            this.pnlProducts.Name = "pnlProducts";
            this.pnlProducts.Size = new System.Drawing.Size(900, 342);
            this.pnlProducts.TabIndex = 4;
            this.pnlProducts.Visible = false;
            // 
            // lblProducts
            // 
            this.lblProducts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblProducts.Location = new System.Drawing.Point(0, 0);
            this.lblProducts.Name = "lblProducts";
            this.lblProducts.Size = new System.Drawing.Size(900, 342);
            this.lblProducts.TabIndex = 0;
            this.lblProducts.Text = "Products - placeholder";
            this.lblProducts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlDashboard
            // 
            this.pnlDashboard.BackColor = System.Drawing.Color.White;
            this.pnlDashboard.Controls.Add(this.lblDash);
            this.pnlDashboard.Location = new System.Drawing.Point(0, 0);
            this.pnlDashboard.Name = "pnlDashboard";
            this.pnlDashboard.Size = new System.Drawing.Size(900, 342);
            this.pnlDashboard.TabIndex = 5;
            // 
            // lblDash
            // 
            this.lblDash.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDash.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDash.Location = new System.Drawing.Point(0, 0);
            this.lblDash.Name = "lblDash";
            this.lblDash.Size = new System.Drawing.Size(900, 342);
            this.lblDash.TabIndex = 0;
            this.lblDash.Text = "Dashboard - placeholder";
            this.lblDash.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 605);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.contentContainer);
            this.Controls.Add(this.topMenuPanel);
            this.Controls.Add(this.ribbon);
            this.Name = "MainForm";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            this.topMenuPanel.ResumeLayout(false);
            this.flowMenu.ResumeLayout(false);
            this.contentContainer.ResumeLayout(false);
            this.pnlReports.ResumeLayout(false);
            this.pnlPOS.ResumeLayout(false);
            this.pnlStaff.ResumeLayout(false);
            this.pnlSuppliers.ResumeLayout(false);
            this.pnlProducts.ResumeLayout(false);
            this.pnlDashboard.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel topMenuPanel;
        private System.Windows.Forms.FlowLayoutPanel flowMenu;
        private System.Windows.Forms.Button btnTrangChu;
        private System.Windows.Forms.Button btnBanHang;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnDoiTac;
        private System.Windows.Forms.Button btnNhanSu;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Panel contentContainer;
        private System.Windows.Forms.Panel pnlDashboard;
        private System.Windows.Forms.Panel pnlProducts;
        private System.Windows.Forms.Panel pnlSuppliers;
        private System.Windows.Forms.Panel pnlStaff;
        private System.Windows.Forms.Panel pnlPOS;
        private System.Windows.Forms.Panel pnlReports;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Label lblPOS;
        private System.Windows.Forms.Label lblStaff;
        private System.Windows.Forms.Label lblSuppliers;
        private System.Windows.Forms.Label lblProducts;
        private System.Windows.Forms.Label lblDash;
    }
}