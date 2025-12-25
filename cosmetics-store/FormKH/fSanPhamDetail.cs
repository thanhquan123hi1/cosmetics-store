using System;
using System.Drawing;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormKH
{
    public partial class fSanPhamDetail : DevExpress.XtraEditors.XtraForm
    {
        private SanPham _sanPham;
        private CosmeticsContext _context;

        public fSanPhamDetail(SanPham sanPham, CosmeticsContext context)
        {
            InitializeComponent();
            _sanPham = sanPham;
            _context = context;
            this.Load += fSanPhamDetail_Load;
        }

        private void fSanPhamDetail_Load(object sender, EventArgs e)
        {
            LoadProductInfo();
        }

        private void LoadProductInfo()
        {
            if (_sanPham == null) return;

            lblTenSP.Text = _sanPham.TenSP;
            lblThuongHieu.Text = _sanPham.ThuongHieu?.TenThuongHieu ?? "N/A";
            lblGia.Text = $"{_sanPham.DonGia:N0} VND";
            lblMoTa.Text = _sanPham.MoTa ?? "Chưa có mô tả";
            lblTonKho.Text = _sanPham.SoLuongTon > 0 ? $"Còn hàng ({_sanPham.SoLuongTon})" : "Hết hàng";
            lblTonKho.ForeColor = _sanPham.SoLuongTon > 0 ? Color.Green : Color.Red;

            // Cấu hình số lượng theo tồn kho
            if (spinSoLuong != null)
            {
                spinSoLuong.Properties.MinValue = 1;
                spinSoLuong.Properties.MaxValue = _sanPham.SoLuongTon > 0 ? _sanPham.SoLuongTon : 1;

                // Clamp lại giá trị hiện tại
                var current = Convert.ToInt32(spinSoLuong.Value);
                if (_sanPham.SoLuongTon <= 0)
                {
                    spinSoLuong.Value = 1;
                    spinSoLuong.Enabled = false;
                }
                else
                {
                    spinSoLuong.Enabled = true;
                    if (current < 1) spinSoLuong.Value = 1;
                    if (current > _sanPham.SoLuongTon) spinSoLuong.Value = _sanPham.SoLuongTon;
                }
            }

            // Load hình ảnh
            try
            {
                if (!string.IsNullOrEmpty(_sanPham.HinhAnh))
                {
                    string path = System.IO.Path.Combine(Application.StartupPath, _sanPham.HinhAnh);
                    if (System.IO.File.Exists(path))
                    {
                        picSanPham.Image = Image.FromFile(path);
                    }
                }
            }
            catch { }
        }

        private void btnThemGio_Click(object sender, EventArgs e)
        {
            if (_sanPham.SoLuongTon <= 0)
            {
                XtraMessageBox.Show("Sản phẩm đã hết hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Trả quantity cho form gọi (đọc qua spinSoLuong.Value)
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        public int SelectedQuantity
        {
            get
            {
                try { return Convert.ToInt32(spinSoLuong.Value); }
                catch { return 1; }
            }
        }
    }
}
