namespace cosmetics_store.FormStaff
{
    partial class fLapHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraTab.XtraTabControl tabControl;
        private DevExpress.XtraTab.XtraTabPage tabThongTin;
        private DevExpress.XtraTab.XtraTabPage tabDanhSach;
        private DevExpress.XtraEditors.LabelControl lblMaHD;
        private DevExpress.XtraEditors.LabelControl lblNV;
        private DevExpress.XtraEditors.LabelControl lblNgay;
        private DevExpress.XtraGrid.GridControl gridSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSanPham;
        private DevExpress.XtraGrid.GridControl gridChiTiet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChiTiet;
        private DevExpress.XtraEditors.SpinEdit spinSoLuong;
        private DevExpress.XtraEditors.SimpleButton btnThemSP;
        private DevExpress.XtraEditors.LabelControl lblTongTien;
        private DevExpress.XtraEditors.LabelControl lblKhachHang;
        private DevExpress.XtraEditors.SimpleButton btnChonKH;
        private DevExpress.XtraEditors.SimpleButton btnThanhToan;
        private DevExpress.XtraEditors.SimpleButton btnLuu;

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.tabControl = new DevExpress.XtraTab.XtraTabControl();
            this.tabThongTin = new DevExpress.XtraTab.XtraTabPage();
            this.lblMaHD = new DevExpress.XtraEditors.LabelControl();
            this.lblNV = new DevExpress.XtraEditors.LabelControl();
            this.lblNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblKhachHang = new DevExpress.XtraEditors.LabelControl();
            this.btnChonKH = new DevExpress.XtraEditors.SimpleButton();
            this.lblTongTien = new DevExpress.XtraEditors.LabelControl();
            this.btnThanhToan = new DevExpress.XtraEditors.SimpleButton();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.tabDanhSach = new DevExpress.XtraTab.XtraTabPage();
            this.gridSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.spinSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.btnThemSP = new DevExpress.XtraEditors.SimpleButton();
            this.gridChiTiet = new DevExpress.XtraGrid.GridControl();
            this.gridViewChiTiet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabThongTin.SuspendLayout();
            this.tabDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.tabControl);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(950, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Location = new System.Drawing.Point(20, 55);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedTabPage = this.tabThongTin;
            this.tabControl.Size = new System.Drawing.Size(910, 530);
            this.tabControl.TabIndex = 1;
            this.tabControl.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.tabThongTin,
            this.tabDanhSach});
            // 
            // tabThongTin
            // 
            this.tabThongTin.Appearance.Header.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabThongTin.Appearance.Header.Options.UseFont = true;
            this.tabThongTin.Controls.Add(this.lblMaHD);
            this.tabThongTin.Controls.Add(this.lblNV);
            this.tabThongTin.Controls.Add(this.lblNgay);
            this.tabThongTin.Controls.Add(this.lblKhachHang);
            this.tabThongTin.Controls.Add(this.btnChonKH);
            this.tabThongTin.Controls.Add(this.lblTongTien);
            this.tabThongTin.Controls.Add(this.btnThanhToan);
            this.tabThongTin.Controls.Add(this.btnLuu);
            this.tabThongTin.Name = "tabThongTin";
            this.tabThongTin.Size = new System.Drawing.Size(908, 493);
            this.tabThongTin.Text = "THÔNG TIN HÓA ĐƠN";
            // 
            // lblMaHD
            // 
            this.lblMaHD.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaHD.Appearance.Options.UseFont = true;
            this.lblMaHD.Location = new System.Drawing.Point(20, 25);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(136, 25);
            this.lblMaHD.TabIndex = 0;
            this.lblMaHD.Text = "Mã HĐ: HD0123";
            // 
            // lblNV
            // 
            this.lblNV.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNV.Appearance.Options.UseFont = true;
            this.lblNV.Location = new System.Drawing.Point(20, 55);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(77, 25);
            this.lblNV.TabIndex = 1;
            this.lblNV.Text = "NV: NV01";
            // 
            // lblNgay
            // 
            this.lblNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNgay.Appearance.Options.UseFont = true;
            this.lblNgay.Location = new System.Drawing.Point(20, 85);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(98, 25);
            this.lblNgay.TabIndex = 2;
            this.lblNgay.Text = "Ngày: 15/12";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblKhachHang.Appearance.Options.UseFont = true;
            this.lblKhachHang.Location = new System.Drawing.Point(20, 130);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(212, 25);
            this.lblKhachHang.TabIndex = 3;
            this.lblKhachHang.Text = "Khách hàng: (Chưa chọn)";
            // 
            // btnChonKH
            // 
            this.btnChonKH.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnChonKH.Appearance.Options.UseFont = true;
            this.btnChonKH.Location = new System.Drawing.Point(250, 125);
            this.btnChonKH.Name = "btnChonKH";
            this.btnChonKH.Size = new System.Drawing.Size(200, 39);
            this.btnChonKH.TabIndex = 4;
            this.btnChonKH.Text = "👥 Chọn khách hàng";
            this.btnChonKH.Click += new System.EventHandler(this.btnChonKH_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTien.Appearance.Options.UseFont = true;
            this.lblTongTien.Appearance.Options.UseForeColor = true;
            this.lblTongTien.Location = new System.Drawing.Point(20, 190);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(275, 32);
            this.lblTongTien.TabIndex = 5;
            this.lblTongTien.Text = "Tổng tiền: 490.000 VND";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThanhToan.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Appearance.Options.UseBackColor = true;
            this.btnThanhToan.Appearance.Options.UseFont = true;
            this.btnThanhToan.Appearance.Options.UseForeColor = true;
            this.btnThanhToan.Location = new System.Drawing.Point(150, 250);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(171, 40);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "💳 Thanh toán";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Location = new System.Drawing.Point(371, 250);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(119, 40);
            this.btnLuu.TabIndex = 7;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // tabDanhSach
            // 
            this.tabDanhSach.Appearance.Header.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabDanhSach.Appearance.Header.Options.UseFont = true;
            this.tabDanhSach.Controls.Add(this.gridSanPham);
            this.tabDanhSach.Controls.Add(this.spinSoLuong);
            this.tabDanhSach.Controls.Add(this.btnThemSP);
            this.tabDanhSach.Controls.Add(this.gridChiTiet);
            this.tabDanhSach.Name = "tabDanhSach";
            this.tabDanhSach.Size = new System.Drawing.Size(908, 493);
            this.tabDanhSach.Text = "DANH SÁCH SẢN PHẨM";
            // 
            // gridSanPham
            // 
            this.gridSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSanPham.Location = new System.Drawing.Point(10, 10);
            this.gridSanPham.MainView = this.gridViewSanPham;
            this.gridSanPham.Name = "gridSanPham";
            this.gridSanPham.Size = new System.Drawing.Size(888, 180);
            this.gridSanPham.TabIndex = 0;
            this.gridSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSanPham});
            // 
            // gridViewSanPham
            // 
            this.gridViewSanPham.GridControl = this.gridSanPham;
            this.gridViewSanPham.Name = "gridViewSanPham";
            this.gridViewSanPham.OptionsBehavior.Editable = false;
            this.gridViewSanPham.OptionsView.ShowGroupPanel = false;
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSoLuong.Location = new System.Drawing.Point(10, 200);
            this.spinSoLuong.Name = "spinSoLuong";
            this.spinSoLuong.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinSoLuong.Properties.Appearance.Options.UseFont = true;
            this.spinSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSoLuong.Properties.IsFloatValue = false;
            this.spinSoLuong.Properties.MaxValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSoLuong.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSoLuong.Size = new System.Drawing.Size(80, 30);
            this.spinSoLuong.TabIndex = 1;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThemSP.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemSP.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Appearance.Options.UseBackColor = true;
            this.btnThemSP.Appearance.Options.UseFont = true;
            this.btnThemSP.Appearance.Options.UseForeColor = true;
            this.btnThemSP.Location = new System.Drawing.Point(100, 198);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(155, 32);
            this.btnThemSP.TabIndex = 2;
            this.btnThemSP.Text = "➕ Thêm SP";
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // gridChiTiet
            // 
            this.gridChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridChiTiet.Location = new System.Drawing.Point(10, 240);
            this.gridChiTiet.MainView = this.gridViewChiTiet;
            this.gridChiTiet.Name = "gridChiTiet";
            this.gridChiTiet.Size = new System.Drawing.Size(888, 247);
            this.gridChiTiet.TabIndex = 3;
            this.gridChiTiet.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewChiTiet});
            // 
            // gridViewChiTiet
            // 
            this.gridViewChiTiet.GridControl = this.gridChiTiet;
            this.gridViewChiTiet.Name = "gridViewChiTiet";
            this.gridViewChiTiet.OptionsBehavior.Editable = false;
            this.gridViewChiTiet.OptionsView.ShowGroupPanel = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(382, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "📝 LẬP HÓA ĐƠN BÁN HÀNG";
            // 
            // fLapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fLapHoaDon";
            this.Text = "Lập hóa đơn bán hàng";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabThongTin.ResumeLayout(false);
            this.tabThongTin.PerformLayout();
            this.tabDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTiet)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
