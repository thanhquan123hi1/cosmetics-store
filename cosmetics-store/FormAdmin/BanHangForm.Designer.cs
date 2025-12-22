namespace cosmetics_store.Forms
{
    partial class BanHangForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DevExpress.XtraEditors.GroupControl grpSanPham;
        private DevExpress.XtraEditors.SearchControl searchSanPham;
        private DevExpress.XtraGrid.GridControl gridSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSanPham;
        private DevExpress.XtraEditors.GroupControl grpGioHang;
        private DevExpress.XtraGrid.GridControl gridGioHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGioHang;
        private DevExpress.XtraEditors.SimpleButton btnThemVaoGio;
        private DevExpress.XtraEditors.SimpleButton btnXoaKhoiGio;
        private DevExpress.XtraEditors.GroupControl grpThanhToan;
        private DevExpress.XtraEditors.LabelControl lblKhachHang;
        private DevExpress.XtraEditors.LookUpEdit lookupKhachHang;
        private DevExpress.XtraEditors.LabelControl lblTongTien;
        private DevExpress.XtraEditors.LabelControl lblTongTienValue;
        private DevExpress.XtraEditors.LabelControl lblPhuongThuc;
        private DevExpress.XtraEditors.ComboBoxEdit cboPhuongThuc;
        private DevExpress.XtraEditors.SimpleButton btnThanhToan;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.SpinEdit spinSoLuong;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.grpSanPham = new DevExpress.XtraEditors.GroupControl();
            this.searchSanPham = new DevExpress.XtraEditors.SearchControl();
            this.gridSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.spinSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.btnThemVaoGio = new DevExpress.XtraEditors.SimpleButton();
            this.grpGioHang = new DevExpress.XtraEditors.GroupControl();
            this.gridGioHang = new DevExpress.XtraGrid.GridControl();
            this.gridViewGioHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoaKhoiGio = new DevExpress.XtraEditors.SimpleButton();
            this.grpThanhToan = new DevExpress.XtraEditors.GroupControl();
            this.lblKhachHang = new DevExpress.XtraEditors.LabelControl();
            this.lookupKhachHang = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTongTien = new DevExpress.XtraEditors.LabelControl();
            this.lblTongTienValue = new DevExpress.XtraEditors.LabelControl();
            this.lblPhuongThuc = new DevExpress.XtraEditors.LabelControl();
            this.cboPhuongThuc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnThanhToan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpSanPham)).BeginInit();
            this.grpSanPham.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchSanPham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGioHang)).BeginInit();
            this.grpGioHang.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGioHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGioHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpThanhToan)).BeginInit();
            this.grpThanhToan.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhuongThuc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.splitContainer);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1000, 650);
            this.pnlMain.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.Location = new System.Drawing.Point(20, 55);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.grpSanPham);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.grpGioHang);
            this.splitContainer.Panel2.Controls.Add(this.grpThanhToan);
            this.splitContainer.Size = new System.Drawing.Size(960, 580);
            this.splitContainer.SplitterDistance = 480;
            this.splitContainer.TabIndex = 1;
            // 
            // grpSanPham
            // 
            this.grpSanPham.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpSanPham.AppearanceCaption.Options.UseFont = true;
            this.grpSanPham.Controls.Add(this.searchSanPham);
            this.grpSanPham.Controls.Add(this.gridSanPham);
            this.grpSanPham.Controls.Add(this.lblSoLuong);
            this.grpSanPham.Controls.Add(this.spinSoLuong);
            this.grpSanPham.Controls.Add(this.btnThemVaoGio);
            this.grpSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSanPham.Location = new System.Drawing.Point(0, 0);
            this.grpSanPham.Name = "grpSanPham";
            this.grpSanPham.Size = new System.Drawing.Size(480, 580);
            this.grpSanPham.TabIndex = 0;
            this.grpSanPham.Text = "Danh sách sản phẩm";
            // 
            // searchSanPham
            // 
            this.searchSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchSanPham.Location = new System.Drawing.Point(10, 35);
            this.searchSanPham.Name = "searchSanPham";
            this.searchSanPham.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchSanPham.Properties.Appearance.Options.UseFont = true;
            this.searchSanPham.Properties.NullValuePrompt = "T?m s?n ph?m...";
            this.searchSanPham.Properties.ShowClearButton = false;
            this.searchSanPham.Properties.ShowSearchButton = false;
            this.searchSanPham.Size = new System.Drawing.Size(460, 30);
            this.searchSanPham.TabIndex = 0;
            this.searchSanPham.SelectedIndexChanged += new System.EventHandler(this.searchSanPham_SelectedIndexChanged);
            // 
            // gridSanPham
            // 
            this.gridSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSanPham.Location = new System.Drawing.Point(5, 71);
            this.gridSanPham.MainView = this.gridViewSanPham;
            this.gridSanPham.Name = "gridSanPham";
            this.gridSanPham.Size = new System.Drawing.Size(465, 450);
            this.gridSanPham.TabIndex = 1;
            this.gridSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSanPham});
            this.gridSanPham.Click += new System.EventHandler(this.gridSanPham_Click);
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
            this.lblSoLuong.Location = new System.Drawing.Point(10, 535);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(77, 23);
            this.lblSoLuong.TabIndex = 2;
            this.lblSoLuong.Text = "Số lượng: ";
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.spinSoLuong.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSoLuong.Location = new System.Drawing.Point(80, 532);
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
            this.spinSoLuong.TabIndex = 3;
            // 
            // btnThemVaoGio
            // 
            this.btnThemVaoGio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemVaoGio.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThemVaoGio.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnThemVaoGio.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThemVaoGio.Appearance.Options.UseBackColor = true;
            this.btnThemVaoGio.Appearance.Options.UseFont = true;
            this.btnThemVaoGio.Appearance.Options.UseForeColor = true;
            this.btnThemVaoGio.Location = new System.Drawing.Point(180, 530);
            this.btnThemVaoGio.Name = "btnThemVaoGio";
            this.btnThemVaoGio.Size = new System.Drawing.Size(150, 30);
            this.btnThemVaoGio.TabIndex = 4;
            this.btnThemVaoGio.Text = "Thêm vào giỏ";
            this.btnThemVaoGio.Click += new System.EventHandler(this.btnThemVaoGio_Click);
            // 
            // grpGioHang
            // 
            this.grpGioHang.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpGioHang.AppearanceCaption.Options.UseFont = true;
            this.grpGioHang.Controls.Add(this.gridGioHang);
            this.grpGioHang.Controls.Add(this.btnXoaKhoiGio);
            this.grpGioHang.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpGioHang.Location = new System.Drawing.Point(0, 0);
            this.grpGioHang.Name = "grpGioHang";
            this.grpGioHang.Size = new System.Drawing.Size(476, 300);
            this.grpGioHang.TabIndex = 0;
            this.grpGioHang.Text = "Giỏ hàng";
            // 
            // gridGioHang
            // 
            this.gridGioHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridGioHang.Location = new System.Drawing.Point(15, 40);
            this.gridGioHang.MainView = this.gridViewGioHang;
            this.gridGioHang.Name = "gridGioHang";
            this.gridGioHang.Size = new System.Drawing.Size(456, 220);
            this.gridGioHang.TabIndex = 0;
            this.gridGioHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGioHang});
            // 
            // gridViewGioHang
            // 
            this.gridViewGioHang.GridControl = this.gridGioHang;
            this.gridViewGioHang.Name = "gridViewGioHang";
            this.gridViewGioHang.OptionsBehavior.Editable = false;
            this.gridViewGioHang.OptionsView.ShowGroupPanel = false;
            // 
            // btnXoaKhoiGio
            // 
            this.btnXoaKhoiGio.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnXoaKhoiGio.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaKhoiGio.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoaKhoiGio.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnXoaKhoiGio.Appearance.Options.UseBackColor = true;
            this.btnXoaKhoiGio.Appearance.Options.UseFont = true;
            this.btnXoaKhoiGio.Appearance.Options.UseForeColor = true;
            this.btnXoaKhoiGio.Location = new System.Drawing.Point(10, 262);
            this.btnXoaKhoiGio.Name = "btnXoaKhoiGio";
            this.btnXoaKhoiGio.Size = new System.Drawing.Size(100, 28);
            this.btnXoaKhoiGio.TabIndex = 1;
            this.btnXoaKhoiGio.Text = "Xóa";
            this.btnXoaKhoiGio.Click += new System.EventHandler(this.btnXoaKhoiGio_Click);
            // 
            // grpThanhToan
            // 
            this.grpThanhToan.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpThanhToan.AppearanceCaption.Options.UseFont = true;
            this.grpThanhToan.Controls.Add(this.lblKhachHang);
            this.grpThanhToan.Controls.Add(this.lookupKhachHang);
            this.grpThanhToan.Controls.Add(this.lblTongTien);
            this.grpThanhToan.Controls.Add(this.lblTongTienValue);
            this.grpThanhToan.Controls.Add(this.lblPhuongThuc);
            this.grpThanhToan.Controls.Add(this.cboPhuongThuc);
            this.grpThanhToan.Controls.Add(this.btnThanhToan);
            this.grpThanhToan.Controls.Add(this.btnHuy);
            this.grpThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpThanhToan.Location = new System.Drawing.Point(0, 0);
            this.grpThanhToan.Name = "grpThanhToan";
            this.grpThanhToan.Size = new System.Drawing.Size(476, 580);
            this.grpThanhToan.TabIndex = 1;
            this.grpThanhToan.Text = "?? Thanh toán";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblKhachHang.Appearance.Options.UseFont = true;
            this.lblKhachHang.Location = new System.Drawing.Point(15, 40);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(95, 23);
            this.lblKhachHang.TabIndex = 0;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // lookupKhachHang
            // 
            this.lookupKhachHang.Location = new System.Drawing.Point(100, 37);
            this.lookupKhachHang.Name = "lookupKhachHang";
            this.lookupKhachHang.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lookupKhachHang.Properties.Appearance.Options.UseFont = true;
            this.lookupKhachHang.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupKhachHang.Properties.NullText = "-- Ch?n khách hàng --";
            this.lookupKhachHang.Size = new System.Drawing.Size(280, 30);
            this.lookupKhachHang.TabIndex = 1;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Appearance.Options.UseFont = true;
            this.lblTongTien.Location = new System.Drawing.Point(15, 80);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(105, 28);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "T?NG TI?N:";
            // 
            // lblTongTienValue
            // 
            this.lblTongTienValue.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTongTienValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTienValue.Appearance.Options.UseFont = true;
            this.lblTongTienValue.Appearance.Options.UseForeColor = true;
            this.lblTongTienValue.Location = new System.Drawing.Point(15, 110);
            this.lblTongTienValue.Name = "lblTongTienValue";
            this.lblTongTienValue.Size = new System.Drawing.Size(43, 41);
            this.lblTongTienValue.TabIndex = 3;
            this.lblTongTienValue.Text = "0 ð";
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPhuongThuc.Appearance.Options.UseFont = true;
            this.lblPhuongThuc.Location = new System.Drawing.Point(15, 160);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(122, 23);
            this.lblPhuongThuc.TabIndex = 4;
            this.lblPhuongThuc.Text = "Phýõng th?c TT:";
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.EditValue = "Ti?n m?t";
            this.cboPhuongThuc.Location = new System.Drawing.Point(150, 157);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboPhuongThuc.Properties.Appearance.Options.UseFont = true;
            this.cboPhuongThuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboPhuongThuc.Properties.Items.AddRange(new object[] {
            "Ti?n m?t",
            "Chuy?n kho?n",
            "Th? tín d?ng"});
            this.cboPhuongThuc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboPhuongThuc.Size = new System.Drawing.Size(150, 30);
            this.cboPhuongThuc.TabIndex = 5;
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnThanhToan.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Appearance.Options.UseBackColor = true;
            this.btnThanhToan.Appearance.Options.UseFont = true;
            this.btnThanhToan.Appearance.Options.UseForeColor = true;
            this.btnThanhToan.Location = new System.Drawing.Point(15, 210);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(180, 45);
            this.btnThanhToan.TabIndex = 6;
            this.btnThanhToan.Text = "?? THANH TOÁN";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Location = new System.Drawing.Point(210, 220);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(100, 30);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "H?y";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(143, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Bán hàng";
            // 
            // BanHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 650);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BanHangForm";
            this.Text = "Bán hàng";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpSanPham)).EndInit();
            this.grpSanPham.ResumeLayout(false);
            this.grpSanPham.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchSanPham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpGioHang)).EndInit();
            this.grpGioHang.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridGioHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGioHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpThanhToan)).EndInit();
            this.grpThanhToan.ResumeLayout(false);
            this.grpThanhToan.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhuongThuc.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
