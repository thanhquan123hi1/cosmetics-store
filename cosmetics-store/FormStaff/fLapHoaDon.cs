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
using BusinessAccessLayer.Services;

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
                lblMaHD.Text = "Mã HĐ: HD" + _currentMaHD.ToString("D4");
                lblNV.Text = "NV: " + (CurrentUser.IsLoggedIn ? CurrentUser.User.HoTen : "N/A");
                lblNgay.Text = "Ngày: " + DateTime.Now.ToString("dd/MM/yyyy");
            }
            catch
            {
                _currentMaHD = 1;
                lblMaHD.Text = "Mã HĐ: HD0001";
            }
        }

        private void LoadSanPham(string keyword = "")
        {
            try
            {
                var query = _context.SanPhams
                    .Include(sp => sp.ThuongHieu)
                    .Where(sp => sp.SoLuongTon > 0);

                if (!string.IsNullOrEmpty(keyword))
                {
                    keyword = keyword.ToLower();
                    query = query.Where(sp => sp.TenSP.ToLower().Contains(keyword) ||
                                               sp.ThuongHieu.TenThuongHieu.ToLower().Contains(keyword));
                }

                var sanPhams = query.Select(sp => new
                {
                    sp.MaSP,
                    sp.TenSP,
                    sp.DonGia,
                    TonKho = sp.SoLuongTon,
                    ThuongHieu = sp.ThuongHieu.TenThuongHieu
                }).ToList();

                gridSanPham.DataSource = sanPhams;

                if (gridViewSanPham.Columns.Count > 0)
                {
                    gridViewSanPham.Columns["MaSP"].Caption = "Mã SP";
                    gridViewSanPham.Columns["TenSP"].Caption = "Tên SP";
                    gridViewSanPham.Columns["DonGia"].Caption = "Đơn giá";
                    gridViewSanPham.Columns["TonKho"].Caption = "Tồn kho";
                    gridViewSanPham.Columns["ThuongHieu"].Caption = "Thương hiệu";

                    gridViewSanPham.Columns["MaSP"].Width = 60;
                    gridViewSanPham.Columns["TenSP"].Width = 180;
                    gridViewSanPham.Columns["DonGia"].Width = 90;
                    gridViewSanPham.Columns["TonKho"].Width = 70;
                    gridViewSanPham.Columns["ThuongHieu"].Width = 100;

                    gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridViewSanPham.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
                }
            }
            catch { }
        }

        private void SetupGrid()
        {
            gridViewChiTiet.OptionsBehavior.Editable = false;
            gridViewChiTiet.OptionsView.ShowGroupPanel = false;
        }

        private void btnTimSP_Click(object sender, EventArgs e)
        {
            LoadSanPham(txtTimSP.Text.Trim());
        }

        private void txtTimSP_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                LoadSanPham(txtTimSP.Text.Trim());
            }
        }

        private void btnThemSP_Click(object sender, EventArgs e)
        {
            if (gridViewSanPham.FocusedRowHandle < 0)
            {
                XtraMessageBox.Show("Vui lòng chọn sản phẩm!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int maSP = Convert.ToInt32(gridViewSanPham.GetFocusedRowCellValue("MaSP"));
            string tenSP = gridViewSanPham.GetFocusedRowCellValue("TenSP").ToString();
            decimal donGia = Convert.ToDecimal(gridViewSanPham.GetFocusedRowCellValue("DonGia"));
            int tonKho = Convert.ToInt32(gridViewSanPham.GetFocusedRowCellValue("TonKho"));
            int soLuong = Convert.ToInt32(spinSoLuong.Value);

            if (soLuong <= 0)
            {
                XtraMessageBox.Show("Số lượng phải > 0!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra đã có trong list chưa
            var existing = _chiTietList.FirstOrDefault(c => c.MaSP == maSP);
            int totalQty = existing != null ? existing.SoLuong + soLuong : soLuong;

            if (totalQty > tonKho)
            {
                XtraMessageBox.Show("Vượt quá tồn kho! (Tồn: " + tonKho + ")", "Thông báo",
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
            spinSoLuong.Value = 1;
        }

        private void btnXoaSP_Click(object sender, EventArgs e)
        {
            if (gridViewChiTiet.FocusedRowHandle < 0) return;

            int maSP = Convert.ToInt32(gridViewChiTiet.GetFocusedRowCellValue("MaSP"));
            var item = _chiTietList.FirstOrDefault(c => c.MaSP == maSP);
            if (item != null)
            {
                _chiTietList.Remove(item);
                // Re-number STT
                int stt = 1;
                foreach (var ct in _chiTietList)
                {
                    ct.STT = stt++;
                }
                RefreshChiTietGrid();
                UpdateTongTien();
            }
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
                gridViewChiTiet.Columns["DonGia"].Caption = "Đơn giá";
                gridViewChiTiet.Columns["ThanhTien"].Caption = "Thành tiền";

                gridViewChiTiet.Columns["STT"].Width = 40;
                gridViewChiTiet.Columns["TenSP"].Width = 180;
                gridViewChiTiet.Columns["SoLuong"].Width = 50;
                gridViewChiTiet.Columns["DonGia"].Width = 90;
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
            lblTongTien.Text = "TỔNG TIỀN: " + tongTien.ToString("N0") + " VND";
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
                        lblKhachHang.Text = "Khách hàng: " + _selectedKhachHang.HoTen;
                    }
                }
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (_chiTietList.Count == 0)
            {
                XtraMessageBox.Show("Chưa có sản phẩm trong hóa đơn!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_selectedKhachHang == null)
            {
                XtraMessageBox.Show("Vui lòng chọn khách hàng!", "Thông báo",
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

                // Chi tiết hóa đơn
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

                    // Trừ tồn kho
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
                    DuLieuMoi = "HĐ #" + hoaDon.MaHD + ", Tổng: " + tongTien.ToString("N0") + "đ",
                    MaNV = CurrentUser.IsLoggedIn ? CurrentUser.User.MaNV : (int?)null
                };
                _context.AuditLogs.Add(log);
                _context.SaveChanges();

                XtraMessageBox.Show(
                    "Thanh toán thành công!\nHóa đơn: HD" + hoaDon.MaHD.ToString("D4") + "\nTổng tiền: " + tongTien.ToString("N0") + " VND",
                    "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset
                ResetForm();
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show("Lỗi: " + ex.Message, "Lỗi",
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
            lblKhachHang.Text = "Khách hàng: (Chưa chọn)";
            LoadSanPham();
        }

        private void btnHuyHD_Click(object sender, EventArgs e)
        {
            if (_chiTietList.Count > 0)
            {
                var result = XtraMessageBox.Show(
                    "Bạn có chắc muốn hủy hóa đơn này?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    ResetForm();
                }
            }
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
