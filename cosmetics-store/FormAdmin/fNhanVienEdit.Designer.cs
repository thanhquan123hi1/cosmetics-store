namespace cosmetics_store.Forms
{
    partial class fNhanVienEdit
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemHoTen;
        private DevExpress.XtraEditors.DateEdit dateNgaySinh;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemNgaySinh;
        private DevExpress.XtraEditors.ComboBoxEdit cboGioiTinh;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemGioiTinh;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDiaChi;
        private DevExpress.XtraEditors.ComboBoxEdit cboChucVu;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemChucVu;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSDT;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemBtnOk;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemBtnCancel;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutItemBtnOk = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemBtnCancel = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.dateNgaySinh = new DevExpress.XtraEditors.DateEdit();
            this.cboGioiTinh = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.cboChucVu = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.layoutItemHoTen = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemNgaySinh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemGioiTinh = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDiaChi = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemChucVu = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemSDT = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucVu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHoTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNgaySinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGioiTinh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDiaChi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemChucVu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSDT)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            // Giữ dock fill, nhưng form sẽ tăng chiều cao để không cuộn.
            this.layoutControl.Size = new System.Drawing.Size(550, 460);
            this.layoutControl.Appearance.Control.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutControl.Appearance.Control.Options.UseFont = true;
            this.layoutControl.Appearance.ControlFocused.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.layoutControl.Appearance.ControlFocused.Options.UseBorderColor = true;
            this.layoutControl.Controls.Add(this.txtHoTen);
            this.layoutControl.Controls.Add(this.dateNgaySinh);
            this.layoutControl.Controls.Add(this.cboGioiTinh);
            this.layoutControl.Controls.Add(this.txtDiaChi);
            this.layoutControl.Controls.Add(this.cboChucVu);
            this.layoutControl.Controls.Add(this.txtSDT);
            this.layoutControl.Controls.Add(this.btnOk);
            this.layoutControl.Controls.Add(this.btnCancel);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(100, 100, 500, 400);
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(550, 460);
            this.layoutControl.TabIndex = 0;
            // 
            // btnOk
            // 
            this.btnOk.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnOk.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnOk.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnOk.Appearance.Options.UseBackColor = true;
            this.btnOk.Appearance.Options.UseFont = true;
            this.btnOk.Appearance.Options.UseForeColor = true;
            this.btnOk.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.btnOk.AppearanceHovered.Options.UseBackColor = true;
            this.btnOk.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(97)))), ((int)(((byte)(141)))));
            this.btnOk.AppearancePressed.Options.UseBackColor = true;
            this.btnOk.Location = new System.Drawing.Point(33, 397);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(339, 36);
            this.btnOk.StyleController = this.layoutControl;
            this.btnOk.TabIndex = 6;
            this.btnOk.Text = "Lưu";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseBackColor = true;
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.btnCancel.AppearanceHovered.Options.UseBackColor = true;
            this.btnCancel.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnCancel.AppearancePressed.Options.UseBackColor = true;
            this.btnCancel.Location = new System.Drawing.Point(386, 397);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 36);
            this.btnCancel.StyleController = this.layoutControl;
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.AppearanceGroup.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.layoutControlGroup1.AppearanceGroup.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.layoutControlGroup1.AppearanceGroup.Options.UseFont = true;
            this.layoutControlGroup1.AppearanceGroup.Options.UseForeColor = true;
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutItemHoTen,
            this.layoutItemNgaySinh,
            this.layoutItemGioiTinh,
            this.layoutItemDiaChi,
            this.layoutItemChucVu,
            this.layoutItemSDT,
            this.emptySpaceItem1,
            this.layoutItemBtnOk,
            this.layoutItemBtnCancel});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(16, 16, 16, 16);
            this.layoutControlGroup1.Size = new System.Drawing.Size(529, 460);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutItemHoTen
            // 
            this.layoutItemHoTen.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemHoTen.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.layoutItemHoTen.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemHoTen.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutItemHoTen.Control = this.txtHoTen;
            this.layoutItemHoTen.Location = new System.Drawing.Point(0, 0);
            this.layoutItemHoTen.Name = "layoutItemHoTen";
            this.layoutItemHoTen.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutItemHoTen.Size = new System.Drawing.Size(497, 60);
            this.layoutItemHoTen.Text = "Họ tên:";
            this.layoutItemHoTen.TextSize = new System.Drawing.Size(83, 23);
            // 
            // layoutItemNgaySinh
            // 
            this.layoutItemNgaySinh.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemNgaySinh.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.layoutItemNgaySinh.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemNgaySinh.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutItemNgaySinh.Control = this.dateNgaySinh;
            this.layoutItemNgaySinh.Location = new System.Drawing.Point(0, 60);
            this.layoutItemNgaySinh.Name = "layoutItemNgaySinh";
            this.layoutItemNgaySinh.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutItemNgaySinh.Size = new System.Drawing.Size(275, 60);
            this.layoutItemNgaySinh.Text = "Ngày sinh:";
            this.layoutItemNgaySinh.TextSize = new System.Drawing.Size(83, 23);
            // 
            // layoutItemGioiTinh
            // 
            this.layoutItemGioiTinh.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemGioiTinh.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.layoutItemGioiTinh.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemGioiTinh.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutItemGioiTinh.Control = this.cboGioiTinh;
            this.layoutItemGioiTinh.Location = new System.Drawing.Point(275, 60);
            this.layoutItemGioiTinh.Name = "layoutItemGioiTinh";
            this.layoutItemGioiTinh.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutItemGioiTinh.Size = new System.Drawing.Size(222, 60);
            this.layoutItemGioiTinh.Text = "Giới tính:";
            this.layoutItemGioiTinh.TextSize = new System.Drawing.Size(83, 23);
            // 
            // layoutItemDiaChi
            // 
            this.layoutItemDiaChi.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemDiaChi.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.layoutItemDiaChi.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemDiaChi.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutItemDiaChi.Control = this.txtDiaChi;
            this.layoutItemDiaChi.Location = new System.Drawing.Point(0, 120);
            this.layoutItemDiaChi.Name = "layoutItemDiaChi";
            this.layoutItemDiaChi.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutItemDiaChi.Size = new System.Drawing.Size(497, 60);
            this.layoutItemDiaChi.Text = "Địa chỉ:";
            this.layoutItemDiaChi.TextSize = new System.Drawing.Size(83, 23);
            // 
            // layoutItemChucVu
            // 
            this.layoutItemChucVu.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemChucVu.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.layoutItemChucVu.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemChucVu.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutItemChucVu.Control = this.cboChucVu;
            this.layoutItemChucVu.Location = new System.Drawing.Point(0, 180);
            this.layoutItemChucVu.Name = "layoutItemChucVu";
            this.layoutItemChucVu.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutItemChucVu.Size = new System.Drawing.Size(497, 60);
            this.layoutItemChucVu.Text = "Chức vụ:";
            this.layoutItemChucVu.TextSize = new System.Drawing.Size(83, 23);
            // 
            // layoutItemSDT
            // 
            this.layoutItemSDT.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemSDT.AppearanceItemCaption.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.layoutItemSDT.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemSDT.AppearanceItemCaption.Options.UseForeColor = true;
            this.layoutItemSDT.Control = this.txtSDT;
            this.layoutItemSDT.Location = new System.Drawing.Point(0, 240);
            this.layoutItemSDT.Name = "layoutItemSDT";
            this.layoutItemSDT.Padding = new DevExpress.XtraLayout.Utils.Padding(10, 10, 10, 10);
            this.layoutItemSDT.Size = new System.Drawing.Size(497, 60);
            this.layoutItemSDT.Text = "Điện thoại:";
            this.layoutItemSDT.TextSize = new System.Drawing.Size(83, 23);
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 360);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(497, 10);
            // 
            // layoutItemBtnOk
            // 
            this.layoutItemBtnOk.Control = this.btnOk;
            this.layoutItemBtnOk.Location = new System.Drawing.Point(0, 370);
            this.layoutItemBtnOk.Name = "layoutItemBtnOk";
            this.layoutItemBtnOk.Size = new System.Drawing.Size(363, 54);
            this.layoutItemBtnOk.TextVisible = false;
            // 
            // layoutItemBtnCancel
            // 
            this.layoutItemBtnCancel.Control = this.btnCancel;
            this.layoutItemBtnCancel.Location = new System.Drawing.Point(363, 370);
            this.layoutItemBtnCancel.Name = "layoutItemBtnCancel";
            this.layoutItemBtnCancel.Size = new System.Drawing.Size(134, 54);
            this.layoutItemBtnCancel.TextVisible = false;
            // 
            // fNhanVienEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 460);
            this.Controls.Add(this.layoutControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fNhanVienEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thông tin nhân viên";
            this.Load += new System.EventHandler(this.fNhanVienEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgaySinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboGioiTinh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboChucVu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHoTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemNgaySinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemGioiTinh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDiaChi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemChucVu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSDT)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
