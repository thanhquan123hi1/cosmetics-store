namespace cosmetics_store.FormStaff
{
    partial class fThemKhachHangNhanh
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraLayout.LayoutControl layoutControl;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemHoTen;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemSDT;
        private DevExpress.XtraEditors.TextEdit txtDiaChi;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemDiaChi;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemBtnLuu;
        private DevExpress.XtraLayout.LayoutControlItem layoutItemBtnHuy;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.layoutControl = new DevExpress.XtraLayout.LayoutControl();
            this.btnLuu = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutItemBtnLuu = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemBtnHuy = new DevExpress.XtraLayout.LayoutControlItem();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.TextEdit();
            this.layoutItemHoTen = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemSDT = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutItemDiaChi = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).BeginInit();
            this.layoutControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnLuu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnHuy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHoTen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSDT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDiaChi)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl
            // 
            this.layoutControl.Controls.Add(this.txtHoTen);
            this.layoutControl.Controls.Add(this.txtSDT);
            this.layoutControl.Controls.Add(this.txtDiaChi);
            this.layoutControl.Controls.Add(this.btnLuu);
            this.layoutControl.Controls.Add(this.btnHuy);
            this.layoutControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl.Location = new System.Drawing.Point(0, 0);
            this.layoutControl.Name = "layoutControl";
            this.layoutControl.Root = this.layoutControlGroup1;
            this.layoutControl.Size = new System.Drawing.Size(400, 200);
            this.layoutControl.TabIndex = 0;
            // 
            // btnLuu
            // 
            this.btnLuu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnLuu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLuu.Appearance.Options.UseBackColor = true;
            this.btnLuu.Appearance.Options.UseFont = true;
            this.btnLuu.Appearance.Options.UseForeColor = true;
            this.btnLuu.Location = new System.Drawing.Point(14, 158);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(273, 28);
            this.btnLuu.StyleController = this.layoutControl;
            this.btnLuu.TabIndex = 3;
            this.btnLuu.Text = "💾 Lưu";
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Location = new System.Drawing.Point(291, 158);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(95, 28);
            this.btnHuy.StyleController = this.layoutControl;
            this.btnHuy.TabIndex = 4;
            this.btnHuy.Text = "❌ Hủy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutItemHoTen,
            this.layoutItemSDT,
            this.layoutItemDiaChi,
            this.emptySpaceItem1,
            this.layoutItemBtnLuu,
            this.layoutItemBtnHuy});
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(400, 200);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 102);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(376, 42);
            // 
            // layoutItemBtnLuu
            // 
            this.layoutItemBtnLuu.Control = this.btnLuu;
            this.layoutItemBtnLuu.Location = new System.Drawing.Point(0, 144);
            this.layoutItemBtnLuu.Name = "layoutItemBtnLuu";
            this.layoutItemBtnLuu.Size = new System.Drawing.Size(277, 32);
            this.layoutItemBtnLuu.TextVisible = false;
            // 
            // layoutItemBtnHuy
            // 
            this.layoutItemBtnHuy.Control = this.btnHuy;
            this.layoutItemBtnHuy.Location = new System.Drawing.Point(277, 144);
            this.layoutItemBtnHuy.Name = "layoutItemBtnHuy";
            this.layoutItemBtnHuy.Size = new System.Drawing.Size(99, 32);
            this.layoutItemBtnHuy.TextVisible = false;
            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(85, 14);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtHoTen.Properties.Appearance.Options.UseFont = true;
            this.txtHoTen.Size = new System.Drawing.Size(301, 30);
            this.txtHoTen.StyleController = this.layoutControl;
            this.txtHoTen.TabIndex = 0;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(85, 48);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSDT.Properties.Appearance.Options.UseFont = true;
            this.txtSDT.Size = new System.Drawing.Size(301, 30);
            this.txtSDT.StyleController = this.layoutControl;
            this.txtSDT.TabIndex = 1;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(85, 82);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtDiaChi.Properties.Appearance.Options.UseFont = true;
            this.txtDiaChi.Size = new System.Drawing.Size(301, 30);
            this.txtDiaChi.StyleController = this.layoutControl;
            this.txtDiaChi.TabIndex = 2;
            // 
            // layoutItemHoTen
            // 
            this.layoutItemHoTen.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemHoTen.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemHoTen.Control = this.txtHoTen;
            this.layoutItemHoTen.Location = new System.Drawing.Point(0, 0);
            this.layoutItemHoTen.Name = "layoutItemHoTen";
            this.layoutItemHoTen.Size = new System.Drawing.Size(376, 34);
            this.layoutItemHoTen.Text = "Họ tên:";
            this.layoutItemHoTen.TextSize = new System.Drawing.Size(56, 23);
            // 
            // layoutItemSDT
            // 
            this.layoutItemSDT.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemSDT.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemSDT.Control = this.txtSDT;
            this.layoutItemSDT.Location = new System.Drawing.Point(0, 34);
            this.layoutItemSDT.Name = "layoutItemSDT";
            this.layoutItemSDT.Size = new System.Drawing.Size(376, 34);
            this.layoutItemSDT.Text = "SĐT:";
            this.layoutItemSDT.TextSize = new System.Drawing.Size(56, 23);
            // 
            // layoutItemDiaChi
            // 
            this.layoutItemDiaChi.AppearanceItemCaption.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.layoutItemDiaChi.AppearanceItemCaption.Options.UseFont = true;
            this.layoutItemDiaChi.Control = this.txtDiaChi;
            this.layoutItemDiaChi.Location = new System.Drawing.Point(0, 68);
            this.layoutItemDiaChi.Name = "layoutItemDiaChi";
            this.layoutItemDiaChi.Size = new System.Drawing.Size(376, 34);
            this.layoutItemDiaChi.Text = "Địa chỉ:";
            this.layoutItemDiaChi.TextSize = new System.Drawing.Size(56, 23);
            // 
            // fThemKhachHangNhanh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(400, 200);
            this.Controls.Add(this.layoutControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fThemKhachHangNhanh";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Thêm khách hàng nhanh";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl)).EndInit();
            this.layoutControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnLuu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemBtnHuy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemHoTen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemSDT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutItemDiaChi)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
