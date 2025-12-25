namespace cosmetics_store.Forms
{
    partial class TaiKhoanEdit
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.LookUpEdit lookupNhanVien;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemNhanVien;
        private DevExpress.XtraEditors.TextEdit txtTenDN;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemTenDN;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemMatKhau;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemEmail;
        private DevExpress.XtraEditors.ComboBoxEdit cboQuyen;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemQuyen;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemBtnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemBtnCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.LabelControl lblMatKhau;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.lookupNhanVien = new DevExpress.XtraEditors.LookUpEdit();
            this.txtTenDN = new DevExpress.XtraEditors.TextEdit();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.cboQuyen = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutItemNhanVien = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemTenDN = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemMatKhau = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemEmail = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemQuyen = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutItemBtnOk = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemBtnCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.lblMatKhau = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhanVien.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuyen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNhanVien)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTenDN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMatKhau)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEmail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemQuyen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.lookupNhanVien);
            this.layoutControl.Controls.Add(this.txtTenDN);
            this.layoutControl.Controls.Add(this.txtMatKhau);
            this.layoutControl.Controls.Add(this.txtEmail);
            this.layoutControl.Controls.Add(this.cboQuyen);
            this.layoutControl.Controls.Add(this.btnOk);
            this.layoutControl.Controls.Add(this.btnCancel);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(511, 0, 812, 500);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(450, 280);
            this.layoutControl.TabIndex = 0;
            // 
            // lookupNhanVien
            // 
            this.lookupNhanVien.Location = new System.Drawing.Point(161, 14);
            this.lookupNhanVien.Name = "lookupNhanVien";
            this.lookupNhanVien.Properties.Appearance.BackColor = System.Drawing.Color.Silver;
            this.lookupNhanVien.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lookupNhanVien.Properties.Appearance.Options.UseBackColor = true;
            this.lookupNhanVien.Properties.Appearance.Options.UseFont = true;
            this.lookupNhanVien.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupNhanVien.Properties.NullText = "-- Chọn nhân viên --";
            this.lookupNhanVien.Size = new System.Drawing.Size(275, 30);
            this.lookupNhanVien.StyleController = this.layoutControl;
            this.lookupNhanVien.TabIndex = 0;
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(161, 48);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenDN.Properties.Appearance.Options.UseFont = true;
            this.txtTenDN.Size = new System.Drawing.Size(275, 30);
            this.txtTenDN.StyleController = this.layoutControl;
            this.txtTenDN.TabIndex = 1;
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(161, 82);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhau.Properties.Appearance.Options.UseFont = true;
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(275, 30);
            this.txtMatKhau.StyleController = this.layoutControl;
            this.txtMatKhau.TabIndex = 2;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(161, 116);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Size = new System.Drawing.Size(275, 30);
            this.txtEmail.StyleController = this.layoutControl;
            this.txtEmail.TabIndex = 3;
            // 
            // cboQuyen
            // 
            this.cboQuyen.Location = new System.Drawing.Point(161, 150);
            this.cboQuyen.Name = "cboQuyen";
            this.cboQuyen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboQuyen.Properties.Appearance.Options.UseFont = true;
            this.cboQuyen.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboQuyen.Properties.Items.AddRange(new object[] {
            "Admin",
            "Nhân viên",
            "Khách hàng"});
            this.cboQuyen.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboQuyen.Size = new System.Drawing.Size(275, 30);
            this.cboQuyen.StyleController = this.layoutControl;
            this.cboQuyen.TabIndex = 4;
            this.cboQuyen.SelectedIndexChanged += new System.EventHandler(this.cboQuyen_SelectedIndexChanged);
            // 
            // btnOk
            // 
            this.btnOk.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnOk.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnOk.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOk.Appearance.Options.UseBackColor = true;
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Appearance.Options.UseForeColor = true;
            this.btnOk.Location = new System.Drawing.Point(14, 238);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(317, 28);
            this.btnOk.StyleController = this.layoutControl;
            this.btnOk.TabIndex = 5;
            this.btnOk.Text = "Lưu";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(335, 238);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(101, 28);
            this.btnCancel.StyleController = this.layoutControl;
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Hủy ";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutItemNhanVien,
            this.layoutItemTenDN,
            this.layoutItemMatKhau,
            this.layoutItemEmail,
            this.layoutItemQuyen,
            this.emptySpaceItem1,
            this.layoutItemBtnOk,
            this.layoutItemBtnCancel});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(450, 280);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutItemNhanVien
            // 
            this.layoutItemNhanVien.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layoutItemNhanVien.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.layoutItemNhanVien.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutItemNhanVien.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemNhanVien.Control = this.lookupNhanVien;
            this.layoutItemNhanVien.Location = new System.Drawing.Point(0, 0);
            this.layoutItemNhanVien.Name = "layoutItemNhanVien";
            this.layoutItemNhanVien.Size = new System.Drawing.Size(426, 34);
            this.layoutItemNhanVien.Text = "Nhân viên:";
            this.layoutItemNhanVien.TextSize = new System.Drawing.Size(132, 23);
            // 
            // layoutItemTenDN
            // 
            this.layoutItemTenDN.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layoutItemTenDN.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.layoutItemTenDN.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutItemTenDN.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemTenDN.Control = this.txtTenDN;
            this.layoutItemTenDN.CustomizationFormText = "Tên đăng nhập:";
            this.layoutItemTenDN.Location = new System.Drawing.Point(0, 34);
            this.layoutItemTenDN.Name = "layoutItemTenDN";
            this.layoutItemTenDN.Size = new System.Drawing.Size(426, 34);
            this.layoutItemTenDN.Text = "Tên đăng nhập:";
            this.layoutItemTenDN.TextSize = new System.Drawing.Size(132, 23);
            // 
            // layoutItemMatKhau
            // 
            this.layoutItemMatKhau.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layoutItemMatKhau.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.layoutItemMatKhau.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutItemMatKhau.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemMatKhau.Control = this.txtMatKhau;
            this.layoutItemMatKhau.Location = new System.Drawing.Point(0, 68);
            this.layoutItemMatKhau.Name = "layoutItemMatKhau";
            this.layoutItemMatKhau.Size = new System.Drawing.Size(426, 34);
            this.layoutItemMatKhau.Text = "Mật Khẩu: ";
            this.layoutItemMatKhau.TextSize = new System.Drawing.Size(132, 23);
            // 
            // layoutItemEmail
            // 
            this.layoutItemEmail.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layoutItemEmail.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.layoutItemEmail.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutItemEmail.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemEmail.Control = this.txtEmail;
            this.layoutItemEmail.Location = new System.Drawing.Point(0, 102);
            this.layoutItemEmail.Name = "layoutItemEmail";
            this.layoutItemEmail.Size = new System.Drawing.Size(426, 34);
            this.layoutItemEmail.Text = "Email:";
            this.layoutItemEmail.TextSize = new System.Drawing.Size(132, 23);
            // 
            // layoutItemQuyen
            // 
            this.layoutItemQuyen.AppearanceItemCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.layoutItemQuyen.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold);
            this.layoutItemQuyen.AppearanceItemCaption.Options.UseBackColor = true;
            this.layoutItemQuyen.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemQuyen.Control = this.cboQuyen;
            this.layoutItemQuyen.Location = new System.Drawing.Point(0, 136);
            this.layoutItemQuyen.Name = "layoutItemQuyen";
            this.layoutItemQuyen.Size = new System.Drawing.Size(426, 34);
            this.layoutItemQuyen.Text = "Quyền : ";
            this.layoutItemQuyen.TextSize = new System.Drawing.Size(132, 23);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 170);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(426, 54);
            // 
            // layoutItemBtnOk
            // 
            this.layoutItemBtnOk.Control = this.btnOk;
            this.layoutItemBtnOk.Location = new System.Drawing.Point(0, 224);
            this.layoutItemBtnOk.Name = "layoutItemBtnOk";
            this.layoutItemBtnOk.Size = new System.Drawing.Size(321, 32);
            this.layoutItemBtnOk.TextVisible = false;
            // 
            // layoutItemBtnCancel
            // 
            this.layoutItemBtnCancel.Control = this.btnCancel;
            this.layoutItemBtnCancel.Location = new System.Drawing.Point(321, 224);
            this.layoutItemBtnCancel.Name = "layoutItemBtnCancel";
            this.layoutItemBtnCancel.Size = new System.Drawing.Size(105, 32);
            this.layoutItemBtnCancel.TextVisible = false;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Location = new System.Drawing.Point(0, 0);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(0, 16);
            this.lblMatKhau.TabIndex = 99;
            this.lblMatKhau.Visible = false;
            // 
            // TaiKhoanEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(450, 280);
            this.Controls.Add(this.layoutControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaiKhoanEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin tài khoản";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lookupNhanVien.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboQuyen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNhanVien)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemTenDN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemMatKhau)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemEmail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemQuyen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnCancel)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
