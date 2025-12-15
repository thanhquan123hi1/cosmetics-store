namespace cosmetics_store.Forms
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlRight;
        private DevExpress.XtraEditors.LabelControl lblWelcome;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.LabelControl lblGioiTinh;
        private System.Windows.Forms.ComboBox cboGioiTinh;
        private DevExpress.XtraEditors.LabelControl lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.LabelControl lblSDT;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.LabelControl lblUsername;
        private DevExpress.XtraEditors.TextEdit txtUsername;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblConfirmPassword;
        private DevExpress.XtraEditors.TextEdit txtConfirmPassword;
        private DevExpress.XtraEditors.SimpleButton btnRegister;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private System.Windows.Forms.LinkLabel lnkLogin;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegisterForm));
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblWelcome = new DevExpress.XtraEditors.LabelControl();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.lblGioiTinh = new DevExpress.XtraEditors.LabelControl();
            this.cboGioiTinh = new System.Windows.Forms.ComboBox();
            this.lblNgaySinh = new DevExpress.XtraEditors.LabelControl();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.lblSDT = new DevExpress.XtraEditors.LabelControl();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.lblUsername = new DevExpress.XtraEditors.LabelControl();
            this.txtUsername = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.lblConfirmPassword = new DevExpress.XtraEditors.LabelControl();
            this.txtConfirmPassword = new DevExpress.XtraEditors.TextEdit();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.pnlLeft.SuspendLayout();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.pnlLeft.Controls.Add(this.lblWelcome);
            this.pnlLeft.Controls.Add(this.lblSystemName);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(350, 700);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Appearance.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblWelcome.Appearance.Options.UseFont = true;
            this.lblWelcome.Appearance.Options.UseForeColor = true;
            this.lblWelcome.Location = new System.Drawing.Point(40, 250);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(178, 62);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Dang ky";
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.Location = new System.Drawing.Point(40, 330);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(270, 32);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Tao tai khoan moi de bat dau";
            // 
            // pnlRight
            // 
            this.pnlRight.AutoScroll = true;
            this.pnlRight.BackColor = System.Drawing.Color.White;
            this.pnlRight.Controls.Add(this.lblTitle);
            this.pnlRight.Controls.Add(this.lblHoTen);
            this.pnlRight.Controls.Add(this.txtHoTen);
            this.pnlRight.Controls.Add(this.lblGioiTinh);
            this.pnlRight.Controls.Add(this.cboGioiTinh);
            this.pnlRight.Controls.Add(this.lblNgaySinh);
            this.pnlRight.Controls.Add(this.dtpNgaySinh);
            this.pnlRight.Controls.Add(this.lblDiaChi);
            this.pnlRight.Controls.Add(this.txtDiaChi);
            this.pnlRight.Controls.Add(this.lblSDT);
            this.pnlRight.Controls.Add(this.txtSDT);
            this.pnlRight.Controls.Add(this.lblUsername);
            this.pnlRight.Controls.Add(this.txtUsername);
            this.pnlRight.Controls.Add(this.lblEmail);
            this.pnlRight.Controls.Add(this.txtEmail);
            this.pnlRight.Controls.Add(this.lblPassword);
            this.pnlRight.Controls.Add(this.txtPassword);
            this.pnlRight.Controls.Add(this.lblConfirmPassword);
            this.pnlRight.Controls.Add(this.txtConfirmPassword);
            this.pnlRight.Controls.Add(this.btnRegister);
            this.pnlRight.Controls.Add(this.btnCancel);
            this.pnlRight.Controls.Add(this.lnkLogin);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(350, 0);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(550, 700);
            this.pnlRight.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(50, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(253, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thong tin dang ky";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblHoTen.Appearance.Options.UseFont = true;
            this.lblHoTen.Location = new System.Drawing.Point(50, 100);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(82, 20);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Ho ten (*):";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(50, 125);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Properties.AutoHeight = false;
            this.txtHoTen.Size = new System.Drawing.Size(220, 35);
            this.txtHoTen.TabIndex = 2;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGioiTinh.Appearance.Options.UseFont = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(290, 100);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(60, 20);
            this.lblGioiTinh.TabIndex = 3;
            this.lblGioiTinh.Text = "Gioi tinh:";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGioiTinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGioiTinh.FormattingEnabled = true;
            this.cboGioiTinh.Items.AddRange(new object[] {
            "Nam",
            "Nu",
            "Khac"});
            this.cboGioiTinh.Location = new System.Drawing.Point(290, 125);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Size = new System.Drawing.Size(200, 31);
            this.cboGioiTinh.TabIndex = 4;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNgaySinh.Appearance.Options.UseFont = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(50, 180);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(94, 20);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngay sinh (*):";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpNgaySinh.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpNgaySinh.Location = new System.Drawing.Point(50, 205);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(220, 30);
            this.dtpNgaySinh.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDiaChi.Appearance.Options.UseFont = true;
            this.lblDiaChi.Location = new System.Drawing.Point(290, 180);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(49, 20);
            this.lblDiaChi.TabIndex = 7;
            this.lblDiaChi.Text = "Dia chi:";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(290, 205);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Properties.AutoHeight = false;
            this.txtDiaChi.Size = new System.Drawing.Size(200, 35);
            this.txtDiaChi.TabIndex = 8;
            // 
            // lblSDT
            // 
            this.lblSDT.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSDT.Appearance.Options.UseFont = true;
            this.lblSDT.Location = new System.Drawing.Point(50, 260);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(85, 20);
            this.lblSDT.TabIndex = 9;
            this.lblSDT.Text = "So dien thoai:";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(50, 285);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Properties.AutoHeight = false;
            this.txtSDT.Size = new System.Drawing.Size(220, 35);
            this.txtSDT.TabIndex = 10;
            // 
            // lblUsername
            // 
            this.lblUsername.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblUsername.Appearance.Options.UseFont = true;
            this.lblUsername.Location = new System.Drawing.Point(290, 260);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(131, 20);
            this.lblUsername.TabIndex = 11;
            this.lblUsername.Text = "Ten dang nhap (*):";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(290, 285);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtUsername.Properties.Appearance.Options.UseFont = true;
            this.txtUsername.Properties.AutoHeight = false;
            this.txtUsername.Size = new System.Drawing.Size(200, 35);
            this.txtUsername.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Location = new System.Drawing.Point(50, 340);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(66, 20);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email (*):";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(50, 365);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.AutoHeight = false;
            this.txtEmail.Size = new System.Drawing.Size(440, 35);
            this.txtEmail.TabIndex = 14;
            // 
            // lblPassword
            // 
            this.lblPassword.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPassword.Appearance.Options.UseFont = true;
            this.lblPassword.Location = new System.Drawing.Point(50, 420);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(91, 20);
            this.lblPassword.TabIndex = 15;
            this.lblPassword.Text = "Mat khau (*):";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(50, 445);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.AutoHeight = false;
            this.txtPassword.Properties.PasswordChar = '?';
            this.txtPassword.Size = new System.Drawing.Size(220, 35);
            this.txtPassword.TabIndex = 16;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConfirmPassword.Appearance.Options.UseFont = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(290, 420);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(155, 20);
            this.lblConfirmPassword.TabIndex = 17;
            this.lblConfirmPassword.Text = "Xac nhan mat khau (*):";
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(290, 445);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtConfirmPassword.Properties.Appearance.Options.UseFont = true;
            this.txtConfirmPassword.Properties.AutoHeight = false;
            this.txtConfirmPassword.Properties.PasswordChar = '?';
            this.txtConfirmPassword.Size = new System.Drawing.Size(200, 35);
            this.txtConfirmPassword.TabIndex = 18;
            // 
            // btnRegister
            // 
            this.btnRegister.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.btnRegister.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Appearance.Options.UseBackColor = true;
            this.btnRegister.Appearance.Options.UseFont = true;
            this.btnRegister.Appearance.Options.UseForeColor = true;
            this.btnRegister.Location = new System.Drawing.Point(50, 510);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(220, 45);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "Dang ky";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(195)))), ((int)(((byte)(199)))));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Location = new System.Drawing.Point(290, 510);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(200, 45);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Huy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lnkLogin
            // 
            this.lnkLogin.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(188)))), ((int)(((byte)(156)))));
            this.lnkLogin.Location = new System.Drawing.Point(155, 580);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(232, 20);
            this.lnkLogin.TabIndex = 21;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Da co tai khoan? Dang nhap ngay";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 700);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dang ky tai khoan";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUsername.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtConfirmPassword.Properties)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
