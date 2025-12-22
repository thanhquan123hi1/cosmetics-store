namespace cosmetics_store.Forms
{
    partial class fDashboardNhanVien
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.SimpleButton btnDangXuat;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionMenu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDashboard;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceKinhDoanh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceBanHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceKhachHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceHangHoa;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceSanPham;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTonKho;
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
            this.aceKinhDoanh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceBanHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceKhachHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceHangHoa = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceSanPham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceTonKho = new DevExpress.XtraBars.Navigation.AccordionControlElement();
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
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
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
            this.lblTitle.Size = new System.Drawing.Size(301, 31);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cosmetics Store - Nhân viên";
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
            this.lblUserName.Size = new System.Drawing.Size(114, 23);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Xin chào, User!";
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
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.OnDangXuatClick);
            // 
            // accordionMenu
            // 
            this.accordionMenu.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.accordionMenu.Appearance.AccordionControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.accordionMenu.Appearance.AccordionControl.ForeColor = System.Drawing.Color.White;
            this.accordionMenu.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionMenu.Appearance.AccordionControl.Options.UseFont = true;
            this.accordionMenu.Appearance.AccordionControl.Options.UseForeColor = true;
            this.accordionMenu.Appearance.Group.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.accordionMenu.Appearance.Group.Hovered.ForeColor = System.Drawing.Color.White;
            this.accordionMenu.Appearance.Group.Hovered.Options.UseBackColor = true;
            this.accordionMenu.Appearance.Group.Hovered.Options.UseForeColor = true;
            this.accordionMenu.Appearance.Group.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.accordionMenu.Appearance.Group.Normal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.accordionMenu.Appearance.Group.Normal.ForeColor = System.Drawing.Color.White;
            this.accordionMenu.Appearance.Group.Normal.Options.UseBackColor = true;
            this.accordionMenu.Appearance.Group.Normal.Options.UseFont = true;
            this.accordionMenu.Appearance.Group.Normal.Options.UseForeColor = true;
            this.accordionMenu.Appearance.Item.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.accordionMenu.Appearance.Item.Hovered.ForeColor = System.Drawing.Color.White;
            this.accordionMenu.Appearance.Item.Hovered.Options.UseBackColor = true;
            this.accordionMenu.Appearance.Item.Hovered.Options.UseForeColor = true;
            this.accordionMenu.Appearance.Item.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.accordionMenu.Appearance.Item.Normal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.accordionMenu.Appearance.Item.Normal.ForeColor = System.Drawing.Color.White;
            this.accordionMenu.Appearance.Item.Normal.Options.UseBackColor = true;
            this.accordionMenu.Appearance.Item.Normal.Options.UseFont = true;
            this.accordionMenu.Appearance.Item.Normal.Options.UseForeColor = true;
            this.accordionMenu.Appearance.Item.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.accordionMenu.Appearance.Item.Pressed.ForeColor = System.Drawing.Color.White;
            this.accordionMenu.Appearance.Item.Pressed.Options.UseBackColor = true;
            this.accordionMenu.Appearance.Item.Pressed.Options.UseForeColor = true;
            this.accordionMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceDashboard,
            this.aceKinhDoanh,
            this.aceHangHoa});
            this.accordionMenu.Location = new System.Drawing.Point(0, 50);
            this.accordionMenu.Name = "accordionMenu";
            this.accordionMenu.Size = new System.Drawing.Size(220, 650);
            this.accordionMenu.TabIndex = 1;
            // 
            // aceDashboard
            // 
            this.aceDashboard.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            this.aceDashboard.Appearance.Normal.Options.UseForeColor = true;
            this.aceDashboard.Name = "aceDashboard";
            this.aceDashboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDashboard.Text = "DASHBOARD";
            this.aceDashboard.Click += new System.EventHandler(this.OnDashboardClick);
            // 
            // aceKinhDoanh
            // 
            this.aceKinhDoanh.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            this.aceKinhDoanh.Appearance.Normal.Options.UseForeColor = true;
            this.aceKinhDoanh.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceBanHang,
            this.aceKhachHang});
            this.aceKinhDoanh.Expanded = true;
            this.aceKinhDoanh.Name = "aceKinhDoanh";
            this.aceKinhDoanh.Text = "KINH DOANH";
            // 
            // aceBanHang
            // 
            this.aceBanHang.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            this.aceBanHang.Appearance.Normal.Options.UseForeColor = true;
            this.aceBanHang.Name = "aceBanHang";
            this.aceBanHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceBanHang.Text = "Bán hàng";
            this.aceBanHang.Click += new System.EventHandler(this.OnBanHangClick);
            // 
            // aceKhachHang
            // 
            this.aceKhachHang.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            this.aceKhachHang.Appearance.Normal.Options.UseForeColor = true;
            this.aceKhachHang.Name = "aceKhachHang";
            this.aceKhachHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceKhachHang.Text = "Khách hàng";
            this.aceKhachHang.Click += new System.EventHandler(this.OnKhachHangClick);
            // 
            // aceHangHoa
            // 
            this.aceHangHoa.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            this.aceHangHoa.Appearance.Normal.Options.UseForeColor = true;
            this.aceHangHoa.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceSanPham,
            this.aceTonKho});
            this.aceHangHoa.Expanded = true;
            this.aceHangHoa.Name = "aceHangHoa";
            this.aceHangHoa.Text = "HÀNG HÓA";
            // 
            // aceSanPham
            // 
            this.aceSanPham.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            this.aceSanPham.Appearance.Normal.Options.UseForeColor = true;
            this.aceSanPham.Name = "aceSanPham";
            this.aceSanPham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceSanPham.Text = "Sản phẩm";
            this.aceSanPham.Click += new System.EventHandler(this.OnSanPhamClick);
            // 
            // aceTonKho
            // 
            this.aceTonKho.Appearance.Normal.ForeColor = System.Drawing.Color.White;
            this.aceTonKho.Appearance.Normal.Options.UseForeColor = true;
            this.aceTonKho.Name = "aceTonKho";
            this.aceTonKho.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceTonKho.Text = "Tồn kho";
            this.aceTonKho.Click += new System.EventHandler(this.OnTonKhoClick);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(245)))));
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(220, 50);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(980, 650);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.EditValue = global::cosmetics_store.Properties.Resources.picNhanVien;
            this.pictureEdit1.Location = new System.Drawing.Point(0, 299);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Size = new System.Drawing.Size(197, 401);
            this.pictureEdit1.TabIndex = 3;
            this.pictureEdit1.EditValueChanged += new System.EventHandler(this.pictureEdit1_EditValueChanged);
            // 
            // fDashboardNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pictureEdit1);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.accordionMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "fDashboardNhanVien";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cosmetics Store - Nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
    }
}
