using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class SanPhamEditForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private SanPham _sanPham;
        private bool _isEditMode;
        private string _imagesFolder;
        private string _selectedImagePath;

        public SanPhamEditForm(CosmeticsContext context)
        {
            InitializeComponent();
            _context = context;
            _isEditMode = false;
            InitializeForm();
        }

        public SanPhamEditForm(CosmeticsContext context, SanPham sanPham)
        {
            InitializeComponent();
            _context = context;
            _sanPham = sanPham;
            _isEditMode = true;
            InitializeForm();
            LoadSanPhamData();
        }

        private void InitializeForm()
        {
            // Tạo thư mục lưu hình ảnh nếu chưa có
            _imagesFolder = Path.Combine(Application.StartupPath, "Images", "Products");
            if (!Directory.Exists(_imagesFolder))
            {
                Directory.CreateDirectory(_imagesFolder);
            }

            LoadLoaiSP();
            LoadThuongHieu();

            if (!_isEditMode)
            {
                spinSoLuong.Value = 0;
                spinDonGia.Value = 0;
                _selectedImagePath = "";
            }
        }

        private void LoadLoaiSP()
        {
            try
            {
                var loaiList = _context.LoaiSPs
                    .Select(l => new { l.MaLoai, l.TenLoai })
                    .ToList();

                lookupLoai.Properties.DataSource = loaiList;
                lookupLoai.Properties.DisplayMember = "TenLoai";
                lookupLoai.Properties.ValueMember = "MaLoai";
                lookupLoai.Properties.Columns.Clear();
                lookupLoai.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenLoai", "Loại sản phẩm"));
                lookupLoai.Properties.NullText = "-- Chọn loại sản phẩm --";
            }
            catch { }
        }

        private void LoadThuongHieu()
        {
            try
            {
                var thuongHieuList = _context.ThuongHieus
                    .Select(t => new { t.MaThuongHieu, t.TenThuongHieu })
                    .ToList();

                lookupThuong.Properties.DataSource = thuongHieuList;
                lookupThuong.Properties.DisplayMember = "TenThuongHieu";
                lookupThuong.Properties.ValueMember = "MaThuongHieu";
                lookupThuong.Properties.Columns.Clear();
                lookupThuong.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TenThuongHieu", "Thương hiệu"));
                lookupThuong.Properties.NullText = "-- Chọn thương hiệu --";
            }
            catch { }
        }

        private void LoadSanPhamData()
        {
            if (_sanPham == null) return;

            txtTen.Text = _sanPham.TenSP;
            txtMoTa.Text = _sanPham.MoTa ?? "";
            lookupLoai.EditValue = _sanPham.MaLoai;
            lookupThuong.EditValue = _sanPham.MaThuongHieu;
            spinSoLuong.Value = _sanPham.SoLuongTon;
            spinDonGia.Value = _sanPham.DonGia;
            _selectedImagePath = _sanPham.HinhAnh ?? "";

            // Load hình ảnh nếu có
            LoadImage(_selectedImagePath);
        }

        private void LoadImage(string imagePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(imagePath))
                {
                    string fullPath = imagePath;

                    // Nếu là đường dẫn tương đối, ghép với thư mục ứng dụng
                    if (!Path.IsPathRooted(imagePath))
                    {
                        fullPath = Path.Combine(Application.StartupPath, imagePath);
                    }

                    if (File.Exists(fullPath))
                    {
                        // Load image t? stream ð? tránh lock file
                        using (var stream = new FileStream(fullPath, FileMode.Open, FileAccess.Read))
                        {
                            picHinhAnh.Image = Image.FromStream(stream);
                        }
                    }
                    else
                    {
                        picHinhAnh.Image = null;
                    }
                }
                else
                {
                    picHinhAnh.Image = null;
                }
            }
            catch
            {
                picHinhAnh.Image = null;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string sourceFile = openFileDialog.FileName;
                    string fileName = Path.GetFileName(sourceFile);
                    
                    // Tạo tên file unique để tránh trùng
                    string uniqueFileName = $"{DateTime.Now:yyyyMMddHHmmss}_{fileName}";
                    string destPath = Path.Combine(_imagesFolder, uniqueFileName);

                    // Copy file vào thư mục Images/Products
                    File.Copy(sourceFile, destPath, true);

                    // Lưu đường dẫn tương đối
                    _selectedImagePath = Path.Combine("Images", "Products", uniqueFileName);

                    // Hiển thị ảnh preview
                    using (var stream = new FileStream(destPath, FileMode.Open, FileAccess.Read))
                    {
                        picHinhAnh.Image = Image.FromStream(stream);
                    }

                    XtraMessageBox.Show("Đã upload hình ảnh thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show($"Lỗi upload hình ảnh: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public SanPham GetSanPham()
        {
            return new SanPham
            {
                TenSP = txtTen.Text.Trim(),
                MoTa = txtMoTa.Text.Trim(),
                MaLoai = Convert.ToInt32(lookupLoai.EditValue),
                MaThuongHieu = Convert.ToInt32(lookupThuong.EditValue),
                SoLuongTon = Convert.ToInt32(spinSoLuong.Value),
                DonGia = spinDonGia.Value,
                HinhAnh = _selectedImagePath
            };
        }

        public void UpdateSanPham(SanPham sanPham)
        {
            sanPham.TenSP = txtTen.Text.Trim();
            sanPham.MoTa = txtMoTa.Text.Trim();
            sanPham.MaLoai = Convert.ToInt32(lookupLoai.EditValue);
            sanPham.MaThuongHieu = Convert.ToInt32(lookupThuong.EditValue);
            sanPham.SoLuongTon = Convert.ToInt32(spinSoLuong.Value);
            sanPham.DonGia = spinDonGia.Value;
            sanPham.HinhAnh = _selectedImagePath;
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtTen.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập tên sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTen.Focus();
                return false;
            }

            if (lookupLoai.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn loại sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookupLoai.Focus();
                return false;
            }

            if (lookupThuong.EditValue == null)
            {
                XtraMessageBox.Show("Vui lòng chọn thương hiệu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                lookupThuong.Focus();
                return false;
            }

            if (spinDonGia.Value <= 0)
            {
                XtraMessageBox.Show("Đơn giá phải > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinDonGia.Focus();
                return false;
            }

            if (spinSoLuong.Value < 0)
            {
                XtraMessageBox.Show("Số lượng tồn không được âm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                spinSoLuong.Focus();
                return false;
            }

            return true;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
