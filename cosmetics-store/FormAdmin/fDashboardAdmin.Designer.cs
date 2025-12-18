namespace cosmetics_store.Forms
{
    partial class fDashboardAdmin
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
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnDangXuat = new DevExpress.XtraEditors.SimpleButton();
            this.lblUserName = new DevExpress.XtraEditors.LabelControl();
            this.lblAppTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlLeft = new DevExpress.XtraEditors.PanelControl();
            this.accordionControl = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.accGroupDashboard = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accGroupNguoiDung = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemNhanVien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemTaiKhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemNhatKy = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemCauHinh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accGroupHangHoa = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemSanPham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemTonKho = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemNhapHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemNhaCC = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accGroupKinhDoanh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemHoaDon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accItemBaoCao = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.pnlMainContent = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMainContent)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.btnDangXuat);
            this.pnlHeader.Controls.Add(this.lblUserName);
            this.pnlHeader.Controls.Add(this.lblAppTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1400, 62);
            this.pnlHeader.TabIndex = 0;
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDangXuat.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnDangXuat.Appearance.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Appearance.Options.UseBackColor = true;
            this.btnDangXuat.Appearance.Options.UseFont = true;
            this.btnDangXuat.Appearance.Options.UseForeColor = true;
            this.btnDangXuat.Location = new System.Drawing.Point(1272, 12);
            this.btnDangXuat.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(117, 37);
            this.btnDangXuat.TabIndex = 2;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.OnDangXuatClick);
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Appearance.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.lblUserName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblUserName.Appearance.Options.UseFont = true;
            this.lblUserName.Appearance.Options.UseForeColor = true;
            this.lblUserName.Location = new System.Drawing.Point(992, 18);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(202, 25);
            this.lblUserName.TabIndex = 1;
            this.lblUserName.Text = "Xin chào, Administrator!";
            // 
            // lblAppTitle
            // 
            this.lblAppTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Appearance.Options.UseFont = true;
            this.lblAppTitle.Appearance.Options.UseForeColor = true;
            this.lblAppTitle.Location = new System.Drawing.Point(18, 15);
            this.lblAppTitle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(182, 32);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "Cosmetics Store";
            // 
            // pnlLeft
            // 
            this.pnlLeft.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.pnlLeft.Appearance.Options.UseBackColor = true;
            this.pnlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLeft.Controls.Add(this.accordionControl);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 62);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(292, 738);
            this.pnlLeft.TabIndex = 1;
            // 
            // accordionControl
            // 
            this.accordionControl.AllowItemSelection = true;
            this.accordionControl.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(37)))), ((int)(((byte)(38)))));
            this.accordionControl.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl.Appearance.Group.Default.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.accordionControl.Appearance.Group.Default.ForeColor = System.Drawing.Color.White;
            this.accordionControl.Appearance.Group.Default.Options.UseFont = true;
            this.accordionControl.Appearance.Group.Default.Options.UseForeColor = true;
            this.accordionControl.Appearance.Item.Default.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.accordionControl.Appearance.Item.Default.ForeColor = System.Drawing.Color.LightGray;
            this.accordionControl.Appearance.Item.Default.Options.UseFont = true;
            this.accordionControl.Appearance.Item.Default.Options.UseForeColor = true;
            this.accordionControl.Appearance.Item.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(62)))), ((int)(((byte)(66)))));
            this.accordionControl.Appearance.Item.Hovered.Options.UseBackColor = true;
            this.accordionControl.Appearance.Item.Pressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.accordionControl.Appearance.Item.Pressed.Options.UseBackColor = true;
            this.accordionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accordionControl.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accGroupDashboard,
            this.accGroupNguoiDung,
            this.accGroupHangHoa,
            this.accGroupKinhDoanh});
            this.accordionControl.Location = new System.Drawing.Point(0, 0);
            this.accordionControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.accordionControl.Name = "accordionControl";
            this.accordionControl.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl.Size = new System.Drawing.Size(292, 738);
            this.accordionControl.TabIndex = 0;
            // 
            // accGroupDashboard
            // 
            this.accGroupDashboard.Name = "accGroupDashboard";
            this.accGroupDashboard.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accGroupDashboard.Text = "📊  DASHBOARD";
            this.accGroupDashboard.Click += new System.EventHandler(this.OnDashboardClick);
            // 
            // accGroupNguoiDung
            // 
            this.accGroupNguoiDung.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accItemNhanVien,
            this.accItemTaiKhoan,
            this.accItemNhatKy,
            this.accItemCauHinh});
            this.accGroupNguoiDung.Expanded = true;
            this.accGroupNguoiDung.Name = "accGroupNguoiDung";
            this.accGroupNguoiDung.Text = "👤  NGƯỜI DÙNG && HỆ THỐNG";
            // 
            // accItemNhanVien
            // 
            this.accItemNhanVien.Name = "accItemNhanVien";
            this.accItemNhanVien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemNhanVien.Text = "   + Quản lý Nhân viên";
            this.accItemNhanVien.Click += new System.EventHandler(this.OnQuanLyNhanVienClick);
            // 
            // accItemTaiKhoan
            // 
            this.accItemTaiKhoan.Name = "accItemTaiKhoan";
            this.accItemTaiKhoan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemTaiKhoan.Text = "   + Tài khoản && Quyền";
            this.accItemTaiKhoan.Click += new System.EventHandler(this.OnTaiKhoanQuyenClick);
            // 
            // accItemNhatKy
            // 
            this.accItemNhatKy.Name = "accItemNhatKy";
            this.accItemNhatKy.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemNhatKy.Text = "   + Nhật ký hệ thống";
            this.accItemNhatKy.Click += new System.EventHandler(this.OnNhatKyHeThongClick);
            // 
            // accItemCauHinh
            // 
            this.accItemCauHinh.Name = "accItemCauHinh";
            this.accItemCauHinh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemCauHinh.Text = "   + Cấu hình";
            this.accItemCauHinh.Click += new System.EventHandler(this.OnCauHinhClick);
            // 
            // accGroupHangHoa
            // 
            this.accGroupHangHoa.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accItemSanPham,
            this.accItemTonKho,
            this.accItemNhapHang,
            this.accItemNhaCC});
            this.accGroupHangHoa.Expanded = true;
            this.accGroupHangHoa.Name = "accGroupHangHoa";
            this.accGroupHangHoa.Text = "📦  HÀNG HÓA && KHO";
            // 
            // accItemSanPham
            // 
            this.accItemSanPham.Name = "accItemSanPham";
            this.accItemSanPham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemSanPham.Text = "   + Sản phẩm";
            this.accItemSanPham.Click += new System.EventHandler(this.OnSanPhamClick);
            // 
            // accItemTonKho
            // 
            this.accItemTonKho.Name = "accItemTonKho";
            this.accItemTonKho.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemTonKho.Text = "   + Tồn kho";
            this.accItemTonKho.Click += new System.EventHandler(this.OnTonKhoClick);
            // 
            // accItemNhapHang
            // 
            this.accItemNhapHang.Name = "accItemNhapHang";
            this.accItemNhapHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemNhapHang.Text = "   + Nhập hàng";
            this.accItemNhapHang.Click += new System.EventHandler(this.OnNhapHangClick);
            // 
            // accItemNhaCC
            // 
            this.accItemNhaCC.Name = "accItemNhaCC";
            this.accItemNhaCC.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemNhaCC.Text = "   + Nhà cung cấp";
            this.accItemNhaCC.Click += new System.EventHandler(this.OnNhaCungCapClick);
            // 
            // accGroupKinhDoanh
            // 
            this.accGroupKinhDoanh.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accItemHoaDon,
            this.accItemBaoCao});
            this.accGroupKinhDoanh.Expanded = true;
            this.accGroupKinhDoanh.Name = "accGroupKinhDoanh";
            this.accGroupKinhDoanh.Text = "💰  KINH DOANH";
            // 
            // accItemHoaDon
            // 
            this.accItemHoaDon.Name = "accItemHoaDon";
            this.accItemHoaDon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemHoaDon.Text = "   + Hóa đơn bán hàng";
            this.accItemHoaDon.Click += new System.EventHandler(this.OnHoaDonBanHangClick);
            // 
            // accItemBaoCao
            // 
            this.accItemBaoCao.Name = "accItemBaoCao";
            this.accItemBaoCao.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accItemBaoCao.Text = "   + Báo cáo";
            this.accItemBaoCao.Click += new System.EventHandler(this.OnBaoCaoClick);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlMainContent.Appearance.Options.UseBackColor = true;
            this.pnlMainContent.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(292, 62);
            this.pnlMainContent.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Padding = new System.Windows.Forms.Padding(12, 12, 12, 12);
            this.pnlMainContent.Size = new System.Drawing.Size(1108, 738);
            this.pnlMainContent.TabIndex = 2;
            // 
            // fDashboardAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 800);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1167, 738);
            this.Name = "fDashboardAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cosmetics Store - Admin Dashboard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMainContent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.SimpleButton btnDangXuat;
        private DevExpress.XtraEditors.LabelControl lblUserName;
        private DevExpress.XtraEditors.LabelControl lblAppTitle;
        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accGroupDashboard;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accGroupNguoiDung;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemNhanVien;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemTaiKhoan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemNhatKy;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemCauHinh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accGroupHangHoa;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemSanPham;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemTonKho;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemNhapHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemNhaCC;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accGroupKinhDoanh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemHoaDon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accItemBaoCao;
        private DevExpress.XtraEditors.PanelControl pnlMainContent;
    }
}
