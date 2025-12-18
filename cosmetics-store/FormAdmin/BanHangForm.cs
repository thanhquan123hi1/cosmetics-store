using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.Forms
{
    public partial class BanHangForm : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private List<GioHangItem> _gioHang = new List<GioHangItem>();

        public BanHangForm()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += BanHangForm_Load;
        }

        private void BanHangForm_Load(object sender, EventArgs e)
        {
            LoadKhachHang();
            LoadSanPham();
            SetupGridGioHang();
            searchSanPham.TextChanged += SearchSanPham_TextChanged;
        }

        private void LoadKhachHang()
        {
            try
            {
                var khachHangs = _context.KhachHangs
                    .Select(kh => new { kh.MaKH, kh.HoTen, kh.SDT })
                    .ToList();

                lookupKhachHang.Properties.DataSource = khachHangs;
                lookupKhachHang.Properties.DisplayMember = "HoTen";
                lookupKhachHang.Properties.ValueMember = "MaKH";
                lookupKhachHang.Properties.Columns.Clear();
                lookupKhachHang.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("HoTen", "H? tên", 150));
                lookupKhachHang.Properties.Columns.Add(new DevExpress.XtraEditors.Controls.LookUpColumnInfo("SDT", "SÐT", 100));
            }
            catch { }
        }

        private void LoadSanPham(string keyword = "")
        {
            try
            {
                var query = _context.SanPhams
                    .Include(sp => sp.LoaiSP)
                    .Where(sp => sp.SoLuongTon > 0);

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSP.ToLower().Contains(keyword) ||
                                               sp.MaSP.ToString().Contains(keyword));
                }

                var data = query.Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    TenLoai = sp.LoaiSP.TenLoai,
                    sp.DonGia,
                    sp.SoLuongTon
                }).ToList();

                gridSanPham.DataSource = data;

                gridViewSanPham.Columns.Clear();
                gridViewSanPham.Columns.AddVisible("MaSP", "M? SP");
                gridViewSanPham.Columns.AddVisible("TenSP", "Tên s?n ph?m");
                gridViewSanPham.Columns.AddVisible("TenLoai", "Lo?i");
                gridViewSanPham.Columns.AddVisible("DonGia", "Ðõn giá");
                gridViewSanPham.Columns.AddVisible("SoLuongTon", "T?n kho");

                gridViewSanPham.Columns["MaSP"].Width = 60;
                gridViewSanPham.Columns["TenSP"].Width = 180;
                gridViewSanPham.Columns["TenLoai"].Width = 80;
                gridViewSanPham.Columns["DonGia"].Width = 100;
                gridViewSanPham.Columns["SoLuongTon"].Width = 70;

                gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatString = "#,##0 ð";
            }
            catch { }
        }

        private void SetupGridGioHang()
        {
            gridViewGioHang.Columns.Clear();
            gridViewGioHang.Columns.AddVisible("TenSP", "S?n ph?m");
            gridViewGioHang.Columns.AddVisible("SoLuong", "SL");
            gridViewGioHang.Columns.AddVisible("DonGia", "Ðõn giá");
            gridViewGioHang.Columns.AddVisible("ThanhTien", "Thành ti?n");

            gridViewGioHang.Columns["TenSP"].Width = 120;
            gridViewGioHang.Columns["SoLuong"].Width = 40;
            gridViewGioHang.Columns["DonGia"].Width = 80;
            gridViewGioHang.Columns["ThanhTien"].Width = 90;

            gridViewGioHang.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewGioHang.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
            gridViewGioHang.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewGioHang.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0";
        }

        private void SearchSanPham_TextChanged(object sender, EventArgs e)
        {
            LoadSanPham(searchSanPham.Text);
        }

        private void btnThemVaoGio_Click(object sender, EventArgs e)
        {
            if (gridViewSanPham.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui l?ng ch?n s?n ph?m!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(gridViewSanPham.GetFocusedRowCellValue("MaSP"));
            string tenSP = gridViewSanPham.GetFocusedRowCellValue("TenSP").ToString();
            decimal donGia = Convert.ToDecimal(gridViewSanPham.GetFocusedRowCellValue("DonGia"));
            int tonKho = Convert.ToInt32(gridViewSanPham.GetFocusedRowCellValue("SoLuongTon"));
            int soLuong = Convert.ToInt32(spinSoLuong.Value);

            // Ki?m tra t?n kho
            var existing = _gioHang.FirstOrDefault(g => g.MaSP == maSP);
            int totalInCart = existing != null ? existing.SoLuong + soLuong : soLuong;

            if (totalInCart > tonKho)
            {
                XtraMessageBox.Show($"S? lý?ng yêu c?u vý?t quá t?n kho! (T?n: {tonKho})", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (existing != null)
            {
                existing.SoLuong += soLuong;
                existing.ThanhTien = existing.SoLuong * existing.DonGia;
            }
            else
            {
                _gioHang.Add(new GioHangItem
                {
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = soLuong * donGia
                });
            }

            RefreshGioHang();
        }

        private void btnXoaKhoiGio_Click(object sender, EventArgs e)
        {
            if (gridViewGioHang.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui l?ng ch?n s?n ph?m c?n xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var maSP = gridViewGioHang.GetFocusedRowCellValue("MaSP");
            if (maSP != null)
            {
                _gioHang.RemoveAll(g => g.MaSP == Convert.ToInt32(maSP));
                RefreshGioHang();
            }
        }

        private void RefreshGioHang()
        {
            gridGioHang.DataSource = null;
            gridGioHang.DataSource = _gioHang;

            decimal tongTien = _gioHang.Sum(g => g.ThanhTien);
            lblTongTienValue.Text = $"{tongTien:N0} ð";
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_gioHang.Count == 0)
            {
                XtraMessageBox.Show("Gi? hàng tr?ng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lookupKhachHang.EditValue == null)
            {
                XtraMessageBox.Show("Vui l?ng ch?n khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                decimal tongTien = _gioHang.Sum(g => g.ThanhTien);

                // T?o hóa ðõn
                var hoaDon = new HoaDon
                {
                    MaKH = Convert.ToInt32(lookupKhachHang.EditValue),
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 1,
                    NgayLap = DateTime.Now,
                    TongTien = tongTien,
                    TrangThai = "Hoàn thành",
                    PhuongThucTT = cboPhuongThuc.EditValue?.ToString() ?? "Ti?n m?t"
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // T?o chi ti?t và tr? t?n kho
                int stt = 1;
                foreach (var item in _gioHang)
                {
                    var chiTiet = new CT_HoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaSP = item.MaSP,
                        STT = stt++,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    _context.CT_HoaDons.Add(chiTiet);

                    // Tr? t?n kho
                    var sanPham = _context.SanPhams.Find(item.MaSP);
                    if (sanPham != null)
                    {
                        sanPham.SoLuongTon -= item.SoLuong;
                    }
                }

                _context.SaveChanges();

                // Log
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "CREATE_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"Hóa ðõn #{hoaDon.MaHD}, T?ng: {tongTien:N0}ð",
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();

                XtraMessageBox.Show($"Thanh toán thành công!\nHóa ðõn #{hoaDon.MaHD}\nT?ng ti?n: {tongTien:N0} ð",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                _gioHang.Clear();
                RefreshGioHang();
                lookupKhachHang.EditValue = null;
                LoadSanPham();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i thanh toán: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (_gioHang.Count > 0)
            {
                var result = XtraMessageBox.Show("B?n có ch?c mu?n h?y gi? hàng?", "Xác nh?n",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    _gioHang.Clear();
                    RefreshGioHang();
                }
            }
        }
    }

    public class GioHangItem
    {
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
