using System;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DataAccessLayer;
using DataAccessLayer.EntityClass;
using DevExpress.XtraEditors;

namespace cosmetics_store.FormStaff
{
    public partial class fChiTietHoaDon : DevExpress.XtraEditors.XtraForm
    {
        private CosmeticsContext _context;
        private int _maHD;
        private HoaDon _hoaDon;

        public fChiTietHoaDon(CosmeticsContext context, int maHD)
        {
            InitializeComponent();
            _context = context;
            _maHD = maHD;
            this.Load += fChiTietHoaDon_Load;
        }

        private void fChiTietHoaDon_Load(object sender, EventArgs e)
        {
            LoadHoaDon();
        }

        private void LoadHoaDon()
        {
            try
            {
                _hoaDon = _context.HoaDons
                    .Include(h => h.KhachHang)
                    .Include(h => h.NhanVien)
                    .Include(h => h.CT_HoaDons.Select(ct => ct.SanPham))
                    .FirstOrDefault(h => h.MaHD == _maHD);

                if (_hoaDon == null)
                {
                    XtraMessageBox.Show("Không tìm thấy hóa đơn!", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                // Hiển thị thông tin hóa đơn
                lblMaHD.Text = $"Mã HĐ: HD{_hoaDon.MaHD:D4}";
                lblNgayLap.Text = $"Ngày lập: {_hoaDon.NgayLap:dd/MM/yyyy HH:mm}";
                lblKhachHang.Text = $"Khách hàng: {_hoaDon.KhachHang?.HoTen ?? "Khách lẻ"}";
                lblSDT.Text = $"SĐT: {_hoaDon.KhachHang?.SDT ?? "N/A"}";
                lblDiaChi.Text = $"Địa chỉ: {_hoaDon.KhachHang?.DiaChi ?? "N/A"}";
                lblNhanVien.Text = $"Nhân viên: {_hoaDon.NhanVien?.HoTen ?? "N/A"}";
                lblPhuongThuc.Text = $"Phương thức: {_hoaDon.PhuongThucTT}";
                lblTrangThai.Text = $"Trạng thái: {_hoaDon.TrangThai}";

                // Đổi màu trạng thái
                switch (_hoaDon.TrangThai)
                {
                    case "CHO_DUYET":
                        lblTrangThai.ForeColor = Color.Orange;
                        break;
                    case "DA_DUYET":
                        lblTrangThai.ForeColor = Color.Green;
                        break;
                    case "TU_CHOI":
                        lblTrangThai.ForeColor = Color.Red;
                        break;
                    case "Hoàn thành":
                        lblTrangThai.ForeColor = Color.Blue;
                        break;
                    default:
                        lblTrangThai.ForeColor = Color.Black;
                        break;
                }

                // Load chi tiết sản phẩm
                var chiTiet = _hoaDon.CT_HoaDons.Select(ct => new
                {
                    ct.STT,
                    MaSP = ct.MaSP,
                    TenSP = ct.SanPham?.TenSP ?? "N/A",
                    ct.SoLuong,
                    ct.DonGia,
                    ThanhTien = ct.SoLuong * ct.DonGia
                }).OrderBy(ct => ct.STT).ToList();

                gridChiTiet.DataSource = chiTiet;

                if (gridViewCT.Columns.Count > 0)
                {
                    gridViewCT.Columns["STT"].Caption = "STT";
                    gridViewCT.Columns["MaSP"].Caption = "Mã SP";
                    gridViewCT.Columns["TenSP"].Caption = "Tên sản phẩm";
                    gridViewCT.Columns["SoLuong"].Caption = "Số lượng";
                    gridViewCT.Columns["DonGia"].Caption = "Đơn giá";
                    gridViewCT.Columns["ThanhTien"].Caption = "Thành tiền";

                    gridViewCT.Columns["STT"].Width = 50;
                    gridViewCT.Columns["MaSP"].Width = 70;
                    gridViewCT.Columns["TenSP"].Width = 220;
                    gridViewCT.Columns["SoLuong"].Width = 80;
                    gridViewCT.Columns["DonGia"].Width = 100;
                    gridViewCT.Columns["ThanhTien"].Width = 120;

                    gridViewCT.Columns["DonGia"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridViewCT.Columns["DonGia"].DisplayFormat.FormatString = "#,##0";
                    gridViewCT.Columns["ThanhTien"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    gridViewCT.Columns["ThanhTien"].DisplayFormat.FormatString = "#,##0";
                }

                // Tổng tiền
                lblTongTien.Text = $"TỔNG TIỀN: {_hoaDon.TongTien:N0} VND";
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            // Tạo nội dung in
            string content = "═══════════════════════════════════════\n";
            content += "           COSMETICS STORE             \n";
            content += "═══════════════════════════════════════\n\n";
            content += $"Mã HĐ: HD{_hoaDon.MaHD:D4}\n";
            content += $"Ngày lập: {_hoaDon.NgayLap:dd/MM/yyyy HH:mm}\n";
            content += $"Khách hàng: {_hoaDon.KhachHang?.HoTen ?? "Khách lẻ"}\n";
            content += $"SĐT: {_hoaDon.KhachHang?.SDT ?? "N/A"}\n";
            content += $"Nhân viên: {_hoaDon.NhanVien?.HoTen ?? "N/A"}\n\n";
            content += "───────────────────────────────────────\n";
            content += "CHI TIẾT SẢN PHẨM:\n";
            content += "───────────────────────────────────────\n";

            foreach (var ct in _hoaDon.CT_HoaDons)
            {
                decimal thanhTien = ct.SoLuong * ct.DonGia;
                content += $"{ct.STT}. {ct.SanPham?.TenSP ?? "N/A"}\n";
                content += $"   SL: {ct.SoLuong} x {ct.DonGia:N0}đ = {thanhTien:N0}đ\n";
            }

            content += "\n───────────────────────────────────────\n";
            content += $"TỔNG TIỀN: {_hoaDon.TongTien:N0} VND\n";
            content += $"Phương thức: {_hoaDon.PhuongThucTT}\n";
            content += "───────────────────────────────────────\n";
            content += "\n        Cảm ơn quý khách!             \n";
            content += "═══════════════════════════════════════\n";

            XtraMessageBox.Show(content, "Hóa đơn",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
