namespace cosmetics_store.Forms
{
    partial class CauHinhForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.GroupControl grpStore;
        private DevExpress.XtraEditors.LabelControl lblStoreName;
        private DevExpress.XtraEditors.TextEdit txtStoreName;
        private DevExpress.XtraEditors.LabelControl lblStoreAddress;
        private DevExpress.XtraEditors.TextEdit txtStoreAddress;
        private DevExpress.XtraEditors.LabelControl lblStorePhone;
        private DevExpress.XtraEditors.TextEdit txtStorePhone;
        private DevExpress.XtraEditors.LabelControl lblStoreEmail;
        private DevExpress.XtraEditors.TextEdit txtStoreEmail;
        private DevExpress.XtraEditors.GroupControl grpInventory;
        private DevExpress.XtraEditors.LabelControl lblLowStock;
        private DevExpress.XtraEditors.SpinEdit spinLowStock;
        private DevExpress.XtraEditors.LabelControl lblLowStockNote;
        private DevExpress.XtraEditors.GroupControl grpEmail;
        private DevExpress.XtraEditors.LabelControl lblSmtpEmail;
        private DevExpress.XtraEditors.TextEdit txtSmtpEmail;
        private DevExpress.XtraEditors.LabelControl lblSmtpDisplayName;
        private DevExpress.XtraEditors.TextEdit txtSmtpDisplayName;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnResetDefault;
        private DevExpress.XtraEditors.LabelControl lblTitle;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.grpStore = new DevExpress.XtraEditors.GroupControl();
            this.lblStoreName = new DevExpress.XtraEditors.LabelControl();
            this.txtStoreName = new DevExpress.XtraEditors.TextEdit();
            this.lblStoreAddress = new DevExpress.XtraEditors.LabelControl();
            this.txtStoreAddress = new DevExpress.XtraEditors.TextEdit();
            this.lblStorePhone = new DevExpress.XtraEditors.LabelControl();
            this.txtStorePhone = new DevExpress.XtraEditors.TextEdit();
            this.lblStoreEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtStoreEmail = new DevExpress.XtraEditors.TextEdit();
            this.grpInventory = new DevExpress.XtraEditors.GroupControl();
            this.lblLowStock = new DevExpress.XtraEditors.LabelControl();
            this.spinLowStock = new DevExpress.XtraEditors.SpinEdit();
            this.lblLowStockNote = new DevExpress.XtraEditors.LabelControl();
            this.grpEmail = new DevExpress.XtraEditors.GroupControl();
            this.lblSmtpEmail = new DevExpress.XtraEditors.LabelControl();
            this.txtSmtpEmail = new DevExpress.XtraEditors.TextEdit();
            this.lblSmtpDisplayName = new DevExpress.XtraEditors.LabelControl();
            this.txtSmtpDisplayName = new DevExpress.XtraEditors.TextEdit();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetDefault = new DevExpress.XtraEditors.SimpleButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStore)).BeginInit();
            this.grpStore.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorePhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpInventory)).BeginInit();
            this.grpInventory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinLowStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmail)).BeginInit();
            this.grpEmail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSmtpEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSmtpDisplayName.Properties)).BeginInit();
            this.pnlBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.grpStore);
            this.pnlMain.Controls.Add(this.grpInventory);
            this.pnlMain.Controls.Add(this.grpEmail);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Controls.Add(this.pictureBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(800, 550);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(40, 13);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(270, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Cấu hình hệ thống";
            // 
            // grpStore
            // 
            this.grpStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStore.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpStore.Appearance.Options.UseBackColor = true;
            this.grpStore.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpStore.AppearanceCaption.Options.UseFont = true;
            this.grpStore.Controls.Add(this.lblStoreName);
            this.grpStore.Controls.Add(this.txtStoreName);
            this.grpStore.Controls.Add(this.lblStoreAddress);
            this.grpStore.Controls.Add(this.txtStoreAddress);
            this.grpStore.Controls.Add(this.lblStorePhone);
            this.grpStore.Controls.Add(this.txtStorePhone);
            this.grpStore.Controls.Add(this.lblStoreEmail);
            this.grpStore.Controls.Add(this.txtStoreEmail);
            this.grpStore.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.grpStore.Location = new System.Drawing.Point(25, 60);
            this.grpStore.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpStore.Name = "grpStore";
            this.grpStore.Size = new System.Drawing.Size(750, 155);
            this.grpStore.TabIndex = 1;
            this.grpStore.Text = "Thông tin cửa hàng";
            // 
            // lblStoreName
            // 
            this.lblStoreName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreName.Appearance.Options.UseFont = true;
            this.lblStoreName.Location = new System.Drawing.Point(11, 35);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(113, 23);
            this.lblStoreName.TabIndex = 0;
            this.lblStoreName.Text = "Tên cửa hàng:";
            // 
            // txtStoreName
            // 
            this.txtStoreName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStoreName.Location = new System.Drawing.Point(130, 32);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStoreName.Properties.Appearance.Options.UseFont = true;
            this.txtStoreName.Size = new System.Drawing.Size(600, 30);
            this.txtStoreName.TabIndex = 1;
            // 
            // lblStoreAddress
            // 
            this.lblStoreAddress.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreAddress.Appearance.Options.UseFont = true;
            this.lblStoreAddress.Location = new System.Drawing.Point(15, 65);
            this.lblStoreAddress.Name = "lblStoreAddress";
            this.lblStoreAddress.Size = new System.Drawing.Size(61, 23);
            this.lblStoreAddress.TabIndex = 2;
            this.lblStoreAddress.Text = "Địa chỉ:";
            // 
            // txtStoreAddress
            // 
            this.txtStoreAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStoreAddress.Location = new System.Drawing.Point(130, 62);
            this.txtStoreAddress.Name = "txtStoreAddress";
            this.txtStoreAddress.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStoreAddress.Properties.Appearance.Options.UseFont = true;
            this.txtStoreAddress.Size = new System.Drawing.Size(600, 30);
            this.txtStoreAddress.TabIndex = 3;
            // 
            // lblStorePhone
            // 
            this.lblStorePhone.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStorePhone.Appearance.Options.UseFont = true;
            this.lblStorePhone.Location = new System.Drawing.Point(15, 95);
            this.lblStorePhone.Name = "lblStorePhone";
            this.lblStorePhone.Size = new System.Drawing.Size(109, 23);
            this.lblStorePhone.TabIndex = 4;
            this.lblStorePhone.Text = "Số điện thoại:";
            // 
            // txtStorePhone
            // 
            this.txtStorePhone.Location = new System.Drawing.Point(130, 92);
            this.txtStorePhone.Name = "txtStorePhone";
            this.txtStorePhone.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStorePhone.Properties.Appearance.Options.UseFont = true;
            this.txtStorePhone.Size = new System.Drawing.Size(180, 30);
            this.txtStorePhone.TabIndex = 5;
            // 
            // lblStoreEmail
            // 
            this.lblStoreEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStoreEmail.Appearance.Options.UseFont = true;
            this.lblStoreEmail.Location = new System.Drawing.Point(15, 125);
            this.lblStoreEmail.Name = "lblStoreEmail";
            this.lblStoreEmail.Size = new System.Drawing.Size(49, 23);
            this.lblStoreEmail.TabIndex = 6;
            this.lblStoreEmail.Text = "Email:";
            // 
            // txtStoreEmail
            // 
            this.txtStoreEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStoreEmail.Location = new System.Drawing.Point(130, 122);
            this.txtStoreEmail.Name = "txtStoreEmail";
            this.txtStoreEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStoreEmail.Properties.Appearance.Options.UseFont = true;
            this.txtStoreEmail.Size = new System.Drawing.Size(400, 30);
            this.txtStoreEmail.TabIndex = 7;
            // 
            // grpInventory
            // 
            this.grpInventory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInventory.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpInventory.Appearance.Options.UseBackColor = true;
            this.grpInventory.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpInventory.AppearanceCaption.Options.UseFont = true;
            this.grpInventory.Controls.Add(this.lblLowStock);
            this.grpInventory.Controls.Add(this.spinLowStock);
            this.grpInventory.Controls.Add(this.lblLowStockNote);
            this.grpInventory.Location = new System.Drawing.Point(25, 225);
            this.grpInventory.Name = "grpInventory";
            this.grpInventory.Size = new System.Drawing.Size(750, 95);
            this.grpInventory.TabIndex = 2;
            this.grpInventory.Text = "Cấu hình tồn kho";
            this.grpInventory.Paint += new System.Windows.Forms.PaintEventHandler(this.grpInventory_Paint);
            // 
            // lblLowStock
            // 
            this.lblLowStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStock.Appearance.Options.UseFont = true;
            this.lblLowStock.Location = new System.Drawing.Point(15, 38);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(179, 23);
            this.lblLowStock.TabIndex = 0;
            this.lblLowStock.Text = "Ngưỡng cảnh báo tồn:";
            // 
            // spinLowStock
            // 
            this.spinLowStock.EditValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.spinLowStock.Location = new System.Drawing.Point(200, 35);
            this.spinLowStock.Name = "spinLowStock";
            this.spinLowStock.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinLowStock.Properties.Appearance.Options.UseFont = true;
            this.spinLowStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinLowStock.Properties.MaxValue = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.spinLowStock.Size = new System.Drawing.Size(100, 30);
            this.spinLowStock.TabIndex = 1;
            // 
            // lblLowStockNote
            // 
            this.lblLowStockNote.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLowStockNote.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblLowStockNote.Appearance.Options.UseFont = true;
            this.lblLowStockNote.Appearance.Options.UseForeColor = true;
            this.lblLowStockNote.Location = new System.Drawing.Point(20, 67);
            this.lblLowStockNote.Name = "lblLowStockNote";
            this.lblLowStockNote.Size = new System.Drawing.Size(485, 20);
            this.lblLowStockNote.TabIndex = 2;
            this.lblLowStockNote.Text = "Sản phẩm có số lượng tồn <= ngưỡng này sẽ được cảnh báo màu đỏ";
            // 
            // grpEmail
            // 
            this.grpEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEmail.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpEmail.Appearance.Options.UseBackColor = true;
            this.grpEmail.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpEmail.AppearanceCaption.Options.UseFont = true;
            this.grpEmail.Controls.Add(this.lblSmtpEmail);
            this.grpEmail.Controls.Add(this.txtSmtpEmail);
            this.grpEmail.Controls.Add(this.lblSmtpDisplayName);
            this.grpEmail.Controls.Add(this.txtSmtpDisplayName);
            this.grpEmail.Location = new System.Drawing.Point(25, 330);
            this.grpEmail.Name = "grpEmail";
            this.grpEmail.Size = new System.Drawing.Size(750, 100);
            this.grpEmail.TabIndex = 3;
            this.grpEmail.Text = "Cấu hình Email ( SMTP )";
            // 
            // lblSmtpEmail
            // 
            this.lblSmtpEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmtpEmail.Appearance.Options.UseFont = true;
            this.lblSmtpEmail.Location = new System.Drawing.Point(20, 35);
            this.lblSmtpEmail.Name = "lblSmtpEmail";
            this.lblSmtpEmail.Size = new System.Drawing.Size(99, 23);
            this.lblSmtpEmail.TabIndex = 0;
            this.lblSmtpEmail.Text = "Email SMTP:";
            // 
            // txtSmtpEmail
            // 
            this.txtSmtpEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSmtpEmail.Location = new System.Drawing.Point(130, 32);
            this.txtSmtpEmail.Name = "txtSmtpEmail";
            this.txtSmtpEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSmtpEmail.Properties.Appearance.Options.UseFont = true;
            this.txtSmtpEmail.Properties.ReadOnly = true;
            this.txtSmtpEmail.Size = new System.Drawing.Size(400, 30);
            this.txtSmtpEmail.TabIndex = 1;
            // 
            // lblSmtpDisplayName
            // 
            this.lblSmtpDisplayName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSmtpDisplayName.Appearance.Options.UseFont = true;
            this.lblSmtpDisplayName.Location = new System.Drawing.Point(20, 67);
            this.lblSmtpDisplayName.Name = "lblSmtpDisplayName";
            this.lblSmtpDisplayName.Size = new System.Drawing.Size(109, 23);
            this.lblSmtpDisplayName.TabIndex = 2;
            this.lblSmtpDisplayName.Text = "Tên hiển thị : ";
            // 
            // txtSmtpDisplayName
            // 
            this.txtSmtpDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSmtpDisplayName.Location = new System.Drawing.Point(130, 64);
            this.txtSmtpDisplayName.Name = "txtSmtpDisplayName";
            this.txtSmtpDisplayName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSmtpDisplayName.Properties.Appearance.Options.UseFont = true;
            this.txtSmtpDisplayName.Size = new System.Drawing.Size(400, 30);
            this.txtSmtpDisplayName.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnResetDefault);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(20, 475);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(760, 55);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(425, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(165, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "✅ Lưu cấu hình";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(613, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hoàn tác";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResetDefault
            // 
            this.btnResetDefault.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnResetDefault.Appearance.Font = new System.Drawing.Font("Segoe UI", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResetDefault.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnResetDefault.Appearance.Options.UseBackColor = true;
            this.btnResetDefault.Appearance.Options.UseFont = true;
            this.btnResetDefault.Appearance.Options.UseForeColor = true;
            this.btnResetDefault.Location = new System.Drawing.Point(25, 12);
            this.btnResetDefault.Name = "btnResetDefault";
            this.btnResetDefault.Size = new System.Drawing.Size(213, 32);
            this.btnResetDefault.TabIndex = 2;
            this.btnResetDefault.Text = "♻️ Khôi phục mặc định";
            this.btnResetDefault.Click += new System.EventHandler(this.btnResetDefault_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::cosmetics_store.Properties.Resources.Small_Fresh_Spring_Green_Leaf_H5_Background_Wallpaper_Image_For_Free_Download___Pngtree;
            this.pictureBox1.Location = new System.Drawing.Point(20, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(760, 510);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // CauHinhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CauHinhForm";
            this.Text = "Cấu hình hệ thống";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpStore)).EndInit();
            this.grpStore.ResumeLayout(false);
            this.grpStore.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStorePhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStoreEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpInventory)).EndInit();
            this.grpInventory.ResumeLayout(false);
            this.grpInventory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spinLowStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEmail)).EndInit();
            this.grpEmail.ResumeLayout(false);
            this.grpEmail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSmtpEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSmtpDisplayName.Properties)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
