namespace cosmetics_store.Forms
{
    partial class TonKhoForm
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private System.Windows.Forms.Panel pnlStats;
        private DevExpress.XtraEditors.LabelControl lblTotalProducts;
        private DevExpress.XtraEditors.LabelControl lblTotalStock;
        private DevExpress.XtraEditors.LabelControl lblTotalValue;
        private DevExpress.XtraEditors.LabelControl lblLowStock;
        private DevExpress.XtraEditors.LabelControl lblOutOfStock;
        private System.Windows.Forms.Panel pnlFilter;
        private DevExpress.XtraEditors.SearchControl searchControl;
        private DevExpress.XtraEditors.LookUpEdit cboLoai;
        private DevExpress.XtraEditors.ComboBoxEdit cboTrangThai;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlFilter = new System.Windows.Forms.Panel();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.cboLoai = new DevExpress.XtraEditors.LookUpEdit();
            this.cboTrangThai = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.lblTotalProducts = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalStock = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalValue = new DevExpress.XtraEditors.LabelControl();
            this.lblLowStock = new DevExpress.XtraEditors.LabelControl();
            this.lblOutOfStock = new DevExpress.XtraEditors.LabelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pnlFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTrangThai.Properties)).BeginInit();
            this.pnlStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.grid);
            this.pnlMain.Controls.Add(this.pnlFilter);
            this.pnlMain.Controls.Add(this.pnlStats);
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 600);
            this.pnlMain.TabIndex = 0;
            // 
            // grid
            // 
            this.grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grid.Location = new System.Drawing.Point(20, 170);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(860, 420);
            this.grid.TabIndex = 3;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            // 
            // gridView
            // 
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // pnlFilter
            // 
            this.pnlFilter.BackColor = System.Drawing.Color.White;
            this.pnlFilter.Controls.Add(this.searchControl);
            this.pnlFilter.Controls.Add(this.cboLoai);
            this.pnlFilter.Controls.Add(this.cboTrangThai);
            this.pnlFilter.Controls.Add(this.btnRefresh);
            this.pnlFilter.Controls.Add(this.btnExport);
            this.pnlFilter.Location = new System.Drawing.Point(20, 115);
            this.pnlFilter.Name = "pnlFilter";
            this.pnlFilter.Size = new System.Drawing.Size(860, 45);
            this.pnlFilter.TabIndex = 2;
            // 
            // searchControl
            // 
            this.searchControl.Location = new System.Drawing.Point(5, 10);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchControl.Properties.Appearance.Options.UseFont = true;
            this.searchControl.Properties.NullValuePrompt = "Tìm theo tên, mã sản phẩm...";
            this.searchControl.Properties.ShowClearButton = false;
            this.searchControl.Properties.ShowSearchButton = false;
            this.searchControl.Size = new System.Drawing.Size(250, 30);
            this.searchControl.TabIndex = 0;
            this.searchControl.EditValueChanged += new System.EventHandler(this.searchControl_TextChanged);
            // 
            // cboLoai
            // 
            this.cboLoai.Location = new System.Drawing.Point(270, 10);
            this.cboLoai.Name = "cboLoai";
            this.cboLoai.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboLoai.Properties.Appearance.Options.UseFont = true;
            this.cboLoai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboLoai.Size = new System.Drawing.Size(180, 30);
            this.cboLoai.TabIndex = 1;
            this.cboLoai.EditValueChanged += new System.EventHandler(this.cboLoai_EditValueChanged);
            // 
            // cboTrangThai
            // 
            this.cboTrangThai.EditValue = "Tất cả";
            this.cboTrangThai.Location = new System.Drawing.Point(465, 10);
            this.cboTrangThai.Name = "cboTrangThai";
            this.cboTrangThai.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboTrangThai.Properties.Appearance.Options.UseFont = true;
            this.cboTrangThai.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboTrangThai.Properties.Items.AddRange(new object[] {
            "Tất cả",
            "Còn hàng",
            "Sắp hết",
            "Hết hàng"});
            this.cboTrangThai.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboTrangThai.Size = new System.Drawing.Size(120, 30);
            this.cboTrangThai.TabIndex = 2;
            this.cboTrangThai.EditValueChanged += new System.EventHandler(this.cboTrangThai_EditValueChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Location = new System.Drawing.Point(591, 8);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(123, 30);
            this.btnRefresh.TabIndex = 3;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Location = new System.Drawing.Point(720, 8);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(130, 30);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "📄 Xuất Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pnlStats
            // 
            this.pnlStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(250)))));
            this.pnlStats.Controls.Add(this.lblTotalProducts);
            this.pnlStats.Controls.Add(this.lblTotalStock);
            this.pnlStats.Controls.Add(this.lblTotalValue);
            this.pnlStats.Controls.Add(this.lblLowStock);
            this.pnlStats.Controls.Add(this.lblOutOfStock);
            this.pnlStats.Location = new System.Drawing.Point(20, 55);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(860, 50);
            this.pnlStats.TabIndex = 1;
            // 
            // lblTotalProducts
            // 
            this.lblTotalProducts.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalProducts.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblTotalProducts.Appearance.Options.UseFont = true;
            this.lblTotalProducts.Appearance.Options.UseForeColor = true;
            this.lblTotalProducts.Location = new System.Drawing.Point(15, 15);
            this.lblTotalProducts.Name = "lblTotalProducts";
            this.lblTotalProducts.Size = new System.Drawing.Size(143, 23);
            this.lblTotalProducts.TabIndex = 0;
            this.lblTotalProducts.Text = "Tổng sản phẩm: 0";
            // 
            // lblTotalStock
            // 
            this.lblTotalStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalStock.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.lblTotalStock.Appearance.Options.UseFont = true;
            this.lblTotalStock.Appearance.Options.UseForeColor = true;
            this.lblTotalStock.Location = new System.Drawing.Point(180, 15);
            this.lblTotalStock.Name = "lblTotalStock";
            this.lblTotalStock.Size = new System.Drawing.Size(128, 23);
            this.lblTotalStock.TabIndex = 1;
            this.lblTotalStock.Text = "Tổng tồn kho: 0";
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.lblTotalValue.Appearance.Options.UseFont = true;
            this.lblTotalValue.Appearance.Options.UseForeColor = true;
            this.lblTotalValue.Location = new System.Drawing.Point(350, 15);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(131, 23);
            this.lblTotalValue.TabIndex = 2;
            this.lblTotalValue.Text = "Tổng giá trị: 0 đ";
            // 
            // lblLowStock
            // 
            this.lblLowStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblLowStock.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            this.lblLowStock.Appearance.Options.UseFont = true;
            this.lblLowStock.Appearance.Options.UseForeColor = true;
            this.lblLowStock.Location = new System.Drawing.Point(544, 15);
            this.lblLowStock.Name = "lblLowStock";
            this.lblLowStock.Size = new System.Drawing.Size(100, 23);
            this.lblLowStock.TabIndex = 3;
            this.lblLowStock.Text = "Sản phẩm: 0";
            // 
            // lblOutOfStock
            // 
            this.lblOutOfStock.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblOutOfStock.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblOutOfStock.Appearance.Options.UseFont = true;
            this.lblOutOfStock.Appearance.Options.UseForeColor = true;
            this.lblOutOfStock.Location = new System.Drawing.Point(710, 15);
            this.lblOutOfStock.Name = "lblOutOfStock";
            this.lblOutOfStock.Size = new System.Drawing.Size(94, 23);
            this.lblOutOfStock.TabIndex = 4;
            this.lblOutOfStock.Text = "Hết hàng: 0";
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 41);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Quản Lý Tồn Kho";
            // 
            // TonKhoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TonKhoForm";
            this.Text = "Quản lý tồn kho";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pnlFilter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboLoai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboTrangThai.Properties)).EndInit();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
