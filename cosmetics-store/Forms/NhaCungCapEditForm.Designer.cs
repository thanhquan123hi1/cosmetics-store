namespace cosmetics_store.Forms
{
    partial class NhaCungCapEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.LabelControl lblTenNCC;
        private DevExpress.XtraEditors.TextEdit txtTenNCC;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.LabelControl lblSDT;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTenNCC = new DevExpress.XtraEditors.LabelControl();
            this.txtTenNCC = new DevExpress.XtraEditors.TextEdit();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.lblSDT = new DevExpress.XtraEditors.LabelControl();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTenNCC
            // 
            this.lblTenNCC.Location = new System.Drawing.Point(20, 23);
            this.lblTenNCC.Text = "Ten nha cung cap:";
            // 
            // txtTenNCC
            // 
            this.txtTenNCC.Location = new System.Drawing.Point(140, 20);
            this.txtTenNCC.Size = new System.Drawing.Size(300, 22);
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Location = new System.Drawing.Point(20, 63);
            this.lblDiaChi.Text = "Dia chi:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(140, 60);
            this.txtDiaChi.Size = new System.Drawing.Size(300, 22);
            // 
            // lblSDT
            // 
            this.lblSDT.Location = new System.Drawing.Point(20, 103);
            this.lblSDT.Text = "So dien thoai:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(140, 100);
            this.txtSDT.Size = new System.Drawing.Size(150, 22);
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(20, 143);
            this.lblEmail.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(140, 140);
            this.txtEmail.Size = new System.Drawing.Size(300, 22);
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(240, 190);
            this.btnOk.Size = new System.Drawing.Size(94, 29);
            this.btnOk.Text = "Luu";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(346, 190);
            this.btnCancel.Size = new System.Drawing.Size(94, 29);
            this.btnCancel.Text = "Huy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // NhaCungCapEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 240);
            this.Controls.Add(this.lblTenNCC);
            this.Controls.Add(this.txtTenNCC);
            this.Controls.Add(this.lblDiaChi);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.lblEmail);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NhaCungCapEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thong tin nha cung cap";
            ((System.ComponentModel.ISupportInitialize)(this.txtTenNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
