namespace cosmetics_store.Forms
{
    partial class fBrand
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlTop;
        private DevExpress.XtraEditors.SearchControl searchControl;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.GridControl grid;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.searchControl = new DevExpress.XtraEditors.SearchControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.grid = new DevExpress.XtraGrid.GridControl();
            this.gridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.BackgroundImage = global::cosmetics_store.Properties.Resources.bg_dgvNhanVien;
            this.pnlTop.Controls.Add(this.searchControl);
            this.pnlTop.Controls.Add(this.btnAdd);
            this.pnlTop.Controls.Add(this.btnEdit);
            this.pnlTop.Controls.Add(this.btnDelete);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(800, 48);
            this.pnlTop.TabIndex = 0;
            // 
            // searchControl
            // 
            this.searchControl.Location = new System.Drawing.Point(12, 12);
            this.searchControl.Name = "searchControl";
            this.searchControl.Properties.NullValuePrompt = "Tìm thương hiệu...";
            this.searchControl.Properties.ShowClearButton = false;
            this.searchControl.Properties.ShowSearchButton = false;
            this.searchControl.Size = new System.Drawing.Size(250, 22);
            this.searchControl.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.Location = new System.Drawing.Point(420, 8);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 29);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "➕ Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnEdit.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Appearance.Options.UseForeColor = true;
            this.btnEdit.Location = new System.Drawing.Point(540, 8);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(94, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "✏️ Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold);
            this.btnDelete.Appearance.ForeColor = System.Drawing.Color.Red;
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Appearance.Options.UseForeColor = true;
            this.btnDelete.Location = new System.Drawing.Point(664, 8);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 29);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // grid
            // 
            this.grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grid.Location = new System.Drawing.Point(0, 48);
            this.grid.MainView = this.gridView;
            this.grid.Name = "grid";
            this.grid.Size = new System.Drawing.Size(800, 402);
            this.grid.TabIndex = 1;
            this.grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView});
            this.grid.Click += new System.EventHandler(this.grid_Click);
            // 
            // gridView
            // 
            this.gridView.GridControl = this.grid;
            this.gridView.Name = "gridView";
            this.gridView.OptionsBehavior.Editable = false;
            this.gridView.OptionsView.ShowGroupPanel = false;
            // 
            // fBrand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grid);
            this.Controls.Add(this.pnlTop);
            this.Name = "fBrand";
            this.Text = "Quản lý thương hiệu";
            this.pnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.searchControl.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
