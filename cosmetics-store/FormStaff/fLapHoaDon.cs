using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace cosmetics_store.FormStaff
{
    public partial class fLapHoaDon : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private List<ChiTietHoaDonItem> _chiTietList = new List<ChiTietHoaDonItem>();
        private KhachHang _selectedKhachHang;
        private int _currentMaHD;

        public fLapHoaDon()
        {
            InitializeComponent();
            _context = new CosmeticsContext();
            this.Load += fLapHoaDon_Load;
        }

        private void fLapHoaDon_Load(object sender, EventArgs e)
        {
            GenerateMaHD();
            LoadSanPham();
            SetupGrid();
            UpdateTongTien();
        }

        private void GenerateMaHD()
        {
            try
            {
                var maxHD = _context.HoaDons.Max(h => (int?)h.MaHD) ?? 0;
                _currentMaHD = maxHD + 1;
                lblMaHD.Text = $"M? HÐ: HD{_currentMaHD:D4}";
                lblNV.Text = $"NV: {(CurrentUser.IsLoggedIn ? CurrentUser.User.HoTen : "N/A")}";
                lblNgay.Text = $"Ngày: {DateTime.Now:dd/MM}";
            }
            catch
            {
                _currentMaHD = 1;
                lblMaHD.Text = "M? HÐ: HD0001";
            }
        }

        private void LoadSanPham()
        {
            try
            {
                var sanPhams = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Where(sp => sp.SoLuongTon > 0)
                    .Select(sp => new
                    {
                        sp.MaSP,
                        sp.TenSP,
                        sp.DonGia,
                        sp.SoLuongTon,
                        ThuongHieu = sp.ThuongHieu.TenThuongHieu
                    })
                    .ToList();

                gridSanPham.DataSource = sanPhams;

                gridViewSanPham.Columns["MaSP"].Caption = "M? SP";
                gridViewSanPham.Columns["TenSP"].Caption = "Tên SP";
                gridViewSanPham.Columns["DonGia"].Caption = "Ðõn giá";
                gridViewSanPham.Columns["SoLuongTon"].Caption = "T?n kho";
                gridViewSanPham.Columns["ThuongHieu"].Caption = "Thýõng hi?u";

                gridViewSanPham.Columns["MaSP"].Width = 60;
                gridViewSanPham.Columns["TenSP"].Width = 150;
                gridViewSanPham.Columns["DonGia"].Width = 100;
                gridViewSanPham.Columns["SoLuongTon"].Width = 70;
                gridViewSanPham.Columns["ThuongHieu"].Width = 100;

                gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
            }
            catch { }
        }

        private void SetupGrid()
        {
            gridViewChiTiet.OptionsBehavior.Editable = false;
            gridViewChiTiet.OptionsView.ShowGroupPanel = false;
        }

        private void btnThemSP_Click(object sender, EventArgs e)
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

            if (soLuong <= 0)
            {
                XtraMessageBox.Show("S? lý?ng ph?i > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ki?m tra ð? có trong list chýa
            var existing = _chiTietList.FirstOrDefault(c => c.MaSP == maSP);
            int totalQty = existing != null ? existing.SoLuong + soLuong : soLuong;

            if (totalQty > tonKho)
            {
                XtraMessageBox.Show($"Vý?t quá t?n kho! (T?n: {tonKho})", "Thông báo",
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
                int stt = _chiTietList.Count + 1;
                _chiTietList.Add(new ChiTietHoaDonItem
                {
                    STT = stt,
                    MaSP = maSP,
                    TenSP = tenSP,
                    SoLuong = soLuong,
                    DonGia = donGia,
                    ThanhTien = soLuong * donGia
                });
            }

            RefreshChiTietGrid();
            UpdateTongTien();
        }

        private void RefreshChiTietGrid()
        {
            gridChiTiet.DataSource = null;
            gridChiTiet.DataSource = _chiTietList;

            if (gridViewChiTiet.Columns.Count > 0)
            {
                gridViewChiTiet.Columns["STT"].Caption = "STT";
                gridViewChiTiet.Columns["MaSP"].Visible = false;
                gridViewChiTiet.Columns["TenSP"].Caption = "Tên SP";
                gridViewChiTiet.Columns["SoLuong"].Caption = "SL";
                gridViewChiTiet.Columns["DonGia"].Caption = "Ðõn giá";
                gridViewChiTiet.Columns["ThanhTien"].Caption = "Thành ti?n";

                gridViewChiTiet.Columns["STT"].Width = 40;
                gridViewChiTiet.Columns["TenSP"].Width = 150;
                gridViewChiTiet.Columns["SoLuong"].Width = 50;
                gridViewChiTiet.Columns["DonGia"].Width = 80;
                gridViewChiTiet.Columns["ThanhTien"].Width = 100;

                gridViewChiTiet.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewChiTiet.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
                gridViewChiTiet.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewChiTiet.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0";
            }
        }

        private void UpdateTongTien()
        {
            decimal tongTien = _chiTietList.Sum(c => c.ThanhTien);
            lblTongTien.Text = $"T?ng ti?n: {tongTien:N0} VND";
        }

        private void btnChonKH_Click(object sender, EventArgs e)
        {
            using (var form = new fChonKhachHang(_context))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    _selectedKhachHang = form.SelectedKhachHang;
                    if (_selectedKhachHang != null)
                    {
                        lblKhachHang.Text = $"Khách hàng: {_selectedKhachHang.HoTen}";
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_chiTietList.Count == 0)
            {
                XtraMessageBox.Show("Chýa có s?n ph?m trong hóa ðõn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedKhachHang == null)
            {
                XtraMessageBox.Show("Vui l?ng ch?n khách hàng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal tongTien = _chiTietList.Sum(c => c.ThanhTien);

            using (var form = new fThanhToan(_selectedKhachHang, tongTien))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    SaveHoaDon(form.PhuongThucTT);
                }
            }
        }

        private void SaveHoaDon(string phuongThuc)
        {
            try
            {
                decimal tongTien = _chiTietList.Sum(c => c.ThanhTien);

                var hoaDon = new HoaDon
                {
                    MaKH = _selectedKhachHang.MaKH,
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : 1,
                    NgayLap = DateTime.Now,
                    TongTien = tongTien,
                    TrangThai = "Hoàn thành",
                    PhuongThucTT = phuongThuc
                };

                _context.HoaDons.Add(hoaDon);
                _context.SaveChanges();

                // Chi ti?t hóa ðõn
                foreach (var item in _chiTietList)
                {
                    var ct = new CT_HoaDon
                    {
                        MaHD = hoaDon.MaHD,
                        MaSP = item.MaSP,
                        STT = item.STT,
                        SoLuong = item.SoLuong,
                        DonGia = item.DonGia
                    };
                    _context.CT_HoaDons.Add(ct);

                    // Tr? t?n kho
                    var sp = _context.SanPhams.Find(item.MaSP);
                    if (sp != null) sp.SoLuongTon -= item.SoLuong;
                }

                _context.SaveChanges();

                // Log
                var log = new AuditLog
                {
                    ThoiGian = DateTime.Now,
                    HanhDong = "CREATE_HoaDon",
                    MaBanGhi = hoaDon.MaHD.ToString(),
                    DuLieuMoi = $"HÐ #{hoaDon.MaHD}, T?ng: {tongTien:N0}ð",
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();

                XtraMessageBox.Show($"Thanh toán thành công!\nHóa ðõn: HD{hoaDon.MaHD:D4}\nT?ng ti?n: {tongTien:N0} VND",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                ResetForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"L?i: {ex.Message}", "L?i",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ResetForm()
        {
            _chiTietList.Clear();
            _selectedKhachHang = null;
            RefreshChiTietGrid();
            UpdateTongTien();
            GenerateMaHD();
            lblKhachHang.Text = "Khách hàng: (Chýa ch?n)";
            LoadSanPham();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            // Lýu hóa ðõn t?m (chýa thanh toán)
            XtraMessageBox.Show("Ð? lýu hóa ðõn t?m!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
            base.Dispose(disposing);
        }
    }

    public class ChiTietHoaDonItem
    {
        public int STT { get; set; }
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public decimal ThanhTien { get; set; }
    }
}
