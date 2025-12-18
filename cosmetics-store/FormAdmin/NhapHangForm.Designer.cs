namespace cosmetics_store.Forms
{
    partial class NhapHangForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlLeft;
        private DevExpress.XtraEditors.LabelControl lblNCC;
        private DevExpress.XtraEditors.LookUpEdit lookupNCC;
        private DevExpress.XtraEditors.LabelControl lblNgayNhap;
        private DevExpress.XtraEditors.DateEdit dateNgayNhap;
        private DevExpress.XtraEditors.LabelControl lblSPMoi;
        private DevExpress.XtraEditors.LookUpEdit lookupSPMoi;
        private DevExpress.XtraEditors.LabelControl lblSoLuong;
        private DevExpress.XtraEditors.SpinEdit spinSoLuong;
        private DevExpress.XtraEditors.LabelControl lblDonGia;
        private DevExpress.XtraEditors.SpinEdit spinDonGia;
        private DevExpress.XtraEditors.LabelControl lblHanSD;
        private DevExpress.XtraEditors.DateEdit dateHanSD;
        private DevExpress.XtraEditors.SimpleButton btnThemSP;
        private DevExpress.XtraEditors.SimpleButton btnXoaSP;
        private DevExpress.XtraEditors.SimpleButton btnTaoPhieu;
        private DevExpress.XtraGrid.GridControl gridChiTietMoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChiTietMoi;
        private DevExpress.XtraGrid.GridControl gridMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMaster;
        private DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookupSP;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.lblNCC = new DevExpress.XtraEditors.LabelControl();
            this.lookupNCC = new DevExpress.XtraEditors.LookUpEdit();
            this.lblNgayNhap = new DevExpress.XtraEditors.LabelControl();
            this.dateNgayNhap = new DevExpress.XtraEditors.DateEdit();
            this.lblSPMoi = new DevExpress.XtraEditors.LabelControl();
            this.lookupSPMoi = new DevExpress.XtraEditors.LookUpEdit();
            this.lblSoLuong = new DevExpress.XtraEditors.LabelControl();
            this.spinSoLuong = new DevExpress.XtraEditors.SpinEdit();
            this.lblDonGia = new DevExpress.XtraEditors.LabelControl();
            this.spinDonGia = new DevExpress.XtraEditors.SpinEdit();
            this.lblHanSD = new DevExpress.XtraEditors.LabelControl();
            this.dateHanSD = new DevExpress.XtraEditors.DateEdit();
            this.btnThemSP = new DevExpress.XtraEditors.SimpleButton();
            this.btnXoaSP = new DevExpress.XtraEditors.SimpleButton();
            this.btnTaoPhieu = new DevExpress.XtraEditors.SimpleButton();
            this.gridChiTietMoi = new DevExpress.XtraGrid.GridControl();
            this.gridViewChiTietMoi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repoLookupSP = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNCC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayNhap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupSPMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHanSD.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHanSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTietMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTietMoi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookupSP)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Size = new System.Drawing.Size(1100, 700);
            this.splitContainer.SplitterDistance = 450;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.lblNCC);
            this.pnlLeft.Controls.Add(this.lookupNCC);
            this.pnlLeft.Controls.Add(this.lblNgayNhap);
            this.pnlLeft.Controls.Add(this.dateNgayNhap);
            this.pnlLeft.Controls.Add(this.lblSPMoi);
            this.pnlLeft.Controls.Add(this.lookupSPMoi);
            this.pnlLeft.Controls.Add(this.lblSoLuong);
            this.pnlLeft.Controls.Add(this.spinSoLuong);
            this.pnlLeft.Controls.Add(this.lblDonGia);
            this.pnlLeft.Controls.Add(this.spinDonGia);
            this.pnlLeft.Controls.Add(this.lblHanSD);
            this.pnlLeft.Controls.Add(this.dateHanSD);
            this.pnlLeft.Controls.Add(this.btnThemSP);
            this.pnlLeft.Controls.Add(this.btnXoaSP);
            this.pnlLeft.Controls.Add(this.btnTaoPhieu);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Size = new System.Drawing.Size(450, 280);
            this.splitContainer.Panel1.Controls.Add(this.pnlLeft);
            this.splitContainer.Panel1.Controls.Add(this.gridChiTietMoi);
            // 
            // lblNCC
            // 
            this.lblNCC.Location = new System.Drawing.Point(12, 15);
            this.lblNCC.Text = "Nha cung cap:";
            // 
            // lookupNCC
            // 
            this.lookupNCC.Location = new System.Drawing.Point(120, 12);
            this.lookupNCC.Size = new System.Drawing.Size(300, 22);
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.Location = new System.Drawing.Point(12, 55);
            this.lblNgayNhap.Text = "Ngay nhap:";
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.Location = new System.Drawing.Point(120, 52);
            this.dateNgayNhap.Size = new System.Drawing.Size(140, 22);
            // 
            // lblSPMoi
            // 
            this.lblSPMoi.Location = new System.Drawing.Point(12, 95);
            this.lblSPMoi.Text = "San pham:";
            // 
            // lookupSPMoi
            // 
            this.lookupSPMoi.Location = new System.Drawing.Point(120, 92);
            this.lookupSPMoi.Size = new System.Drawing.Size(300, 22);
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(12, 135);
            this.lblSoLuong.Text = "So luong:";
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.EditValue = new decimal(1);
            this.spinSoLuong.Location = new System.Drawing.Point(120, 132);
            this.spinSoLuong.Size = new System.Drawing.Size(100, 22);
            // 
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(240, 135);
            this.lblDonGia.Text = "Don gia:";
            // 
            // spinDonGia
            // 
            this.spinDonGia.EditValue = new decimal(0);
            this.spinDonGia.Location = new System.Drawing.Point(300, 132);
            this.spinDonGia.Size = new System.Drawing.Size(120, 22);
            // 
            // lblHanSD
            // 
            this.lblHanSD.Location = new System.Drawing.Point(12, 175);
            this.lblHanSD.Text = "Han su dung:";
            // 
            // dateHanSD
            // 
            this.dateHanSD.Location = new System.Drawing.Point(120, 172);
            this.dateHanSD.Size = new System.Drawing.Size(140, 22);
            // 
            // btnThemSP
            // 
            this.btnThemSP.Location = new System.Drawing.Point(120, 212);
            this.btnThemSP.Size = new System.Drawing.Size(94, 29);
            this.btnThemSP.Text = "Them SP";
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Location = new System.Drawing.Point(230, 212);
            this.btnXoaSP.Size = new System.Drawing.Size(94, 29);
            this.btnXoaSP.Text = "Xoa SP";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Location = new System.Drawing.Point(120, 248);
            this.btnTaoPhieu.Size = new System.Drawing.Size(200, 29);
            this.btnTaoPhieu.Text = "TAO PHIEU NHAP";
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // gridChiTietMoi
            // 
            this.gridChiTietMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChiTietMoi.Location = new System.Drawing.Point(0, 280);
            this.gridChiTietMoi.MainView = this.gridViewChiTietMoi;
            this.gridChiTietMoi.Size = new System.Drawing.Size(450, 420);
            // 
            // gridViewChiTietMoi
            // 
            this.gridViewChiTietMoi.GridControl = this.gridChiTietMoi;
            this.gridViewChiTietMoi.OptionsView.ShowGroupPanel = false;
            // 
            // gridMaster
            // 
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.MainView = this.gridViewMaster;
            this.gridMaster.Size = new System.Drawing.Size(646, 300);
            this.splitContainer.Panel2.Controls.Add(this.gridMaster);
            this.splitContainer.Panel2.Controls.Add(this.gridDetail);
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.GridControl = this.gridMaster;
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMaster_FocusedRowChanged);
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 300);
            this.gridDetail.MainView = this.gridViewDetail;
            this.gridDetail.Size = new System.Drawing.Size(646, 400);
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.GridControl = this.gridDetail;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // NhapHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.splitContainer);
            this.Name = "NhapHangForm";
            this.Text = "Nhap hang";
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lookupNCC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayNhap.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayNhap.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupSPMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDonGia.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHanSD.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHanSD.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridChiTietMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewChiTietMoi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMaster)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repoLookupSP)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
