namespace cosmetics_store.Forms
{
    partial class BanHangFormDx
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer;
        private DevExpress.XtraEditors.SearchControl txtSearch;
        private DevExpress.XtraGrid.GridControl gridSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSanPham;
        private DevExpress.XtraEditors.SimpleButton btnThemVaoGio;
        private DevExpress.XtraGrid.GridControl gridGioHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGioHang;
        private DevExpress.XtraEditors.SimpleButton btnXoaKhoiGio;
        private DevExpress.XtraEditors.LabelControl lblKhachHang;
        private DevExpress.XtraEditors.LookUpEdit lookupKhachHang;
        private DevExpress.XtraEditors.LabelControl lblPhuongThuc;
        private DevExpress.XtraEditors.ComboBoxEdit cboPhuongThuc;
        private DevExpress.XtraEditors.LabelControl lblTongTien;
        private DevExpress.XtraEditors.SimpleButton btnThanhToan;
        private DevExpress.XtraEditors.SimpleButton btnHuyDon;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            DevExpress.XtraGrid.GridLevelNode gridLevelNode2 = new DevExpress.XtraGrid.GridLevelNode();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.txtSearch = new DevExpress.XtraEditors.SearchControl();
            this.gridSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSanPham = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnThemVaoGio = new DevExpress.XtraEditors.SimpleButton();
            this.gridGioHang = new DevExpress.XtraGrid.GridControl();
            this.gridViewGioHang = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoaKhoiGio = new DevExpress.XtraEditors.SimpleButton();
            this.lblKhachHang = new DevExpress.XtraEditors.LabelControl();
            this.lookupKhachHang = new DevExpress.XtraEditors.LookUpEdit();
            this.lblPhuongThuc = new DevExpress.XtraEditors.LabelControl();
            this.cboPhuongThuc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTongTien = new DevExpress.XtraEditors.LabelControl();
            this.btnThanhToan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuyDon = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGioHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGioHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupKhachHang.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhuongThuc.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.txtSearch);
            this.splitContainer.Panel1.Controls.Add(this.gridSanPham);
            this.splitContainer.Panel1.Controls.Add(this.btnThemVaoGio);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gridGioHang);
            this.splitContainer.Panel2.Controls.Add(this.btnXoaKhoiGio);
            this.splitContainer.Panel2.Controls.Add(this.lblKhachHang);
            this.splitContainer.Panel2.Controls.Add(this.lookupKhachHang);
            this.splitContainer.Panel2.Controls.Add(this.lblPhuongThuc);
            this.splitContainer.Panel2.Controls.Add(this.cboPhuongThuc);
            this.splitContainer.Panel2.Controls.Add(this.lblTongTien);
            this.splitContainer.Panel2.Controls.Add(this.btnThanhToan);
            this.splitContainer.Panel2.Controls.Add(this.btnHuyDon);
            this.splitContainer.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer_Panel2_Paint);
            this.splitContainer.Size = new System.Drawing.Size(1200, 700);
            this.splitContainer.SplitterDistance = 600;
            this.splitContainer.TabIndex = 0;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.NullValuePrompt = "Tìm sản phẩm...";
            this.txtSearch.Properties.ShowClearButton = false;
            this.txtSearch.Properties.ShowSearchButton = false;
            this.txtSearch.Size = new System.Drawing.Size(400, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.SelectedIndexChanged += new System.EventHandler(this.txtSearch_SelectedIndexChanged);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // gridSanPham
            // 
            this.gridSanPham.Location = new System.Drawing.Point(12, 50);
            this.gridSanPham.MainView = this.gridViewSanPham;
            this.gridSanPham.Name = "gridSanPham";
            this.gridSanPham.Size = new System.Drawing.Size(576, 500);
            this.gridSanPham.TabIndex = 1;
            this.gridSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSanPham});
            this.gridSanPham.Click += new System.EventHandler(this.gridSanPham_Click);
            // 
            // gridViewSanPham
            // 
            this.gridViewSanPham.GridControl = this.gridSanPham;
            this.gridViewSanPham.Name = "gridViewSanPham";
            this.gridViewSanPham.OptionsView.ShowGroupPanel = false;
            // 
            // btnThemVaoGio
            // 
            this.btnThemVaoGio.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemVaoGio.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnThemVaoGio.Appearance.Options.UseFont = true;
            this.btnThemVaoGio.Appearance.Options.UseForeColor = true;
            this.btnThemVaoGio.Location = new System.Drawing.Point(12, 570);
            this.btnThemVaoGio.Name = "btnThemVaoGio";
            this.btnThemVaoGio.Size = new System.Drawing.Size(217, 35);
            this.btnThemVaoGio.TabIndex = 2;
            this.btnThemVaoGio.Text = " Thêm vào giỏ";
            this.btnThemVaoGio.Click += new System.EventHandler(this.btnThemVaoGio_Click);
            // 
            // gridGioHang
            // 
            gridLevelNode2.RelationName = "Level1";
            this.gridGioHang.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode2});
            this.gridGioHang.Location = new System.Drawing.Point(12, 12);
            this.gridGioHang.MainView = this.gridViewGioHang;
            this.gridGioHang.Name = "gridGioHang";
            this.gridGioHang.Size = new System.Drawing.Size(572, 400);
            this.gridGioHang.TabIndex = 0;
            this.gridGioHang.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewGioHang});
            // 
            // gridViewGioHang
            // 
            this.gridViewGioHang.GridControl = this.gridGioHang;
            this.gridViewGioHang.Name = "gridViewGioHang";
            this.gridViewGioHang.OptionsView.ShowGroupPanel = false;
            // 
            // btnXoaKhoiGio
            // 
            this.btnXoaKhoiGio.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnXoaKhoiGio.Appearance.ForeColor = System.Drawing.Color.BlueViolet;
            this.btnXoaKhoiGio.Appearance.Options.UseFont = true;
            this.btnXoaKhoiGio.Appearance.Options.UseForeColor = true;
            this.btnXoaKhoiGio.Location = new System.Drawing.Point(12, 420);
            this.btnXoaKhoiGio.Name = "btnXoaKhoiGio";
            this.btnXoaKhoiGio.Size = new System.Drawing.Size(150, 29);
            this.btnXoaKhoiGio.TabIndex = 1;
            this.btnXoaKhoiGio.Text = "❌ Xóa khỏi giỏ";
            this.btnXoaKhoiGio.Click += new System.EventHandler(this.btnXoaKhoiGio_Click);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Location = new System.Drawing.Point(12, 470);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(71, 16);
            this.lblKhachHang.TabIndex = 2;
            this.lblKhachHang.Text = "Khách hàng:";
            // 
            // lookupKhachHang
            // 
            this.lookupKhachHang.Location = new System.Drawing.Point(100, 467);
            this.lookupKhachHang.Name = "lookupKhachHang";
            this.lookupKhachHang.Size = new System.Drawing.Size(200, 22);
            this.lookupKhachHang.TabIndex = 3;
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.Location = new System.Drawing.Point(320, 470);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(77, 16);
            this.lblPhuongThuc.TabIndex = 4;
            this.lblPhuongThuc.Text = "Phương thức:";
            // 
            // cboPhuongThuc
            // 
            this.cboPhuongThuc.Location = new System.Drawing.Point(410, 467);
            this.cboPhuongThuc.Name = "cboPhuongThuc";
            this.cboPhuongThuc.Properties.Items.AddRange(new object[] {
            "Tiền mặt",
            "Chuyển khoản",
            "Thẻ"});
            this.cboPhuongThuc.Size = new System.Drawing.Size(150, 22);
            this.cboPhuongThuc.TabIndex = 5;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblTongTien.Appearance.Options.UseFont = true;
            this.lblTongTien.Appearance.Options.UseForeColor = true;
            this.lblTongTien.Location = new System.Drawing.Point(12, 520);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(137, 31);
            this.lblTongTien.TabIndex = 6;
            this.lblTongTien.Text = "TỔNG TIỀN:";
            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhToan.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnThanhToan.Appearance.Options.UseFont = true;
            this.btnThanhToan.Appearance.Options.UseForeColor = true;
            this.btnThanhToan.Location = new System.Drawing.Point(12, 570);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(238, 50);
            this.btnThanhToan.TabIndex = 7;
            this.btnThanhToan.Text = "💳 THANH TOÁN";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);
            // 
            // btnHuyDon
            // 
            this.btnHuyDon.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHuyDon.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.btnHuyDon.Appearance.Options.UseFont = true;
            this.btnHuyDon.Appearance.Options.UseForeColor = true;
            this.btnHuyDon.Location = new System.Drawing.Point(351, 570);
            this.btnHuyDon.Name = "btnHuyDon";
            this.btnHuyDon.Size = new System.Drawing.Size(175, 50);
            this.btnHuyDon.TabIndex = 8;
            this.btnHuyDon.Text = "❌ HỦY ĐƠN";
            this.btnHuyDon.Click += new System.EventHandler(this.btnHuyDon_Click);
            // 
            // BanHangFormDx
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.splitContainer);
            this.Name = "BanHangFormDx";
            this.Text = "Bán hàng (POS)";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridGioHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGioHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupKhachHang.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboPhuongThuc.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
