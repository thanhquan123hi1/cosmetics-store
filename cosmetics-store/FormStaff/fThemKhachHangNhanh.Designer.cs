namespace cosmetics_store.FormStaff
{
    partial class fThemKhachHangNhanh
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
            DevExpress.XtraEditors.SimpleButton btnLuu;
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.lblSDT = new DevExpress.XtraEditors.LabelControl();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            btnLuu = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLuu
            // 
            btnLuu.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            btnLuu.Appearance.ForeColor = System.Drawing.Color.Red;
            btnLuu.Appearance.Options.UseFont = true;
            btnLuu.Appearance.Options.UseForeColor = true;
            btnLuu.Location = new System.Drawing.Point(160, 205);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new System.Drawing.Size(120, 36);
            btnLuu.TabIndex = 7;
            btnLuu.Text = "Lưu";
            btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(23, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(293, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "THÊM KHÁCH HÀNG NHANH";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Appearance.Options.UseFont = true;
            this.lblHoTen.Location = new System.Drawing.Point(23, 65);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(63, 23);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ tên:";
            // 
            // lblSDT
            // 
            this.lblSDT.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblSDT.Appearance.Options.UseFont = true;
            this.lblSDT.Location = new System.Drawing.Point(23, 110);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(116, 23);
            this.lblSDT.TabIndex = 2;
            this.lblSDT.Text = "Số điện thoại:";
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.lblDiaChi.Appearance.Options.UseFont = true;
            this.lblDiaChi.Location = new System.Drawing.Point(23, 155);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(61, 23);
            this.lblDiaChi.TabIndex = 3;
            this.lblDiaChi.Text = "Địa chỉ:";
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnHuy.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Appearance.Options.UseForeColor = true;
            this.btnHuy.Location = new System.Drawing.Point(303, 205);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(120, 36);
            this.btnHuy.TabIndex = 8;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(160, 151);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Properties.MaxLength = 200;
            this.txtDiaChi.Size = new System.Drawing.Size(263, 30);
            this.txtDiaChi.TabIndex = 6;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(160, 106);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Properties.MaskSettings.Set("MaskManagerType", typeof(DevExpress.Data.Mask.RegExpMaskManager));
            this.txtSDT.Properties.MaskSettings.Set("allowBlankInput", true);
            this.txtSDT.Properties.MaskSettings.Set("mask", "\\d{0,15}");
            this.txtSDT.Size = new System.Drawing.Size(263, 30);
            this.txtSDT.TabIndex = 5;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(160, 61);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Properties.MaxLength = 100;
            this.txtHoTen.Size = new System.Drawing.Size(263, 30);
            this.txtHoTen.TabIndex = 4;
            // 
            // fThemKhachHangNhanh
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayoutStore = System.Windows.Forms.ImageLayout.Tile;
            this.BackgroundImageStore = global::cosmetics_store.Properties.Resources.tải_xuống__5_;
            this.ClientSize = new System.Drawing.Size(457, 260);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(btnLuu);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.lblTitle);
            this.Font = new System.Drawing.Font("Vladimir Script", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fThemKhachHangNhanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm khách hàng nhanh";
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraEditors.LabelControl lblSDT;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
    }
}
