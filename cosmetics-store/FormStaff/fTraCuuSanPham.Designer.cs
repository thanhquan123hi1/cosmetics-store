namespace cosmetics_store.FormStaff
{
    partial class fTraCuuSanPham
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblTimKiem;
        private DevExpress.XtraEditors.TextEdit txtTimKiem;
        private DevExpress.XtraEditors.LabelControl lblThuongHieu;
        private DevExpress.XtraEditors.LookUpEdit cboThuongHieu;
        private DevExpress.XtraEditors.LabelControl lblLoai;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiSP;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private DevExpress.XtraGrid.GridControl gridSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSP;
        private DevExpress.XtraEditors.LabelControl lblKetQua;

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblTimKiem = new DevExpress.XtraEditors.LabelControl();
            this.txtTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblThuongHieu = new DevExpress.XtraEditors.LabelControl();
            this.cboThuongHieu = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLoai = new DevExpress.XtraEditors.LabelControl();
            this.cboLoaiSP = new DevExpress.XtraEditors.LookUpEdit();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.gridSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblKetQua = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThuongHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSP)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.lblKetQua);
            this.pnlMain.Controls.Add(this.btnLamMoi);
            this.pnlMain.Controls.Add(this.btnTimKiem);
            this.pnlMain.Controls.Add(this.cboLoaiSP);
            this.pnlMain.Controls.Add(this.lblLoai);
            this.pnlMain.Controls.Add(this.cboThuongHieu);
            this.pnlMain.Controls.Add(this.lblThuongHieu);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblTimKiem);
            this.pnlMain.Controls.Add(this.txtTimKiem);
            this.pnlMain.Controls.Add(this.gridSanPham);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 550);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(315, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 TRA CỨU SẢN PHẨM";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiem.Appearance.Options.UseFont = true;
            this.lblTimKiem.Location = new System.Drawing.Point(20, 65);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(67, 23);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm kiếm";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(95, 63);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Properties.Appearance.Options.UseFont = true;
            this.txtTimKiem.Size = new System.Drawing.Size(200, 30);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // lblThuongHieu
            // 
            this.lblThuongHieu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThuongHieu.Appearance.Options.UseFont = true;
            this.lblThuongHieu.Location = new System.Drawing.Point(305, 65);
            this.lblThuongHieu.Name = "lblThuongHieu";
            this.lblThuongHieu.Size = new System.Drawing.Size(97, 23);
            this.lblThuongHieu.TabIndex = 3;
            this.lblThuongHieu.Text = "Thương hiệu";
            // 
            // cboThuongHieu
            // 
            this.cboThuongHieu.Location = new System.Drawing.Point(410, 63);
            this.cboThuongHieu.Name = "cboThuongHieu";
            this.cboThuongHieu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThuongHieu.Properties.Appearance.Options.UseFont = true;
            this.cboThuongHieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThuongHieu.Properties.NullText = "";
            this.cboThuongHieu.Size = new System.Drawing.Size(150, 30);
            this.cboThuongHieu.TabIndex = 4;
            // 
            // lblLoai
            // 
            this.lblLoai.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoai.Appearance.Options.UseFont = true;
            this.lblLoai.Location = new System.Drawing.Point(570, 65);
            this.lblLoai.Name = "lblLoai";
            this.lblLoai.Size = new System.Drawing.Size(32, 23);
            this.lblLoai.TabIndex = 5;
            this.lblLoai.Text = "Loại";
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.Location = new System.Drawing.Point(610, 63);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiSP.Properties.Appearance.Options.UseFont = true;
            this.cboLoaiSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiSP.Properties.NullText = "";
            this.cboLoaiSP.Size = new System.Drawing.Size(150, 30);
            this.cboLoaiSP.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Appearance.Options.UseBackColor = true;
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Appearance.Options.UseForeColor = true;
            this.btnTimKiem.Location = new System.Drawing.Point(20, 105);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(100, 30);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "🔎 Tìm kiếm";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLamMoi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Appearance.Options.UseBackColor = true;
            this.btnLamMoi.Appearance.Options.UseFont = true;
            this.btnLamMoi.Appearance.Options.UseForeColor = true;
            this.btnLamMoi.Location = new System.Drawing.Point(130, 105);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(100, 30);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // gridSanPham
            // 
            this.gridSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSanPham.Location = new System.Drawing.Point(20, 145);
            this.gridSanPham.MainView = this.gridViewSP;
            this.gridSanPham.Name = "gridSanPham";
            this.gridSanPham.Size = new System.Drawing.Size(860, 360);
            this.gridSanPham.TabIndex = 9;
            this.gridSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSP});
            // 
            // gridViewSP
            // 
            this.gridViewSP.GridControl = this.gridSanPham;
            this.gridViewSP.Name = "gridViewSP";
            this.gridViewSP.OptionsBehavior.Editable = false;
            this.gridViewSP.OptionsView.ShowGroupPanel = false;
            // 
            // lblKetQua
            // 
            this.lblKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKetQua.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKetQua.Appearance.Options.UseFont = true;
            this.lblKetQua.Location = new System.Drawing.Point(20, 515);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(58, 23);
            this.lblKetQua.TabIndex = 10;
            this.lblKetQua.Text = "Kết quả";
            // 
            // fTraCuuSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fTraCuuSanPham";
            this.Text = "Tra cứu sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThuongHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSP)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
