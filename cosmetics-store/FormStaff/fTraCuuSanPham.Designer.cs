namespace cosmetics_store.FormStaff
{
    partial class fTraCuuSanPham
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblTimKiem;
        private DevExpress.XtraEditors.TextEdit txtTimKiem;
        private DevExpress.XtraEditors.LabelControl lblThuongHieu;
        private DevExpress.XtraEditors.LookUpEdit cboThuongHieu;
        private DevExpress.XtraEditors.LabelControl lblLoaiSP;
        private DevExpress.XtraEditors.LookUpEdit cboLoaiSP;
        private DevExpress.XtraEditors.SimpleButton btnTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private DevExpress.XtraGrid.GridControl gridSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSP;
        private DevExpress.XtraEditors.LabelControl lblKetQua;

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblTimKiem = new DevExpress.XtraEditors.LabelControl();
            this.txtTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.lblThuongHieu = new DevExpress.XtraEditors.LabelControl();
            this.cboThuongHieu = new DevExpress.XtraEditors.LookUpEdit();
            this.lblLoaiSP = new DevExpress.XtraEditors.LabelControl();
            this.cboLoaiSP = new DevExpress.XtraEditors.LookUpEdit();
            this.btnTimKiem = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.gridSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSP = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblKetQua = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThuongHieu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiSP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSP)).BeginInit();
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
            this.pnlMain.Controls.Add(this.lblThuongHieu);
            this.pnlMain.Controls.Add(this.cboThuongHieu);
            this.pnlMain.Controls.Add(this.lblLoaiSP);
            this.pnlMain.Controls.Add(this.cboLoaiSP);
            this.pnlMain.Controls.Add(this.btnTimKiem);
            this.pnlMain.Controls.Add(this.btnLamMoi);
            this.pnlMain.Controls.Add(this.gridSanPham);
            this.pnlMain.Controls.Add(this.lblKetQua);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 550);
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
            this.lblTitle.Size = new System.Drawing.Size(220, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "TRA CUU SAN PHAM";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimKiem.Appearance.Options.UseFont = true;
            this.lblTimKiem.Location = new System.Drawing.Point(20, 60);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(70, 19);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tim kiem:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(100, 57);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Properties.Appearance.Options.UseFont = true;
            this.txtTimKiem.Properties.NullValuePrompt = "Nhap ten san pham...";
            this.txtTimKiem.Size = new System.Drawing.Size(200, 26);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // lblThuongHieu
            // 
            this.lblThuongHieu.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThuongHieu.Appearance.Options.UseFont = true;
            this.lblThuongHieu.Location = new System.Drawing.Point(320, 60);
            this.lblThuongHieu.Name = "lblThuongHieu";
            this.lblThuongHieu.Size = new System.Drawing.Size(90, 19);
            this.lblThuongHieu.TabIndex = 3;
            this.lblThuongHieu.Text = "Thuong hieu:";
            // 
            // cboThuongHieu
            // 
            this.cboThuongHieu.Location = new System.Drawing.Point(420, 57);
            this.cboThuongHieu.Name = "cboThuongHieu";
            this.cboThuongHieu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboThuongHieu.Properties.Appearance.Options.UseFont = true;
            this.cboThuongHieu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboThuongHieu.Properties.NullText = "";
            this.cboThuongHieu.Size = new System.Drawing.Size(150, 26);
            this.cboThuongHieu.TabIndex = 4;
            // 
            // lblLoaiSP
            // 
            this.lblLoaiSP.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLoaiSP.Appearance.Options.UseFont = true;
            this.lblLoaiSP.Location = new System.Drawing.Point(590, 60);
            this.lblLoaiSP.Name = "lblLoaiSP";
            this.lblLoaiSP.Size = new System.Drawing.Size(40, 19);
            this.lblLoaiSP.TabIndex = 5;
            this.lblLoaiSP.Text = "Loai:";
            // 
            // cboLoaiSP
            // 
            this.cboLoaiSP.Location = new System.Drawing.Point(640, 57);
            this.cboLoaiSP.Name = "cboLoaiSP";
            this.cboLoaiSP.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoaiSP.Properties.Appearance.Options.UseFont = true;
            this.cboLoaiSP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoaiSP.Properties.NullText = "";
            this.cboLoaiSP.Size = new System.Drawing.Size(130, 26);
            this.cboLoaiSP.TabIndex = 6;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnTimKiem.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTimKiem.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTimKiem.Appearance.Options.UseBackColor = true;
            this.btnTimKiem.Appearance.Options.UseFont = true;
            this.btnTimKiem.Appearance.Options.UseForeColor = true;
            this.btnTimKiem.Location = new System.Drawing.Point(790, 54);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(90, 32);
            this.btnTimKiem.TabIndex = 7;
            this.btnTimKiem.Text = "Tim kiem";
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.Appearance.Options.UseFont = true;
            this.btnLamMoi.Location = new System.Drawing.Point(790, 15);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(90, 30);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Lam moi";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // gridSanPham
            // 
            this.gridSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSanPham.Location = new System.Drawing.Point(20, 100);
            this.gridSanPham.MainView = this.gridViewSP;
            this.gridSanPham.Name = "gridSanPham";
            this.gridSanPham.Size = new System.Drawing.Size(860, 410);
            this.gridSanPham.TabIndex = 9;
            // 
            // gridViewSP
            // 
            this.gridViewSP.GridControl = this.gridSanPham;
            this.gridViewSP.Name = "gridViewSP";
            this.gridViewSP.OptionsBehavior.Editable = false;
            this.gridViewSP.OptionsView.ShowGroupPanel = false;
            // 
            // lblKetQua
            // 
            this.lblKetQua.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblKetQua.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblKetQua.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblKetQua.Appearance.Options.UseFont = true;
            this.lblKetQua.Appearance.Options.UseForeColor = true;
            this.lblKetQua.Location = new System.Drawing.Point(20, 520);
            this.lblKetQua.Name = "lblKetQua";
            this.lblKetQua.Size = new System.Drawing.Size(150, 19);
            this.lblKetQua.TabIndex = 10;
            this.lblKetQua.Text = "Tim thay 0 san pham";
            // 
            // fTraCuuSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fTraCuuSanPham";
            this.Text = "Tra cuu san pham";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboThuongHieu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoaiSP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSP)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
