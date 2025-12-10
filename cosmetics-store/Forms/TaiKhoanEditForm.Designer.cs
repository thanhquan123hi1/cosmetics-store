namespace cosmetics_store.Forms
{
    partial class TaiKhoanEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblNhanVien;
        private DevExpress.XtraEditors.LookUpEdit lookupNhanVien;
        private DevExpress.XtraEditors.LabelControl lblTenDN;
        private DevExpress.XtraEditors.TextEdit txtTenDN;
        private DevExpress.XtraEditors.LabelControl lblMatKhau;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblQuyen;
        private DevExpress.XtraEditors.ComboBoxEdit cboQuyen;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.lookupNhanVien = new DevExpress.XtraEditors.LookUpEdit();
            this.lblTenDN = new DevExpress.XtraEditors.LabelControl();
            this.txtTenDN = new DevExpress.XtraEditors.TextEdit();
            this.lblMatKhau = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblQuyen = new DevExpress.XtraEditors.LabelControl();
            this.cboQuyen = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuyen.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Location = new System.Drawing.Point(20, 23);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Text = "Nhan vien:";
            // 
            // lookupNhanVien
            // 
            this.lookupNhanVien.Location = new System.Drawing.Point(120, 20);
            this.lookupNhanVien.Name = "lookupNhanVien";
            this.lookupNhanVien.Size = new System.Drawing.Size(280, 22);
            // 
            // lblTenDN
            // 
            this.lblTenDN.Location = new System.Drawing.Point(20, 63);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Text = "Ten dang nhap:";
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(120, 60);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Size = new System.Drawing.Size(280, 22);
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Location = new System.Drawing.Point(20, 103);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Text = "Mat khau:";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(120, 100);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(280, 22);
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(20, 143);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 140);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(280, 22);
            // 
            // lblQuyen
            // 
            this.lblQuyen.Location = new System.Drawing.Point(20, 183);
            this.lblQuyen.Name = "lblQuyen";
            this.lblQuyen.Text = "Quyen:";
            // 
            // cboQuyen
            // 
            this.cboQuyen.Location = new System.Drawing.Point(120, 180);
            this.cboQuyen.Name = "cboQuyen";
            this.cboQuyen.Properties.Items.AddRange(new object[] { "Admin", "NhanVien", "QuanLy" });
            this.cboQuyen.Size = new System.Drawing.Size(150, 22);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(200, 230);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.Text = "Luu";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(306, 230);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.Text = "Huy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // TaiKhoanEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(430, 280);
            this.Controls.Add(this.lblNhanVien);
            this.Controls.Add(this.lookupNhanVien);
            this.Controls.Add(this.lblTenDN);
            this.Controls.Add(this.txtTenDN);
            this.Controls.Add(this.lblMatKhau);
            this.Controls.Add(this.txtMatKhau);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblQuyen);
            this.Controls.Add(this.cboQuyen);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaiKhoanEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thong tin tai khoan";
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuyen.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
