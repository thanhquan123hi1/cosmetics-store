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
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.grpStore);
            this.pnlMain.Controls.Add(this.grpInventory);
            this.pnlMain.Controls.Add(this.grpEmail);
            this.pnlMain.Controls.Add(this.pnlBottom);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMain.Size = new System.Drawing.Size(800, 550);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(25, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? C?u h?nh h? th?ng";
            // 
            // grpStore
            // 
            this.grpStore.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpStore.Location = new System.Drawing.Point(25, 60);
            this.grpStore.Name = "grpStore";
            this.grpStore.Size = new System.Drawing.Size(750, 155);
            this.grpStore.TabIndex = 1;
            this.grpStore.Text = "Thông tin c?a hàng";
            // 
            // lblStoreName
            // 
            this.lblStoreName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStoreName.Appearance.Options.UseFont = true;
            this.lblStoreName.Location = new System.Drawing.Point(20, 35);
            this.lblStoreName.Name = "lblStoreName";
            this.lblStoreName.Size = new System.Drawing.Size(95, 19);
            this.lblStoreName.TabIndex = 0;
            this.lblStoreName.Text = "Tên c?a hàng:";
            // 
            // txtStoreName
            // 
            this.txtStoreName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStoreName.Location = new System.Drawing.Point(130, 32);
            this.txtStoreName.Name = "txtStoreName";
            this.txtStoreName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStoreName.Properties.Appearance.Options.UseFont = true;
            this.txtStoreName.Size = new System.Drawing.Size(600, 26);
            this.txtStoreName.TabIndex = 1;
            // 
            // lblStoreAddress
            // 
            this.lblStoreAddress.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStoreAddress.Appearance.Options.UseFont = true;
            this.lblStoreAddress.Location = new System.Drawing.Point(20, 65);
            this.lblStoreAddress.Name = "lblStoreAddress";
            this.lblStoreAddress.Size = new System.Drawing.Size(50, 19);
            this.lblStoreAddress.TabIndex = 2;
            this.lblStoreAddress.Text = "Ð?a ch?:";
            // 
            // txtStoreAddress
            // 
            this.txtStoreAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStoreAddress.Location = new System.Drawing.Point(130, 62);
            this.txtStoreAddress.Name = "txtStoreAddress";
            this.txtStoreAddress.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStoreAddress.Properties.Appearance.Options.UseFont = true;
            this.txtStoreAddress.Size = new System.Drawing.Size(600, 26);
            this.txtStoreAddress.TabIndex = 3;
            // 
            // lblStorePhone
            // 
            this.lblStorePhone.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStorePhone.Appearance.Options.UseFont = true;
            this.lblStorePhone.Location = new System.Drawing.Point(20, 95);
            this.lblStorePhone.Name = "lblStorePhone";
            this.lblStorePhone.Size = new System.Drawing.Size(90, 19);
            this.lblStorePhone.TabIndex = 4;
            this.lblStorePhone.Text = "S? ði?n tho?i:";
            // 
            // txtStorePhone
            // 
            this.txtStorePhone.Location = new System.Drawing.Point(130, 92);
            this.txtStorePhone.Name = "txtStorePhone";
            this.txtStorePhone.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStorePhone.Properties.Appearance.Options.UseFont = true;
            this.txtStorePhone.Size = new System.Drawing.Size(180, 26);
            this.txtStorePhone.TabIndex = 5;
            // 
            // lblStoreEmail
            // 
            this.lblStoreEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStoreEmail.Appearance.Options.UseFont = true;
            this.lblStoreEmail.Location = new System.Drawing.Point(20, 125);
            this.lblStoreEmail.Name = "lblStoreEmail";
            this.lblStoreEmail.Size = new System.Drawing.Size(37, 19);
            this.lblStoreEmail.TabIndex = 6;
            this.lblStoreEmail.Text = "Email:";
            // 
            // txtStoreEmail
            // 
            this.txtStoreEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStoreEmail.Location = new System.Drawing.Point(130, 122);
            this.txtStoreEmail.Name = "txtStoreEmail";
            this.txtStoreEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtStoreEmail.Properties.Appearance.Options.UseFont = true;
            this.txtStoreEmail.Size = new System.Drawing.Size(400, 26);
            this.txtStoreEmail.TabIndex = 7;
            // 
            // grpInventory
            // 
            this.grpInventory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.grpInventory.AppearanceCaption.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.grpInventory.AppearanceCaption.Options.UseFont = true;
            this.grpInventory.Controls.Add(this.lblLowStock);
            this.grpInventory.Controls.Add(this.spinLowStock);
            this.grpInventory.Controls.Add(this.lblLowStockNote);
            this.grpInventory.Location = new System.Drawing.Point(25, 225);
            this.grpInventory.Name = "grpInventory";
            this.grpInventory.Size = new System.Drawing.Size(750, 95);
            this.grpInventory.TabIndex = 2;
            this.grpInventory.Text = "C?u h?nh t?n kho";
            // 
            // lblLowStock
            // 
            this.lblLowStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLowStock.Appearance.Options.UseFont = true;
            this.lblLowStock.Location = new System.Drawing.Point(20, 38);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(143, 19);
            this.lblLowStock.TabIndex = 0;
            this.lblLowStock.Text = "Ngý?ng c?nh báo t?n:";
            // 
            // spinLowStock
            // 
            this.spinLowStock.EditValue = new decimal(new int[] { 10, 0, 0, 0 });
            this.spinLowStock.Location = new System.Drawing.Point(180, 35);
            this.spinLowStock.Name = "spinLowStock";
            this.spinLowStock.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.spinLowStock.Properties.Appearance.Options.UseFont = true;
            this.spinLowStock.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.spinLowStock.Properties.MaxValue = new decimal(new int[] { 1000, 0, 0, 0 });
            this.spinLowStock.Properties.MinValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinLowStock.Size = new System.Drawing.Size(100, 26);
            this.spinLowStock.TabIndex = 1;
            // 
            // lblLowStockNote
            // 
            this.lblLowStockNote.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblLowStockNote.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblLowStockNote.Appearance.Options.UseFont = true;
            this.lblLowStockNote.Appearance.Options.UseForeColor = true;
            this.lblLowStockNote.Location = new System.Drawing.Point(20, 67);
            this.lblLowStockNote.Name = "lblLowStockNote";
            this.lblLowStockNote.Size = new System.Drawing.Size(365, 15);
            this.lblLowStockNote.TabIndex = 2;
            this.lblLowStockNote.Text = "S?n ph?m có s? lý?ng t?n <= ngý?ng này s? ðý?c c?nh báo màu ð?";
            // 
            // grpEmail
            // 
            this.grpEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
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
            this.grpEmail.Text = "C?u h?nh Email (SMTP)";
            // 
            // lblSmtpEmail
            // 
            this.lblSmtpEmail.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSmtpEmail.Appearance.Options.UseFont = true;
            this.lblSmtpEmail.Location = new System.Drawing.Point(20, 35);
            this.lblSmtpEmail.Name = "lblSmtpEmail";
            this.lblSmtpEmail.Size = new System.Drawing.Size(77, 19);
            this.lblSmtpEmail.TabIndex = 0;
            this.lblSmtpEmail.Text = "Email SMTP:";
            // 
            // txtSmtpEmail
            // 
            this.txtSmtpEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSmtpEmail.Location = new System.Drawing.Point(130, 32);
            this.txtSmtpEmail.Name = "txtSmtpEmail";
            this.txtSmtpEmail.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSmtpEmail.Properties.Appearance.Options.UseFont = true;
            this.txtSmtpEmail.Properties.ReadOnly = true;
            this.txtSmtpEmail.Size = new System.Drawing.Size(400, 26);
            this.txtSmtpEmail.TabIndex = 1;
            // 
            // lblSmtpDisplayName
            // 
            this.lblSmtpDisplayName.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSmtpDisplayName.Appearance.Options.UseFont = true;
            this.lblSmtpDisplayName.Location = new System.Drawing.Point(20, 67);
            this.lblSmtpDisplayName.Name = "lblSmtpDisplayName";
            this.lblSmtpDisplayName.Size = new System.Drawing.Size(79, 19);
            this.lblSmtpDisplayName.TabIndex = 2;
            this.lblSmtpDisplayName.Text = "Tên hi?n th?:";
            // 
            // txtSmtpDisplayName
            // 
            this.txtSmtpDisplayName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSmtpDisplayName.Location = new System.Drawing.Point(130, 64);
            this.txtSmtpDisplayName.Name = "txtSmtpDisplayName";
            this.txtSmtpDisplayName.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSmtpDisplayName.Properties.Appearance.Options.UseFont = true;
            this.txtSmtpDisplayName.Size = new System.Drawing.Size(400, 26);
            this.txtSmtpDisplayName.TabIndex = 3;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlBottom.Controls.Add(this.btnSave);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnResetDefault);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 495);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(800, 55);
            this.pnlBottom.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnSave.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSave.Appearance.Options.UseBackColor = true;
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseForeColor = true;
            this.btnSave.Location = new System.Drawing.Point(555, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 32);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "?? Lýu c?u h?nh";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Location = new System.Drawing.Point(675, 12);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Hoàn tác";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnResetDefault
            // 
            this.btnResetDefault.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnResetDefault.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnResetDefault.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnResetDefault.Appearance.Options.UseBackColor = true;
            this.btnResetDefault.Appearance.Options.UseFont = true;
            this.btnResetDefault.Appearance.Options.UseForeColor = true;
            this.btnResetDefault.Location = new System.Drawing.Point(25, 12);
            this.btnResetDefault.Name = "btnResetDefault";
            this.btnResetDefault.Size = new System.Drawing.Size(140, 32);
            this.btnResetDefault.TabIndex = 2;
            this.btnResetDefault.Text = "?? Khôi ph?c m?c ð?nh";
            this.btnResetDefault.Click += new System.EventHandler(this.btnResetDefault_Click);
            // 
            // CauHinhForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CauHinhForm";
            this.Text = "C?u h?nh h? th?ng";
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
            this.ResumeLayout(false);
        }
    }
}
