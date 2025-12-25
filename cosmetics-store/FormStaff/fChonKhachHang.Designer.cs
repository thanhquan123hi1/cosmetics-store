namespace cosmetics_store.FormStaff
{
    partial class fChonKhachHang
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblTimKiem;
        private DevExpress.XtraEditors.TextEdit txtTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnTim;
        private DevExpress.XtraGrid.GridControl gridKhachHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewKH;
        private DevExpress.XtraEditors.SimpleButton btnChon;
        private DevExpress.XtraEditors.SimpleButton btnThemNhanh;
        private DevExpress.XtraEditors.SimpleButton btnHuy;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblTimKiem = new DevExpress.XtraEditors.LabelControl();
            this.txtTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnTim = new DevExpress.XtraEditors.SimpleButton();
            this.gridKhachHang = new DevExpress.XtraGrid.GridControl();
            this.gridViewKH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnChon = new DevExpress.XtraEditors.SimpleButton();
            this.btnThemNhanh = new DevExpress.XtraEditors.SimpleButton();
            this.btnHuy = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKH)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblTimKiem);
            this.pnlMain.Controls.Add(this.txtTimKiem);
            this.pnlMain.Controls.Add(this.btnTim);
            this.pnlMain.Controls.Add(this.gridKhachHang);
            this.pnlMain.Controls.Add(this.btnChon);
            this.pnlMain.Controls.Add(this.btnThemNhanh);
            this.pnlMain.Controls.Add(this.btnHuy);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(580, 450);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "CHON KHACH HANG";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiem.Appearance.Options.UseFont = true;
            this.lblTimKiem.Location = new System.Drawing.Point(20, 58);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(190, 19);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tim theo SDT hoac Ten KH:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(220, 55);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Properties.Appearance.Options.UseFont = true;
            this.txtTimKiem.Size = new System.Drawing.Size(240, 26);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // btnTim
            // 
            this.btnTim.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTim.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTim.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTim.Appearance.Options.UseBackColor = true;
            this.btnTim.Appearance.Options.UseFont = true;
            this.btnTim.Appearance.Options.UseForeColor = true;
            this.btnTim.Location = new System.Drawing.Point(475, 52);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(85, 32);
            this.btnTim.TabIndex = 3;
            this.btnTim.Text = "Tim kiem";
            this.btnTim.Click += new System.EventHandler(this.btnTim_Click);
            // 
            // gridKhachHang
            // 
            this.gridKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gridKhachHang.Location = new System.Drawing.Point(20, 95);
            this.gridKhachHang.MainView = this.gridViewKH;
            this.gridKhachHang.Name = "gridKhachHang";
            this.gridKhachHang.Size = new System.Drawing.Size(540, 290);
            this.gridKhachHang.TabIndex = 4;
            // 
            // gridViewKH
            // 
            this.gridViewKH.GridControl = this.gridKhachHang;
            this.gridViewKH.Name = "gridViewKH";
            this.gridViewKH.OptionsBehavior.Editable = false;
            this.gridViewKH.OptionsView.ShowGroupPanel = false;
            this.gridViewKH.DoubleClick += new System.EventHandler(this.gridViewKH_DoubleClick);
            // 
            // btnChon
            // 
            this.btnChon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnChon.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnChon.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnChon.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnChon.Appearance.Options.UseBackColor = true;
            this.btnChon.Appearance.Options.UseFont = true;
            this.btnChon.Appearance.Options.UseForeColor = true;
            this.btnChon.Location = new System.Drawing.Point(20, 400);
            this.btnChon.Name = "btnChon";
            this.btnChon.Size = new System.Drawing.Size(130, 38);
            this.btnChon.TabIndex = 5;
            this.btnChon.Text = "CHON";
            this.btnChon.Click += new System.EventHandler(this.btnChon_Click);
            // 
            // btnThemNhanh
            // 
            this.btnThemNhanh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnThemNhanh.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnThemNhanh.Appearance.Options.UseFont = true;
            this.btnThemNhanh.Location = new System.Drawing.Point(165, 400);
            this.btnThemNhanh.Name = "btnThemNhanh";
            this.btnThemNhanh.Size = new System.Drawing.Size(150, 38);
            this.btnThemNhanh.TabIndex = 6;
            this.btnThemNhanh.Text = "+ Them KH moi";
            this.btnThemNhanh.Click += new System.EventHandler(this.btnThemNhanh_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuy.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnHuy.Appearance.Options.UseFont = true;
            this.btnHuy.Location = new System.Drawing.Point(475, 400);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(85, 38);
            this.btnHuy.TabIndex = 7;
            this.btnHuy.Text = "Huy";
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // fChonKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 450);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fChonKhachHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Chon khach hang";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewKH)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
