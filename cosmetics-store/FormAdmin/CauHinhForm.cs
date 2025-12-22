using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class CauHinhForm : DevExpress.XtraEditors.XtraForm
    {
        public CauHinhForm()
        {
            InitializeComponent();
            this.Load += CauHinhForm_Load;
        }

        private void CauHinhForm_Load(object sender, EventArgs e)
        {
            ApplyModernTheme();
            LoadSettings();
        }

        private void ApplyModernTheme()
        {
            // Màu sắc dễ nhìn hơn - theme sáng và tươi
            var lightBackground = Color.FromArgb(240, 242, 245);    // Nền sáng
            var cardBackground = Color.White;                        // Card trắng
            var headerBackground = Color.FromArgb(52, 73, 94);      // Header xanh đậm
            var inputBackground = Color.FromArgb(250, 251, 252);    // Input trắng nhạt
            var textDark = Color.FromArgb(44, 62, 80);              // Text đen xanh
            var borderColor = Color.FromArgb(220, 223, 230);        // Border nhạt

            // Form styling - nền sáng dễ nhìn
            this.BackColor = lightBackground;

            // Font - rõ ràng và dễ đọc
            var mainFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            var boldFont = new Font("Segoe UI", 10F, FontStyle.Bold);
            var titleFont = new Font("Segoe UI", 12F, FontStyle.Bold);
            var headerFont = new Font("Segoe UI", 18F, FontStyle.Bold);

            try
            {
                // Style main title
                if (this.Controls.Find("lblTitle", true).Length > 0)
                {
                    var lblTitle = this.Controls.Find("lblTitle", true)[0] as DevExpress.XtraEditors.LabelControl;
                    if (lblTitle != null)
                    {
                        lblTitle.Appearance.Font = headerFont;
                        lblTitle.Appearance.ForeColor = headerBackground;
                        lblTitle.Appearance.Options.UseFont = true;
                        lblTitle.Appearance.Options.UseForeColor = true;
                    }
                }

                // Style GroupBoxes - card trắng đẹp
                foreach (Control ctrl in GetAllControls(this))
                {
                    if (ctrl is DevExpress.XtraEditors.GroupControl groupBox)
                    {
                        groupBox.Appearance.BackColor = cardBackground;
                        groupBox.Appearance.Options.UseBackColor = true;
                        groupBox.AppearanceCaption.Font = titleFont;
                        groupBox.AppearanceCaption.ForeColor = headerBackground;
                        groupBox.AppearanceCaption.Options.UseFont = true;
                        groupBox.AppearanceCaption.Options.UseForeColor = true;
                        groupBox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                    }
                    else if (ctrl is DevExpress.XtraEditors.LabelControl label)
                    {
                        if (!label.Name.Contains("Title") && !label.Name.Contains("Note"))
                        {
                            StyleLabel(label, mainFont, textDark);
                        }
                        else if (label.Name.Contains("Note"))
                        {
                            label.Appearance.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
                            label.Appearance.ForeColor = Color.FromArgb(127, 140, 141);
                            label.Appearance.Options.UseFont = true;
                            label.Appearance.Options.UseForeColor = true;
                        }
                    }
                    else if (ctrl is DevExpress.XtraEditors.TextEdit textEdit)
                    {
                        StyleTextEdit(textEdit, mainFont, inputBackground, textDark, borderColor);
                    }
                    else if (ctrl is DevExpress.XtraEditors.MemoEdit memoEdit)
                    {
                        StyleMemoEdit(memoEdit, mainFont, inputBackground, textDark, borderColor);
                    }
                    else if (ctrl is DevExpress.XtraEditors.SpinEdit spinEdit)
                    {
                        StyleSpinEdit(spinEdit, mainFont, inputBackground, textDark, borderColor);
                    }
                }

                // Style buttons - màu sắc nổi bật và dễ nhìn
                if (this.Controls.Find("btnSave", true).Length > 0)
                    StyleButton(this.Controls.Find("btnSave", true)[0] as DevExpress.XtraEditors.SimpleButton,
                        Color.FromArgb(46, 204, 113), Color.White, boldFont, "💾 Lưu cấu hình");

                if (this.Controls.Find("btnCancel", true).Length > 0)
                    StyleButton(this.Controls.Find("btnCancel", true)[0] as DevExpress.XtraEditors.SimpleButton,
                        Color.FromArgb(149, 165, 166), Color.White, boldFont, "❌ Hủy");

                if (this.Controls.Find("btnResetDefault", true).Length > 0)
                    StyleButton(this.Controls.Find("btnResetDefault", true)[0] as DevExpress.XtraEditors.SimpleButton,
                        Color.FromArgb(231, 76, 60), Color.White, boldFont, "🔄 Khôi phục mặc định");

                // Style pnlMain
                if (this.Controls.Find("pnlMain", true).Length > 0)
                {
                    var pnlMain = this.Controls.Find("pnlMain", true)[0] as DevExpress.XtraEditors.PanelControl;
                    if (pnlMain != null)
                    {
                        pnlMain.Appearance.BackColor = lightBackground;
                        pnlMain.Appearance.Options.UseBackColor = true;
                    }
                }

                // Style pnlBottom
                if (this.Controls.Find("pnlBottom", true).Length > 0)
                {
                    var pnlBottom = this.Controls.Find("pnlBottom", true)[0] as Panel;
                    if (pnlBottom != null)
                    {
                        pnlBottom.BackColor = Color.FromArgb(236, 240, 241);
                    }
                }

                // Style CheckEdits
                foreach (Control ctrl in GetAllControls(this))
                {
                    if (ctrl is DevExpress.XtraEditors.CheckEdit checkEdit)
                    {
                        checkEdit.Properties.Appearance.Font = mainFont;
                        checkEdit.Properties.Appearance.ForeColor = textDark;
                        checkEdit.Properties.Appearance.Options.UseFont = true;
                        checkEdit.Properties.Appearance.Options.UseForeColor = true;
                    }
                }
            }
            catch { }
        }

        private System.Collections.Generic.IEnumerable<Control> GetAllControls(Control container)
        {
            var controls = container.Controls.Cast<Control>().ToList();
            return controls.SelectMany(c => GetAllControls(c)).Concat(controls);
        }

        private void StyleLabel(DevExpress.XtraEditors.LabelControl label, Font font, Color foreColor)
        {
            if (label == null) return;
            label.Appearance.Font = font;
            label.Appearance.ForeColor = foreColor;
            label.Appearance.Options.UseFont = true;
            label.Appearance.Options.UseForeColor = true;
        }

        private void StyleTextEdit(DevExpress.XtraEditors.TextEdit textEdit, Font font, Color backColor, Color foreColor, Color borderColor)
        {
            if (textEdit == null) return;
            textEdit.Properties.Appearance.Font = font;
            textEdit.Properties.Appearance.BackColor = backColor;
            textEdit.Properties.Appearance.ForeColor = foreColor;
            textEdit.Properties.Appearance.Options.UseFont = true;
            textEdit.Properties.Appearance.Options.UseBackColor = true;
            textEdit.Properties.Appearance.Options.UseForeColor = true;
            textEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            textEdit.Properties.Appearance.BorderColor = borderColor;
        }

        private void StyleMemoEdit(DevExpress.XtraEditors.MemoEdit memoEdit, Font font, Color backColor, Color foreColor, Color borderColor)
        {
            if (memoEdit == null) return;
            memoEdit.Properties.Appearance.Font = font;
            memoEdit.Properties.Appearance.BackColor = backColor;
            memoEdit.Properties.Appearance.ForeColor = foreColor;
            memoEdit.Properties.Appearance.Options.UseFont = true;
            memoEdit.Properties.Appearance.Options.UseBackColor = true;
            memoEdit.Properties.Appearance.Options.UseForeColor = true;
            memoEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        private void StyleSpinEdit(DevExpress.XtraEditors.SpinEdit spinEdit, Font font, Color backColor, Color foreColor, Color borderColor)
        {
            if (spinEdit == null) return;
            spinEdit.Properties.Appearance.Font = font;
            spinEdit.Properties.Appearance.BackColor = backColor;
            spinEdit.Properties.Appearance.ForeColor = foreColor;
            spinEdit.Properties.Appearance.Options.UseFont = true;
            spinEdit.Properties.Appearance.Options.UseBackColor = true;
            spinEdit.Properties.Appearance.Options.UseForeColor = true;
            spinEdit.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
        }

        private void StyleButton(DevExpress.XtraEditors.SimpleButton button, Color backColor, Color foreColor, Font font, string text)
        {
            if (button == null) return;
            button.Text = text;
            button.Appearance.BackColor = backColor;
            button.Appearance.ForeColor = foreColor;
            button.Appearance.Font = font;
            button.Appearance.Options.UseBackColor = true;
            button.Appearance.Options.UseForeColor = true;
            button.Appearance.Options.UseFont = true;
            button.LookAndFeel.UseDefaultLookAndFeel = false;
            button.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat;
            button.Height = Math.Max(button.Height, 36);
            button.Padding = new Padding(8, 4, 8, 4);

            button.MouseEnter += (s, e) => { button.Appearance.BackColor = ControlPaint.Light(backColor, 0.2f); };
            button.MouseLeave += (s, e) => { button.Appearance.BackColor = backColor; };
        }

        private void LoadSettings()
        {
            // Load cấu hình mặc định
            txtStoreName.Text = "Cosmetics Store";
            txtStoreAddress.Text = "";
            txtStorePhone.Text = "";
            txtStoreEmail.Text = "";
            spinLowStock.Value = 10;
            txtSmtpEmail.Text = "";
            txtSmtpDisplayName.Text = "Cosmetics Store";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(txtStoreName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên cửa hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStoreName.Focus();
                return;
            }

            if (spinLowStock.Value < 0)
            {
                XtraMessageBox.Show("Ngưỡng cảnh báo tồn kho phải >= 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinLowStock.Focus();
                return;
            }

            // TODO: Implement save to database or config file
            XtraMessageBox.Show("Lưu cấu hình thành công!\n(Chức năng lưu cấu hình đang được phát triển)",
                "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            LoadSettings();
        }

        private void btnResetDefault_Click(object sender, EventArgs e)
        {
            var result = XtraMessageBox.Show("Bạn có chắc chắn muốn khôi phục cấu hình mặc định?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                txtStoreName.Text = "Cosmetics Store";
                txtStoreAddress.Text = "";
                txtStorePhone.Text = "";
                txtStoreEmail.Text = "";
                spinLowStock.Value = 10;
                txtSmtpDisplayName.Text = "Cosmetics Store";
            }
        }

        private void grpInventory_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
