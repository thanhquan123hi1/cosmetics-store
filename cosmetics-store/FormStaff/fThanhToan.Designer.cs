namespace cosmetics_store.FormStaff
{
    partial class fThanhToan
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblKhachHang;
        private DevExpress.XtraEditors.LabelControl lblSDT;
        private DevExpress.XtraEditors.LabelControl lblTongTien;
        private DevExpress.XtraEditors.LabelControl lblPhuongThuc;
        private System.Windows.Forms.RadioButton rbTienMat;
        private System.Windows.Forms.RadioButton rbChuyenKhoan;
        private System.Windows.Forms.RadioButton rbViDienTu;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.SimpleButton btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblKhachHang = new DevExpress.XtraEditors.LabelControl();
            this.lblSDT = new DevExpress.XtraEditors.LabelControl();
            this.lblTongTien = new DevExpress.XtraEditors.LabelControl();
            this.lblPhuongThuc = new DevExpress.XtraEditors.LabelControl();
            this.rbTienMat = new System.Windows.Forms.RadioButton();
            this.rbChuyenKhoan = new System.Windows.Forms.RadioButton();
            this.rbViDienTu = new System.Windows.Forms.RadioButton();
            this.btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblKhachHang);
            this.pnlMain.Controls.Add(this.lblSDT);
            this.pnlMain.Controls.Add(this.lblTongTien);
            this.pnlMain.Controls.Add(this.lblPhuongThuc);
            this.pnlMain.Controls.Add(this.rbTienMat);
            this.pnlMain.Controls.Add(this.rbChuyenKhoan);
            this.pnlMain.Controls.Add(this.rbViDienTu);
            this.pnlMain.Controls.Add(this.btnXacNhan);
            this.pnlMain.Controls.Add(this.btnHuy);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(400, 380);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(361, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "💳 THANH TOÁN HÓA ĐƠN";
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblKhachHang.Appearance.Options.UseFont = true;
            this.lblKhachHang.Location = new System.Drawing.Point(20, 70);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(229, 25);
            this.lblKhachHang.TabIndex = 1;
            this.lblKhachHang.Text = "Khách hàng: Nguyễn Văn A";
            // 
            // lblSDT
            // 
            this.lblSDT.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSDT.Appearance.Options.UseFont = true;
            this.lblSDT.Location = new System.Drawing.Point(20, 100);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(100, 23);
            this.lblSDT.TabIndex = 2;
            this.lblSDT.Text = "SĐT: 0123456789";
            // 
            // lblTongTien
            // 
            this.lblTongTien.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTongTien.Appearance.Options.UseFont = true;
            this.lblTongTien.Appearance.Options.UseForeColor = true;
            this.lblTongTien.Location = new System.Drawing.Point(20, 135);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(275, 32);
            this.lblTongTien.TabIndex = 3;
            this.lblTongTien.Text = "Tổng tiền: 490.000 VND";
            // 
            // lblPhuongThuc
            // 
            this.lblPhuongThuc.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPhuongThuc.Appearance.Options.UseFont = true;
            this.lblPhuongThuc.Location = new System.Drawing.Point(20, 180);
            this.lblPhuongThuc.Name = "lblPhuongThuc";
            this.lblPhuongThuc.Size = new System.Drawing.Size(224, 25);
            this.lblPhuongThuc.TabIndex = 4;
            this.lblPhuongThuc.Text = "Phương thức thanh toán:";
            // 
            // rbTienMat
            // 
            this.rbTienMat.AutoSize = true;
            this.rbTienMat.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbTienMat.Location = new System.Drawing.Point(40, 215);
            this.rbTienMat.Name = "rbTienMat";
            this.rbTienMat.Size = new System.Drawing.Size(132, 29);
            this.rbTienMat.TabIndex = 5;
            this.rbTienMat.TabStop = true;
            this.rbTienMat.Text = "💵 Tiền mặt";
            this.rbTienMat.UseVisualStyleBackColor = true;
            // 
            // rbChuyenKhoan
            // 
            this.rbChuyenKhoan.AutoSize = true;
            this.rbChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbChuyenKhoan.Location = new System.Drawing.Point(40, 245);
            this.rbChuyenKhoan.Name = "rbChuyenKhoan";
            this.rbChuyenKhoan.Size = new System.Drawing.Size(180, 29);
            this.rbChuyenKhoan.TabIndex = 6;
            this.rbChuyenKhoan.TabStop = true;
            this.rbChuyenKhoan.Text = "🏦 Chuyển khoản";
            this.rbChuyenKhoan.UseVisualStyleBackColor = true;
            // 
            // rbViDienTu
            // 
            this.rbViDienTu.AutoSize = true;
            this.rbViDienTu.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.rbViDienTu.Location = new System.Drawing.Point(40, 275);
            this.rbViDienTu.Name = "rbViDienTu";
            this.rbViDienTu.Size = new System.Drawing.Size(140, 29);
            this.rbViDienTu.TabIndex = 7;
            this.rbViDienTu.TabStop = true;
            this.rbViDienTu.Text = "📱 Ví điện tử";
            this.rbViDienTu.UseVisualStyleBackColor = true;
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnXacNhan.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnXacNhan.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnXacNhan.Appearance.Options.UseBackColor = true;
            this.btnXacNhan.Appearance.Options.UseFont = true;
            this.btnXacNhan.Appearance.Options.UseForeColor = true;
            this.btnXacNhan.Location = new System.Drawing.Point(40, 320);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(158, 40);
            this.btnXacNhan.TabIndex = 8;
            this.btnXacNhan.Text = "✅ Xác nhận";
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Location = new System.Drawing.Point(219, 320);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(136, 40);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // fThanhToan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 380);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fThanhToan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thanh toán hóa đơn";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
