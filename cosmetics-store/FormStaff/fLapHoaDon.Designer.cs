namespace cosmetics_store.FormStaff
{
    partial class fLapHoaDon
    {
        private System.ComponentModel.IContainer components = null;
        
        // Left Panel - San pham
        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.LabelControl lblTitleSP;
        private DevExpress.XtraEditors.TextEdit txtTimSP;
        private DevExpress.XtraEditors.SimpleButton btnTimSP;
        private DevExpress.XtraGrid.GridControl gridSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSanPham;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.SpinEdit spinSoLuong;
        private DevExpress.XtraEditors.SimpleButton btnThemSP;
        
        // Right Panel - Hoa don
        private DevExpress.XtraEditors.PanelControl pnlRight;
        private DevExpress.XtraEditors.LabelControl lblTitleHD;
        private DevExpress.XtraEditors.LabelControl lblMaHD;
        private DevExpress.XtraEditors.LabelControl lblNV;
        private DevExpress.XtraEditors.LabelControl lblNgay;
        private DevExpress.XtraEditors.LabelControl lblKhachHang;
        private DevExpress.XtraEditors.SimpleButton btnChonKH;
        private DevExpress.XtraGrid.GridControl gridChiTiet;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChiTiet;
        private DevExpress.XtraEditors.SimpleButton btnXoaSP;
        private DevExpress.XtraEditors.LabelControl lblTongTien;
        private DevExpress.XtraEditors.SimpleButton btnThanhToan;
        private DevExpress.XtraEditors.SimpleButton btnHuyHD;

        private void InitializeComponent()
        {
            this.pnlLeft = new DevExpress.XtraEditors.PanelControl();
            this.lblTitleSP = new DevExpress.XtraEditors.LabelControl();
            this.txtTimSP = new DevExpress.XtraEditors.TextEdit();
            this.btnTimSP = new DevExpress.XtraEditors.SimpleButton();
            this.gridSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.spinSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.btnThemSP = new DevExpress.XtraEditors.SimpleButton();
            this.pnlRight = new DevExpress.XtraEditors.PanelControl();
            this.lblTitleHD = new DevExpress.XtraEditors.LabelControl();
            this.lblMaHD = new DevExpress.XtraEditors.LabelControl();
            this.lblNV = new DevExpress.XtraEditors.LabelControl();
            this.lblNgay = new DevExpress.XtraEditors.LabelControl();
            this.lblKhachHang = new DevExpress.XtraEditors.LabelControl();
            this.btnChonKH = new DevExpress.XtraEditors.SimpleButton();
            this.gridChiTiet = new DevExpress.XtraGrid.GridControl();
            this.gridViewChiTiet = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoaSP = new DevExpress.XtraEditors.SimpleButton();
            this.lblTongTien = new DevExpress.XtraEditors.LabelControl();
            this.btnThanhToan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuyHD = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTiet)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft - Panel san pham
            // 
            this.pnlLeft.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Appearance.Options.UseBackColor = true;
            this.pnlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLeft.Controls.Add(this.lblTitleSP);
            this.pnlLeft.Controls.Add(this.txtTimSP);
            this.pnlLeft.Controls.Add(this.btnTimSP);
            this.pnlLeft.Controls.Add(this.gridSanPham);
            this.pnlLeft.Controls.Add(this.lblSoLuong);
            this.pnlLeft.Controls.Add(this.spinSoLuong);
            this.pnlLeft.Controls.Add(this.btnThemSP);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Padding = new System.Windows.Forms.Padding(15);
            this.pnlLeft.Size = new System.Drawing.Size(500, 600);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblTitleSP
            // 
            this.lblTitleSP.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleSP.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitleSP.Appearance.Options.UseFont = true;
            this.lblTitleSP.Appearance.Options.UseForeColor = true;
            this.lblTitleSP.Location = new System.Drawing.Point(15, 15);
            this.lblTitleSP.Name = "lblTitleSP";
            this.lblTitleSP.Size = new System.Drawing.Size(180, 25);
            this.lblTitleSP.TabIndex = 0;
            this.lblTitleSP.Text = "DANH SACH SAN PHAM";
            // 
            // txtTimSP
            // 
            this.txtTimSP.Location = new System.Drawing.Point(15, 50);
            this.txtTimSP.Name = "txtTimSP";
            this.txtTimSP.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimSP.Properties.Appearance.Options.UseFont = true;
            this.txtTimSP.Properties.NullValuePrompt = "Tim kiem san pham...";
            this.txtTimSP.Size = new System.Drawing.Size(370, 26);
            this.txtTimSP.TabIndex = 1;
            this.txtTimSP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimSP_KeyPress);
            // 
            // btnTimSP
            // 
            this.btnTimSP.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTimSP.Appearance.Options.UseFont = true;
            this.btnTimSP.Location = new System.Drawing.Point(395, 48);
            this.btnTimSP.Name = "btnTimSP";
            this.btnTimSP.Size = new System.Drawing.Size(90, 30);
            this.btnTimSP.TabIndex = 2;
            this.btnTimSP.Text = "Tim";
            this.btnTimSP.Click += new System.EventHandler(this.btnTimSP_Click);
            // 
            // gridSanPham
            // 
            this.gridSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSanPham.Location = new System.Drawing.Point(15, 90);
            this.gridSanPham.MainView = this.gridViewSanPham;
            this.gridSanPham.Name = "gridSanPham";
            this.gridSanPham.Size = new System.Drawing.Size(470, 430);
            this.gridSanPham.TabIndex = 3;
            // 
            // gridViewSanPham
            // 
            this.gridViewSanPham.GridControl = this.gridSanPham;
            this.gridViewSanPham.Name = "gridViewSanPham";
            this.gridViewSanPham.OptionsBehavior.Editable = false;
            this.gridViewSanPham.OptionsView.ShowGroupPanel = false;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblSoLuong.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSoLuong.Appearance.Options.UseFont = true;
            this.lblSoLuong.Location = new System.Drawing.Point(15, 535);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(60, 19);
            this.lblSoLuong.TabIndex = 4;
            this.lblSoLuong.Text = "So luong:";
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinSoLuong.EditValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinSoLuong.Location = new System.Drawing.Point(85, 532);
            this.spinSoLuong.Name = "spinSoLuong";
            this.spinSoLuong.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.spinSoLuong.Properties.Appearance.Options.UseFont = true;
            this.spinSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSoLuong.Properties.IsFloatValue = false;
            this.spinSoLuong.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinSoLuong.Size = new System.Drawing.Size(80, 28);
            this.spinSoLuong.TabIndex = 5;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemSP.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThemSP.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThemSP.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Appearance.Options.UseBackColor = true;
            this.btnThemSP.Appearance.Options.UseFont = true;
            this.btnThemSP.Appearance.Options.UseForeColor = true;
            this.btnThemSP.Location = new System.Drawing.Point(180, 528);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(180, 38);
            this.btnThemSP.TabIndex = 6;
            this.btnThemSP.Text = "+ THEM VAO HOA DON";
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // pnlRight - Panel hoa don
            // 
            this.pnlRight.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.pnlRight.Appearance.Options.UseBackColor = true;
            this.pnlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlRight.Controls.Add(this.lblTitleHD);
            this.pnlRight.Controls.Add(this.lblMaHD);
            this.pnlRight.Controls.Add(this.lblNV);
            this.pnlRight.Controls.Add(this.lblNgay);
            this.pnlRight.Controls.Add(this.lblKhachHang);
            this.pnlRight.Controls.Add(this.btnChonKH);
            this.pnlRight.Controls.Add(this.gridChiTiet);
            this.pnlRight.Controls.Add(this.btnXoaSP);
            this.pnlRight.Controls.Add(this.lblTongTien);
            this.pnlRight.Controls.Add(this.btnThanhToan);
            this.pnlRight.Controls.Add(this.btnHuyHD);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(500, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Padding = new System.Windows.Forms.Padding(15);
            this.pnlRight.Size = new System.Drawing.Size(500, 600);
            this.pnlRight.TabIndex = 1;
            // 
            // lblTitleHD
            // 
            this.lblTitleHD.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitleHD.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitleHD.Appearance.Options.UseFont = true;
            this.lblTitleHD.Appearance.Options.UseForeColor = true;
            this.lblTitleHD.Location = new System.Drawing.Point(15, 15);
            this.lblTitleHD.Name = "lblTitleHD";
            this.lblTitleHD.Size = new System.Drawing.Size(180, 25);
            this.lblTitleHD.TabIndex = 0;
            this.lblTitleHD.Text = "HOA DON BAN HANG";
            // 
            // lblMaHD
            // 
            this.lblMaHD.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblMaHD.Appearance.Options.UseFont = true;
            this.lblMaHD.Location = new System.Drawing.Point(15, 55);
            this.lblMaHD.Name = "lblMaHD";
            this.lblMaHD.Size = new System.Drawing.Size(140, 20);
            this.lblMaHD.TabIndex = 1;
            this.lblMaHD.Text = "Ma HD: HD0123";
            // 
            // lblNV
            // 
            this.lblNV.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNV.Appearance.Options.UseFont = true;
            this.lblNV.Location = new System.Drawing.Point(180, 55);
            this.lblNV.Name = "lblNV";
            this.lblNV.Size = new System.Drawing.Size(100, 19);
            this.lblNV.TabIndex = 2;
            this.lblNV.Text = "NV: NV01";
            // 
            // lblNgay
            // 
            this.lblNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblNgay.Appearance.Options.UseFont = true;
            this.lblNgay.Location = new System.Drawing.Point(320, 55);
            this.lblNgay.Name = "lblNgay";
            this.lblNgay.Size = new System.Drawing.Size(130, 19);
            this.lblNgay.TabIndex = 3;
            this.lblNgay.Text = "Ngay: 15/12/2025";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKhachHang.Appearance.Options.UseFont = true;
            this.lblKhachHang.Location = new System.Drawing.Point(15, 90);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(180, 19);
            this.lblKhachHang.TabIndex = 4;
            this.lblKhachHang.Text = "Khach hang: (Chua chon)";
            // 
            // btnChonKH
            // 
            this.btnChonKH.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnChonKH.Appearance.Options.UseFont = true;
            this.btnChonKH.Location = new System.Drawing.Point(230, 86);
            this.btnChonKH.Name = "btnChonKH";
            this.btnChonKH.Size = new System.Drawing.Size(100, 28);
            this.btnChonKH.TabIndex = 5;
            this.btnChonKH.Text = "Chon KH";
            this.btnChonKH.Click += new System.EventHandler(this.btnChonKH_Click);
            // 
            // gridChiTiet
            // 
            this.gridChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gridChiTiet.Location = new System.Drawing.Point(15, 125);
            this.gridChiTiet.MainView = this.gridViewChiTiet;
            this.gridChiTiet.Name = "gridChiTiet";
            this.gridChiTiet.Size = new System.Drawing.Size(470, 350);
            this.gridChiTiet.TabIndex = 6;
            // 
            // gridViewChiTiet
            // 
            this.gridViewChiTiet.GridControl = this.gridChiTiet;
            this.gridViewChiTiet.Name = "gridViewChiTiet";
            this.gridViewChiTiet.OptionsBehavior.Editable = false;
            this.gridViewChiTiet.OptionsView.ShowGroupPanel = false;
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaSP.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaSP.Appearance.Options.UseFont = true;
            this.btnXoaSP.Location = new System.Drawing.Point(15, 485);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(100, 30);
            this.btnXoaSP.TabIndex = 7;
            this.btnXoaSP.Text = "Xoa dong";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // lblTongTien
            // 
            this.lblTongTien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblTongTien.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTien.Appearance.Options.UseFont = true;
            this.lblTongTien.Appearance.Options.UseForeColor = true;
            this.lblTongTien.Location = new System.Drawing.Point(15, 525);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(250, 30);
            this.lblTongTien.TabIndex = 8;
            this.lblTongTien.Text = "TONG TIEN: 0 VND";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThanhToan.Appearance.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Appearance.Options.UseBackColor = true;
            this.btnThanhToan.Appearance.Options.UseFont = true;
            this.btnThanhToan.Appearance.Options.UseForeColor = true;
            this.btnThanhToan.Location = new System.Drawing.Point(280, 520);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(140, 45);
            this.btnThanhToan.TabIndex = 9;
            this.btnThanhToan.Text = "THANH TOAN";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnHuyHD
            // 
            this.btnHuyHD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyHD.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuyHD.Appearance.Options.UseFont = true;
            this.btnHuyHD.Location = new System.Drawing.Point(430, 520);
            this.btnHuyHD.Name = "btnHuyHD";
            this.btnHuyHD.Size = new System.Drawing.Size(55, 45);
            this.btnHuyHD.TabIndex = 10;
            this.btnHuyHD.Text = "Huy";
            this.btnHuyHD.Click += new System.EventHandler(this.btnHuyHD_Click);
            // 
            // fLapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fLapHoaDon";
            this.Text = "Lap hoa don ban hang";
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTiet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTiet)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
