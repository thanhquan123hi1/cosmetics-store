namespace cosmetics_store.FormStaff
{
    partial class fTraCuuSanPham
    {
        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraEditors.LabelControl lblTimKiem;
        private DevExpress.XtraEditors.TextEdit txtTimKiem;
        private DevExpress.XtraEditors.SimpleButton btnLoc;
        private DevExpress.XtraGrid.GridControl gridSanPham;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewSP;

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblTimKiem = new DevExpress.XtraEditors.LabelControl();
            this.txtTimKiem = new DevExpress.XtraEditors.TextEdit();
            this.btnLoc = new DevExpress.XtraEditors.SimpleButton();
            this.gridSanPham = new DevExpress.XtraGrid.GridControl();
            this.gridViewSP = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSP)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.lblTitle);
            this.pnlMain.Controls.Add(this.lblTimKiem);
            this.pnlMain.Controls.Add(this.txtTimKiem);
            this.pnlMain.Controls.Add(this.btnLoc);
            this.pnlMain.Controls.Add(this.gridSanPham);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(900, 550);
            this.pnlMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(244, 28);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "🔍 TRA CỨU SẢN PHẨM";
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.Appearance.Font = new System.Drawing.Font("Segoe UI Black", 9.2F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.Appearance.Options.UseFont = true;
            this.lblTimKiem.Location = new System.Drawing.Point(20, 60);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(317, 21);
            this.lblTimKiem.TabIndex = 1;
            this.lblTimKiem.Text = "Tìm theo: [ Tên SP / Loại / Thương hiệu ]";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(359, 57);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Properties.Appearance.Options.UseFont = true;
            this.txtTimKiem.Size = new System.Drawing.Size(300, 30);
            this.txtTimKiem.TabIndex = 2;
            this.txtTimKiem.EditValueChanged += new System.EventHandler(this.txtTimKiem_EditValueChanged);
            this.txtTimKiem.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTimKiem_KeyPress);
            // 
            // btnLoc
            // 
            this.btnLoc.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnLoc.Appearance.Font = new System.Drawing.Font("Times New Roman", 10.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLoc.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Appearance.Options.UseBackColor = true;
            this.btnLoc.Appearance.Options.UseFont = true;
            this.btnLoc.Appearance.Options.UseForeColor = true;
            this.btnLoc.Location = new System.Drawing.Point(701, 57);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(106, 30);
            this.btnLoc.TabIndex = 3;
            this.btnLoc.Text = "🔎 Lọc";
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // gridSanPham
            // 
            this.gridSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSanPham.Location = new System.Drawing.Point(20, 100);
            this.gridSanPham.MainView = this.gridViewSP;
            this.gridSanPham.Name = "gridSanPham";
            this.gridSanPham.Size = new System.Drawing.Size(860, 430);
            this.gridSanPham.TabIndex = 4;
            this.gridSanPham.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewSP});
            // 
            // gridViewSP
            // 
            this.gridViewSP.GridControl = this.gridSanPham;
            this.gridViewSP.Name = "gridViewSP";
            this.gridViewSP.OptionsBehavior.Editable = false;
            this.gridViewSP.OptionsView.ShowGroupPanel = false;
            // 
            // fTraCuuSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 550);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "fTraCuuSanPham";
            this.Text = "Tra cứu sản phẩm";
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTimKiem.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSanPham)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewSP)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
