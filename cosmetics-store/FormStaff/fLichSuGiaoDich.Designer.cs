namespace cosmetics_store.FormStaff
{
    partial class fLichSuGiaoDich
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblNhanVien;
        private DevExpress.XtraGrid.GridControl gridHoaDon;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewHD;
        private DevExpress.XtraEditors.DateEdit dteFrom;
        private DevExpress.XtraEditors.DateEdit dteTo;
        private DevExpress.XtraEditors.SimpleButton btnLoc;
        private DevExpress.XtraEditors.SimpleButton btnHomNay;
        private DevExpress.XtraEditors.SimpleButton btnTuanNay;
        private DevExpress.XtraEditors.SimpleButton btnThangNay;
        private DevExpress.XtraEditors.SimpleButton btnXemChiTiet;
        private DevExpress.XtraEditors.LabelControl lblThongKe;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.dteFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.dteTo = new DevExpress.XtraEditors.DateEdit();
            this.btnLoc = new DevExpress.XtraEditors.SimpleButton();
            this.btnHomNay = new DevExpress.XtraEditors.SimpleButton();
            this.btnTuanNay = new DevExpress.XtraEditors.SimpleButton();
            this.btnThangNay = new DevExpress.XtraEditors.SimpleButton();
            this.gridHoaDon = new DevExpress.XtraGrid.GridControl();
            this.gridViewHD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblThongKe = new DevExpress.XtraEditors.LabelControl();
            this.btnXemChiTiet = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.btnXemChiTiet);
            this.pnlMain.Controls.Add(this.lblThongKe);
            this.pnlMain.Controls.Add(this.btnThangNay);
            this.pnlMain.Controls.Add(this.btnTuanNay);
            this.pnlMain.Controls.Add(this.btnHomNay);
            this.pnlMain.Controls.Add(this.btnLoc);
            this.pnlMain.Controls.Add(this.dteTo);
            this.pnlMain.Controls.Add(this.lblDenNgay);
            this.pnlMain.Controls.Add(this.dteFrom);
            this.pnlMain.Controls.Add(this.lblTuNgay);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblNhanVien);
            this.pnlMain.Controls.Add(this.gridHoaDon);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 550);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(384, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LỊCH SỬ GIAO DỊCH CÁ NHÂN";
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNhanVien.Appearance.Options.UseFont = true;
            this.lblNhanVien.Location = new System.Drawing.Point(20, 55);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(93, 25);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Nhân viên : ";
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTuNgay.Appearance.Options.UseFont = true;
            this.lblTuNgay.Location = new System.Drawing.Point(20, 90);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(55, 23);
            this.lblTuNgay.TabIndex = 2;
            this.lblTuNgay.Text = "Từ ngày";
            // 
            // dteFrom
            // 
            this.dteFrom.EditValue = null;
            this.dteFrom.Location = new System.Drawing.Point(85, 88);
            this.dteFrom.Name = "dteFrom";
            this.dteFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteFrom.Size = new System.Drawing.Size(120, 22);
            this.dteFrom.TabIndex = 3;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDenNgay.Appearance.Options.UseFont = true;
            this.lblDenNgay.Location = new System.Drawing.Point(215, 90);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(67, 23);
            this.lblDenNgay.TabIndex = 4;
            this.lblDenNgay.Text = "Đến ngày";
            // 
            // dteTo
            // 
            this.dteTo.EditValue = null;
            this.dteTo.Location = new System.Drawing.Point(290, 88);
            this.dteTo.Name = "dteTo";
            this.dteTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteTo.Size = new System.Drawing.Size(120, 22);
            this.dteTo.TabIndex = 5;
            // 
            // btnLoc
            // 
            this.btnLoc.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLoc.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnLoc.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Appearance.Options.UseBackColor = true;
            this.btnLoc.Appearance.Options.UseFont = true;
            this.btnLoc.Appearance.Options.UseForeColor = true;
            this.btnLoc.Location = new System.Drawing.Point(420, 85);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 28);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // btnHomNay
            // 
            this.btnHomNay.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnHomNay.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnHomNay.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnHomNay.Appearance.Options.UseBackColor = true;
            this.btnHomNay.Appearance.Options.UseFont = true;
            this.btnHomNay.Appearance.Options.UseForeColor = true;
            this.btnHomNay.Location = new System.Drawing.Point(505, 85);
            this.btnHomNay.Name = "btnHomNay";
            this.btnHomNay.Size = new System.Drawing.Size(80, 28);
            this.btnHomNay.TabIndex = 7;
            this.btnHomNay.Text = "Hôm nay";
            this.btnHomNay.Click += new System.EventHandler(this.btnHomNay_Click);
            // 
            // btnTuanNay
            // 
            this.btnTuanNay.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.btnTuanNay.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnTuanNay.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTuanNay.Appearance.Options.UseBackColor = true;
            this.btnTuanNay.Appearance.Options.UseFont = true;
            this.btnTuanNay.Appearance.Options.UseForeColor = true;
            this.btnTuanNay.Location = new System.Drawing.Point(595, 85);
            this.btnTuanNay.Name = "btnTuanNay";
            this.btnTuanNay.Size = new System.Drawing.Size(80, 28);
            this.btnTuanNay.TabIndex = 8;
            this.btnTuanNay.Text = "Tuần này";
            this.btnTuanNay.Click += new System.EventHandler(this.btnTuanNay_Click);
            // 
            // btnThangNay
            // 
            this.btnThangNay.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.btnThangNay.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnThangNay.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThangNay.Appearance.Options.UseBackColor = true;
            this.btnThangNay.Appearance.Options.UseFont = true;
            this.btnThangNay.Appearance.Options.UseForeColor = true;
            this.btnThangNay.Location = new System.Drawing.Point(685, 85);
            this.btnThangNay.Name = "btnThangNay";
            this.btnThangNay.Size = new System.Drawing.Size(85, 28);
            this.btnThangNay.TabIndex = 9;
            this.btnThangNay.Text = "Tháng này";
            this.btnThangNay.Click += new System.EventHandler(this.btnThangNay_Click);
            // 
            // gridHoaDon
            // 
            this.gridHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHoaDon.Location = new System.Drawing.Point(20, 125);
            this.gridHoaDon.MainView = this.gridViewHD;
            this.gridHoaDon.Name = "gridHoaDon";
            this.gridHoaDon.Size = new System.Drawing.Size(860, 350);
            this.gridHoaDon.TabIndex = 10;
            this.gridHoaDon.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewHD});
            // 
            // gridViewHD
            // 
            this.gridViewHD.GridControl = this.gridHoaDon;
            this.gridViewHD.Name = "gridViewHD";
            this.gridViewHD.OptionsBehavior.Editable = false;
            this.gridViewHD.OptionsView.ShowGroupPanel = false;
            // 
            // lblThongKe
            // 
            this.lblThongKe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblThongKe.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThongKe.Appearance.Options.UseFont = true;
            this.lblThongKe.Location = new System.Drawing.Point(20, 485);
            this.lblThongKe.Name = "lblThongKe";
            this.lblThongKe.Size = new System.Drawing.Size(72, 23);
            this.lblThongKe.TabIndex = 11;
            this.lblThongKe.Text = "Thống kê";
            // 
            // btnXemChiTiet
            // 
            this.btnXemChiTiet.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXemChiTiet.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXemChiTiet.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXemChiTiet.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnXemChiTiet.Appearance.Options.UseBackColor = true;
            this.btnXemChiTiet.Appearance.Options.UseFont = true;
            this.btnXemChiTiet.Appearance.Options.UseForeColor = true;
            this.btnXemChiTiet.Location = new System.Drawing.Point(775, 481);
            this.btnXemChiTiet.Name = "btnXemChiTiet";
            this.btnXemChiTiet.Size = new System.Drawing.Size(105, 32);
            this.btnXemChiTiet.TabIndex = 12;
            this.btnXemChiTiet.Text = "Xem chi tiết";
            this.btnXemChiTiet.Click += new System.EventHandler(this.btnXemChiTiet_Click);
            // 
            // fLichSuGiaoDich
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fLichSuGiaoDich";
            this.Text = "Lich su giao dich ca nhan";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
