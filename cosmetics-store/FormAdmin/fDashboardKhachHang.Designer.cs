namespace cosmetics_store.Forms
{
    partial class fDashboardKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.SimpleButton btnDangXuat;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionMenu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDashboard;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceSanPham;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDonHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceThongTin;
        private System.Windows.Forms.Panel pnlMainContent;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.btnDangXuat = new DevExpress.XtraEditors.SimpleButton();
            this.accordionMenu = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceDashboard = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceSanPham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDonHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceThongTin = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblUserName);
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 50);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "??? Cosmetics Store";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblUserName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Appearance.Options.UseForeColor = true;
            this.lblUserName.Location = new System.Drawing.Point(900, 15);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(150, 19);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Xin chào, Khách hàng!";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDangXuat.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDangXuat.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Appearance.Options.UseBackColor = true;
            this.btnDangXuat.Appearance.Options.UseFont = true;
            this.btnDangXuat.Appearance.Options.UseForeColor = true;
            this.btnDangXuat.Location = new System.Drawing.Point(1090, 10);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(100, 30);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Ðãng xu?t";
            this.btnDangXuat.Click += new System.EventHandler(this.OnDangXuatClick);
            // 
            // accordionMenu
            // 
            this.accordionMenu.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(142)))), ((int)(((byte)(68)))), ((int)(((byte)(173)))));
            this.accordionMenu.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceDashboard,
            this.aceSanPham,
            this.aceDonHang,
            this.aceThongTin});
            this.accordionMenu.Location = new System.Drawing.Point(0, 50);
            this.accordionMenu.Name = "accordionMenu";
            this.accordionMenu.Size = new System.Drawing.Size(220, 650);
            this.accordionMenu.TabIndex = 1;
            // 
            // aceDashboard
            // 
            this.aceDashboard.Name = "aceDashboard";
            this.aceDashboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDashboard.Text = "?? Trang ch?";
            this.aceDashboard.Click += new System.EventHandler(this.OnDashboardClick);
            // 
            // aceSanPham
            // 
            this.aceSanPham.Name = "aceSanPham";
            this.aceSanPham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceSanPham.Text = "??? S?n ph?m";
            this.aceSanPham.Click += new System.EventHandler(this.OnSanPhamClick);
            // 
            // aceDonHang
            // 
            this.aceDonHang.Name = "aceDonHang";
            this.aceDonHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDonHang.Text = "?? Ðõn hàng c?a tôi";
            this.aceDonHang.Click += new System.EventHandler(this.OnDonHangClick);
            // 
            // aceThongTin
            // 
            this.aceThongTin.Name = "aceThongTin";
            this.aceThongTin.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceThongTin.Text = "?? Thông tin cá nhân";
            this.aceThongTin.Click += new System.EventHandler(this.OnThongTinCaNhanClick);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(220, 50);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(980, 650);
            this.pnlMainContent.TabIndex = 2;
            // 
            // fDashboardKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.accordionMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "fDashboardKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cosmetics Store - Khách hàng";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionMenu)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
