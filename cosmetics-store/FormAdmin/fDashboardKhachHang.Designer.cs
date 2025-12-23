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
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement3 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
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
            this.pnlHeader.Size = new System.Drawing.Size(1200, 56);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(16, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(176, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cosmetics Store";
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Appearance.Options.UseForeColor = true;
            this.lblUserName.ImageOptions.Image = global::cosmetics_store.Properties.Resources.role_tag1;
            this.lblUserName.Location = new System.Drawing.Point(843, 8);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(179, 42);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Xin chào, Khách hàng!";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDangXuat.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDangXuat.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Appearance.Options.UseBackColor = true;
            this.btnDangXuat.Appearance.Options.UseFont = true;
            this.btnDangXuat.Appearance.Options.UseForeColor = true;
            this.btnDangXuat.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnDangXuat.Location = new System.Drawing.Point(1084, 13);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(104, 30);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng xuất";
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
            this.aceThongTin,
            this.accordionControlElement1,
            this.accordionControlElement2,
            this.accordionControlElement3,
            this.accordionControlElement4});
            this.accordionMenu.Location = new System.Drawing.Point(0, 56);
            this.accordionMenu.Name = "accordionMenu";
            this.accordionMenu.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Hidden;
            this.accordionMenu.Size = new System.Drawing.Size(220, 644);
            this.accordionMenu.TabIndex = 1;
            // 
            // aceDashboard
            // 
            this.aceDashboard.Name = "aceDashboard";
            this.aceDashboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDashboard.Text = "Trang chủ";
            this.aceDashboard.Click += new System.EventHandler(this.OnDashboardClick);
            // 
            // aceSanPham
            // 
            this.aceSanPham.Name = "aceSanPham";
            this.aceSanPham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceSanPham.Text = "Sản Phẩm";
            this.aceSanPham.Click += new System.EventHandler(this.OnSanPhamClick);
            // 
            // aceDonHang
            // 
            this.aceDonHang.Name = "aceDonHang";
            this.aceDonHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDonHang.Text = "Đơn hàng của tôi";
            this.aceDonHang.Click += new System.EventHandler(this.OnDonHangClick);
            // 
            // aceThongTin
            // 
            this.aceThongTin.Name = "aceThongTin";
            this.aceThongTin.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceThongTin.Text = "Thông tin cá nhân";
            this.aceThongTin.Click += new System.EventHandler(this.OnThongTinCaNhanClick);
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement1.Text = "Element1";
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Element2";
            // 
            // accordionControlElement3
            // 
            this.accordionControlElement3.Name = "accordionControlElement3";
            this.accordionControlElement3.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement3.Text = "Element3";
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "Element4";
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(220, 56);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(980, 644);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::cosmetics_store.Properties.Resources.picKhachHang;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 223);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureEdit1.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(200, 477);
            this.pictureEdit1.TabIndex = 3;
            // 
            // fDashboardKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pictureEdit1);
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement3;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
    }
}
