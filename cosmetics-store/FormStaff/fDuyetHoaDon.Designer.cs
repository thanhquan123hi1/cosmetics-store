namespace cosmetics_store.FormStaff
{
    partial class fDuyetHoaDon
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.panelTop = new System.Windows.Forms.Panel();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblThongKe = new DevExpress.XtraEditors.LabelControl();
            this.panelFilter = new System.Windows.Forms.Panel();
            this.cboTrangThai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTrangThai = new DevExpress.XtraEditors.LabelControl();
            this.btnLoc = new DevExpress.XtraEditors.SimpleButton();
            this.btnLamMoi = new DevExpress.XtraEditors.SimpleButton();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.btnXemChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.btnDuyet = new DevExpress.XtraEditors.SimpleButton();
            this.btnTuChoi = new DevExpress.XtraEditors.SimpleButton();
            this.gridHoaDon = new DevExpress.XtraGrid.GridControl();
            this.gridViewHD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.panelTop.SuspendLayout();
            this.panelFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTrangThai.Properties)).BeginInit();
            this.panelButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).BeginInit();
            this.SuspendLayout();
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.panelTop.Controls.Add(this.lblTitle);
            this.panelTop.Controls.Add(this.lblThongKe);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(950, 60);
            this.panelTop.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(15, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(196, 30);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DUYỆT HÓA ĐƠN";
            // 
            // lblThongKe
            // 
            this.lblThongKe.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThongKe.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblThongKe.Appearance.Options.UseFont = true;
            this.lblThongKe.Appearance.Options.UseForeColor = true;
            this.lblThongKe.Location = new System.Drawing.Point(400, 20);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(200, 19);
            this.lblThongKe.TabIndex = 1;
            this.lblThongKe.Text = "Chờ duyệt: 0 | Đã duyệt: 0 | Từ chối: 0";
            // 
            // panelFilter
            // 
            this.panelFilter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelFilter.Controls.Add(this.lblTrangThai);
            this.panelFilter.Controls.Add(this.cboTrangThai);
            this.panelFilter.Controls.Add(this.btnLoc);
            this.panelFilter.Controls.Add(this.btnLamMoi);
            this.panelFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFilter.Location = new System.Drawing.Point(0, 60);
            this.panelFilter.Name = "panelFilter";
            this.panelFilter.Size = new System.Drawing.Size(950, 50);
            this.panelFilter.TabIndex = 1;
            // 
            // lblTrangThai
            // 
            this.lblTrangThai.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTrangThai.Location = new System.Drawing.Point(15, 15);
            this.lblTrangThai.Name = "lblTrangThai";
            this.lblTrangThai.Size = new System.Drawing.Size(66, 19);
            this.lblTrangThai.TabIndex = 0;
            this.lblTrangThai.Text = "Trạng thái:";
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.Location = new System.Drawing.Point(90, 12);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTrangThai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTrangThai.Size = new System.Drawing.Size(150, 22);
            this.cboTrangThai.TabIndex = 1;
            // 
            // btnLoc
            // 
            this.btnLoc.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLoc.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnLoc.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Appearance.Options.UseBackColor = true;
            this.btnLoc.Appearance.Options.UseFont = true;
            this.btnLoc.Appearance.Options.UseForeColor = true;
            this.btnLoc.Location = new System.Drawing.Point(260, 10);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(80, 28);
            this.btnLoc.TabIndex = 2;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLamMoi.Location = new System.Drawing.Point(350, 10);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(80, 28);
            this.btnLamMoi.TabIndex = 3;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.Click += new System.EventHandler(this.btnLamMoi_Click);
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(247)))), ((int)(((byte)(250)))));
            this.panelButtons.Controls.Add(this.btnXemChiTiet);
            this.panelButtons.Controls.Add(this.btnDuyet);
            this.panelButtons.Controls.Add(this.btnTuChoi);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelButtons.Location = new System.Drawing.Point(0, 500);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(950, 60);
            this.panelButtons.TabIndex = 2;
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemChiTiet.Appearance.Options.UseFont = true;
            this.btnXemChiTiet.Location = new System.Drawing.Point(15, 13);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(130, 35);
            this.btnXemChiTiet.TabIndex = 0;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // btnDuyet
            // 
            this.btnDuyet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnDuyet.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDuyet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDuyet.Appearance.Options.UseBackColor = true;
            this.btnDuyet.Appearance.Options.UseFont = true;
            this.btnDuyet.Appearance.Options.UseForeColor = true;
            this.btnDuyet.Location = new System.Drawing.Point(160, 13);
            this.btnDuyet.Name = "btnDuyet";
            this.btnDuyet.Size = new System.Drawing.Size(130, 35);
            this.btnDuyet.TabIndex = 1;
            this.btnDuyet.Text = "✓ Duyệt";
            this.btnDuyet.Click += new System.EventHandler(this.btnDuyet_Click);
            // 
            // btnTuChoi
            // 
            this.btnTuChoi.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnTuChoi.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTuChoi.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTuChoi.Appearance.Options.UseBackColor = true;
            this.btnTuChoi.Appearance.Options.UseFont = true;
            this.btnTuChoi.Appearance.Options.UseForeColor = true;
            this.btnTuChoi.Location = new System.Drawing.Point(305, 13);
            this.btnTuChoi.Name = "btnTuChoi";
            this.btnTuChoi.Size = new System.Drawing.Size(130, 35);
            this.btnTuChoi.TabIndex = 2;
            this.btnTuChoi.Text = "✗ Từ chối";
            this.btnTuChoi.Click += new System.EventHandler(this.btnTuChoi_Click);
            // 
            // gridHoaDon
            // 
            this.gridHoaDon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridHoaDon.Location = new System.Drawing.Point(0, 110);
            this.gridHoaDon.MainView = this.gridViewHD;
            this.gridHoaDon.Name = "gridHoaDon";
            this.gridHoaDon.Size = new System.Drawing.Size(950, 390);
            this.gridHoaDon.TabIndex = 3;
            this.gridHoaDon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHD});
            // 
            // gridViewHD
            // 
            this.gridViewHD.GridControl = this.gridHoaDon;
            this.gridViewHD.Name = "gridViewHD";
            this.gridViewHD.OptionsBehavior.Editable = false;
            this.gridViewHD.OptionsView.ShowGroupPanel = false;
            this.gridViewHD.DoubleClick += new System.EventHandler(this.gridViewHD_DoubleClick);
            // 
            // fDuyetHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 560);
            this.Controls.Add(this.gridHoaDon);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelFilter);
            this.Controls.Add(this.panelTop);
            this.Name = "fDuyetHoaDon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Duyệt Hóa Đơn";
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelFilter.ResumeLayout(false);
            this.panelFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cboTrangThai.Properties)).EndInit();
            this.panelButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelTop;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblThongKe;
        private System.Windows.Forms.Panel panelFilter;
        private DevExpress.XtraEditors.LabelControl lblTrangThai;
        private DevExpress.XtraEditors.ComboBoxEdit cboTrangThai;
        private DevExpress.XtraEditors.SimpleButton btnLoc;
        private DevExpress.XtraEditors.SimpleButton btnLamMoi;
        private System.Windows.Forms.Panel panelButtons;
        private DevExpress.XtraEditors.SimpleButton btnXemChiTiet;
        private DevExpress.XtraEditors.SimpleButton btnDuyet;
        private DevExpress.XtraEditors.SimpleButton btnTuChoi;
        private DevExpress.XtraGrid.GridControl gridHoaDon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHD;
    }
}
