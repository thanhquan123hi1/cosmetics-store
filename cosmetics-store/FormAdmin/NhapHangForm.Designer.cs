namespace cosmetics_store.Forms
{
    partial class NhapHangForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.Panel pnlInputForm;
        private System.Windows.Forms.Panel pnlChiTietMoi;
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
        private DevExpress.XtraEditors.LabelControl lblTitleChiTiet;
        private DevExpress.XtraEditors.LabelControl lblTongTien;
        private DevExpress.XtraGrid.GridControl gridChiTietMoi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewChiTietMoi;
        private DevExpress.XtraGrid.GridControl gridMaster;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMaster;
        private DevExpress.XtraGrid.GridControl gridDetail;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDetail;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repoLookupSP;
        private DevExpress.XtraEditors.LabelControl lblTitleLichSu;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pnlInputForm = new System.Windows.Forms.Panel();
            this.pnlChiTietMoi = new System.Windows.Forms.Panel();
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
            this.lblTitleChiTiet = new DevExpress.XtraEditors.LabelControl();
            this.lblTongTien = new DevExpress.XtraEditors.LabelControl();
            this.gridChiTietMoi = new DevExpress.XtraGrid.GridControl();
            this.gridViewChiTietMoi = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridMaster = new DevExpress.XtraGrid.GridControl();
            this.gridViewMaster = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridDetail = new DevExpress.XtraGrid.GridControl();
            this.gridViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repoLookupSP = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.lblTitleLichSu = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlInputForm.SuspendLayout();
            this.pnlChiTietMoi.SuspendLayout();
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
            this.splitContainer.Size = new System.Drawing.Size(1100, 700);
            this.splitContainer.SplitterDistance = 500;
            this.splitContainer.SplitterWidth = 6;
            this.splitContainer.TabIndex = 0;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.pnlLeft);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.gridDetail);
            this.splitContainer.Panel2.Controls.Add(this.gridMaster);
            this.splitContainer.Panel2.Controls.Add(this.lblTitleLichSu);
            // 
            // pnlLeft
            // 
            this.pnlLeft.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Controls.Add(this.pnlChiTietMoi);
            this.pnlLeft.Controls.Add(this.pnlInputForm);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(0, 0);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(500, 700);
            this.pnlLeft.TabIndex = 0;
            // 
            // pnlInputForm
            // 
            this.pnlInputForm.Controls.Add(this.lblNCC);
            this.pnlInputForm.Controls.Add(this.lookupNCC);
            this.pnlInputForm.Controls.Add(this.lblNgayNhap);
            this.pnlInputForm.Controls.Add(this.dateNgayNhap);
            this.pnlInputForm.Controls.Add(this.lblSPMoi);
            this.pnlInputForm.Controls.Add(this.lookupSPMoi);
            this.pnlInputForm.Controls.Add(this.lblSoLuong);
            this.pnlInputForm.Controls.Add(this.spinSoLuong);
            this.pnlInputForm.Controls.Add(this.lblDonGia);
            this.pnlInputForm.Controls.Add(this.spinDonGia);
            this.pnlInputForm.Controls.Add(this.lblHanSD);
            this.pnlInputForm.Controls.Add(this.dateHanSD);
            this.pnlInputForm.Controls.Add(this.btnThemSP);
            this.pnlInputForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlInputForm.Location = new System.Drawing.Point(0, 0);
            this.pnlInputForm.Name = "pnlInputForm";
            this.pnlInputForm.Padding = new System.Windows.Forms.Padding(15);
            this.pnlInputForm.Size = new System.Drawing.Size(500, 200);
            this.pnlInputForm.TabIndex = 0;
            // 
            // lblNCC
            // 
            this.lblNCC.Location = new System.Drawing.Point(20, 20);
            this.lblNCC.Name = "lblNCC";
            this.lblNCC.Size = new System.Drawing.Size(84, 16);
            this.lblNCC.TabIndex = 0;
            this.lblNCC.Text = "Nhà cung cấp:";
            // 
            // lookupNCC
            // 
            this.lookupNCC.Location = new System.Drawing.Point(120, 17);
            this.lookupNCC.Name = "lookupNCC";
            this.lookupNCC.Size = new System.Drawing.Size(200, 22);
            this.lookupNCC.TabIndex = 1;
            // 
            // lblNgayNhap
            // 
            this.lblNgayNhap.Location = new System.Drawing.Point(340, 20);
            this.lblNgayNhap.Name = "lblNgayNhap";
            this.lblNgayNhap.Size = new System.Drawing.Size(66, 16);
            this.lblNgayNhap.TabIndex = 2;
            this.lblNgayNhap.Text = "Ngày nhập:";
            // 
            // dateNgayNhap
            // 
            this.dateNgayNhap.EditValue = null;
            this.dateNgayNhap.Location = new System.Drawing.Point(410, 17);
            this.dateNgayNhap.Name = "dateNgayNhap";
            this.dateNgayNhap.Size = new System.Drawing.Size(70, 22);
            this.dateNgayNhap.TabIndex = 3;
            // 
            // lblSPMoi
            // 
            this.lblSPMoi.Location = new System.Drawing.Point(20, 55);
            this.lblSPMoi.Name = "lblSPMoi";
            this.lblSPMoi.Size = new System.Drawing.Size(59, 16);
            this.lblSPMoi.TabIndex = 4;
            this.lblSPMoi.Text = "Sản phẩm:";
            // 
            // lookupSPMoi
            // 
            this.lookupSPMoi.Location = new System.Drawing.Point(120, 52);
            this.lookupSPMoi.Name = "lookupSPMoi";
            this.lookupSPMoi.Size = new System.Drawing.Size(200, 22);
            this.lookupSPMoi.TabIndex = 5;
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.Location = new System.Drawing.Point(340, 55);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(52, 16);
            this.lblSoLuong.TabIndex = 6;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // spinSoLuong
            // 
            this.spinSoLuong.EditValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinSoLuong.Location = new System.Drawing.Point(410, 52);
            this.spinSoLuong.Name = "spinSoLuong";
            this.spinSoLuong.Properties.IsFloatValue = false;
            this.spinSoLuong.Properties.MinValue = new decimal(new int[] { 1, 0, 0, 0 });
            this.spinSoLuong.Size = new System.Drawing.Size(70, 22);
            this.spinSoLuong.TabIndex = 7;
            // 
            // lblDonGia
            // 
            this.lblDonGia.Location = new System.Drawing.Point(20, 90);
            this.lblDonGia.Name = "lblDonGia";
            this.lblDonGia.Size = new System.Drawing.Size(45, 16);
            this.lblDonGia.TabIndex = 8;
            this.lblDonGia.Text = "Đơn giá:";
            // 
            // spinDonGia
            // 
            this.spinDonGia.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            this.spinDonGia.Location = new System.Drawing.Point(120, 87);
            this.spinDonGia.Name = "spinDonGia";
            this.spinDonGia.Properties.IsFloatValue = false;
            this.spinDonGia.Size = new System.Drawing.Size(100, 22);
            this.spinDonGia.TabIndex = 9;
            // 
            // lblHanSD
            // 
            this.lblHanSD.Location = new System.Drawing.Point(240, 90);
            this.lblHanSD.Name = "lblHanSD";
            this.lblHanSD.Size = new System.Drawing.Size(79, 16);
            this.lblHanSD.TabIndex = 10;
            this.lblHanSD.Text = "Hạn sử dụng:";
            // 
            // dateHanSD
            // 
            this.dateHanSD.EditValue = null;
            this.dateHanSD.Location = new System.Drawing.Point(330, 87);
            this.dateHanSD.Name = "dateHanSD";
            this.dateHanSD.Size = new System.Drawing.Size(100, 22);
            this.dateHanSD.TabIndex = 11;
            // 
            // btnThemSP
            // 
            this.btnThemSP.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnThemSP.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThemSP.Appearance.Options.UseBackColor = true;
            this.btnThemSP.Appearance.Options.UseForeColor = true;
            this.btnThemSP.Location = new System.Drawing.Point(20, 125);
            this.btnThemSP.Name = "btnThemSP";
            this.btnThemSP.Size = new System.Drawing.Size(120, 30);
            this.btnThemSP.TabIndex = 12;
            this.btnThemSP.Text = "Thêm SP";
            this.btnThemSP.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // pnlChiTietMoi
            // 
            this.pnlChiTietMoi.Controls.Add(this.lblTitleChiTiet);
            this.pnlChiTietMoi.Controls.Add(this.gridChiTietMoi);
            this.pnlChiTietMoi.Controls.Add(this.lblTongTien);
            this.pnlChiTietMoi.Controls.Add(this.btnXoaSP);
            this.pnlChiTietMoi.Controls.Add(this.btnTaoPhieu);
            this.pnlChiTietMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChiTietMoi.Location = new System.Drawing.Point(0, 200);
            this.pnlChiTietMoi.Name = "pnlChiTietMoi";
            this.pnlChiTietMoi.Padding = new System.Windows.Forms.Padding(15);
            this.pnlChiTietMoi.Size = new System.Drawing.Size(500, 500);
            this.pnlChiTietMoi.TabIndex = 1;
            // 
            // lblTitleChiTiet
            // 
            this.lblTitleChiTiet.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTitleChiTiet.Appearance.Options.UseFont = true;
            this.lblTitleChiTiet.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleChiTiet.Location = new System.Drawing.Point(15, 15);
            this.lblTitleChiTiet.Name = "lblTitleChiTiet";
            this.lblTitleChiTiet.Size = new System.Drawing.Size(166, 25);
            this.lblTitleChiTiet.TabIndex = 0;
            this.lblTitleChiTiet.Text = "Chi tiết phiếu nhập mới";
            // 
            // gridChiTietMoi
            // 
            this.gridChiTietMoi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridChiTietMoi.Location = new System.Drawing.Point(15, 40);
            this.gridChiTietMoi.MainView = this.gridViewChiTietMoi;
            this.gridChiTietMoi.Name = "gridChiTietMoi";
            this.gridChiTietMoi.Size = new System.Drawing.Size(470, 350);
            this.gridChiTietMoi.TabIndex = 1;
            this.gridChiTietMoi.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewChiTietMoi });
            // 
            // gridViewChiTietMoi
            // 
            this.gridViewChiTietMoi.GridControl = this.gridChiTietMoi;
            this.gridViewChiTietMoi.Name = "gridViewChiTietMoi";
            this.gridViewChiTietMoi.OptionsBehavior.Editable = false;
            this.gridViewChiTietMoi.OptionsView.ShowGroupPanel = false;
            // 
            // lblTongTien
            // 
            this.lblTongTien.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTongTien.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTongTien.Appearance.Options.UseFont = true;
            this.lblTongTien.Appearance.Options.UseForeColor = true;
            this.lblTongTien.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblTongTien.Location = new System.Drawing.Point(15, 400);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(126, 27);
            this.lblTongTien.TabIndex = 2;
            this.lblTongTien.Text = "Tổng tiền: 0 đ";
            // 
            // btnXoaSP
            // 
            this.btnXoaSP.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.btnXoaSP.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnXoaSP.Appearance.Options.UseBackColor = true;
            this.btnXoaSP.Appearance.Options.UseForeColor = true;
            this.btnXoaSP.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnXoaSP.Location = new System.Drawing.Point(15, 430);
            this.btnXoaSP.Name = "btnXoaSP";
            this.btnXoaSP.Size = new System.Drawing.Size(470, 30);
            this.btnXoaSP.TabIndex = 3;
            this.btnXoaSP.Text = "Xóa SP đã chọn";
            this.btnXoaSP.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnTaoPhieu
            // 
            this.btnTaoPhieu.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(174)))), ((int)(((byte)(96)))));
            this.btnTaoPhieu.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnTaoPhieu.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTaoPhieu.Appearance.Options.UseBackColor = true;
            this.btnTaoPhieu.Appearance.Options.UseFont = true;
            this.btnTaoPhieu.Appearance.Options.UseForeColor = true;
            this.btnTaoPhieu.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnTaoPhieu.Location = new System.Drawing.Point(15, 460);
            this.btnTaoPhieu.Name = "btnTaoPhieu";
            this.btnTaoPhieu.Size = new System.Drawing.Size(470, 40);
            this.btnTaoPhieu.TabIndex = 4;
            this.btnTaoPhieu.Text = "TẠO PHIẾU NHẬP";
            this.btnTaoPhieu.Click += new System.EventHandler(this.btnTaoPhieu_Click);
            // 
            // lblTitleLichSu
            // 
            this.lblTitleLichSu.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitleLichSu.Appearance.Options.UseFont = true;
            this.lblTitleLichSu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitleLichSu.Location = new System.Drawing.Point(0, 0);
            this.lblTitleLichSu.Name = "lblTitleLichSu";
            this.lblTitleLichSu.Padding = new System.Windows.Forms.Padding(10, 10, 0, 10);
            this.lblTitleLichSu.Size = new System.Drawing.Size(173, 47);
            this.lblTitleLichSu.TabIndex = 0;
            this.lblTitleLichSu.Text = "LỊCH SỬ PHIẾU NHẬP";
            // 
            // gridMaster
            // 
            this.gridMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridMaster.Location = new System.Drawing.Point(0, 47);
            this.gridMaster.MainView = this.gridViewMaster;
            this.gridMaster.Name = "gridMaster";
            this.gridMaster.Size = new System.Drawing.Size(594, 250);
            this.gridMaster.TabIndex = 1;
            this.gridMaster.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewMaster });
            // 
            // gridViewMaster
            // 
            this.gridViewMaster.GridControl = this.gridMaster;
            this.gridViewMaster.Name = "gridViewMaster";
            this.gridViewMaster.OptionsBehavior.Editable = false;
            this.gridViewMaster.OptionsView.ShowGroupPanel = false;
            // 
            // gridDetail
            // 
            this.gridDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridDetail.Location = new System.Drawing.Point(0, 297);
            this.gridDetail.MainView = this.gridViewDetail;
            this.gridDetail.Name = "gridDetail";
            this.gridDetail.Size = new System.Drawing.Size(594, 403);
            this.gridDetail.TabIndex = 2;
            this.gridDetail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { this.gridViewDetail });
            // 
            // gridViewDetail
            // 
            this.gridViewDetail.GridControl = this.gridDetail;
            this.gridViewDetail.Name = "gridViewDetail";
            this.gridViewDetail.OptionsBehavior.Editable = false;
            this.gridViewDetail.OptionsView.ShowGroupPanel = false;
            // 
            // NhapHangForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 700);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.Name = "NhapHangForm";
            this.Text = "Nhập hàng";
            this.Load += new System.EventHandler(this.NhapHangForm_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.pnlLeft.ResumeLayout(false);
            this.pnlInputForm.ResumeLayout(false);
            this.pnlInputForm.PerformLayout();
            this.pnlChiTietMoi.ResumeLayout(false);
            this.pnlChiTietMoi.PerformLayout();
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
