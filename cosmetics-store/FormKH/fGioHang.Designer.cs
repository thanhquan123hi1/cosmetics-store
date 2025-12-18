namespace cosmetics_store.FormKH
{
    partial class fGioHang
    {
        private System.ComponentModel.IContainer components = null;
        
        // Main panels
        private DevExpress.XtraEditors.PanelControl pnlMain;
        private DevExpress.XtraEditors.PanelControl pnlLeft;
        private DevExpress.XtraEditors.PanelControl pnlRight;
        
        // Cart section
        private DevExpress.XtraEditors.LabelControl lblTitle;
        private DevExpress.XtraGrid.GridControl gridGioHang;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewGH;
        private DevExpress.XtraEditors.SimpleButton btnXoa;
        private DevExpress.XtraEditors.SimpleButton btnTangSL;
        private DevExpress.XtraEditors.SimpleButton btnGiamSL;
        
        // Shipping section
        private DevExpress.XtraEditors.LabelControl lblShippingTitle;
        private DevExpress.XtraEditors.TextEdit txtHoTen;
        private DevExpress.XtraEditors.TextEdit txtSDT;
        private DevExpress.XtraEditors.MemoEdit txtDiaChi;
        private DevExpress.XtraEditors.MemoEdit txtGhiChu;
        
        // Voucher section
        private DevExpress.XtraEditors.LabelControl lblVoucherTitle;
        private DevExpress.XtraEditors.TextEdit txtVoucher;
        private DevExpress.XtraEditors.SimpleButton btnApVoucher;
        private DevExpress.XtraEditors.LabelControl lblVoucherHint;
        private DevExpress.XtraEditors.LabelControl lblVoucherStatus;
        
        // Payment methods
        private DevExpress.XtraEditors.LabelControl lblPaymentTitle;
        private DevExpress.XtraEditors.PanelControl pnlPaymentMethods;
        
        // QR Code section
        private DevExpress.XtraEditors.PanelControl pnlQRCode;
        private System.Windows.Forms.PictureBox picQRCode;
        private DevExpress.XtraEditors.LabelControl lblPaymentInstructions;
        
        // Summary section
        private DevExpress.XtraEditors.LabelControl lblSummaryTitle;
        private DevExpress.XtraEditors.LabelControl lblSubtotalLabel;
        private DevExpress.XtraEditors.LabelControl lblSubtotal;
        private DevExpress.XtraEditors.LabelControl lblShippingLabel;
        private DevExpress.XtraEditors.LabelControl lblShipping;
        private DevExpress.XtraEditors.LabelControl lblDiscountLabel;
        private DevExpress.XtraEditors.LabelControl lblDiscount;
        private DevExpress.XtraEditors.LabelControl lblTotalLabel;
        private DevExpress.XtraEditors.LabelControl lblTotal;
        
        // Buttons
        private DevExpress.XtraEditors.SimpleButton btnThanhToan;
        private DevExpress.XtraEditors.SimpleButton btnTiepTuc;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.pnlLeft = new DevExpress.XtraEditors.PanelControl();
            this.pnlRight = new DevExpress.XtraEditors.PanelControl();
            this.lblTitle = new DevExpress.XtraEditors.LabelControl();
            this.gridGioHang = new DevExpress.XtraGrid.GridControl();
            this.gridViewGH = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnXoa = new DevExpress.XtraEditors.SimpleButton();
            this.btnTangSL = new DevExpress.XtraEditors.SimpleButton();
            this.btnGiamSL = new DevExpress.XtraEditors.SimpleButton();
            this.lblShippingTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtHoTen = new DevExpress.XtraEditors.TextEdit();
            this.txtSDT = new DevExpress.XtraEditors.TextEdit();
            this.txtDiaChi = new DevExpress.XtraEditors.MemoEdit();
            this.txtGhiChu = new DevExpress.XtraEditors.MemoEdit();
            this.lblVoucherTitle = new DevExpress.XtraEditors.LabelControl();
            this.txtVoucher = new DevExpress.XtraEditors.TextEdit();
            this.btnApVoucher = new DevExpress.XtraEditors.SimpleButton();
            this.lblVoucherHint = new DevExpress.XtraEditors.LabelControl();
            this.lblVoucherStatus = new DevExpress.XtraEditors.LabelControl();
            this.lblPaymentTitle = new DevExpress.XtraEditors.LabelControl();
            this.pnlPaymentMethods = new DevExpress.XtraEditors.PanelControl();
            this.pnlQRCode = new DevExpress.XtraEditors.PanelControl();
            this.picQRCode = new System.Windows.Forms.PictureBox();
            this.lblPaymentInstructions = new DevExpress.XtraEditors.LabelControl();
            this.lblSummaryTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblSubtotalLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblSubtotal = new DevExpress.XtraEditors.LabelControl();
            this.lblShippingLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblShipping = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscountLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblDiscount = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalLabel = new DevExpress.XtraEditors.LabelControl();
            this.lblTotal = new DevExpress.XtraEditors.LabelControl();
            this.btnThanhToan = new DevExpress.XtraEditors.SimpleButton();
            this.btnTiepTuc = new DevExpress.XtraEditors.SimpleButton();

            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).BeginInit();
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).BeginInit();
            this.pnlRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGioHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucher.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPaymentMethods)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQRCode)).BeginInit();
            this.pnlQRCode.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).BeginInit();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.Appearance.BackColor = System.Drawing.Color.FromArgb(250, 248, 255);
            this.pnlMain.Appearance.Options.UseBackColor = true;
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlMain.Controls.Add(this.pnlLeft);
            this.pnlMain.Controls.Add(this.pnlRight);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1050, 700);
            this.pnlMain.TabIndex = 0;

            // 
            // pnlLeft - Gi? hàng + Giao hàng
            // 
            this.pnlLeft.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlLeft.Appearance.Options.UseBackColor = true;
            this.pnlLeft.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlLeft.Location = new System.Drawing.Point(15, 15);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(600, 670);
            this.pnlLeft.TabIndex = 0;
            this.pnlLeft.Controls.Add(this.lblTitle);
            this.pnlLeft.Controls.Add(this.gridGioHang);
            this.pnlLeft.Controls.Add(this.btnXoa);
            this.pnlLeft.Controls.Add(this.btnTangSL);
            this.pnlLeft.Controls.Add(this.btnGiamSL);
            this.pnlLeft.Controls.Add(this.lblShippingTitle);
            this.pnlLeft.Controls.Add(this.txtHoTen);
            this.pnlLeft.Controls.Add(this.txtSDT);
            this.pnlLeft.Controls.Add(this.txtDiaChi);
            this.pnlLeft.Controls.Add(this.txtGhiChu);

            // 
            // lblTitle
            // 
            this.lblTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(128, 0, 128);
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Appearance.Options.UseForeColor = true;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(200, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "?? GI? HÀNG";

            // 
            // gridGioHang
            // 
            this.gridGioHang.Location = new System.Drawing.Point(20, 60);
            this.gridGioHang.MainView = this.gridViewGH;
            this.gridGioHang.Name = "gridGioHang";
            this.gridGioHang.Size = new System.Drawing.Size(560, 200);
            this.gridGioHang.TabIndex = 1;

            // 
            // gridViewGH
            // 
            this.gridViewGH.GridControl = this.gridGioHang;
            this.gridViewGH.Name = "gridViewGH";
            this.gridViewGH.OptionsBehavior.Editable = false;
            this.gridViewGH.OptionsView.ShowGroupPanel = false;
            this.gridViewGH.RowHeight = 30;

            // 
            // btnXoa
            // 
            this.btnXoa.Appearance.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnXoa.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnXoa.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Appearance.Options.UseBackColor = true;
            this.btnXoa.Appearance.Options.UseFont = true;
            this.btnXoa.Appearance.Options.UseForeColor = true;
            this.btnXoa.Location = new System.Drawing.Point(20, 268);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(80, 30);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "??? Xóa";
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);

            // 
            // btnGiamSL
            // 
            this.btnGiamSL.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnGiamSL.Location = new System.Drawing.Point(110, 268);
            this.btnGiamSL.Name = "btnGiamSL";
            this.btnGiamSL.Size = new System.Drawing.Size(35, 30);
            this.btnGiamSL.TabIndex = 3;
            this.btnGiamSL.Text = "?";
            this.btnGiamSL.Click += new System.EventHandler(this.btnGiamSL_Click);

            // 
            // btnTangSL
            // 
            this.btnTangSL.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTangSL.Location = new System.Drawing.Point(150, 268);
            this.btnTangSL.Name = "btnTangSL";
            this.btnTangSL.Size = new System.Drawing.Size(35, 30);
            this.btnTangSL.TabIndex = 4;
            this.btnTangSL.Text = "+";
            this.btnTangSL.Click += new System.EventHandler(this.btnTangSL_Click);

            // 
            // lblShippingTitle
            // 
            this.lblShippingTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblShippingTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblShippingTitle.Appearance.Options.UseFont = true;
            this.lblShippingTitle.Appearance.Options.UseForeColor = true;
            this.lblShippingTitle.Location = new System.Drawing.Point(20, 315);
            this.lblShippingTitle.Name = "lblShippingTitle";
            this.lblShippingTitle.Size = new System.Drawing.Size(220, 25);
            this.lblShippingTitle.TabIndex = 5;
            this.lblShippingTitle.Text = "?? THÔNG TIN GIAO HÀNG";

            // 
            // txtHoTen
            // 
            this.txtHoTen.Location = new System.Drawing.Point(20, 350);
            this.txtHoTen.Name = "txtHoTen";
            this.txtHoTen.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtHoTen.Properties.NullValuePrompt = "?? H? tên ng??i nh?n *";
            this.txtHoTen.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtHoTen.Size = new System.Drawing.Size(270, 30);
            this.txtHoTen.TabIndex = 6;

            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(310, 350);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtSDT.Properties.NullValuePrompt = "?? S? ?i?n tho?i *";
            this.txtSDT.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSDT.Size = new System.Drawing.Size(270, 30);
            this.txtSDT.TabIndex = 7;

            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(20, 390);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtDiaChi.Properties.NullValuePrompt = "?? ??a ch? giao hàng ??y ?? (s? nhà, ???ng, ph??ng/xã, qu?n/huy?n, t?nh/thành ph?) *";
            this.txtDiaChi.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDiaChi.Size = new System.Drawing.Size(560, 80);
            this.txtDiaChi.TabIndex = 8;

            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(20, 480);
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtGhiChu.Properties.NullValuePrompt = "?? Ghi chú cho ??n hàng (không b?t bu?c)";
            this.txtGhiChu.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtGhiChu.Size = new System.Drawing.Size(560, 60);
            this.txtGhiChu.TabIndex = 9;

            // 
            // pnlRight - Voucher + Thanh toán + T?ng k?t
            // 
            this.pnlRight.Appearance.BackColor = System.Drawing.Color.White;
            this.pnlRight.Appearance.Options.UseBackColor = true;
            this.pnlRight.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlRight.Location = new System.Drawing.Point(630, 15);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(405, 670);
            this.pnlRight.TabIndex = 1;
            this.pnlRight.Controls.Add(this.lblVoucherTitle);
            this.pnlRight.Controls.Add(this.txtVoucher);
            this.pnlRight.Controls.Add(this.btnApVoucher);
            this.pnlRight.Controls.Add(this.lblVoucherHint);
            this.pnlRight.Controls.Add(this.lblVoucherStatus);
            this.pnlRight.Controls.Add(this.lblPaymentTitle);
            this.pnlRight.Controls.Add(this.pnlPaymentMethods);
            this.pnlRight.Controls.Add(this.pnlQRCode);
            this.pnlRight.Controls.Add(this.lblSummaryTitle);
            this.pnlRight.Controls.Add(this.lblSubtotalLabel);
            this.pnlRight.Controls.Add(this.lblSubtotal);
            this.pnlRight.Controls.Add(this.lblShippingLabel);
            this.pnlRight.Controls.Add(this.lblShipping);
            this.pnlRight.Controls.Add(this.lblDiscountLabel);
            this.pnlRight.Controls.Add(this.lblDiscount);
            this.pnlRight.Controls.Add(this.lblTotalLabel);
            this.pnlRight.Controls.Add(this.lblTotal);
            this.pnlRight.Controls.Add(this.btnThanhToan);
            this.pnlRight.Controls.Add(this.btnTiepTuc);

            // 
            // lblVoucherTitle
            // 
            this.lblVoucherTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblVoucherTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblVoucherTitle.Location = new System.Drawing.Point(15, 15);
            this.lblVoucherTitle.Name = "lblVoucherTitle";
            this.lblVoucherTitle.Size = new System.Drawing.Size(130, 21);
            this.lblVoucherTitle.TabIndex = 0;
            this.lblVoucherTitle.Text = "?? MÃ GI?M GIÁ";

            // 
            // txtVoucher
            // 
            this.txtVoucher.Location = new System.Drawing.Point(15, 45);
            this.txtVoucher.Name = "txtVoucher";
            this.txtVoucher.Properties.Appearance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtVoucher.Properties.NullValuePrompt = "Nh?p mã voucher...";
            this.txtVoucher.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtVoucher.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtVoucher.Size = new System.Drawing.Size(270, 30);
            this.txtVoucher.TabIndex = 1;

            // 
            // btnApVoucher
            // 
            this.btnApVoucher.Appearance.BackColor = System.Drawing.Color.FromArgb(147, 112, 219);
            this.btnApVoucher.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnApVoucher.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnApVoucher.Appearance.Options.UseBackColor = true;
            this.btnApVoucher.Appearance.Options.UseFont = true;
            this.btnApVoucher.Appearance.Options.UseForeColor = true;
            this.btnApVoucher.Location = new System.Drawing.Point(295, 45);
            this.btnApVoucher.Name = "btnApVoucher";
            this.btnApVoucher.Size = new System.Drawing.Size(90, 30);
            this.btnApVoucher.TabIndex = 2;
            this.btnApVoucher.Text = "Áp d?ng";
            this.btnApVoucher.Click += new System.EventHandler(this.btnApVoucher_Click);

            // 
            // lblVoucherHint
            // 
            this.lblVoucherHint.Appearance.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblVoucherHint.Appearance.ForeColor = System.Drawing.Color.Gray;
            this.lblVoucherHint.Location = new System.Drawing.Point(15, 80);
            this.lblVoucherHint.Name = "lblVoucherHint";
            this.lblVoucherHint.Size = new System.Drawing.Size(370, 14);
            this.lblVoucherHint.TabIndex = 3;
            this.lblVoucherHint.Text = "?? Th?: FREESHIP, GIAM10, GIAM20, GIAM50K, NEWUSER";

            // 
            // lblVoucherStatus
            // 
            this.lblVoucherStatus.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblVoucherStatus.Location = new System.Drawing.Point(15, 98);
            this.lblVoucherStatus.Name = "lblVoucherStatus";
            this.lblVoucherStatus.Size = new System.Drawing.Size(370, 15);
            this.lblVoucherStatus.TabIndex = 4;
            this.lblVoucherStatus.Text = "";

            // 
            // lblPaymentTitle
            // 
            this.lblPaymentTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPaymentTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblPaymentTitle.Location = new System.Drawing.Point(15, 125);
            this.lblPaymentTitle.Name = "lblPaymentTitle";
            this.lblPaymentTitle.Size = new System.Drawing.Size(200, 21);
            this.lblPaymentTitle.TabIndex = 5;
            this.lblPaymentTitle.Text = "?? PH??NG TH?C THANH TOÁN";

            // 
            // pnlPaymentMethods
            // 
            this.pnlPaymentMethods.Appearance.BackColor = System.Drawing.Color.FromArgb(250, 250, 255);
            this.pnlPaymentMethods.Appearance.Options.UseBackColor = true;
            this.pnlPaymentMethods.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlPaymentMethods.Location = new System.Drawing.Point(15, 152);
            this.pnlPaymentMethods.Name = "pnlPaymentMethods";
            this.pnlPaymentMethods.Size = new System.Drawing.Size(370, 135);
            this.pnlPaymentMethods.TabIndex = 6;

            // 
            // pnlQRCode
            // 
            this.pnlQRCode.Appearance.BackColor = System.Drawing.Color.FromArgb(245, 245, 250);
            this.pnlQRCode.Appearance.Options.UseBackColor = true;
            this.pnlQRCode.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnlQRCode.Controls.Add(this.picQRCode);
            this.pnlQRCode.Controls.Add(this.lblPaymentInstructions);
            this.pnlQRCode.Location = new System.Drawing.Point(15, 295);
            this.pnlQRCode.Name = "pnlQRCode";
            this.pnlQRCode.Size = new System.Drawing.Size(370, 180);
            this.pnlQRCode.TabIndex = 7;
            this.pnlQRCode.Visible = false;

            // 
            // picQRCode
            // 
            this.picQRCode.Location = new System.Drawing.Point(10, 10);
            this.picQRCode.Name = "picQRCode";
            this.picQRCode.Size = new System.Drawing.Size(160, 160);
            this.picQRCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picQRCode.TabIndex = 0;

            // 
            // lblPaymentInstructions
            // 
            this.lblPaymentInstructions.Appearance.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPaymentInstructions.Appearance.ForeColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.lblPaymentInstructions.Location = new System.Drawing.Point(180, 10);
            this.lblPaymentInstructions.Name = "lblPaymentInstructions";
            this.lblPaymentInstructions.Size = new System.Drawing.Size(180, 160);
            this.lblPaymentInstructions.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPaymentInstructions.TabIndex = 1;
            this.lblPaymentInstructions.Text = "?? Quét mã QR ?? thanh toán";

            // 
            // lblSummaryTitle
            // 
            this.lblSummaryTitle.Appearance.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblSummaryTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblSummaryTitle.Location = new System.Drawing.Point(15, 485);
            this.lblSummaryTitle.Name = "lblSummaryTitle";
            this.lblSummaryTitle.Size = new System.Drawing.Size(150, 21);
            this.lblSummaryTitle.TabIndex = 8;
            this.lblSummaryTitle.Text = "?? TÓM T?T ??N HÀNG";

            // 
            // lblSubtotalLabel
            // 
            this.lblSubtotalLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtotalLabel.Location = new System.Drawing.Point(15, 515);
            this.lblSubtotalLabel.Name = "lblSubtotalLabel";
            this.lblSubtotalLabel.Size = new System.Drawing.Size(80, 17);
            this.lblSubtotalLabel.TabIndex = 9;
            this.lblSubtotalLabel.Text = "T?m tính:";

            // 
            // lblSubtotal
            // 
            this.lblSubtotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSubtotal.Location = new System.Drawing.Point(280, 515);
            this.lblSubtotal.Name = "lblSubtotal";
            this.lblSubtotal.Size = new System.Drawing.Size(105, 17);
            this.lblSubtotal.TabIndex = 10;
            this.lblSubtotal.Text = "0?";

            // 
            // lblShippingLabel
            // 
            this.lblShippingLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblShippingLabel.Location = new System.Drawing.Point(15, 540);
            this.lblShippingLabel.Name = "lblShippingLabel";
            this.lblShippingLabel.Size = new System.Drawing.Size(100, 17);
            this.lblShippingLabel.TabIndex = 11;
            this.lblShippingLabel.Text = "Phí v?n chuy?n:";

            // 
            // lblShipping
            // 
            this.lblShipping.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblShipping.Location = new System.Drawing.Point(280, 540);
            this.lblShipping.Name = "lblShipping";
            this.lblShipping.Size = new System.Drawing.Size(105, 17);
            this.lblShipping.TabIndex = 12;
            this.lblShipping.Text = "30,000?";

            // 
            // lblDiscountLabel
            // 
            this.lblDiscountLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDiscountLabel.Location = new System.Drawing.Point(15, 565);
            this.lblDiscountLabel.Name = "lblDiscountLabel";
            this.lblDiscountLabel.Size = new System.Drawing.Size(80, 17);
            this.lblDiscountLabel.TabIndex = 13;
            this.lblDiscountLabel.Text = "Gi?m giá:";

            // 
            // lblDiscount
            // 
            this.lblDiscount.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblDiscount.Appearance.ForeColor = System.Drawing.Color.FromArgb(46, 204, 113);
            this.lblDiscount.Location = new System.Drawing.Point(280, 565);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(105, 17);
            this.lblDiscount.TabIndex = 14;
            this.lblDiscount.Text = "0?";

            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTotalLabel.Appearance.ForeColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.lblTotalLabel.Location = new System.Drawing.Point(15, 595);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(100, 25);
            this.lblTotalLabel.TabIndex = 15;
            this.lblTotalLabel.Text = "T?NG C?NG:";

            // 
            // lblTotal
            // 
            this.lblTotal.Appearance.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Appearance.ForeColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.lblTotal.Location = new System.Drawing.Point(230, 590);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(155, 32);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "0?";

            // 
            // btnThanhToan
            // 
            this.btnThanhToan.Appearance.BackColor = System.Drawing.Color.FromArgb(231, 76, 60);
            this.btnThanhToan.Appearance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan.Appearance.Options.UseBackColor = true;
            this.btnThanhToan.Appearance.Options.UseFont = true;
            this.btnThanhToan.Appearance.Options.UseForeColor = true;
            this.btnThanhToan.Location = new System.Drawing.Point(15, 630);
            this.btnThanhToan.Name = "btnThanhToan";
            this.btnThanhToan.Size = new System.Drawing.Size(260, 45);
            this.btnThanhToan.TabIndex = 17;
            this.btnThanhToan.Text = "?? ??T HÀNG NGAY";
            this.btnThanhToan.Click += new System.EventHandler(this.btnThanhToan_Click);

            // 
            // btnTiepTuc
            // 
            this.btnTiepTuc.Appearance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnTiepTuc.Location = new System.Drawing.Point(285, 630);
            this.btnTiepTuc.Name = "btnTiepTuc";
            this.btnTiepTuc.Size = new System.Drawing.Size(100, 45);
            this.btnTiepTuc.TabIndex = 18;
            this.btnTiepTuc.Text = "? Ti?p t?c mua";
            this.btnTiepTuc.Click += new System.EventHandler(this.btnTiepTuc_Click);

            // 
            // fGioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 700);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fGioHang";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "?? Gi? hàng & Thanh toán - BEAUTY BOX";

            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlLeft)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlRight)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridGioHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewGH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtHoTen.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSDT.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiaChi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtGhiChu.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtVoucher.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPaymentMethods)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlQRCode)).EndInit();
            this.pnlQRCode.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picQRCode)).EndInit();
            this.ResumeLayout(false);
        }
    }
}
