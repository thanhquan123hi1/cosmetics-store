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

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblNhanVien = new DevExpress.XtraEditors.LabelControl();
            this.gridHoaDon = new DevExpress.XtraGrid.GridControl();
            this.gridViewHD = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
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
            this.lblNhanVien.Appearance.Font = new System.Drawing.Font("Times New Roman", 11.2F, System.Drawing.FontStyle.Bold);
            this.lblNhanVien.Appearance.Options.UseFont = true;
            this.lblNhanVien.Location = new System.Drawing.Point(20, 55);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(97, 22);
            this.lblNhanVien.TabIndex = 1;
            this.lblNhanVien.Text = "Nhân viên : ";
            // 
            // gridHoaDon
            // 
            this.gridHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridHoaDon.Location = new System.Drawing.Point(20, 95);
            this.gridHoaDon.MainView = this.gridViewHD;
            this.gridHoaDon.Name = "gridHoaDon";
            this.gridHoaDon.Size = new System.Drawing.Size(860, 435);
            this.gridHoaDon.TabIndex = 2;
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
            ((System.ComponentModel.ISupportInitialize)(this.gridHoaDon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewHD)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
