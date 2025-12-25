namespace cosmetics_store.Forms
{
    partial class fRegister
    {
        private System.ComponentModel.IContainer components = null;

        // Left Panel
        private System.Windows.Forms.Panel pnlLeft;
        private DevExpress.XtraEditors.LabelControl lblWelcome;
        private DevExpress.XtraEditors.LabelControl lblSystemName;
        private DevExpress.XtraEditors.LabelControl lblVersion;

        // Right Panel
        private System.Windows.Forms.Panel pnlRight;
        private DevExpress.XtraEditors.LabelControl lblTitle;

        // Thông tin cá nhân
        private DevExpress.XtraEditors.LabelControl lblHoTen;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.LabelControl lblGioiTinh;
        private DevExpress.XtraEditors.ComboBoxEdit cboGioiTinh;
        private DevExpress.XtraEditors.LabelControl lblNgaySinh;
        private DevExpress.XtraEditors.DateEdit dtNgaySinh;
        private DevExpress.XtraEditors.LabelControl lblDiaChi;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraEditors.LabelControl lblSDT;
        private DevExpress.XtraEditors.TextEdit txtSDT;

        // Thông tin tài khoản
        private DevExpress.XtraEditors.LabelControl lblTenDN;
        private DevExpress.XtraEditors.TextEdit txtTenDN;
        private DevExpress.XtraEditors.LabelControl lblEmail;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl lblMatKhau;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.LabelControl lblXacNhanMK;
        private DevExpress.XtraEditors.TextEdit txtXacNhanMK;

        // Buttons
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblHoTen = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.lblGioiTinh = new DevExpress.XtraEditors.LabelControl();
            this.cboGioiTinh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblNgaySinh = new DevExpress.XtraEditors.LabelControl();
            this.dtNgaySinh = new DevExpress.XtraEditors.DateEdit();
            this.lblDiaChi = new DevExpress.XtraEditors.LabelControl();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.lblSDT = new DevExpress.XtraEditors.LabelControl();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.lblTenDN = new DevExpress.XtraEditors.LabelControl();
            this.txtTenDN = new DevExpress.XtraEditors.TextEdit();
            this.lblEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblMatKhau = new DevExpress.XtraEditors.LabelControl();
            this.txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            this.lblXacNhanMK = new DevExpress.XtraEditors.LabelControl();
            this.txtXacNhanMK = new DevExpress.XtraEditors.TextEdit();
            this.btnRegister = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblWelcome = new DevExpress.XtraEditors.LabelControl();
            this.lblSystemName = new DevExpress.XtraEditors.LabelControl();
            this.lblVersion = new DevExpress.XtraEditors.LabelControl();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXacNhanMK.Properties)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.SuspendLayout();
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
            this.pnlRight.Controls.Add(this.dtNgaySinh);
            this.pnlRight.Controls.Add(this.lblDiaChi);
            this.pnlRight.Controls.Add(this.txtDiaChi);
            this.pnlRight.Controls.Add(this.lblSDT);
            this.pnlRight.Controls.Add(this.txtSDT);
            this.pnlRight.Controls.Add(this.lblTenDN);
            this.pnlRight.Controls.Add(this.txtTenDN);
            this.pnlRight.Controls.Add(this.lblEmail);
            this.pnlRight.Controls.Add(this.txtEmail);
            this.pnlRight.Controls.Add(this.lblMatKhau);
            this.pnlRight.Controls.Add(this.txtMatKhau);
            this.pnlRight.Controls.Add(this.lblXacNhanMK);
            this.pnlRight.Controls.Add(this.txtXacNhanMK);
            this.pnlRight.Controls.Add(this.btnRegister);
            this.pnlRight.Controls.Add(this.btnCancel);
            this.pnlRight.Controls.Add(this.lnkLogin);
            this.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRight.Location = new System.Drawing.Point(343, 0);
            this.pnlRight.Margin = new System.Windows.Forms.Padding(4);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(590, 800);
            this.pnlRight.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Brush Script MT", 22.2F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Strikeout))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(132, 34);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(284, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Đăng Ký Tài Khoản";
            // 
            // lblHoTen
            // 
            this.lblHoTen.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoTen.Appearance.Options.UseFont = true;
            this.lblHoTen.Location = new System.Drawing.Point(47, 98);
            this.lblHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.lblHoTen.Name = "lblHoTen";
            this.lblHoTen.Size = new System.Drawing.Size(90, 23);
            this.lblHoTen.TabIndex = 1;
            this.lblHoTen.Text = "Họ và tên *";
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(47, 123);
            this.txtHoTen.Margin = new System.Windows.Forms.Padding(4);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Properties.AutoHeight = false;
            this.txtHoTen.Size = new System.Drawing.Size(467, 39);
            this.txtHoTen.TabIndex = 2;
            // 
            // lblGioiTinh
            // 
            this.lblGioiTinh.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGioiTinh.Appearance.Options.UseFont = true;
            this.lblGioiTinh.Location = new System.Drawing.Point(47, 172);
            this.lblGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.lblGioiTinh.Name = "lblGioiTinh";
            this.lblGioiTinh.Size = new System.Drawing.Size(68, 23);
            this.lblGioiTinh.TabIndex = 3;
            this.lblGioiTinh.Text = "Giới tính";
            // 
            // cboGioiTinh
            // 
            this.cboGioiTinh.Location = new System.Drawing.Point(47, 197);
            this.cboGioiTinh.Margin = new System.Windows.Forms.Padding(4);
            this.cboGioiTinh.Name = "cboGioiTinh";
            this.cboGioiTinh.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboGioiTinh.Properties.Appearance.Options.UseFont = true;
            this.cboGioiTinh.Properties.AutoHeight = false;
            this.cboGioiTinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboGioiTinh.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboGioiTinh.Size = new System.Drawing.Size(222, 39);
            this.cboGioiTinh.TabIndex = 4;
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Appearance.Options.UseFont = true;
            this.lblNgaySinh.Location = new System.Drawing.Point(292, 172);
            this.lblNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(80, 23);
            this.lblNgaySinh.TabIndex = 5;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtNgaySinh
            // 
            this.dtNgaySinh.EditValue = null;
            this.dtNgaySinh.Location = new System.Drawing.Point(292, 197);
            this.dtNgaySinh.Margin = new System.Windows.Forms.Padding(4);
            this.dtNgaySinh.Name = "dtNgaySinh";
            this.dtNgaySinh.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtNgaySinh.Properties.Appearance.Options.UseFont = true;
            this.dtNgaySinh.Properties.AutoHeight = false;
            this.dtNgaySinh.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgaySinh.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtNgaySinh.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dtNgaySinh.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgaySinh.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dtNgaySinh.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtNgaySinh.Properties.MaskSettings.Set("mask", "dd/MM/yyyy");
            this.dtNgaySinh.Size = new System.Drawing.Size(222, 39);
            this.dtNgaySinh.TabIndex = 6;
            // 
            // lblDiaChi
            // 
            this.lblDiaChi.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDiaChi.Appearance.Options.UseFont = true;
            this.lblDiaChi.Location = new System.Drawing.Point(292, 246);
            this.lblDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.lblDiaChi.Name = "lblDiaChi";
            this.lblDiaChi.Size = new System.Drawing.Size(57, 23);
            this.lblDiaChi.TabIndex = 9;
            this.lblDiaChi.Text = "Địa chỉ";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(292, 271);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Properties.AutoHeight = false;
            this.txtDiaChi.Size = new System.Drawing.Size(222, 39);
            this.txtDiaChi.TabIndex = 10;
            // 
            // lblSDT
            // 
            this.lblSDT.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Appearance.Options.UseFont = true;
            this.lblSDT.Location = new System.Drawing.Point(47, 246);
            this.lblSDT.Margin = new System.Windows.Forms.Padding(4);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(117, 23);
            this.lblSDT.TabIndex = 7;
            this.lblSDT.Text = "Số điện thoại *";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(47, 271);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(4);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Properties.AutoHeight = false;
            this.txtSDT.Size = new System.Drawing.Size(222, 39);
            this.txtSDT.TabIndex = 8;
            // 
            // lblTenDN
            // 
            this.lblTenDN.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenDN.Appearance.Options.UseFont = true;
            this.lblTenDN.Location = new System.Drawing.Point(47, 326);
            this.lblTenDN.Margin = new System.Windows.Forms.Padding(4);
            this.lblTenDN.Name = "lblTenDN";
            this.lblTenDN.Size = new System.Drawing.Size(132, 23);
            this.lblTenDN.TabIndex = 11;
            this.lblTenDN.Text = "Tên đăng nhập *";
            // 
            // txtTenDN
            // 
            this.txtTenDN.Location = new System.Drawing.Point(47, 351);
            this.txtTenDN.Margin = new System.Windows.Forms.Padding(4);
            this.txtTenDN.Name = "txtTenDN";
            this.txtTenDN.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTenDN.Properties.Appearance.Options.UseFont = true;
            this.txtTenDN.Properties.AutoHeight = false;
            this.txtTenDN.Size = new System.Drawing.Size(467, 39);
            this.txtTenDN.TabIndex = 12;
            // 
            // lblEmail
            // 
            this.lblEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Appearance.Options.UseFont = true;
            this.lblEmail.Location = new System.Drawing.Point(47, 400);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 23);
            this.lblEmail.TabIndex = 13;
            this.lblEmail.Text = "Email *";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(47, 425);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtEmail.Properties.Appearance.Options.UseFont = true;
            this.txtEmail.Properties.AutoHeight = false;
            this.txtEmail.Size = new System.Drawing.Size(467, 39);
            this.txtEmail.TabIndex = 14;
            // 
            // lblMatKhau
            // 
            this.lblMatKhau.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMatKhau.Appearance.Options.UseFont = true;
            this.lblMatKhau.Location = new System.Drawing.Point(47, 474);
            this.lblMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.lblMatKhau.Name = "lblMatKhau";
            this.lblMatKhau.Size = new System.Drawing.Size(89, 23);
            this.lblMatKhau.TabIndex = 15;
            this.lblMatKhau.Text = "Mật khẩu *";
            // 
            // txtMatKhau
            // 
            this.txtMatKhau.Location = new System.Drawing.Point(47, 498);
            this.txtMatKhau.Margin = new System.Windows.Forms.Padding(4);
            this.txtMatKhau.Name = "txtMatKhau";
            this.txtMatKhau.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtMatKhau.Properties.Appearance.Options.UseFont = true;
            this.txtMatKhau.Properties.AutoHeight = false;
            this.txtMatKhau.Properties.PasswordChar = '*';
            this.txtMatKhau.Size = new System.Drawing.Size(222, 39);
            this.txtMatKhau.TabIndex = 16;
            // 
            // lblXacNhanMK
            // 
            this.lblXacNhanMK.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblXacNhanMK.Appearance.Options.UseFont = true;
            this.lblXacNhanMK.Location = new System.Drawing.Point(292, 474);
            this.lblXacNhanMK.Margin = new System.Windows.Forms.Padding(4);
            this.lblXacNhanMK.Name = "lblXacNhanMK";
            this.lblXacNhanMK.Size = new System.Drawing.Size(168, 23);
            this.lblXacNhanMK.TabIndex = 17;
            this.lblXacNhanMK.Text = "Xác nhận mật khẩu *";
            // 
            // txtXacNhanMK
            // 
            this.txtXacNhanMK.Location = new System.Drawing.Point(292, 498);
            this.txtXacNhanMK.Margin = new System.Windows.Forms.Padding(4);
            this.txtXacNhanMK.Name = "txtXacNhanMK";
            this.txtXacNhanMK.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtXacNhanMK.Properties.Appearance.Options.UseFont = true;
            this.txtXacNhanMK.Properties.AutoHeight = false;
            this.txtXacNhanMK.Properties.PasswordChar = '*';
            this.txtXacNhanMK.Size = new System.Drawing.Size(222, 39);
            this.txtXacNhanMK.TabIndex = 18;
            // 
            // btnRegister
            // 
            this.btnRegister.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnRegister.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnRegister.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Appearance.Options.UseBackColor = true;
            this.btnRegister.Appearance.Options.UseFont = true;
            this.btnRegister.Appearance.Options.UseForeColor = true;
            this.btnRegister.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnRegister.Location = new System.Drawing.Point(47, 566);
            this.btnRegister.Margin = new System.Windows.Forms.Padding(4);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(222, 55);
            this.btnRegister.TabIndex = 19;
            this.btnRegister.Text = "Đăng Ký";
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.btnCancel.Location = new System.Drawing.Point(292, 566);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(222, 55);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lnkLogin
            // 
            this.lnkLogin.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lnkLogin.AutoSize = true;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.lnkLogin.Location = new System.Drawing.Point(145, 682);
            this.lnkLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(238, 23);
            this.lnkLogin.TabIndex = 21;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Đã có tài khoản? Đăng nhập";
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.pnlLeft.BackgroundImage = global::cosmetics_store.Properties.Resources.Set_of_cosmetic_products_for_skin_care_on_glass_background___Premium_Vector;
            this.pnlLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlLeft.Controls.Add(this.lblWelcome);
            this.pnlLeft.Controls.Add(this.lblSystemName);
            this.pnlLeft.Controls.Add(this.lblVersion);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Margin = new System.Windows.Forms.Padding(4);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(343, 800);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 25.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWelcome.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblWelcome.Appearance.Options.UseFont = true;
            this.lblWelcome.Appearance.Options.UseForeColor = true;
            this.lblWelcome.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWelcome.Location = new System.Drawing.Point(66, 220);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(4);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(303, 74);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Xin Chào!";
            // 
            // lblSystemName
            // 
            this.lblSystemName.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 16.8F, System.Drawing.FontStyle.Bold);
            this.lblSystemName.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblSystemName.Appearance.Options.UseFont = true;
            this.lblSystemName.Appearance.Options.UseForeColor = true;
            this.lblSystemName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSystemName.Location = new System.Drawing.Point(35, 302);
            this.lblSystemName.Margin = new System.Windows.Forms.Padding(4);
            this.lblSystemName.Name = "lblSystemName";
            this.lblSystemName.Size = new System.Drawing.Size(303, 98);
            this.lblSystemName.TabIndex = 1;
            this.lblSystemName.Text = "Hệ thống quản lý\r\nCủa hàng Mỹ Phẩm";
            // 
            // lblVersion
            // 
            this.lblVersion.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblVersion.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblVersion.Appearance.Options.UseFont = true;
            this.lblVersion.Appearance.Options.UseForeColor = true;
            this.lblVersion.Location = new System.Drawing.Point(35, 751);
            this.lblVersion.Margin = new System.Windows.Forms.Padding(4);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(83, 20);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version 1.0.0";
            // 
            // fRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 800);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.pnlLeft);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "fRegister";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đăng ký tài khoản - Cosmetics Store";
            this.Load += new System.EventHandler(this.fRegister_Load);
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtNgaySinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTenDN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMatKhau.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtXacNhanMK.Properties)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
