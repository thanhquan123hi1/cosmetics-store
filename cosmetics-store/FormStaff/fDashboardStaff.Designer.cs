namespace cosmetics_store.FormStaff
{
    partial class fDashboardStaff
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.lblGhiChu = new DevExpress.XtraEditors.LabelControl();
            this.lblNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblCaSang = new DevExpress.XtraEditors.LabelControl();
            this.lblNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.btnDangXuat = new DevExpress.XtraEditors.SimpleButton();
            this.btnThongTin = new DevExpress.XtraEditors.SimpleButton();
            this.btnLichSu = new DevExpress.XtraEditors.SimpleButton();
            this.btnKhachHang = new DevExpress.XtraEditors.SimpleButton();
            this.btnSanPham = new DevExpress.XtraEditors.SimpleButton();
            this.btnLapHoaDon = new DevExpress.XtraEditors.SimpleButton();
            this.lblSidebarTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlRoot.SuspendLayout();
            this.pnlSidebar.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRoot
            // 
            this.pnlRoot.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pnlRoot.Controls.Add(this.pnlMainContent);
            this.pnlRoot.Controls.Add(this.pnlSidebar);
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Location = new System.Drawing.Point(0, 0);
            this.pnlRoot.Name = "pnlRoot";
            this.pnlRoot.Size = new System.Drawing.Size(1200, 700);
            this.pnlRoot.TabIndex = 0;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.BackColor = System.Drawing.Color.White;
            this.pnlMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainContent.Location = new System.Drawing.Point(260, 0);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(940, 700);
            this.pnlMainContent.TabIndex = 1;
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(63)))), ((int)(((byte)(159)))));
            this.pnlSidebar.Controls.Add(this.lblGhiChu);
            this.pnlSidebar.Controls.Add(this.lblNgay);
            this.pnlSidebar.Controls.Add(this.lblCaSang);
            this.pnlSidebar.Controls.Add(this.lblNhanVien);
            this.pnlSidebar.Controls.Add(this.btnDangXuat);
            this.pnlSidebar.Controls.Add(this.btnThongTin);
            this.pnlSidebar.Controls.Add(this.btnLichSu);
            this.pnlSidebar.Controls.Add(this.btnKhachHang);
            this.pnlSidebar.Controls.Add(this.btnSanPham);
            this.pnlSidebar.Controls.Add(this.btnLapHoaDon);
            this.pnlSidebar.Controls.Add(this.lblSidebarTitle);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Padding = new System.Windows.Forms.Padding(20);
            this.pnlSidebar.Size = new System.Drawing.Size(260, 700);
            this.pnlSidebar.TabIndex = 0;
            // 
            // lblGhiChu
            // 
            this.lblGhiChu.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblGhiChu.Appearance.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.lblGhiChu.Appearance.Options.UseFont = true;
            this.lblGhiChu.Appearance.Options.UseForeColor = true;
            this.lblGhiChu.Location = new System.Drawing.Point(23, 200);
            this.lblGhiChu.Name = "lblGhiChu";
            this.lblGhiChu.Size = new System.Drawing.Size(132, 20);
            this.lblGhiChu.TabIndex = 10;
            this.lblGhiChu.Text = "Ghi chú quyền hạn";
            // 
            // lblNgay
            // 
            this.lblNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgay.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblNgay.Appearance.Options.UseFont = true;
            this.lblNgay.Appearance.Options.UseForeColor = true;
            this.lblNgay.Location = new System.Drawing.Point(23, 170);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(92, 23);
            this.lblNgay.TabIndex = 9;
            this.lblNgay.Text = "Ngày: --/--";
            // 
            // lblCaSang
            // 
            this.lblCaSang.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCaSang.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblCaSang.Appearance.Options.UseFont = true;
            this.lblCaSang.Appearance.Options.UseForeColor = true;
            this.lblCaSang.Location = new System.Drawing.Point(23, 140);
            this.lblCaSang.Name = "lblCaSang";
            this.lblCaSang.Size = new System.Drawing.Size(66, 23);
            this.lblCaSang.TabIndex = 8;
            this.lblCaSang.Text = "Ca: ---";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblNhanVien.Appearance.Options.UseFont = true;
            this.lblNhanVien.Appearance.Options.UseForeColor = true;
            this.lblNhanVien.Location = new System.Drawing.Point(23, 110);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(170, 25);
            this.lblNhanVien.TabIndex = 7;
            this.lblNhanVien.Text = "Nhân viên: (Chưa)";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(83)))), ((int)(((byte)(80)))));
            this.btnDangXuat.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDangXuat.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDangXuat.Appearance.Options.UseBackColor = true;
            this.btnDangXuat.Appearance.Options.UseFont = true;
            this.btnDangXuat.Appearance.Options.UseForeColor = true;
            this.btnDangXuat.Location = new System.Drawing.Point(23, 550);
            this.btnDangXuat.Name = "btnDangXuat";
            this.btnDangXuat.Size = new System.Drawing.Size(214, 45);
            this.btnDangXuat.TabIndex = 6;
            this.btnDangXuat.Text = "Đăng xuất";
            this.btnDangXuat.Click += new System.EventHandler(this.OnDangXuatClick);
            // 
            // btnThongTin
            // 
            this.btnThongTin.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnThongTin.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThongTin.Appearance.Options.UseFont = true;
            this.btnThongTin.Appearance.Options.UseForeColor = true;
            this.btnThongTin.Location = new System.Drawing.Point(23, 440);
            this.btnThongTin.Name = "btnThongTin";
            this.btnThongTin.Size = new System.Drawing.Size(214, 40);
            this.btnThongTin.TabIndex = 5;
            this.btnThongTin.Text = "Thông tin nhân viên";
            this.btnThongTin.Click += new System.EventHandler(this.OnThongTinNVClick);
            // 
            // btnLichSu
            // 
            this.btnLichSu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLichSu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLichSu.Appearance.Options.UseFont = true;
            this.btnLichSu.Appearance.Options.UseForeColor = true;
            this.btnLichSu.Location = new System.Drawing.Point(23, 390);
            this.btnLichSu.Name = "btnLichSu";
            this.btnLichSu.Size = new System.Drawing.Size(214, 40);
            this.btnLichSu.TabIndex = 4;
            this.btnLichSu.Text = "Lịch sử giao dịch";
            this.btnLichSu.Click += new System.EventHandler(this.OnLichSuCaNhanClick);
            // 
            // btnKhachHang
            // 
            this.btnKhachHang.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnKhachHang.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnKhachHang.Appearance.Options.UseFont = true;
            this.btnKhachHang.Appearance.Options.UseForeColor = true;
            this.btnKhachHang.Location = new System.Drawing.Point(23, 340);
            this.btnKhachHang.Name = "btnKhachHang";
            this.btnKhachHang.Size = new System.Drawing.Size(214, 40);
            this.btnKhachHang.TabIndex = 3;
            this.btnKhachHang.Text = "Khách hàng";
            this.btnKhachHang.Click += new System.EventHandler(this.OnKhachHangClick);
            // 
            // btnSanPham
            // 
            this.btnSanPham.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSanPham.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSanPham.Appearance.Options.UseFont = true;
            this.btnSanPham.Appearance.Options.UseForeColor = true;
            this.btnSanPham.Location = new System.Drawing.Point(23, 290);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(214, 40);
            this.btnSanPham.TabIndex = 2;
            this.btnSanPham.Text = "Tra cứu sản phẩm";
            this.btnSanPham.Click += new System.EventHandler(this.OnSanPhamClick);
            // 
            // btnLapHoaDon
            // 
            this.btnLapHoaDon.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnLapHoaDon.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLapHoaDon.Appearance.Options.UseFont = true;
            this.btnLapHoaDon.Appearance.Options.UseForeColor = true;
            this.btnLapHoaDon.Location = new System.Drawing.Point(23, 240);
            this.btnLapHoaDon.Name = "btnLapHoaDon";
            this.btnLapHoaDon.Size = new System.Drawing.Size(214, 40);
            this.btnLapHoaDon.TabIndex = 1;
            this.btnLapHoaDon.Text = "Lập hóa đơn";
            this.btnLapHoaDon.Click += new System.EventHandler(this.OnLapHoaDonClick);
            // 
            // lblSidebarTitle
            // 
            this.lblSidebarTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblSidebarTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblSidebarTitle.Appearance.Options.UseFont = true;
            this.lblSidebarTitle.Appearance.Options.UseForeColor = true;
            this.lblSidebarTitle.Location = new System.Drawing.Point(23, 40);
            this.lblSidebarTitle.Name = "lblSidebarTitle";
            this.lblSidebarTitle.Size = new System.Drawing.Size(191, 37);
            this.lblSidebarTitle.TabIndex = 0;
            this.lblSidebarTitle.Text = "Bảng điều khiển";
            // 
            // fDashboardStaff
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.pnlRoot);
            this.Name = "fDashboardStaff";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm Quản lý Cửa hàng Mỹ phẩm - Nhân viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlRoot.ResumeLayout(false);
            this.pnlSidebar.ResumeLayout(false);
            this.pnlSidebar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Panel pnlSidebar;
        private DevExpress.XtraEditors.LabelControl lblSidebarTitle;
        private DevExpress.XtraEditors.SimpleButton btnDangXuat;
        private DevExpress.XtraEditors.SimpleButton btnThongTin;
        private DevExpress.XtraEditors.SimpleButton btnLichSu;
        private DevExpress.XtraEditors.SimpleButton btnKhachHang;
        private DevExpress.XtraEditors.SimpleButton btnSanPham;
        private DevExpress.XtraEditors.SimpleButton btnLapHoaDon;
        private DevExpress.XtraEditors.LabelControl lblNhanVien;
        private DevExpress.XtraEditors.LabelControl lblCaSang;
        private DevExpress.XtraEditors.LabelControl lblNgay;
        private DevExpress.XtraEditors.LabelControl lblGhiChu;
        private System.Windows.Forms.Panel pnlMainContent;
    }
}
