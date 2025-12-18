namespace cosmetics_store.FormKH
{
    partial class fSanPhamDetail
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PictureEdit picSanPham;
        private DevExpress.XtraEditors.LabelControl lblTenSP;
        private DevExpress.XtraEditors.LabelControl lblThuongHieu;
        private DevExpress.XtraEditors.LabelControl lblGia;
        private DevExpress.XtraEditors.LabelControl lblMoTa;
        private DevExpress.XtraEditors.LabelControl lblTonKho;
        private DevExpress.XtraEditors.SpinEdit spinSoLuong;
        private DevExpress.XtraEditors.SimpleButton btnThemGio;
        private DevExpress.XtraEditors.SimpleButton btnDong;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.picSanPham = new DevExpress.XtraEditors.PictureEdit();
            this.lblTenSP = new DevExpress.XtraEditors.LabelControl();
            this.lblThuongHieu = new DevExpress.XtraEditors.LabelControl();
            this.lblGia = new DevExpress.XtraEditors.LabelControl();
            this.lblMoTa = new DevExpress.XtraEditors.LabelControl();
            this.lblTonKho = new DevExpress.XtraEditors.LabelControl();
            this.spinSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.btnThemGio = new DevExpress.XtraEditors.SimpleButton();
            this.btnDong = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanPham.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.picSanPham);
            this.pnlMain.Controls.Add(this.lblTenSP);
            this.pnlMain.Controls.Add(this.lblThuongHieu);
            this.pnlMain.Controls.Add(this.lblGia);
            this.pnlMain.Controls.Add(this.lblMoTa);
            this.pnlMain.Controls.Add(this.lblTonKho);
            this.pnlMain.Controls.Add(this.spinSoLuong);
            this.pnlMain.Controls.Add(this.btnThemGio);
            this.pnlMain.Controls.Add(this.btnDong);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(600, 450);
            this.pnlMain.TabIndex = 0;
            // 
            // picSanPham
            // 
            this.picSanPham.Location = new System.Drawing.Point(20, 20);
            this.picSanPham.Name = "picSanPham";
            this.picSanPham.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picSanPham.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picSanPham.Size = new System.Drawing.Size(250, 250);
            this.picSanPham.TabIndex = 0;
            // 
            // lblTenSP
            // 
            this.lblTenSP.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTenSP.Appearance.Options.UseFont = true;
            this.lblTenSP.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTenSP.Location = new System.Drawing.Point(290, 20);
            this.lblTenSP.Name = "lblTenSP";
            this.lblTenSP.Size = new System.Drawing.Size(290, 60);
            this.lblTenSP.TabIndex = 1;
            this.lblTenSP.Text = "Ten san pham";
            // 
            // lblThuongHieu
            // 
            this.lblThuongHieu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThuongHieu.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblThuongHieu.Appearance.Options.UseFont = true;
            this.lblThuongHieu.Appearance.Options.UseForeColor = true;
            this.lblThuongHieu.Location = new System.Drawing.Point(290, 85);
            this.lblThuongHieu.Name = "lblThuongHieu";
            this.lblThuongHieu.Size = new System.Drawing.Size(100, 19);
            this.lblThuongHieu.TabIndex = 2;
            this.lblThuongHieu.Text = "Thuong hieu";
            // 
            // lblGia
            // 
            this.lblGia.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblGia.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblGia.Appearance.Options.UseFont = true;
            this.lblGia.Appearance.Options.UseForeColor = true;
            this.lblGia.Location = new System.Drawing.Point(290, 120);
            this.lblGia.Name = "lblGia";
            this.lblGia.Size = new System.Drawing.Size(150, 32);
            this.lblGia.TabIndex = 3;
            this.lblGia.Text = "0 VND";
            // 
            // lblMoTa
            // 
            this.lblMoTa.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblMoTa.Appearance.Options.UseFont = true;
            this.lblMoTa.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMoTa.Location = new System.Drawing.Point(290, 165);
            this.lblMoTa.Name = "lblMoTa";
            this.lblMoTa.Size = new System.Drawing.Size(290, 80);
            this.lblMoTa.TabIndex = 4;
            this.lblMoTa.Text = "Mo ta san pham";
            // 
            // lblTonKho
            // 
            this.lblTonKho.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTonKho.Appearance.ForeColor = System.Drawing.Color.Green;
            this.lblTonKho.Appearance.Options.UseFont = true;
            this.lblTonKho.Appearance.Options.UseForeColor = true;
            this.lblTonKho.Location = new System.Drawing.Point(290, 260);
            this.lblTonKho.Name = "lblTonKho";
            this.lblTonKho.Size = new System.Drawing.Size(100, 19);
            this.lblTonKho.TabIndex = 5;
            this.lblTonKho.Text = "Con hang";
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.EditValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinSoLuong.Location = new System.Drawing.Point(290, 300);
            this.spinSoLuong.Name = "spinSoLuong";
            this.spinSoLuong.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.spinSoLuong.Properties.Appearance.Options.UseFont = true;
            this.spinSoLuong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinSoLuong.Properties.IsFloatValue = false;
            this.spinSoLuong.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinSoLuong.Size = new System.Drawing.Size(80, 30);
            this.spinSoLuong.TabIndex = 6;
            // 
            // btnThemGio
            // 
            this.btnThemGio.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnThemGio.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnThemGio.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThemGio.Appearance.Options.UseBackColor = true;
            this.btnThemGio.Appearance.Options.UseFont = true;
            this.btnThemGio.Appearance.Options.UseForeColor = true;
            this.btnThemGio.Location = new System.Drawing.Point(290, 350);
            this.btnThemGio.Name = "btnThemGio";
            this.btnThemGio.Size = new System.Drawing.Size(180, 45);
            this.btnThemGio.TabIndex = 7;
            this.btnThemGio.Text = "THEM VAO GIO";
            this.btnThemGio.Click += new System.EventHandler(this.btnThemGio_Click);
            // 
            // btnDong
            // 
            this.btnDong.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnDong.Appearance.Options.UseFont = true;
            this.btnDong.Location = new System.Drawing.Point(490, 350);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(90, 45);
            this.btnDong.TabIndex = 8;
            this.btnDong.Text = "Dong";
            this.btnDong.Click += new System.EventHandler(this.btnDong_Click);
            // 
            // fSanPhamDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 450);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fSanPhamDetail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiet san pham";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSanPham.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
