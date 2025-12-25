namespace cosmetics_store.FormStaff
{
    partial class fDashboardStaff
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlHeader;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblNhanVien;
        private DevExpress.XtraEditors.LabelControl lblCaSang;
        private DevExpress.XtraEditors.LabelControl lblNgay;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionMenu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceBanHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceLapHoaDon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDuyetHoaDon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTraCuu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceSanPham;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceKhachHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceLichSu;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceLichSuCaNhan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceTaiKhoan;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceThongTinNV;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDoiMatKhau;
        private DevExpress.XtraBars.Navigation.AccordionControlElement aceDangXuat;
        private System.Windows.Forms.Panel pnlMainContent;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlHeader = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.lblCaSang = new DevExpress.XtraEditors.LabelControl();
            this.lblNgay = new DevExpress.XtraEditors.LabelControl();
            this.accordionMenu = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.aceBanHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceLapHoaDon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDuyetHoaDon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceTraCuu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceSanPham = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceKhachHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceLichSu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceLichSuCaNhan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceTaiKhoan = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceThongTinNV = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDoiMatKhau = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.aceDangXuat = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).BeginInit();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.pnlHeader.Appearance.Options.UseBackColor = true;
            this.pnlHeader.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblNhanVien);
            this.pnlHeader.Controls.Add(this.lblCaSang);
            this.pnlHeader.Controls.Add(this.lblNgay);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1200, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 18);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(667, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "PHẦN MỀM QUẢN LÝ CỬA HÀNG MỸ PHẨM - NHÂN VIÊN";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNhanVien.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNhanVien.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblNhanVien.Appearance.Options.UseFont = true;
            this.lblNhanVien.Appearance.Options.UseForeColor = true;
            this.lblNhanVien.Location = new System.Drawing.Point(700, 20);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(197, 23);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Nhân viên: Nguyễn Văn A";
            // 
            // lblCaSang
            // 
            this.lblCaSang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCaSang.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCaSang.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblCaSang.Appearance.Options.UseFont = true;
            this.lblCaSang.Appearance.Options.UseForeColor = true;
            this.lblCaSang.Location = new System.Drawing.Point(920, 20);
            this.lblCaSang.Name = "lblCaSang";
            this.lblCaSang.Size = new System.Drawing.Size(67, 23);
            this.lblCaSang.TabIndex = 2;
            this.lblCaSang.Text = "Ca: Sáng";
            // 
            // lblNgay
            // 
            this.lblNgay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgay.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblNgay.Appearance.Options.UseFont = true;
            this.lblNgay.Appearance.Options.UseForeColor = true;
            this.lblNgay.Location = new System.Drawing.Point(1020, 20);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(135, 23);
            this.lblNgay.TabIndex = 3;
            this.lblNgay.Text = "Ngày: 15/12/2025";
            // 
            // accordionMenu
            // 
            this.accordionMenu.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.accordionMenu.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceBanHang,
            this.aceTraCuu,
            this.aceLichSu,
            this.aceTaiKhoan});
            this.accordionMenu.Location = new System.Drawing.Point(0, 60);
            this.accordionMenu.Name = "accordionMenu";
            this.accordionMenu.Size = new System.Drawing.Size(220, 640);
            this.accordionMenu.TabIndex = 1;
            // 
            // aceBanHang
            // 
            this.aceBanHang.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceLapHoaDon,
            this.aceDuyetHoaDon});
            this.aceBanHang.Expanded = true;
            this.aceBanHang.Name = "aceBanHang";
            this.aceBanHang.Text = "💰 BÁN HÀNG";
            // 
            // aceLapHoaDon
            // 
            this.aceLapHoaDon.Name = "aceLapHoaDon";
            this.aceLapHoaDon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceLapHoaDon.Text = "   • Lập hóa đơn";
            this.aceLapHoaDon.Click += new System.EventHandler(this.OnLapHoaDonClick);
            // 
            // aceDuyetHoaDon
            // 
            this.aceDuyetHoaDon.Name = "aceDuyetHoaDon";
            this.aceDuyetHoaDon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDuyetHoaDon.Text = "   • Duyệt hóa đơn";
            this.aceDuyetHoaDon.Click += new System.EventHandler(this.OnDuyetHoaDonClick);
            // 
            // aceTraCuu
            // 
            this.aceTraCuu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceSanPham,
            this.aceKhachHang});
            this.aceTraCuu.Expanded = true;
            this.aceTraCuu.Name = "aceTraCuu";
            this.aceTraCuu.Text = "🔍 TRA CỨU";
            // 
            // aceSanPham
            // 
            this.aceSanPham.Name = "aceSanPham";
            this.aceSanPham.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceSanPham.Text = "   • Sản phẩm";
            this.aceSanPham.Click += new System.EventHandler(this.OnSanPhamClick);
            // 
            // aceKhachHang
            // 
            this.aceKhachHang.Name = "aceKhachHang";
            this.aceKhachHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceKhachHang.Text = "   • Khách hàng";
            this.aceKhachHang.Click += new System.EventHandler(this.OnKhachHangClick);
            // 
            // aceLichSu
            // 
            this.aceLichSu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceLichSuCaNhan});
            this.aceLichSu.Expanded = true;
            this.aceLichSu.Name = "aceLichSu";
            this.aceLichSu.Text = "📋 LỊCH SỬ";
            // 
            // aceLichSuCaNhan
            // 
            this.aceLichSuCaNhan.Name = "aceLichSuCaNhan";
            this.aceLichSuCaNhan.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceLichSuCaNhan.Text = "   • Hóa đơn cá nhân";
            this.aceLichSuCaNhan.Click += new System.EventHandler(this.OnLichSuCaNhanClick);
            // 
            // aceTaiKhoan
            // 
            this.aceTaiKhoan.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.aceThongTinNV,
            this.aceDoiMatKhau,
            this.aceDangXuat});
            this.aceTaiKhoan.Expanded = true;
            this.aceTaiKhoan.Name = "aceTaiKhoan";
            this.aceTaiKhoan.Text = "👤 TÀI KHOẢN";
            // 
            // aceThongTinNV
            // 
            this.aceThongTinNV.Name = "aceThongTinNV";
            this.aceThongTinNV.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceThongTinNV.Text = "   • Thông tin NV";
            this.aceThongTinNV.Click += new System.EventHandler(this.OnThongTinNVClick);
            // 
            // aceDoiMatKhau
            // 
            this.aceDoiMatKhau.Name = "aceDoiMatKhau";
            this.aceDoiMatKhau.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDoiMatKhau.Text = "   • Đổi mật khẩu";
            this.aceDoiMatKhau.Click += new System.EventHandler(this.OnDoiMatKhauClick);
            // 
            // aceDangXuat
            // 
            this.aceDangXuat.Name = "aceDangXuat";
            this.aceDangXuat.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.aceDangXuat.Text = "   • Đăng xuất";
            this.aceDangXuat.Click += new System.EventHandler(this.OnDangXuatClick);
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(220, 60);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(980, 610);
            this.pnlMainContent.TabIndex = 2;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblGhiChu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblGhiChu.Appearance.Options.UseFont = true;
            this.lblGhiChu.Appearance.Options.UseForeColor = true;
            this.lblGhiChu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblGhiChu.Location = new System.Drawing.Point(220, 670);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Padding = new System.Windows.Forms.Padding(10, 5, 0, 5);
            this.lblGhiChu.Size = new System.Drawing.Size(480, 30);
            this.lblGhiChu.TabIndex = 3;
            this.lblGhiChu.Text = "Ghi chú: Nhân viên KHÔNG có quyền xóa dữ liệu / xem báo cáo tổng hợp";
            // 
            // fDashboardStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.lblGhiChu);
            this.Controls.Add(this.accordionMenu);
            this.Controls.Add(this.pnlHeader);
            this.Name = "fDashboardStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Cửa hàng Mỹ phẩm - Nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pnlHeader)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
