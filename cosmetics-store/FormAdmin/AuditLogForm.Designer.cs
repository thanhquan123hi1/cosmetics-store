namespace cosmetics_store.Forms
{
    partial class AuditLogForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private DevExpress.XtraEditors.LabelControl lblFrom;
        private DevExpress.XtraEditors.DateEdit dateFrom;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.DateEdit dateTo;
        private DevExpress.XtraEditors.LabelControl lblHanhDong;
        private DevExpress.XtraEditors.ComboBoxEdit cboHanhDong;
        private DevExpress.XtraEditors.SearchControl searchControl;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.SimpleButton btnRefresh;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;
        private System.Windows.Forms.Panel pnlBottom;
        private DevExpress.XtraEditors.LabelControl lblTotalRecords;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblFrom = new DevExpress.XtraEditors.LabelControl();
            this.dateFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.dateTo = new DevExpress.XtraEditors.DateEdit();
            this.lblHanhDong = new DevExpress.XtraEditors.LabelControl();
            this.cboHanhDong = new DevExpress.XtraEditors.ComboBoxEdit();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.lblTotalRecords = new DevExpress.XtraEditors.LabelControl();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHanhDong.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(110)))));
            this.pnlTop.Controls.Add(this.lblFrom);
            this.pnlTop.Controls.Add(this.dateFrom);
            this.pnlTop.Controls.Add(this.lblTo);
            this.pnlTop.Controls.Add(this.dateTo);
            this.pnlTop.Controls.Add(this.lblHanhDong);
            this.pnlTop.Controls.Add(this.cboHanhDong);
            this.pnlTop.Controls.Add(this.searchControl);
            this.pnlTop.Controls.Add(this.btnSearch);
            this.pnlTop.Controls.Add(this.btnRefresh);
            this.pnlTop.Controls.Add(this.btnExport);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(1200, 60);
            this.pnlTop.TabIndex = 0;
            // 
            // lblFrom
            // 
            this.lblFrom.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFrom.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblFrom.Appearance.Options.UseFont = true;
            this.lblFrom.Appearance.Options.UseForeColor = true;
            this.lblFrom.Location = new System.Drawing.Point(7, 20);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(75, 23);
            this.lblFrom.TabIndex = 0;
            this.lblFrom.Text = "Từ ngày:";
            // 
            // dateFrom
            // 
            this.dateFrom.EditValue = null;
            this.dateFrom.Location = new System.Drawing.Point(78, 17);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(110)))));
            this.dateFrom.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateFrom.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.dateFrom.Properties.Appearance.Options.UseBackColor = true;
            this.dateFrom.Properties.Appearance.Options.UseFont = true;
            this.dateFrom.Properties.Appearance.Options.UseForeColor = true;
            this.dateFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateFrom.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateFrom.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateFrom.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateFrom.Size = new System.Drawing.Size(110, 30);
            this.dateFrom.TabIndex = 1;
            // 
            // lblTo
            // 
            this.lblTo.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblTo.Appearance.Options.UseFont = true;
            this.lblTo.Appearance.Options.UseForeColor = true;
            this.lblTo.Location = new System.Drawing.Point(200, 20);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(86, 23);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "Đến ngày:";
            // 
            // dateTo
            // 
            this.dateTo.EditValue = null;
            this.dateTo.Location = new System.Drawing.Point(278, 17);
            this.dateTo.Name = "dateTo";
            this.dateTo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(110)))));
            this.dateTo.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dateTo.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.dateTo.Properties.Appearance.Options.UseBackColor = true;
            this.dateTo.Properties.Appearance.Options.UseFont = true;
            this.dateTo.Properties.Appearance.Options.UseForeColor = true;
            this.dateTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateTo.Properties.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.EditFormat.FormatString = "dd/MM/yyyy";
            this.dateTo.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateTo.Properties.Mask.EditMask = "dd/MM/yyyy";
            this.dateTo.Size = new System.Drawing.Size(110, 30);
            this.dateTo.TabIndex = 3;
            // 
            // lblHanhDong
            // 
            this.lblHanhDong.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHanhDong.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblHanhDong.Appearance.Options.UseFont = true;
            this.lblHanhDong.Appearance.Options.UseForeColor = true;
            this.lblHanhDong.Location = new System.Drawing.Point(399, 20);
            this.lblHanhDong.Name = "lblHanhDong";
            this.lblHanhDong.Size = new System.Drawing.Size(99, 23);
            this.lblHanhDong.TabIndex = 4;
            this.lblHanhDong.Text = "Hành động:";
            // 
            // cboHanhDong
            // 
            this.cboHanhDong.Location = new System.Drawing.Point(495, 17);
            this.cboHanhDong.Name = "cboHanhDong";
            this.cboHanhDong.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(110)))));
            this.cboHanhDong.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboHanhDong.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.cboHanhDong.Properties.Appearance.Options.UseBackColor = true;
            this.cboHanhDong.Properties.Appearance.Options.UseFont = true;
            this.cboHanhDong.Properties.Appearance.Options.UseForeColor = true;
            this.cboHanhDong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cboHanhDong.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cboHanhDong.Size = new System.Drawing.Size(130, 30);
            this.cboHanhDong.TabIndex = 5;
            // 
            // searchControl
            // 
            this.searchControl.Location = new System.Drawing.Point(635, 17);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(70)))), ((int)(((byte)(110)))));
            this.searchControl.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.searchControl.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.searchControl.Properties.Appearance.Options.UseBackColor = true;
            this.searchControl.Properties.Appearance.Options.UseFont = true;
            this.searchControl.Properties.Appearance.Options.UseForeColor = true;
            this.searchControl.Properties.NullValuePrompt = "Tìm kiếm...";
            this.searchControl.Properties.ShowClearButton = false;
            this.searchControl.Properties.ShowSearchButton = false;
            this.searchControl.Size = new System.Drawing.Size(200, 30);
            this.searchControl.TabIndex = 6;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Appearance.Options.UseBackColor = true;
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.Location = new System.Drawing.Point(841, 12);
            this.btnSearch.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(115, 36);
            this.btnSearch.TabIndex = 7;
            this.btnSearch.Text = "🔍 Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(117)))), ((int)(((byte)(125)))));
            this.btnRefresh.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefresh.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnRefresh.Appearance.Options.UseBackColor = true;
            this.btnRefresh.Appearance.Options.UseFont = true;
            this.btnRefresh.Appearance.Options.UseForeColor = true;
            this.btnRefresh.Location = new System.Drawing.Point(971, 12);
            this.btnRefresh.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnRefresh.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(105, 36);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "🔄 Làm mới";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.btnExport.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExport.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExport.Appearance.Options.UseBackColor = true;
            this.btnExport.Appearance.Options.UseFont = true;
            this.btnExport.Appearance.Options.UseForeColor = true;
            this.btnExport.Location = new System.Drawing.Point(1082, 12);
            this.btnExport.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            this.btnExport.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(115, 36);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "📊 Xuất Excel";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 60);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(1200, 490);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.grid.Click += new System.EventHandler(this.grid_Click);
            // 
            // gridView
            // 
            this.gridView.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(55)))), ((int)(((byte)(100)))));
            this.gridView.Appearance.EvenRow.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gridView.Appearance.EvenRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridView.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView.Appearance.EvenRow.Options.UseFont = true;
            this.gridView.Appearance.EvenRow.Options.UseForeColor = true;
            this.gridView.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(120)))), ((int)(((byte)(215)))));
            this.gridView.Appearance.FocusedRow.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gridView.Appearance.FocusedRow.ForeColor = System.Drawing.Color.White;
            this.gridView.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView.Appearance.FocusedRow.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(230)))), ((int)(((byte)(245)))));
            this.gridView.Appearance.HeaderPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.gridView.Appearance.HeaderPanel.ForeColor = System.Drawing.Color.Black;
            this.gridView.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView.Appearance.HeaderPanel.Options.UseForeColor = true;
            this.gridView.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.gridView.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(50)))), ((int)(((byte)(95)))));
            this.gridView.Appearance.Row.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gridView.Appearance.Row.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.gridView.Appearance.Row.Options.UseBackColor = true;
            this.gridView.Appearance.Row.Options.UseFont = true;
            this.gridView.Appearance.Row.Options.UseForeColor = true;
            this.gridView.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(100)))), ((int)(((byte)(180)))));
            this.gridView.Appearance.SelectedRow.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.gridView.Appearance.SelectedRow.ForeColor = System.Drawing.Color.White;
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsBehavior.ReadOnly = true;
            this.gridView.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView.OptionsView.RowAutoHeight = true;
            this.gridView.OptionsView.ShowGroupPanel = false;
            this.gridView.RowHeight = 32;
            // 
            // pnlBottom
            // 
            this.pnlBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(60)))), ((int)(((byte)(110)))));
            this.pnlBottom.Controls.Add(this.lblTotalRecords);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 550);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(1200, 30);
            this.pnlBottom.TabIndex = 2;
            // 
            // lblTotalRecords
            // 
            this.lblTotalRecords.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalRecords.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(100)))));
            this.lblTotalRecords.Appearance.Options.UseFont = true;
            this.lblTotalRecords.Appearance.Options.UseForeColor = true;
            this.lblTotalRecords.Location = new System.Drawing.Point(12, 5);
            this.lblTotalRecords.Name = "lblTotalRecords";
            this.lblTotalRecords.Size = new System.Drawing.Size(165, 25);
            this.lblTotalRecords.TabIndex = 0;
            this.lblTotalRecords.Text = "Tổng số: 0 bản ghi";
            // 
            // AuditLogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 580);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.Name = "AuditLogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "📋 Nhật ký hệ thống";
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cboHanhDong.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.pnlBottom.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
