namespace cosmetics_store.Forms
{
    partial class SanPhamEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.TextEdit txtTen;
        private DevExpress.XtraEditors.SpinEdit spinSoLuong;
        private DevExpress.XtraEditors.SpinEdit spinDonGia;
        private DevExpress.XtraEditors.LookUpEdit lookupLoai;
        private DevExpress.XtraEditors.LookUpEdit lookupThuong;
        private DevExpress.XtraEditors.TextEdit txtHinhAnh;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtTen = new DevExpress.XtraEditors.TextEdit();
            this.spinSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.spinDonGia = new DevExpress.XtraEditors.SpinEdit();
            this.lookupLoai = new DevExpress.XtraEditors.LookUpEdit();
            this.lookupThuong = new DevExpress.XtraEditors.LookUpEdit();
            this.txtHinhAnh = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupThuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHinhAnh.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(20, 20);
            this.txtTen.Name = "txtTen";
            this.txtTen.Properties.NullValuePrompt = "Ten san pham";
            this.txtTen.Size = new System.Drawing.Size(450, 22);
            this.txtTen.TabIndex = 0;
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinSoLuong.Location = new System.Drawing.Point(20, 170);
            this.spinSoLuong.Name = "spinSoLuong";
            this.spinSoLuong.Properties.IsFloatValue = false;
            this.spinSoLuong.Size = new System.Drawing.Size(200, 22);
            this.spinSoLuong.TabIndex = 3;
            // 
            // spinDonGia
            // 
            this.spinDonGia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinDonGia.Location = new System.Drawing.Point(270, 170);
            this.spinDonGia.Name = "spinDonGia";
            this.spinDonGia.Size = new System.Drawing.Size(200, 22);
            this.spinDonGia.TabIndex = 4;
            // 
            // lookupLoai
            // 
            this.lookupLoai.Location = new System.Drawing.Point(20, 70);
            this.lookupLoai.Name = "lookupLoai";
            this.lookupLoai.Size = new System.Drawing.Size(450, 22);
            this.lookupLoai.TabIndex = 1;
            // 
            // lookupThuong
            // 
            this.lookupThuong.Location = new System.Drawing.Point(20, 120);
            this.lookupThuong.Name = "lookupThuong";
            this.lookupThuong.Size = new System.Drawing.Size(450, 22);
            this.lookupThuong.TabIndex = 2;
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Location = new System.Drawing.Point(20, 220);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Properties.NullValuePrompt = "Hinh anh (duong dan)";
            this.txtHinhAnh.Size = new System.Drawing.Size(450, 22);
            this.txtHinhAnh.TabIndex = 5;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(270, 270);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "OK";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(376, 270);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Huy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // SanPhamEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(506, 333);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.lookupLoai);
            this.Controls.Add(this.lookupThuong);
            this.Controls.Add(this.spinSoLuong);
            this.Controls.Add(this.spinDonGia);
            this.Controls.Add(this.txtHinhAnh);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SanPhamEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chi tiet san pham";
            ((System.ComponentModel.ISupportInitialize)(this.txtTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupThuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHinhAnh.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
