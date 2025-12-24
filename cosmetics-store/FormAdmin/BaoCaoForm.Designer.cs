namespace cosmetics_store.Forms
{
    partial class BaoCaoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private DevExpress.XtraEditors.LabelControl lblTuNgay;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.LabelControl lblDenNgay;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.SimpleButton btnXemBaoCao;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabDoanhThu;
        private System.Windows.Forms.TabPage tabSPBanChay;
        private System.Windows.Forms.TabPage tabTopKH;
        private System.Windows.Forms.TabPage tabTonKho;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartDoanhThu;
        private DevExpress.XtraGrid.GridControl gridSPBanChay;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSPBanChay;
        private DevExpress.XtraGrid.GridControl gridTopKH;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTopKH;
        private DevExpress.XtraGrid.GridControl gridTonKhoThap;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTonKhoThap;
        private DevExpress.XtraEditors.LabelControl lblTongDoanhThu;
        private DevExpress.XtraEditors.LabelControl lblSoDon;
        private DevExpress.XtraEditors.LabelControl lblSoSPBan;
        private DevExpress.XtraEditors.LabelControl lblTonKhoThap;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTuNgay = new DevExpress.XtraEditors.LabelControl();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblDenNgay = new DevExpress.XtraEditors.LabelControl();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.btnXemBaoCao = new DevExpress.XtraEditors.SimpleButton();
            this.lblTongDoanhThu = new DevExpress.XtraEditors.LabelControl();
            this.lblSoDon = new DevExpress.XtraEditors.LabelControl();
            this.lblSoSPBan = new DevExpress.XtraEditors.LabelControl();
            this.lblTonKhoThap = new DevExpress.XtraEditors.LabelControl();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabDoanhThu = new System.Windows.Forms.TabPage();
            this.chartDoanhThu = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabSPBanChay = new System.Windows.Forms.TabPage();
            this.gridSPBanChay = new DevExpress.XtraGrid.GridControl();
            this.gridViewSPBanChay = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabTopKH = new System.Windows.Forms.TabPage();
            this.gridTopKH = new DevExpress.XtraGrid.GridControl();
            this.gridViewTopKH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabTonKho = new System.Windows.Forms.TabPage();
            this.gridTonKhoThap = new DevExpress.XtraGrid.GridControl();
            this.gridViewTonKhoThap = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabDoanhThu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).BeginInit();
            this.tabSPBanChay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridSPBanChay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSPBanChay)).BeginInit();
            this.tabTopKH.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTopKH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTopKH)).BeginInit();
            this.tabTonKho.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridTonKhoThap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTonKhoThap)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(110)))));
            this.pnlTop.Controls.Add(this.lblTuNgay);
            this.pnlTop.Controls.Add(this.dateFrom);
            this.pnlTop.Controls.Add(this.lblDenNgay);
            this.pnlTop.Controls.Add(this.dateTo);
            this.pnlTop.Controls.Add(this.btnXemBaoCao);
            this.pnlTop.Controls.Add(this.lblTongDoanhThu);
            this.pnlTop.Controls.Add(this.lblSoDon);
            this.pnlTop.Controls.Add(this.lblSoSPBan);
            this.pnlTop.Controls.Add(this.lblTonKhoThap);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 100);
            this.pnlTop.TabIndex = 1;
            this.pnlTop.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlTop_Paint);
            // 
            // lblTuNgay
            // 
            this.lblTuNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTuNgay.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTuNgay.Appearance.Options.UseFont = true;
            this.lblTuNgay.Appearance.Options.UseForeColor = true;
            this.lblTuNgay.Location = new System.Drawing.Point(12, 20);
            this.lblTuNgay.Name = "lblTuNgay";
            this.lblTuNgay.Size = new System.Drawing.Size(65, 23);
            this.lblTuNgay.TabIndex = 0;
            this.lblTuNgay.Text = "Từ ngày:";
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = new System.DateTime(2025, 12, 10, 0, 0, 0, 0);
            this.dateFrom.Location = new System.Drawing.Point(85, 17);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(110)))));
            this.dateFrom.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateFrom.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.dateFrom.Properties.Appearance.Options.UseBackColor = true;
            this.dateFrom.Properties.Appearance.Options.UseFont = true;
            this.dateFrom.Properties.Appearance.Options.UseForeColor = true;
            this.dateFrom.Size = new System.Drawing.Size(130, 30);
            this.dateFrom.TabIndex = 1;
            // 
            // lblDenNgay
            // 
            this.lblDenNgay.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDenNgay.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblDenNgay.Appearance.Options.UseFont = true;
            this.lblDenNgay.Appearance.Options.UseForeColor = true;
            this.lblDenNgay.Location = new System.Drawing.Point(230, 20);
            this.lblDenNgay.Name = "lblDenNgay";
            this.lblDenNgay.Size = new System.Drawing.Size(77, 23);
            this.lblDenNgay.TabIndex = 2;
            this.lblDenNgay.Text = "Đến ngày:";
            // 
            // dateTo
            // 
            this.dateTo.EditValue = new System.DateTime(2025, 12, 10, 0, 0, 0, 0);
            this.dateTo.Location = new System.Drawing.Point(315, 17);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(110)))));
            this.dateTo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTo.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.dateTo.Properties.Appearance.Options.UseBackColor = true;
            this.dateTo.Properties.Appearance.Options.UseFont = true;
            this.dateTo.Properties.Appearance.Options.UseForeColor = true;
            this.dateTo.Size = new System.Drawing.Size(130, 30);
            this.dateTo.TabIndex = 3;
            // 
            // btnXemBaoCao
            // 
            this.btnXemBaoCao.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnXemBaoCao.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXemBaoCao.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnXemBaoCao.Appearance.Options.UseBackColor = true;
            this.btnXemBaoCao.Appearance.Options.UseFont = true;
            this.btnXemBaoCao.Appearance.Options.UseForeColor = true;
            this.btnXemBaoCao.Location = new System.Drawing.Point(460, 12);
            this.btnXemBaoCao.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnXemBaoCao.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnXemBaoCao.Name = "btnXemBaoCao";
            this.btnXemBaoCao.Size = new System.Drawing.Size(140, 36);
            this.btnXemBaoCao.TabIndex = 4;
            this.btnXemBaoCao.Text = "📈 Xem báo cáo";
            this.btnXemBaoCao.Click += new System.EventHandler(this.btnXemBaoCao_Click);
            // 
            // lblTongDoanhThu
            // 
            this.lblTongDoanhThu.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTongDoanhThu.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.lblTongDoanhThu.Appearance.Options.UseFont = true;
            this.lblTongDoanhThu.Appearance.Options.UseForeColor = true;
            this.lblTongDoanhThu.Location = new System.Drawing.Point(12, 60);
            this.lblTongDoanhThu.Name = "lblTongDoanhThu";
            this.lblTongDoanhThu.Size = new System.Drawing.Size(160, 25);
            this.lblTongDoanhThu.TabIndex = 5;
            this.lblTongDoanhThu.Text = "Tổng doanh thu: ";
            // 
            // lblSoDon
            // 
            this.lblSoDon.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoDon.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.lblSoDon.Appearance.Options.UseFont = true;
            this.lblSoDon.Appearance.Options.UseForeColor = true;
            this.lblSoDon.Location = new System.Drawing.Point(350, 63);
            this.lblSoDon.Name = "lblSoDon";
            this.lblSoDon.Size = new System.Drawing.Size(108, 23);
            this.lblSoDon.TabIndex = 6;
            this.lblSoDon.Text = "Số đơn hàng: ";
            // 
            // lblSoSPBan
            // 
            this.lblSoSPBan.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoSPBan.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(150)))));
            this.lblSoSPBan.Appearance.Options.UseFont = true;
            this.lblSoSPBan.Appearance.Options.UseForeColor = true;
            this.lblSoSPBan.Location = new System.Drawing.Point(580, 63);
            this.lblSoSPBan.Name = "lblSoSPBan";
            this.lblSoSPBan.Size = new System.Drawing.Size(112, 23);
            this.lblSoSPBan.TabIndex = 7;
            this.lblSoSPBan.Text = "Số SP đã bán: ";
            // 
            // lblTonKhoThap
            // 
            this.lblTonKhoThap.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTonKhoThap.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.lblTonKhoThap.Appearance.Options.UseFont = true;
            this.lblTonKhoThap.Appearance.Options.UseForeColor = true;
            this.lblTonKhoThap.Location = new System.Drawing.Point(820, 63);
            this.lblTonKhoThap.Name = "lblTonKhoThap";
            this.lblTonKhoThap.Size = new System.Drawing.Size(135, 23);
            this.lblTonKhoThap.TabIndex = 8;
            this.lblTonKhoThap.Text = "SP tồn kho thấp: ";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabDoanhThu);
            this.tabControl.Controls.Add(this.tabSPBanChay);
            this.tabControl.Controls.Add(this.tabTopKH);
            this.tabControl.Controls.Add(this.tabTonKho);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.tabControl.Location = new System.Drawing.Point(0, 100);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 500);
            this.tabControl.TabIndex = 0;
            // 
            // tabDoanhThu
            // 
            this.tabDoanhThu.Controls.Add(this.chartDoanhThu);
            this.tabDoanhThu.Location = new System.Drawing.Point(4, 25);
            this.tabDoanhThu.Name = "tabDoanhThu";
            this.tabDoanhThu.Size = new System.Drawing.Size(1092, 491);
            this.tabDoanhThu.TabIndex = 0;
            this.tabDoanhThu.Text = "📊 Doanh thu";
            // 
            // chartDoanhThu
            // 
            chartArea1.Name = "ChartArea1";
            this.chartDoanhThu.ChartAreas.Add(chartArea1);
            this.chartDoanhThu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartDoanhThu.Location = new System.Drawing.Point(0, 0);
            this.chartDoanhThu.Name = "chartDoanhThu";
            this.chartDoanhThu.Size = new System.Drawing.Size(1092, 491);
            this.chartDoanhThu.TabIndex = 0;
            this.chartDoanhThu.Click += new System.EventHandler(this.chartDoanhThu_Click);
            // 
            // tabSPBanChay
            // 
            this.tabSPBanChay.Controls.Add(this.gridSPBanChay);
            this.tabSPBanChay.Location = new System.Drawing.Point(4, 25);
            this.tabSPBanChay.Name = "tabSPBanChay";
            this.tabSPBanChay.Size = new System.Drawing.Size(1092, 491);
            this.tabSPBanChay.TabIndex = 1;
            this.tabSPBanChay.Text = "🔥 SP bán chạy";
            // 
            // gridSPBanChay
            // 
            this.gridSPBanChay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridSPBanChay.Location = new System.Drawing.Point(0, 0);
            this.gridSPBanChay.MainView = this.gridViewSPBanChay;
            this.gridSPBanChay.Name = "gridSPBanChay";
            this.gridSPBanChay.Size = new System.Drawing.Size(1092, 491);
            this.gridSPBanChay.TabIndex = 0;
            this.gridSPBanChay.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSPBanChay});
            // 
            // gridViewSPBanChay
            // 
            this.gridViewSPBanChay.GridControl = this.gridSPBanChay;
            this.gridViewSPBanChay.Name = "gridViewSPBanChay";
            this.gridViewSPBanChay.OptionsView.ShowGroupPanel = false;
            // 
            // tabTopKH
            // 
            this.tabTopKH.Controls.Add(this.gridTopKH);
            this.tabTopKH.Location = new System.Drawing.Point(4, 25);
            this.tabTopKH.Name = "tabTopKH";
            this.tabTopKH.Size = new System.Drawing.Size(1092, 491);
            this.tabTopKH.TabIndex = 2;
            this.tabTopKH.Text = "🏆 Top khách hàng";
            // 
            // gridTopKH
            // 
            this.gridTopKH.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTopKH.Location = new System.Drawing.Point(0, 0);
            this.gridTopKH.MainView = this.gridViewTopKH;
            this.gridTopKH.Name = "gridTopKH";
            this.gridTopKH.Size = new System.Drawing.Size(1092, 491);
            this.gridTopKH.TabIndex = 0;
            this.gridTopKH.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTopKH});
            // 
            // gridViewTopKH
            // 
            this.gridViewTopKH.GridControl = this.gridTopKH;
            this.gridViewTopKH.Name = "gridViewTopKH";
            this.gridViewTopKH.OptionsView.ShowGroupPanel = false;
            // 
            // tabTonKho
            // 
            this.tabTonKho.Controls.Add(this.gridTonKhoThap);
            this.tabTonKho.Location = new System.Drawing.Point(4, 25);
            this.tabTonKho.Name = "tabTonKho";
            this.tabTonKho.Size = new System.Drawing.Size(1092, 491);
            this.tabTonKho.TabIndex = 3;
            this.tabTonKho.Text = "⚠️ Tồn kho thấp";
            // 
            // gridTonKhoThap
            // 
            this.gridTonKhoThap.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridTonKhoThap.Location = new System.Drawing.Point(0, 0);
            this.gridTonKhoThap.MainView = this.gridViewTonKhoThap;
            this.gridTonKhoThap.Name = "gridTonKhoThap";
            this.gridTonKhoThap.Size = new System.Drawing.Size(1092, 491);
            this.gridTonKhoThap.TabIndex = 0;
            this.gridTonKhoThap.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTonKhoThap});
            // 
            // gridViewTonKhoThap
            // 
            this.gridViewTonKhoThap.GridControl = this.gridTonKhoThap;
            this.gridViewTonKhoThap.Name = "gridViewTonKhoThap";
            this.gridViewTonKhoThap.OptionsView.ShowGroupPanel = false;
            // 
            // BaoCaoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(70)))));
            this.ClientSize = new System.Drawing.Size(1200, 600);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.pnlTop);
            this.Name = "BaoCaoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📈 Báo cáo thống kê";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabDoanhThu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartDoanhThu)).EndInit();
            this.tabSPBanChay.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridSPBanChay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSPBanChay)).EndInit();
            this.tabTopKH.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTopKH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTopKH)).EndInit();
            this.tabTonKho.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridTonKhoThap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTonKhoThap)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
