namespace cosmetics_store.Forms
{
    partial class KhachHangEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.LabelControl lblSDT;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.LabelControl lblGioiTinh;
        private DevExpress.XtraEditors.ComboBoxEdit cboGioiTinh;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.lblSDT = new DevExpress.XtraEditors.LabelControl();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.lblGioiTinh = new DevExpress.XtraEditors.LabelControl();
            this.cboGioiTinh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHoTen
            // 
            this.lblHoTen.Location = new System.Drawing.Point(20, 23);
            this.lblHoTen.Text = "Ho ten:";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(120, 20);
            this.txtHoTen.Size = new System.Drawing.Size(300, 22);
            // 
            // lblSDT
            // 
            this.lblSDT.Location = new System.Drawing.Point(20, 63);
            this.lblSDT.Text = "So dien thoai:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(120, 60);
            this.txtSDT.Size = new System.Drawing.Size(150, 22);
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Location = new System.Drawing.Point(280, 63);
            this.lblGioiTinh.Text = "Gioi tinh:";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Location = new System.Drawing.Point(340, 60);
            this.cboGioiTinh.Properties.Items.AddRange(new object[] { "Nam", "Nu" });
            this.cboGioiTinh.Size = new System.Drawing.Size(80, 22);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Location = new System.Drawing.Point(20, 103);
            this.lblDiaChi.Text = "Dia chi:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(120, 100);
            this.txtDiaChi.Size = new System.Drawing.Size(300, 22);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(220, 150);
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.Text = "Luu";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(326, 150);
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.Text = "Huy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // KhachHangEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 200);
            this.Controls.Add(this.lblHoTen);
            this.Controls.Add(this.txtHoTen);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblGioiTinh);
            this.Controls.Add(this.cboGioiTinh);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "KhachHangEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thong tin khach hang";
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
