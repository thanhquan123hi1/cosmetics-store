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
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayNhap.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateNgayNhap.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupSPMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinSoLuong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spinDonGia.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHanSD.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateHanSD.Properties.CalendarTimeProperties)).BeginInit();
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
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlLeft);
            this.splitContainer.Panel1.Controls.Add(this.gridChiTietMoi);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gridMaster);
            this.splitContainer.Panel2.Controls.Add(this.gridDetail);
            this.splitContainer.Size = new System.Drawing.Size(1100, 700);
            this.splitContainer.SplitterDistance = 449;
            this.splitContainer.TabIndex = 0;
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
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(449, 310);
            this.pnlLeft.TabIndex = 0;
            // 
            // lblNCC
            // 
            this.lblNCC.Location = new System.Drawing.Point(12, 15);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(82, 16);
            this.lblNCC.TabIndex = 0;
            this.lblNCC.Text = "Nhà cung cấp:";
            // 
            // lookupNCC
            // 
            this.lookupNCC.Location = new System.Drawing.Point(120, 12);
            this.lookupNCC.Name = "lookupNCC";
            this.lookupNCC.Size = new System.Drawing.Size(300, 22);
            this.lookupNCC.TabIndex = 1;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.Location = new System.Drawing.Point(12, 55);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(65, 16);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.EditValue = new System.DateTime(2025, 12, 21, 0, 0, 0, 0);
            this.dateNgayNhap.Location = new System.Drawing.Point(120, 52);
            this.dateNgayNhap.Name = "dateNgayNhap";
            this.dateNgayNhap.Size = new System.Drawing.Size(140, 22);
            this.dateNgayNhap.TabIndex = 3;
            // 
            // lblSPMoi
            // 
            this.lblSPMoi.Location = new System.Drawing.Point(12, 95);
            this.lblSPMoi.Name = "lblSPMoi";
            this.lblSPMoi.Size = new System.Drawing.Size(63, 16);
            this.lblSPMoi.TabIndex = 4;
            this.lblSPMoi.Text = "Sản phẩm:";
            // 
            // lookupSPMoi
            // 
            this.lookupSPMoi.Location = new System.Drawing.Point(120, 92);
            this.lookupSPMoi.Name = "lookupSPMoi";
            this.lookupSPMoi.Size = new System.Drawing.Size(300, 22);
            this.lookupSPMoi.TabIndex = 5;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(12, 135);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(56, 16);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.spinSoLuong.Location = new System.Drawing.Point(120, 132);
            this.spinSoLuong.Name = "spinSoLuong";
            this.spinSoLuong.Size = new System.Drawing.Size(100, 22);
            this.spinSoLuong.TabIndex = 7;
            // 
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(240, 135);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(49, 16);
            this.lblDonGia.TabIndex = 8;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // spinDonGia
            // 
            this.spinDonGia.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.spinDonGia.Location = new System.Drawing.Point(300, 132);
            this.spinDonGia.Name = "spinDonGia";
            this.spinDonGia.Size = new System.Drawing.Size(120, 22);
            this.spinDonGia.TabIndex = 9;
            // 
            // lblHanSD
            // 
            this.lblHanSD.Location = new System.Drawing.Point(12, 175);
            this.lblHanSD.Name = "lblHanSD";
            this.lblHanSD.Size = new System.Drawing.Size(77, 16);
            this.lblHanSD.TabIndex = 10;
            this.lblHanSD.Text = "Hạn sử dụng:";
            // 
            // dateHanSD
            // 
            this.dateHanSD.EditValue = new System.DateTime(2025, 12, 21, 0, 0, 0, 0);
            this.dateHanSD.Location = new System.Drawing.Point(120, 172);
            this.dateHanSD.Name = "dateHanSD";
            this.dateHanSD.Size = new System.Drawing.Size(140, 22);
            this.dateHanSD.TabIndex = 11;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Location = new System.Drawing.Point(120, 212);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(94, 29);
            this.btnThemSP.TabIndex = 12;
            this.btnThemSP.Text = "➕ Thêm SP";
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Location = new System.Drawing.Point(230, 212);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(94, 29);
            this.btnXoaSP.TabIndex = 13;
            this.btnXoaSP.Text = "❌ Xóa SP";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Location = new System.Drawing.Point(120, 248);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(200, 29);
            this.btnTaoPhieu.TabIndex = 14;
            this.btnTaoPhieu.Text = "📦 TẠO PHIẾU NHẬP";
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // gridChiTietMoi
            // 
            this.gridChiTietMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChiTietMoi.Location = new System.Drawing.Point(0, 0);
            this.gridChiTietMoi.MainView = this.gridViewChiTietMoi;
            this.gridChiTietMoi.Name = "gridChiTietMoi";
            this.gridChiTietMoi.Size = new System.Drawing.Size(449, 700);
            this.gridChiTietMoi.TabIndex = 1;
            this.gridChiTietMoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewChiTietMoi});
            // 
            // gridViewChiTietMoi
            // 
            this.gridViewChiTietMoi.GridControl = this.gridChiTietMoi;
            this.gridViewChiTietMoi.Name = "gridViewChiTietMoi";
            this.gridViewChiTietMoi.OptionsView.ShowGroupPanel = false;
            // 
            // gridMaster
            // 
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridMaster.Location = new System.Drawing.Point(0, 0);
            this.gridMaster.MainView = this.gridViewMaster;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.Size = new System.Drawing.Size(647, 300);
            this.gridMaster.TabIndex = 0;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMaster});
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.GridControl = this.gridMaster;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            this.gridViewMaster.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewMaster_FocusedRowChanged);
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 0);
            this.gridDetail.MainView = this.gridViewDetail;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(647, 700);
            this.gridDetail.TabIndex = 1;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDetail});
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.GridControl = this.gridDetail;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // repoLookupSP
            // 
            this.repoLookupSP.Name = "repoLookupSP";
            // 
            // NhapHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.splitContainer);
            this.Name = "NhapHangForm";
            this.Text = "Nhập hàng";
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
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
